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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JAL.AquariaRecipes.Properties.StringLoader;

namespace JAL.AquariaRecipes.Interface
{
    internal partial class LoadingForm : Form, IProgress<LoadProgressArguments>
    {
        private CancellationTokenSource cts;
        private Dictionary<UpdateStage, int> progressCounters;

        public LoadingForm()
        {
            InitializeComponent();

            cts = new CancellationTokenSource();
            progressCounters = new Dictionary<UpdateStage, int>();
        }

        public async void Report(LoadProgressArguments value)
        {
            if (InvokeRequired)
            {
                Invoke((Action<LoadProgressArguments>)Report, value);
#if DEBUG
#warning Program loading is tempered, so designers can check the text during loading.
                Task.Delay(Visible ? 400 : 2000).Wait();
#endif
                return;
            }

            if (value.Operation == UpdateOperation.Count)
            {
                progressCounters.Add(value.Stage, 0);
                mainProgress.Maximum += value.Number;
                return;
            }

            if (value.Stage == UpdateStage.Done)
            {
                lblProgress.Text = GetString("Done");
                mainProgress.Value = mainProgress.Maximum;

                progressCounters.Clear();

                if (!Visible) return;

                try
                {
                    await DelayedClose();

                    mainProgress.Maximum = 0;
                    mainProgress.Value = mainProgress.Maximum;
                }
                catch (OperationCanceledException)
                {
                    return; // We have expected this exception.
                }
                return;
            }

            if (!Visible)
            {
                Show();
            }

            progressCounters[value.Stage] = value.Number;

            if (value.Operation == UpdateOperation.None)
            {
                lblProgress.Text = GetString($"{value.Stage}", value.Argumens);
            }
            else
            {
                lblProgress.Text = GetString($"{value.Operation}_{value.Stage}", value.Argumens);
            }

            mainProgress.Value = progressCounters.Values.Sum();
        }

        private async Task DelayedClose()
        {
            await Task.Delay(800, cts.Token);
            Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            cts.Cancel();
            base.OnClosing(e);
        }
    }
}
