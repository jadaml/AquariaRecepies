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
using System.Drawing;
using System.Xml;
using System.Xml.Schema;
using static JAL.AquariaRecipes.Properties.Resources;

namespace JAL.AquariaRecipes.Recipes
{
    public class Category : IIngredient, IEquatable<Category>
    {
        public static readonly Category Nothing = new Category("");

        public static readonly Category Anything = new Category() { Image = AnythingImage };

        private string name;

        public string Name => name ?? "Anything";

        public Bitmap Image { get; set; } = null;

        public Category() { }

        public Category(string name) => this.name = name;

        public Category(string name, Bitmap image) : this(name) => Image = image;

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            name = reader.ReadContentAsString();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteCData(name);
        }

        public bool Equals(Category other) => Name.Equals(other.Name, StringComparison.CurrentCultureIgnoreCase);

        public override bool Equals(object obj) => obj?.GetType() == typeof(Category) && Equals((Category)obj);

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;

        public static bool operator ==(Category a, Category b) => a.Equals(b);

        public static bool operator !=(Category a, Category b) => !a.Equals(b);
    }
}
