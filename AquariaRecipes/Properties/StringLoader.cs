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
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using static System.String;
using static System.Diagnostics.Trace;

namespace JAL.AquariaRecipes.Properties
{
    internal static class StringLoader
    {
        private static ResourceManager resourceManager;
        private static CultureInfo cultureInfo;

        public static CultureInfo CultureInfo
        {
            get => cultureInfo ?? CultureInfo.CurrentUICulture;
            set => cultureInfo = value;
        }

        static StringLoader()
        {
            resourceManager = new ResourceManager("JAL.AquariaRecipes.Properties.Strings", typeof(StringLoader).Assembly);
        }

        public static string GetString(string name, params object[] args)
        {
            string str = resourceManager.GetString(name, CultureInfo);

            if (IsNullOrEmpty(str))
            {
                string argstr = Join("; ", args.Select(obj => $"\"{obj}\""));
                TraceError("String Loader ==> {0} is undefined. Arguments: {1}", name, argstr);
                return $"{name} {argstr}".TrimEnd();
            }

            try
            {
                return Format(str, args);
            }
            catch (FormatException)
            {
                string argstr = Join("; ", args.Select(obj => $"\"{obj}\""));
                TraceError("String Loader ==> {0} key's format malformed. Arguments: {1}", name, argstr);
                return $"ERR: \x201C{str}\x201D {argstr}".TrimEnd();
            }
        }
    }
}
