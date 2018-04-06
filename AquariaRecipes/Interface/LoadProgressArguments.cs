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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAL.AquariaRecipes.Interface
{
    internal class LoadProgressArguments
    {
        public int Number { get; }
        public UpdateStage Stage { get; }
        public UpdateOperation Operation { get; }
        public object[] Argumens { get; }

        public LoadProgressArguments(UpdateStage stage, UpdateOperation operation, params object[] args)
            : this(0, stage, operation, args)
        { }

        public LoadProgressArguments(int number, UpdateStage stage, UpdateOperation operation, params object[] args)
        {
            Number    = number;
            Stage     = stage;
            Operation = operation;
            Argumens  = args;
        }
    }
}
