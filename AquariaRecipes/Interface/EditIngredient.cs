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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace JAL.AquariaRecipes.Interface
{
    public partial class EditIngredient : Form
    {
        private ImageItemControl stampImageItem = new ImageItemControl();
        private RecipeItem stampRecipeItem = new RecipeItem();
        private ObservableCollection<IngredientCollection> ingredientCollection;

        private bool recipesChanged = false;

        private bool creationMode = true;

        public bool CreationMode
        {
            get => creationMode;
            set
            {
                creationMode     = value;
                txtName.ReadOnly = !value;
            }
        }

        public bool RecipesChanged => recipesChanged;

        public string IngredientName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public string Category
        {
            get => cmbCategory.Text;
            set => cmbCategory.Text = value;
        }

        public string ImageName
        {
            get => cmbImage.SelectedValue?.ToString();
            set => cmbImage.SelectedValue = value;
        }

        public string Notes
        {
            get => txtNotes.Text.Replace(Environment.NewLine, "\n");
            set => txtNotes.Text = (value ?? "").Replace("\n", Environment.NewLine);
        }

        public EditIngredient(
            IList<Category> categories,
            IEnumerable<Recipes.Image> images,
            ObservableCollection<IngredientCollection> ingredientCollection = null)
        {
            InitializeComponent();

            srcCategory.DataSource = categories;
            srcImage   .DataSource = new Recipes.Image[] { new Recipes.Image(null, null) }.Concat(images).ToList();

            if (ingredientCollection != null)
            {
                srcIngredients.DataSource = ingredientCollection;
                this.ingredientCollection = ingredientCollection;
            }
            else
            {
                pnlIngredients.Visible = false;
                lblIngredients.Visible = false;
                tlpMain.ColumnStyles[1].Width = 0;
                tlpMain.ColumnStyles[0].Width = 100;
                Width = 400;
            }
        }

        private void Recipe_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            recipesChanged = true;
        }

        private void Recipes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (IngredientCollection recipe in e.NewItems)
                    {
                        recipe.CollectionChanged += Recipe_CollectionChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (IngredientCollection recipe in e.OldItems)
                    {
                        recipe.CollectionChanged -= Recipe_CollectionChanged;
                    }
                    break;
            }
            recipesChanged = true;
        }

        private void SrcCategory_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Category(cmbCategory.SelectedValue.ToString());
        }

        private void CmbImage_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 64;
        }

        private void CmbImage_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            stampImageItem.ImageWidth = e.State.HasFlag(DrawItemState.ComboBoxEdit) ? 22 : 64;

            stampImageItem.DrawItem(e,
                (srcImage[e.Index] as Recipes.Image).Name,
                (srcImage[e.Index] as Recipes.Image).Bitmap);
        }

        private void CmbCategory_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 22;
        }

        private void CmbCategory_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            if (e.State.HasFlag(DrawItemState.ComboBoxEdit)) return;

            stampImageItem.ImageWidth = 22;

            stampImageItem.DrawItem(e,
                (srcCategory[e.Index] as Category).Name,
                (srcCategory[e.Index] as Category).Image);
        }

        private void LstRecipes_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 64;
        }

        private void LstRecipes_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;

            stampRecipeItem.Recipe    = srcIngredients[e.Index] as IngredientCollection;
            stampRecipeItem.BackColor = e.BackColor;
            stampRecipeItem.ForeColor = e.ForeColor;
            stampRecipeItem.Font      = e.Font;
            stampRecipeItem.Width     = e.Bounds.Width;
            stampRecipeItem.Height    = e.Bounds.Height;

            Bitmap bmp = new Bitmap(e.Bounds.Width, e.Bounds.Height);

            stampRecipeItem.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));

            e.DrawBackground();
            e.Graphics.DrawImage(bmp, e.Bounds.Location);
            e.DrawFocusRectangle();
        }

        private void LstRecipes_Resize(object sender, EventArgs e)
        {
            lstRecipes.Invalidate();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            RecipeEditor editor = new RecipeEditor(
                (from IIngredient ingredient in Program.ApplicationContext.Book
                 where !ReferenceEquals(ingredient, srcIngredients.Current)
                 select ingredient).ToList(),
                null);

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            srcIngredients.Add(new IngredientCollection(
                editor.FirstIngredient,
                editor.SecondIngredient,
                editor.ThirdIngredient));
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            RecipeEditor editor = new RecipeEditor(
                (from IIngredient ingredient in Program.ApplicationContext.Book
                 where !ReferenceEquals(ingredient, srcIngredients.Current)
                 select ingredient).ToList(),
                srcIngredients.Current as IngredientCollection);

            if (editor.ShowDialog(this) != DialogResult.OK) return;

            IngredientCollection recipe = srcIngredients.Current as IngredientCollection;

            recipe[0] = editor.FirstIngredient;
            recipe[1] = editor.SecondIngredient;

            if (recipe.Count == 3 && editor.ThirdIngredient != null)
            {
                recipe[2] = editor.ThirdIngredient;
            }
            else if (recipe.Count == 3 && editor.ThirdIngredient == null)
            {
                recipe.RemoveAt(2);
            }
            else if (recipe.Count < 3 && editor.ThirdIngredient != null)
            {
                recipe.Add(editor.ThirdIngredient);
            }

            lstRecipes.Invalidate();
        }

        private void SrcIngredients_ListChanged(object sender, ListChangedEventArgs e)
        {
            lstRecipes.Invalidate();
        }

        private void EditIngredient_Shown(object sender, EventArgs e)
        {
            if (ingredientCollection is null) return;

            ingredientCollection.CollectionChanged += Recipes_CollectionChanged;

            foreach (IngredientCollection recipe in ingredientCollection)
            {
                recipe.CollectionChanged += Recipe_CollectionChanged;
            }
        }

        private void EditIngredient_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ingredientCollection is null) return;

            ingredientCollection.CollectionChanged -= Recipes_CollectionChanged;

            foreach (IngredientCollection recipe in ingredientCollection)
            {
                recipe.CollectionChanged -= Recipe_CollectionChanged;
            }
        }
    }
}
