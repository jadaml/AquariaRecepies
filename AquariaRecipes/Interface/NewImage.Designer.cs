namespace JAL.AquariaRecipes.Interface
{
    partial class NewImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tlpMainLayout;
            System.Windows.Forms.Label lblName;
            System.Windows.Forms.Label lblImage;
            System.Windows.Forms.Button btnBrowseImage;
            System.Windows.Forms.Label lblImagePreview;
            System.Windows.Forms.FlowLayoutPanel flpDialogButtons;
            System.Windows.Forms.Button btnCancel;
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.imgImage = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            lblName = new System.Windows.Forms.Label();
            lblImage = new System.Windows.Forms.Label();
            btnBrowseImage = new System.Windows.Forms.Button();
            lblImagePreview = new System.Windows.Forms.Label();
            flpDialogButtons = new System.Windows.Forms.FlowLayoutPanel();
            btnCancel = new System.Windows.Forms.Button();
            tlpMainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            flpDialogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMainLayout
            // 
            tlpMainLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tlpMainLayout.ColumnCount = 2;
            tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpMainLayout.Controls.Add(lblName, 0, 0);
            tlpMainLayout.Controls.Add(this.txtName, 0, 1);
            tlpMainLayout.Controls.Add(lblImage, 0, 2);
            tlpMainLayout.Controls.Add(this.txtImagePath, 0, 3);
            tlpMainLayout.Controls.Add(btnBrowseImage, 1, 3);
            tlpMainLayout.Controls.Add(lblImagePreview, 0, 4);
            tlpMainLayout.Controls.Add(this.imgImage, 0, 5);
            tlpMainLayout.Controls.Add(flpDialogButtons, 0, 6);
            tlpMainLayout.Location = new System.Drawing.Point(12, 12);
            tlpMainLayout.Name = "tlpMainLayout";
            tlpMainLayout.RowCount = 7;
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            tlpMainLayout.Size = new System.Drawing.Size(364, 237);
            tlpMainLayout.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblName.AutoSize = true;
            tlpMainLayout.SetColumnSpan(lblName, 2);
            lblName.Location = new System.Drawing.Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(358, 13);
            lblName.TabIndex = 0;
            lblName.Text = "Image Name:";
            lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            tlpMainLayout.SetColumnSpan(this.txtName, 2);
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(358, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblImage
            // 
            lblImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblImage.AutoSize = true;
            tlpMainLayout.SetColumnSpan(lblImage, 2);
            lblImage.Location = new System.Drawing.Point(3, 39);
            lblImage.Name = "lblImage";
            lblImage.Size = new System.Drawing.Size(358, 13);
            lblImage.TabIndex = 2;
            lblImage.Text = "Image to Load:";
            lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImagePath.Location = new System.Drawing.Point(3, 56);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(329, 20);
            this.txtImagePath.TabIndex = 3;
            this.txtImagePath.Leave += new System.EventHandler(this.TxtImagePath_Leave);
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnBrowseImage.Image = global::JAL.AquariaRecipes.Properties.Resources.Open_6529;
            btnBrowseImage.Location = new System.Drawing.Point(338, 55);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new System.Drawing.Size(23, 23);
            btnBrowseImage.TabIndex = 4;
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += new System.EventHandler(this.BtnBrowseImage_Click);
            // 
            // lblImagePreview
            // 
            lblImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblImagePreview.AutoSize = true;
            tlpMainLayout.SetColumnSpan(lblImagePreview, 2);
            lblImagePreview.Location = new System.Drawing.Point(3, 81);
            lblImagePreview.Name = "lblImagePreview";
            lblImagePreview.Size = new System.Drawing.Size(358, 13);
            lblImagePreview.TabIndex = 6;
            lblImagePreview.Text = "Preview:";
            lblImagePreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgImage
            // 
            this.imgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            tlpMainLayout.SetColumnSpan(this.imgImage, 2);
            this.imgImage.Location = new System.Drawing.Point(3, 97);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(358, 108);
            this.imgImage.TabIndex = 5;
            this.imgImage.TabStop = false;
            // 
            // flpDialogButtons
            // 
            flpDialogButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            flpDialogButtons.AutoSize = true;
            tlpMainLayout.SetColumnSpan(flpDialogButtons, 2);
            flpDialogButtons.Controls.Add(this.btnOk);
            flpDialogButtons.Controls.Add(btnCancel);
            flpDialogButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flpDialogButtons.Location = new System.Drawing.Point(0, 208);
            flpDialogButtons.Margin = new System.Windows.Forms.Padding(0);
            flpDialogButtons.Name = "flpDialogButtons";
            flpDialogButtons.Size = new System.Drawing.Size(364, 29);
            flpDialogButtons.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(286, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(205, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewImage
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 261);
            this.ControlBox = false;
            this.Controls.Add(tlpMainLayout);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse Image";
            tlpMainLayout.ResumeLayout(false);
            tlpMainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            flpDialogButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox imgImage;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnOk;
    }
}