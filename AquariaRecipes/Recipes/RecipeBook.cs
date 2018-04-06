/* Copyright (c) 2018, Ádám L. Juhász
 *
 * This file is part of AquariaRecepies.
 *
 * AquariaRecepies is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AquariaRecepies is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AquariaRecepies.  If not, see <http://www.gnu.org/licenses/>.
 */

using JAL.AquariaRecipes.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.String;
using static JAL.AquariaRecipes.Properties.Resources;

namespace JAL.AquariaRecipes.Recipes
{
    [XmlRoot]
    public class RecipeBook :
        IListOwner<BasicIngredient>, IListOwner<Product>,
        IList<IIngredient>, IList<BasicIngredient>, IList<Product>, IXmlSerializable
    {
        private readonly List<Image> images;
        private readonly OwnedList<Product> products;
        private readonly OwnedList<BasicIngredient> ingredients;

        private Dictionary<string, Category> categoryCache = new Dictionary<string, Category>();

        private IList<IIngredient> GenericIngredient
        {
            get
            {
                return new IIngredient[] { Category.Anything }
                    .Union(from ingredient in ingredients
                           where ingredient.Category != null
                           select GetCategory(ingredient.Category) as IIngredient)
                    .Union(from product in products
                           where product.Category != null
                           select GetCategory(product.Category) as IIngredient)
                    .Concat(ingredients).Concat(products)
                    .ToList().AsReadOnly();
            }
        }

        public IList<Image> Images => images;

        public IList<BasicIngredient> Ingredients => ingredients;

        public IList<Product> Products => products;

        public XmlSchema GetSchema() => null;

        public RecipeBook()
        {
            images      = new List<Image>                    ();
            products    = new OwnedList<Product>             (this);
            ingredients = new OwnedList<BasicIngredient>     (this);
        }

        public void ReadXml(XmlReader reader)
        {
            int index;
            reader.ReadStartElement(nameof(RecipeBook));
            reader.ReadStartElement("Ingredients");
            if (reader.Name.Equals("Ingredient", StringComparison.Ordinal) && reader.NodeType == XmlNodeType.Element)
            {
                for (index = 0; reader.NodeType != XmlNodeType.EndElement; AdvanceReader(reader, "Ingredient"), ++index)
                {
                    ReportProgress(index, UpdateStage.Ingredients, UpdateOperation.Load);
                    ingredients.Add(new BasicIngredient(this, reader));
                }
                ReportProgress(index, UpdateStage.Ingredients, UpdateOperation.Load);
            }
            if (reader.NodeType == XmlNodeType.EndElement)
                reader.ReadEndElement();
            reader.ReadStartElement("Recipes");
            if (reader.Name.Equals("Recipe", StringComparison.Ordinal) && reader.NodeType == XmlNodeType.Element)
            {
                for (index = 0; reader.NodeType != XmlNodeType.EndElement; AdvanceReader(reader, "Recipe"), ++index)
                {
                    ReportProgress(index, UpdateStage.Products, UpdateOperation.Load);
                    products.Add(new Product(this, reader));
                }
                ReportProgress(index, UpdateStage.Products, UpdateOperation.Load);
            }
            if (reader.NodeType == XmlNodeType.EndElement)
                reader.ReadEndElement();
        }

        private void AdvanceReader(XmlReader reader, string elementName)
        {
            if (reader.Name != elementName) return;
            if (reader.IsEmptyElement)
                reader.ReadStartElement();
            else
                reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            int index = 0;
            writer.WriteStartElement("Ingredients");
            foreach (BasicIngredient ingredient in ingredients)
            {
                ReportProgress(index++, UpdateStage.Ingredients, UpdateOperation.Save);
                writer.WriteStartElement("Ingredient");
                ingredient.WriteXml(writer);
                writer.WriteEndElement();
            }
            ReportProgress(index, UpdateStage.Ingredients, UpdateOperation.Save);
            index = 0;
            writer.WriteEndElement();
            writer.WriteStartElement("Recipes");
            foreach (Product recipe in products)
            {
                ReportProgress(index++, UpdateStage.Products, UpdateOperation.Save);
                writer.WriteStartElement("Recipe");
                recipe.WriteXml(writer);
                writer.WriteEndElement();
            }
            ReportProgress(index, UpdateStage.Products, UpdateOperation.Save);
            writer.WriteEndElement();
        }

        public static RecipeBook OpenBook(string path)
        {
            if (!File.Exists(path)) return null;

            RecipeBook book;
            XmlSerializer serializer = new XmlSerializer(typeof(RecipeBook));

            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Read, Encoding.ASCII))
            {
                var images = from entry in archive.Entries
                             where entry.FullName.StartsWith("Images\\")
                             select entry;
                int imagesCount = images.Count();
                IEnumerator<ZipArchiveEntry> entryEnumerator = null;
                int i;

                ReportProgress(imagesCount, UpdateStage.Images, UpdateOperation.Count);

                using (Stream bookStream = archive.GetEntry("Book.xml").Open())
                {
                    XDocument doc = XDocument.Load(bookStream);

                    ReportProgress(
                        doc.Element("RecipeBook").Element("Ingredients").Elements("Ingredient").Count(),
                        UpdateStage.Ingredients, UpdateOperation.Count);
                    ReportProgress(
                        doc.Element("RecipeBook").Element("Recipes").Elements("Recipe").Count(),
                        UpdateStage.Products, UpdateOperation.Count);
                }

                using (Stream bookStream = archive.GetEntry("Book.xml").Open())
                {
                    book = (RecipeBook)serializer.Deserialize(bookStream);
                }

                string name = "";

                try
                {
                    for (i = 0, entryEnumerator = images.GetEnumerator(); entryEnumerator.MoveNext(); ++i)
                    {
                        ZipArchiveEntry entry = entryEnumerator.Current;

                        ReportProgress(i, UpdateStage.Images, UpdateOperation.Load, (name = entry.Name));

                        using (Stream stream = entry.Open())
                        {
                            book.Images.Add(new Image(Path.GetFileNameWithoutExtension(entry.Name), new Bitmap(stream)));
                        }
                    }
                }
                finally
                {
                    entryEnumerator?.Dispose();
                }

                ReportProgress(i, UpdateStage.Images, UpdateOperation.Load, name);
            }

            IEnumerable<PlaceholderIngredient> placeholders;

            placeholders = from product in book as IList<Product>
                           from recipe in product.Recipes
                           from placeholder in recipe.OfType<PlaceholderIngredient>()
                           select placeholder;

            foreach (PlaceholderIngredient placeholder in placeholders)
            {
                placeholder.ResolvePlaceholder();
            }

            IEnumerable<IngredientCollection> recipes;

            recipes = from product in book.products
                      from recipe in product.Recipes
                      select recipe;

            foreach (IngredientCollection recipe in recipes)
            {
                for (int i = 0; i < recipe.Count; ++i)
                {
                    if (recipe[i] is Category)
                        recipe[i] = book.OfType<Category>().Single(cat => cat.Name == recipe[i].Name);
                }
            }

            ReportProgress(UpdateStage.Done, UpdateOperation.Load);

            return book;
        }

        public static void CloseBook(string path, RecipeBook book)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RecipeBook));
            int i;
            IEnumerator<Image> imageEnumerator;

            if (File.Exists(path))
            {
                string backupName = Path.ChangeExtension(path, "bak");

                if (File.Exists(backupName))
                    File.Delete(backupName);
                File.Move(path, backupName);
            }

            ReportProgress(book.ingredients.Count, UpdateStage.Ingredients, UpdateOperation.Count);
            ReportProgress(book.products.Count,    UpdateStage.Products,    UpdateOperation.Count);
            ReportProgress(book.Images.Count,      UpdateStage.Images,      UpdateOperation.Count);

            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Create, Encoding.ASCII))
            {
                using (Stream bookStream = archive.CreateEntry("Book.xml").Open())
                {
                    serializer.Serialize(bookStream, book);
                }

                var images = from image in book.Images
                             where !IsNullOrEmpty(image.Name)
                             select image;

                string fileName = "";

                for (i = 0, imageEnumerator = images.GetEnumerator(); imageEnumerator.MoveNext(); ++i)
                {
                    Image image = imageEnumerator.Current;

                    ReportProgress(i, UpdateStage.Images, UpdateOperation.Save, (fileName = $"{image.Name}.png"));

                    using (Stream imageStream = archive.CreateEntry($"Images\\{image.Name}.png", CompressionLevel.Optimal).Open())
                    {
                        image.Bitmap.Save(imageStream, ImageFormat.Png);
                    }
                }
                ReportProgress(i, UpdateStage.Images, UpdateOperation.Save, fileName);
            }
        }

        int ICollection<Product>.Count => products.Count;

        int ICollection<BasicIngredient>.Count => ingredients.Count;

        public bool IsReadOnly => false;

        public int Count => GenericIngredient.Count;

        public IIngredient this[int index]
        {
            get => GenericIngredient[index];
            set => GenericIngredient[index] = value;
        }

        BasicIngredient IList<BasicIngredient>.this[int index]
        {
            get => ingredients[index];
            set => ingredients[index] = value;
        }

        Product IList<Product>.this[int index]
        {
            get => products[index];
            set => products[index] = value;
        }

        public void Add(Product item)
        {
            item.RecipeBook = this;
            products.Add(item);
        }

        public void Clear() => products.Clear();

        public bool Contains(Product item) => products.Contains(item);

        public void CopyTo(Product[] array, int arrayIndex) => products.CopyTo(array, arrayIndex);

        IEnumerator<Product> IEnumerable<Product>.GetEnumerator() => products.GetEnumerator();

        public bool Remove(Product item) => products.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GenericIngredient.GetEnumerator();

        public void Add(BasicIngredient item) => ingredients.Add(item);

        public bool Contains(BasicIngredient item) => ingredients.Contains(item);

        public void CopyTo(BasicIngredient[] array, int arrayIndex) => ingredients.CopyTo(array, arrayIndex);

        public bool Remove(BasicIngredient item) => ingredients.Remove(item);

        IEnumerator<BasicIngredient> IEnumerable<BasicIngredient>.GetEnumerator() => ingredients.GetEnumerator();

        public void Add(IIngredient item)
        {
            if (item is BasicIngredient)
                Add(item as BasicIngredient);
            else if (item is Product)
                Add(item as Product);

            throw new ArgumentException("Cannot add the specified item to the collection.", nameof(item));
        }

        public bool Contains(IIngredient item) => GenericIngredient.Contains(item);

        public void CopyTo(IIngredient[] array, int arrayIndex) => GenericIngredient.CopyTo(array, arrayIndex);

        public bool Remove(IIngredient item)
        {
            if (item is BasicIngredient)
                return Remove(item as BasicIngredient);
            if (item is Product)
                return Remove(item as Product);
            return false;
        }

        IEnumerator<IIngredient> IEnumerable<IIngredient>.GetEnumerator() => GenericIngredient.GetEnumerator();

        private static void ReportProgress(UpdateStage stage, UpdateOperation operation, params object[] args)
        {
            Program.ApplicationContext?.Progress.Report(new LoadProgressArguments(stage, operation, args));
        }

        private static void ReportProgress(int number, UpdateStage stage, UpdateOperation operation, params object[] args)
        {
            Program.ApplicationContext?.Progress.Report(new LoadProgressArguments(number, stage, operation, args));
        }

        private Category GetCategory(string category)
        {
            Category result;

            if (categoryCache.ContainsKey(category))
            {
                result = categoryCache[category];
            }
            else
            {
                result = new Category(category);
                categoryCache.Add(category, result);
            }

            result.Image = GenerateCategoryImage(category);

            return result;

            Bitmap GenerateCategoryImage(string cat)
            {
                if (IsNullOrEmpty(cat))
                    return null;

                Bitmap resultImage;
                IEnumerable<Bitmap> imgLst = from ingredient in ingredients.Cast<IIngredient>().Concat(products)
                                             where ((ingredient as BasicIngredient)?.Category == cat
                                                 || (ingredient as Product)?.Category == cat)
                                             && ingredient.Image != null
                                             select ingredient.Image;

                imgLst = imgLst.Take(3).Reverse();

                int count = imgLst.Count();

                if (count == 0)
                    return null;

                resultImage = new Bitmap(imgLst.Max(i => i.Width) + 10 * count, imgLst.Max(i => i.Height) + 10 * count);

                IEnumerator<Bitmap> imgEnum;
                using (Graphics g = Graphics.FromImage(resultImage))
                {
                    int offset;

                    for (offset = 0, imgEnum = imgLst.GetEnumerator(); imgEnum.MoveNext(); offset += 10)
                    {
                        g.DrawImage(imgEnum.Current, new Point((count - 1) * 10 - offset, offset));
                    }
                }
                imgEnum.Dispose();

                return resultImage;
            }
        }

        public int IndexOf(IIngredient item) => GenericIngredient.IndexOf(item);

        public void Insert(int index, IIngredient item) => GenericIngredient.Insert(index, item);

        void IList<IIngredient>.RemoveAt(int index)
        {
            IIngredient element = GenericIngredient[index];

            if (element is BasicIngredient)
                ingredients.Remove(element as BasicIngredient);
            else if (element is Product)
                products.Remove(element as Product);
            else
                throw new InvalidOperationException("Cant remove the specified element");
        }

        public int IndexOf(BasicIngredient item) => ingredients.IndexOf(item);

        public void Insert(int index, BasicIngredient item) => ingredients.Insert(index, item);

        void IList<BasicIngredient>.RemoveAt(int index) => ingredients.RemoveAt(index);

        public int IndexOf(Product item) => products.IndexOf(item);

        public void Insert(int index, Product item) => products.Insert(index, item);

        void IList<Product>.RemoveAt(int index) => products.RemoveAt(index);

        void IListOwner<BasicIngredient>.Add(BasicIngredient element) => element.RecipeBook = this;

        void IListOwner<BasicIngredient>.Remove(BasicIngredient element) => element.RecipeBook = null;

        void IListOwner<Product>.Add(Product element) => element.RecipeBook = this;

        void IListOwner<Product>.Remove(Product element) => element.RecipeBook = null;
    }
}
