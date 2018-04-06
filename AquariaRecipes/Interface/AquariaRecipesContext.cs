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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JAL.AquariaRecipes.Properties.Settings;

namespace JAL.AquariaRecipes.Interface
{
    internal class AquariaRecipesContext : ApplicationContext
    {
        private static readonly IReadOnlyDictionary<UpdateStage, double> offsetMapping =
            new Dictionary<UpdateStage, double>()
            {
                [UpdateStage.Ingredients] = 0d,
                [UpdateStage.Products]    = .5d,
                [UpdateStage.Done]        = 1d,
            };

        private LoadingForm loadingForm = new LoadingForm();
        private EditorForm  editor;
        private BrowserForm browser;
        private RecipeBook  book;
        private bool        bookChanged = false;

        public RecipeBook Book => book;

        public bool BookChanged
        {
            get => bookChanged;
            set
            {
                if (!EditorMode) throw new InvalidOperationException("Made an attempt to modify the book.");
                bookChanged = value;
            }
        }

        public bool EditorMode { get; private set; }

        public IProgress<LoadProgressArguments> Progress => loadingForm;

        internal AquariaRecipesContext(bool editorMode)
        {
            Program.ApplicationContext = this;
            EditorMode = editorMode;
#if !DEBUG
#warning The browser is not yet implemented.
            EditorMode = true;
#endif
            LoadProgram();
        }

        private async void LoadProgram()
        {
            loadingForm.Report(new LoadProgressArguments(UpdateStage.ProgramLoading, UpdateOperation.None));

            await LoadBook();

            if (EditorMode)
            {
                editor = new EditorForm();

                if (Default.EditorLocation != Point.Empty)
                {
                    editor.StartPosition = FormStartPosition.Manual;
                    editor.Location      = Default.EditorLocation;
                }

                if (Default.EditorSize != Size.Empty)
                {
                    editor.Size = Default.EditorSize;
                }

                MainForm = editor;
                editor.Show();
            }
            else
            {
                browser = new BrowserForm();

                if (Default.BrowserLocation != Point.Empty)
                {
                    browser.StartPosition = FormStartPosition.Manual;
                    browser.Location      = Default.BrowserLocation;
                }

                if (Default.BrowserSize != Size.Empty)
                {
                    browser.Size = Default.BrowserSize;
                }

                MainForm = browser;
                browser.Show();
            }
        }

        protected override void ExitThreadCore()
        {
            if (BookChanged)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aquaria.RecipesBook");
                RecipeBook.CloseBook(path, book);
            }

            if (EditorMode)
            {
                Default.EditorLocation = editor.Location;
                Default.EditorSize     = editor.Size;
            }
            else
            {
                Default.BrowserLocation = browser.Location;
                Default.BrowserSize     = browser.Size;
            }

            Default.Save();

            base.ExitThreadCore();
        }

        public Task LoadBook()
        {
            return Task.Run((Action)InternalLoadBook);
        }

        private void InternalLoadBook()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Aquaria.RecipesBook");

            if (!File.Exists(path))
                path = "Aquaria.RecipesBook";

            book = RecipeBook.OpenBook(path);
            EditorMode |= book == null;
            book = book ?? new RecipeBook();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                loadingForm.Close();
                loadingForm.Dispose();
                editor?.Dispose();
                browser?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
