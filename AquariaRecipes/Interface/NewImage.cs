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

using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JAL.AquariaRecipes.Properties.StringLoader;
using static System.String;

namespace JAL.AquariaRecipes.Interface
{
    public partial class NewImage : Form
    {
        private readonly CommonOpenFileDialog openFileDialog;

        public string ImageName
        {
            get => txtName.Text;
            set => txtName.Text = value;
        }

        public Bitmap Image
        {
            get => imgImage.Image as Bitmap ?? new Bitmap(imgImage.Image);
            set => imgImage.Image = value;
        }

        public NewImage()
        {
            InitializeComponent();

            openFileDialog = new CommonOpenFileDialog()
            {
                Title          = "Open image",
                ShowPlacesList = true,
            };

            openFileDialog.Filters.Add(new CommonFileDialogFilter(GetString("SupportedImagesFilter"), "*.png;*.bmp;*.jpg;*.gif;*.jpeg"));
        }

        private void LoadImage()
        {
            try
            {
                using (Stream stream = new FileStream(txtImagePath.Text, FileMode.Open))
                {
                    Image = new Bitmap(stream);
                }
            }
            catch (Exception)
            {
                Image = null;
            }
        }

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FormsShowDialog(this) != CommonFileDialogResult.Ok)
            {
                return;
            }

            if (IsNullOrEmpty(txtName.Text))
                txtName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

            txtImagePath.Text = openFileDialog.FileName;

            LoadImage();
        }

        private void TxtImagePath_Leave(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}
