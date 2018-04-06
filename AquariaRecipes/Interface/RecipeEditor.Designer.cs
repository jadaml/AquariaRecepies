namespace JAL.AquariaRecipes.Interface
{
    partial class RecipeEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TableLayoutPanel tlpMain;
            System.Windows.Forms.Label lblIngredient1;
            System.Windows.Forms.ComboBox cmbIngredient1;
            System.Windows.Forms.Label lblIngredient2;
            System.Windows.Forms.ComboBox cmbIngredient2;
            System.Windows.Forms.Label lblIngredient3;
            System.Windows.Forms.ComboBox cmbIngredient3;
            System.Windows.Forms.Button btnOk;
            System.Windows.Forms.Button btnCancel;
            this.srcIngredient1 = new System.Windows.Forms.BindingSource(this.components);
            this.srcIngredient2 = new System.Windows.Forms.BindingSource(this.components);
            this.srcIngredient3 = new System.Windows.Forms.BindingSource(this.components);
            this.flpDialogButtons = new System.Windows.Forms.FlowLayoutPanel();
            tlpMain = new System.Windows.Forms.TableLayoutPanel();
            lblIngredient1 = new System.Windows.Forms.Label();
            cmbIngredient1 = new System.Windows.Forms.ComboBox();
            lblIngredient2 = new System.Windows.Forms.Label();
            cmbIngredient2 = new System.Windows.Forms.ComboBox();
            lblIngredient3 = new System.Windows.Forms.Label();
            cmbIngredient3 = new System.Windows.Forms.ComboBox();
            btnOk = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient3)).BeginInit();
            this.flpDialogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tlpMain.AutoSize = true;
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMain.Controls.Add(lblIngredient1, 0, 0);
            tlpMain.Controls.Add(cmbIngredient1, 1, 0);
            tlpMain.Controls.Add(lblIngredient2, 0, 1);
            tlpMain.Controls.Add(cmbIngredient2, 1, 1);
            tlpMain.Controls.Add(lblIngredient3, 0, 2);
            tlpMain.Controls.Add(cmbIngredient3, 1, 2);
            tlpMain.Controls.Add(this.flpDialogButtons, 0, 3);
            tlpMain.Location = new System.Drawing.Point(12, 12);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 4;
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tlpMain.Size = new System.Drawing.Size(332, 110);
            tlpMain.TabIndex = 0;
            // 
            // lblIngredient1
            // 
            lblIngredient1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblIngredient1.AutoSize = true;
            lblIngredient1.Location = new System.Drawing.Point(4, 7);
            lblIngredient1.Margin = new System.Windows.Forms.Padding(0);
            lblIngredient1.Name = "lblIngredient1";
            lblIngredient1.Size = new System.Drawing.Size(74, 13);
            lblIngredient1.TabIndex = 0;
            lblIngredient1.Text = "1st Ingredient:";
            lblIngredient1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbIngredient1
            // 
            cmbIngredient1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cmbIngredient1.DataSource = this.srcIngredient1;
            cmbIngredient1.DisplayMember = "Name";
            cmbIngredient1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbIngredient1.DropDownHeight = 220;
            cmbIngredient1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbIngredient1.FormattingEnabled = true;
            cmbIngredient1.IntegralHeight = false;
            cmbIngredient1.Location = new System.Drawing.Point(81, 3);
            cmbIngredient1.Name = "cmbIngredient1";
            cmbIngredient1.Size = new System.Drawing.Size(248, 21);
            cmbIngredient1.TabIndex = 3;
            cmbIngredient1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawIngredientItem);
            cmbIngredient1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureIngredientItemHeight);
            // 
            // srcIngredient1
            // 
            this.srcIngredient1.AllowNew = false;
            this.srcIngredient1.DataSource = typeof(JAL.AquariaRecipes.Recipes.IIngredient);
            // 
            // lblIngredient2
            // 
            lblIngredient2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblIngredient2.AutoSize = true;
            lblIngredient2.Location = new System.Drawing.Point(0, 34);
            lblIngredient2.Margin = new System.Windows.Forms.Padding(0);
            lblIngredient2.Name = "lblIngredient2";
            lblIngredient2.Size = new System.Drawing.Size(78, 13);
            lblIngredient2.TabIndex = 1;
            lblIngredient2.Text = "2nd Ingredient:";
            lblIngredient2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbIngredient2
            // 
            cmbIngredient2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cmbIngredient2.DataSource = this.srcIngredient2;
            cmbIngredient2.DisplayMember = "Name";
            cmbIngredient2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbIngredient2.DropDownHeight = 220;
            cmbIngredient2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbIngredient2.FormattingEnabled = true;
            cmbIngredient2.IntegralHeight = false;
            cmbIngredient2.Location = new System.Drawing.Point(81, 30);
            cmbIngredient2.Name = "cmbIngredient2";
            cmbIngredient2.Size = new System.Drawing.Size(248, 21);
            cmbIngredient2.TabIndex = 4;
            cmbIngredient2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawIngredientItem);
            cmbIngredient2.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureIngredientItemHeight);
            // 
            // srcIngredient2
            // 
            this.srcIngredient2.AllowNew = false;
            this.srcIngredient2.DataSource = typeof(JAL.AquariaRecipes.Recipes.IIngredient);
            // 
            // lblIngredient3
            // 
            lblIngredient3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblIngredient3.AutoSize = true;
            lblIngredient3.Location = new System.Drawing.Point(3, 61);
            lblIngredient3.Margin = new System.Windows.Forms.Padding(0);
            lblIngredient3.Name = "lblIngredient3";
            lblIngredient3.Size = new System.Drawing.Size(75, 13);
            lblIngredient3.TabIndex = 2;
            lblIngredient3.Text = "3rd Ingredient:";
            lblIngredient3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbIngredient3
            // 
            cmbIngredient3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            cmbIngredient3.DataSource = this.srcIngredient3;
            cmbIngredient3.DisplayMember = "Name";
            cmbIngredient3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            cmbIngredient3.DropDownHeight = 220;
            cmbIngredient3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbIngredient3.FormattingEnabled = true;
            cmbIngredient3.IntegralHeight = false;
            cmbIngredient3.Location = new System.Drawing.Point(81, 57);
            cmbIngredient3.Name = "cmbIngredient3";
            cmbIngredient3.Size = new System.Drawing.Size(248, 21);
            cmbIngredient3.TabIndex = 5;
            cmbIngredient3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.DrawIngredientItem);
            cmbIngredient3.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.MeasureIngredientItemHeight);
            // 
            // srcIngredient3
            // 
            this.srcIngredient3.AllowNew = false;
            this.srcIngredient3.DataSource = typeof(JAL.AquariaRecipes.Recipes.IIngredient);
            // 
            // flpDialogButtons
            // 
            this.flpDialogButtons.AutoSize = true;
            this.flpDialogButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tlpMain.SetColumnSpan(this.flpDialogButtons, 2);
            this.flpDialogButtons.Controls.Add(btnOk);
            this.flpDialogButtons.Controls.Add(btnCancel);
            this.flpDialogButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDialogButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpDialogButtons.Location = new System.Drawing.Point(0, 81);
            this.flpDialogButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpDialogButtons.Name = "flpDialogButtons";
            this.flpDialogButtons.Size = new System.Drawing.Size(332, 29);
            this.flpDialogButtons.TabIndex = 6;
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(254, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "&Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(173, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // RecipeEditor
            // 
            this.AcceptButton = btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = btnCancel;
            this.ClientSize = new System.Drawing.Size(356, 134);
            this.Controls.Add(tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecipeEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Recipe";
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredient3)).EndInit();
            this.flpDialogButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flpDialogButtons;
        private System.Windows.Forms.BindingSource srcIngredient1;
        private System.Windows.Forms.BindingSource srcIngredient2;
        private System.Windows.Forms.BindingSource srcIngredient3;
    }
}