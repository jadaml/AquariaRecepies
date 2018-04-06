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

using System.Windows.Forms;
using static System.Diagnostics.Debug;

namespace JAL.AquariaRecipes.Interface
{
    internal static class BingingSourceExtensions
    {
        public static void MoveToItem(this BindingSource source, object obj)
        {
            if (obj == null)
            {
                return;
            }

            source.Position = source.IndexOf(obj);

            Assert(ReferenceEquals(obj, source.Current));
        }
    }
}
