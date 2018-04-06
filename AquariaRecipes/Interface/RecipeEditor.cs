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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace JAL.AquariaRecipes.Interface
{
    public partial class RecipeEditor : Form
    {
        private class NothingIngredient : IIngredient
        {
            public static NothingIngredient Instance { get; } = new NothingIngredient();

            public string Name => null;

            public Bitmap Image => null;

            private NothingIngredient() { }

            public XmlSchema GetSchema() => throw new NotImplementedException();

            public void ReadXml(XmlReader reader) => throw new NotImplementedException();

            public void WriteXml(XmlWriter writer) => throw new NotImplementedException();
        }

        private ImageItemControl ingredientStamp = new ImageItemControl()
        {
            ImageWidth = 22,
        };

        public IIngredient FirstIngredient => srcIngredient1.Current as IIngredient;

        public IIngredient SecondIngredient => srcIngredient2.Current as IIngredient;

        public IIngredient ThirdIngredient => srcIngredient3.Current == NothingIngredient.Instance ? null : srcIngredient3.Current as IIngredient;

        public RecipeEditor(IList<IIngredient> ingredients, IngredientCollection recipe)
            : this(ingredients,
                recipe?.ElementAtOrDefault(0),
                recipe?.ElementAtOrDefault(1),
                recipe?.ElementAtOrDefault(2))
        { }

        public RecipeEditor(
            IList<IIngredient> ingredients,
            IIngredient ingredient1,
            IIngredient ingredient2,
            IIngredient ingredient3)
        {
            InitializeComponent();

            srcIngredient1.DataSource = ingredients.ToList();
            srcIngredient2.DataSource = ingredients.ToList();
            srcIngredient3.DataSource = new IIngredient[] { NothingIngredient.Instance }.Concat(ingredients).ToList();

            srcIngredient1.MoveToItem(ingredient1);
            srcIngredient2.MoveToItem(ingredient2);
            srcIngredient3.MoveToItem(ingredient3);
        }

        private void MeasureIngredientItemHeight(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 22;
        }

        private void DrawIngredientItem(object sender, DrawItemEventArgs e)
        {
            ingredientStamp.ImageWidth = 22;

            IIngredient ingredient = ((sender as ListControl)?.DataSource as BindingSource)?[e.Index] as IIngredient;

            ingredientStamp.DrawItem(e, ingredient?.Name ?? "", ingredient?.Image);
        }
    }
}
