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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using static System.String;

namespace JAL.AquariaRecipes.Recipes
{
    [XmlRoot("Ingredient")]
    public class BasicIngredient : IIngredient, IEquatable<BasicIngredient>, INotifyPropertyChanged
    {
        private RecipeBook book;
        private string name = null;
        private string category;
        private string notes;
        private string imageName;

        public event PropertyChangedEventHandler PropertyChanged;

        public RecipeBook RecipeBook
        {
            get => book;
            internal set => book = value;
        }

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

        public BasicIngredient(RecipeBook book, XmlReader reader)
        {
            this.book = book;
            ReadXml(reader);
        }


        public BasicIngredient(string name) => this.name = name;

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            name      = reader["Name"];
            Category  = reader["Category"];
            ImageName = reader["Image"];

            if (!reader.IsEmptyElement)
            {
                reader.ReadStartElement();
                Notes = reader.ReadContentAsString();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            if (!IsNullOrEmpty(Category)) writer.WriteAttributeString("Category", Category);
            if (!IsNullOrEmpty(ImageName)) writer.WriteAttributeString("Image", ImageName);
            if (!IsNullOrEmpty(Notes))
                writer.WriteCData(Notes);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(BasicIngredient other) => other?.Name.Equals(Name, StringComparison.CurrentCultureIgnoreCase) ?? false;

        public override bool Equals(object obj) => Equals(obj as BasicIngredient);

        public override int GetHashCode() => Name.GetHashCode();

        public override string ToString() => Name;

        public static bool operator ==(BasicIngredient a, BasicIngredient b) => a?.Equals(b) ?? b == null;

        public static bool operator !=(BasicIngredient a, BasicIngredient b) => !a?.Equals(b) ?? b != null;
    }
}
