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

using JAL.AquariaRecipes.Recipes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Diagnostics.Debug;
using static System.Diagnostics.Debugger;

namespace JAL.AquariaRecipes.Interface
{
    public partial class EditorForm : Form
    {
        private bool initializationDone = false;
        private RecipeBook activeBook;

        public EditorForm()
        {
            InitializeComponent();
            SetBookActive(Program.ApplicationContext.Book);

            initializationDone = true;
        }

        private void SetBookActive(RecipeBook book)
        {
            activeBook = Program.ApplicationContext.Book;

            srcImages         .DataSource = activeBook.Images;
            srcBaseIngredients.DataSource = activeBook.Ingredients;
            srcProduct        .DataSource = activeBook.Products;
        }

        private IList<Category> CategoryList => activeBook.OfType<Category>().ToList();

        private void SrcBaseIngredients_CurrentChanged(object sender, EventArgs e)
        {
            btnEditIngredient.Enabled = srcBaseIngredients.Current != null;
        }

        private void SrcProduct_CurrentChanged(object sender, EventArgs e)
        {
            btnEditProduct.Enabled = srcProduct.Current != null;
        }

        private void AddNewImage_Click(object sender, EventArgs e)
        {
            NewImage newImage = new NewImage();

            if (newImage.ShowDialog(this) != DialogResult.OK) return;

            srcImages.Add(new Recipes.Image(newImage.ImageName, newImage.Image));

            Program.ApplicationContext.BookChanged = true;
        }

        private void DgvImages_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void DgvImages_DragDrop(object sender, DragEventArgs e)
        {
            IEnumerable<string> fileList = from path in e.Data.GetData(DataFormats.FileDrop) as string[]
                                           where (Path.GetExtension(path).Equals(".PNG", StringComparison.OrdinalIgnoreCase)
                                               || Path.GetExtension(path).Equals(".BMP", StringComparison.OrdinalIgnoreCase)
                                               || Path.GetExtension(path).Equals(".JPG", StringComparison.OrdinalIgnoreCase)
                                               || Path.GetExtension(path).Equals(".GIF", StringComparison.OrdinalIgnoreCase))
                                              && activeBook.Images.All(i => !Path.GetFileNameWithoutExtension(path).Equals(i.Name, StringComparison.OrdinalIgnoreCase))
                                           select path;

            foreach (string path in fileList)
            {
                Bitmap bmp;

                try
                {
                    using (Stream stream = new FileStream(path, FileMode.Open))
                    {
                        bmp = new Bitmap(stream);
                    }

                    srcImages.Add(new Recipes.Image(Path.GetFileNameWithoutExtension(path), bmp));
                }
                catch (ArgumentException)
                {
                    continue;
                }
            }

            Program.ApplicationContext.BookChanged = true;
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            EditIngredient editor = new EditIngredient(
                CategoryList,
                activeBook.Images);

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            srcBaseIngredients.Add(new BasicIngredient(editor.IngredientName)
            {
                Category  = editor.Category,
                ImageName = editor.ImageName,
                Notes     = editor.Notes,
            });
        }

        private void BtnEditIngredient_Click(object sender, EventArgs e)
        {
            BasicIngredient ingredient = srcBaseIngredients.Current as BasicIngredient;
            EditIngredient editor = new EditIngredient(
                CategoryList,
                activeBook.Images)
            {
                CreationMode   = false,
                IngredientName = ingredient.Name,
                Category       = ingredient.Category,
                ImageName      = ingredient.ImageName,
                Notes          = ingredient.Notes,
            };

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            Assert(ReferenceEquals(ingredient, srcBaseIngredients.Current));

            ingredient.Category  = editor.Category.Equals(Category.Anything.Name, StringComparison.Ordinal) ? null : editor.Category;
            ingredient.ImageName = editor.ImageName;
            ingredient.Notes     = editor.Notes;

            srcBaseIngredients.ResetCurrentItem();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            ObservableCollection<IngredientCollection> recipes = new ObservableCollection<IngredientCollection>();
            EditIngredient editor = new EditIngredient(
                CategoryList,
                activeBook.Images,
                recipes);

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            Product product = new Product(editor.IngredientName)
            {
                Category  = editor.Category,
                ImageName = editor.ImageName,
                Notes     = editor.Notes,
            };

            foreach (IngredientCollection recipe in recipes)
            {
                product.Recipes.Add(recipe);
            }

            srcProduct.Add(product);
        }

        private void BtnEditProduct_Click(object sender, EventArgs e)
        {
            Product product = srcProduct.Current as Product;
            EditIngredient editor = new EditIngredient(
                CategoryList,
                activeBook.Images,
                product.Recipes)
            {
                CreationMode   = false,
                IngredientName = product.Name,
                Category       = product.Category,
                ImageName      = product.ImageName,
                Notes          = product.Notes,
            };

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            Assert(ReferenceEquals(product, srcProduct.Current));

            product.Category  = editor.Category;
            product.ImageName = editor.ImageName;
            product.Notes     = editor.Notes;

            Program.ApplicationContext.BookChanged |= editor.RecipesChanged;
        }

        private void BoundingSourceListChanged(object sender, ListChangedEventArgs e)
        {
            if (!initializationDone)
                return;

            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                case ListChangedType.ItemChanged:
                case ListChangedType.ItemDeleted:
                case ListChangedType.ItemMoved:
                case ListChangedType.Reset:
                    Program.ApplicationContext.BookChanged = true;
                    break;
            }

            switch (sender)
            {
                case BindingSource source when source == srcBaseIngredients:
                    btnEditIngredient.Enabled = source.Count != 0;
                    break;
                case BindingSource source when source == srcProduct:
                    btnEditProduct.Enabled = source.Count != 0;
                    break;
            }
        }

        // I have a problem here during disposal.

        private void DgvImages_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
#if DEBUG
            if (new StackTrace().GetFrames()
                .Any(sf => sf.GetMethod().Name == nameof(IDisposable.Dispose)))
            {
                e.Cancel = true;
            }
            //Break();
#endif
        }

        private void DgvBaseIngredients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
#if DEBUG
            if (new StackTrace().GetFrames()
                .Any(sf => sf.GetMethod().Name == nameof(IDisposable.Dispose)))
            {
                e.Cancel = true;
            }
            //Break();
#endif
        }

        private void DgvProduct_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
#if DEBUG
            if (new StackTrace().GetFrames()
                .Any(sf => sf.GetMethod().Name == nameof(IDisposable.Dispose)))
            {
                e.Cancel = true;
            }
            //Break();
#endif
        }

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }
    }
}
