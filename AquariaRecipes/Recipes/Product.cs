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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.String;

namespace JAL.AquariaRecipes.Recipes
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class Product : IIngredient, IEquatable<Product>, INotifyPropertyChanged
    {
        private RecipeBook book;
        private string name;
        private string category;
        private string notes;
        private string imageName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name => name;

        public Bitmap Image => book?.Images.FirstOrDefault(img => img.Name.Equals(ImageName, StringComparison.InvariantCultureIgnoreCase))?.Bitmap;

        public string Category
        {
            get => category;
            set
            {
                if (category == value) return;
                category = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get => notes;
            set
            {
                if (notes == value) return;
                notes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IngredientCollection> Recipes { get; } = new ObservableCollection<IngredientCollection>();

        public RecipeBook RecipeBook
        {
            get => book;
            internal set => book = value;
        }

        public string ImageName
        {
            get => imageName;
            set
            {
                if (imageName == value) return;
                imageName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Image));
            }
        }

        private string DebuggerDisplay => $"{Name} ({Category})";

        public Product(RecipeBook book, XmlReader reader)
        {
            this.book = book;
            ReadXml(reader);
        }

        public Product(string name) => this.name = name;

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            name      = reader["Name"];
            Category  = reader["Category"];
            ImageName = reader["Image"];

            reader.ReadStartElement();

            if (reader.Name == "Notes")
            {
                reader.ReadStartElement("Notes");
                Notes = reader.ReadContentAsString();
                reader.ReadEndElement();
            }
            while (reader.Name == "Ingredients")
            {
                IngredientCollection ingredients;
                if (reader.IsEmptyElement)
                {
                    reader.ReadStartElement("Ingredients");
                    break;
                }
                reader.ReadStartElement("Ingredients");
                Recipes.Add((ingredients = new IngredientCollection()));
                for (; reader.NodeType != XmlNodeType.EndElement; AdvanceReader(reader, "Recipe", "Ingredient", "Category"))
                {
                    IIngredient ingredient;
                    if (reader.NodeType == XmlNodeType.Whitespace || reader.NodeType == XmlNodeType.SignificantWhitespace)
                        continue;
                    switch (reader.Name)
                    {
                        case "Recipe":
                            reader.ReadStartElement(reader.Name);
                            string recipeName = reader.ReadContentAsString();
                            ingredient = (book as IEnumerable<Product>).FirstOrDefault(i => i.Name == recipeName);
                            ingredients.Add(ingredient ?? new PlaceholderIngredient(this, ingredients, typeof(Product), recipeName));
                            break;
                        case "Ingredient":
                            reader.ReadStartElement(reader.Name);
                            string ingredientName = reader.ReadContentAsString();
                            ingredient = (book as IEnumerable<BasicIngredient>).First(i => i.Name == ingredientName);
                            ingredients.Add(ingredient ?? new PlaceholderIngredient(this, ingredients, typeof(BasicIngredient), ingredientName));
                            break;
                        case "Category":
                            if (reader.IsEmptyElement)
                            {
                                //reader.ReadStartElement(reader.Name);
                                Recipes.Last().Add(AquariaRecipes.Recipes.Category.Anything);
                            }
                            else
                            {
                                reader.ReadStartElement(reader.Name);
                                Recipes.Last().Add(new Category(reader.ReadContentAsString()));
                            }
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
                reader.ReadEndElement();
            }
        }

        private void AdvanceReader(XmlReader reader, params string[] elementName)
        {
            if (!elementName.Contains(reader.Name)) return;
            if (reader.IsEmptyElement)
                reader.ReadStartElement();
            else
                reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            if (!IsNullOrEmpty(Category)) writer.WriteAttributeString("Category", Category);
            if (!IsNullOrEmpty(ImageName)) writer.WriteAttributeString("Image", ImageName);

            if (!IsNullOrEmpty(Notes))
            {
                writer.WriteStartElement("Notes");
                writer.WriteCData(Notes);
                writer.WriteEndElement();
            }

            foreach (IngredientCollection recipe in Recipes)
            {
                writer.WriteStartElement("Ingredients");
                foreach (IIngredient ingredient in recipe)
                {
                    switch (ingredient)
                    {
                        case Product _:
                            writer.WriteStartElement("Recipe");
                            break;
                        case BasicIngredient _:
                            writer.WriteStartElement("Ingredient");
                            break;
                        case Category _:
                            writer.WriteStartElement("Category");
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    if (!ingredient.Equals(AquariaRecipes.Recipes.Category.Anything))
                        writer.WriteCData(ingredient.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(Product other) => (other?.Name.Equals(Name) ?? false) && (other?.Category.Equals(Category) ?? false);

        public override bool Equals(object obj) => Equals(obj as Product);

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;
    }
}
