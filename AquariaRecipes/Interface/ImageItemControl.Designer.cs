namespace JAL.AquariaRecipes.Interface
{
    partial class ImageItemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tlpItemLayout;
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            tlpItemLayout = new System.Windows.Forms.TableLayoutPanel();
            tlpItemLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpItemLayout
            // 
            tlpItemLayout.AutoSize = true;
            tlpItemLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpItemLayout.ColumnCount = 2;
            tlpItemLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpItemLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpItemLayout.Controls.Add(this.picImage, 0, 0);
            tlpItemLayout.Controls.Add(this.lblText, 1, 0);
            tlpItemLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            tlpItemLayout.Location = new System.Drawing.Point(0, 0);
            tlpItemLayout.Margin = new System.Windows.Forms.Padding(0);
            tlpItemLayout.Name = "tlpItemLayout";
            tlpItemLayout.RowCount = 1;
            tlpItemLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpItemLayout.Size = new System.Drawing.Size(150, 22);
            tlpItemLayout.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Margin = new System.Windows.Forms.Padding(0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(22, 22);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(25, 4);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(122, 13);
            this.lblText.TabIndex = 1;
            // 
            // ImageItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tlpItemLayout);
            this.Name = "ImageItemControl";
            this.Size = new System.Drawing.Size(150, 22);
            tlpItemLayout.ResumeLayout(false);
            tlpItemLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblText;
    }
}
