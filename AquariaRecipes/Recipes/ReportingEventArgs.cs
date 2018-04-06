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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAL.AquariaRecipes.Recipes
{
    public class ReportingEventArgs : EventArgs
    {
        public UpdateStage Stage { get; }
        public int Number { get; }
        public int Count { get; }

        public ReportingEventArgs(UpdateStage stage, int number, int count)
        {
            Stage  = stage;
            Number = number;
            Count  = count;
        }

        public ReportingEventArgs(UpdateStage stage) : this (stage, 0, 0) { }
    }
}
