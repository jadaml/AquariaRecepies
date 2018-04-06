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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace JAL.AquariaRecipes.Recipes
{
    public class PlaceholderIngredient : IIngredient
    {
        private Product product;
        private IngredientCollection ingredientCollection;
        private Type ingredientType;
        private string name;

        public string Name => name;

        public Bitmap Image => null;

        public PlaceholderIngredient(Product product, IngredientCollection ingredientCollection, Type ingredientType, string name)
        {
            this.product              = product;
            this.ingredientCollection = ingredientCollection;
            this.ingredientType       = ingredientType;
            this.name                 = name;
        }

        public IIngredient ResolvePlaceholder()
        {
            IIngredient ingredient = InternalResolvePlaceholder();

            if (ingredient is null) return null;

            return ingredientCollection[ingredientCollection.IndexOf(this)] = ingredient;
        }

        private IIngredient InternalResolvePlaceholder()
        {
            switch (ingredientType)
            {
                case Type t when t == typeof(Product):
                    return product.RecipeBook?.FirstOrDefault<Product>(p => p.Name == name);
                case Type t when t == typeof(BasicIngredient):
                    return product.RecipeBook?.FirstOrDefault<BasicIngredient>(i => i.Name == name);
                default:
                    throw new InvalidOperationException();
            }
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new InvalidOperationException("Cannot read XML in to placeholder, because it cannot select the object that is yet to be created.");
        }

        public void WriteXml(XmlWriter writer)
        {
            (InternalResolvePlaceholder() ?? throw new InvalidOperationException("Placeholder ingredient cannot find the ingredient it is representing.")).WriteXml(writer);
        }
    }
}
