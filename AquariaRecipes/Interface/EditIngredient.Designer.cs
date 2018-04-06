using System;
using System.ComponentModel;

namespace JAL.AquariaRecipes.Interface
{
    partial class EditIngredient
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
            System.Windows.Forms.Label lblName;
            System.Windows.Forms.Label lblCategory;
            System.Windows.Forms.Label lblImage;
            System.Windows.Forms.Label lblNotes;
            System.Windows.Forms.Button btnOk;
            System.Windows.Forms.BindingNavigator navIngredients;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIngredient));
            System.Windows.Forms.ToolStripContainer tscIngredinets;
            this.srcIngredients = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.lstRecipes = new System.Windows.Forms.ListBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.srcCategory = new System.Windows.Forms.BindingSource(this.components);
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.srcImage = new System.Windows.Forms.BindingSource(this.components);
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblIngredients = new System.Windows.Forms.Label();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.flpDialogButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            lblName = new System.Windows.Forms.Label();
            lblCategory = new System.Windows.Forms.Label();
            lblImage = new System.Windows.Forms.Label();
            lblNotes = new System.Windows.Forms.Label();
            btnOk = new System.Windows.Forms.Button();
            navIngredients = new System.Windows.Forms.BindingNavigator(this.components);
            tscIngredinets = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(navIngredients)).BeginInit();
            navIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredients)).BeginInit();
            tscIngredinets.ContentPanel.SuspendLayout();
            tscIngredinets.TopToolStripPanel.SuspendLayout();
            tscIngredinets.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcImage)).BeginInit();
            this.pnlIngredients.SuspendLayout();
            this.flpDialogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(3, 0);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(314, 13);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
            // 
            // lblCategory
            // 
            lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblCategory.AutoSize = true;
            lblCategory.Location = new System.Drawing.Point(3, 39);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new System.Drawing.Size(314, 13);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category:";
            // 
            // lblImage
            // 
            lblImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblImage.AutoSize = true;
            lblImage.Location = new System.Drawing.Point(3, 79);
            lblImage.Name = "lblImage";
            lblImage.Size = new System.Drawing.Size(314, 13);
            lblImage.TabIndex = 4;
            lblImage.Text = "Image:";
            // 
            // lblNotes
            // 
            lblNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblNotes.AutoSize = true;
            lblNotes.Location = new System.Drawing.Point(3, 119);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new System.Drawing.Size(314, 13);
            lblNotes.TabIndex = 6;
            lblNotes.Text = "Notes:";
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(562, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "&Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // navIngredients
            // 
            navIngredients.AddNewItem = null;
            navIngredients.BindingSource = this.srcIngredients;
            navIngredients.CountItem = this.bindingNavigatorCountItem;
            navIngredients.DeleteItem = this.bindingNavigatorDeleteItem;
            navIngredients.Dock = System.Windows.Forms.DockStyle.None;
            navIngredients.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            navIngredients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.btnEdit,
            this.bindingNavigatorDeleteItem});
            navIngredients.Location = new System.Drawing.Point(3, 0);
            navIngredients.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            navIngredients.MoveLastItem = this.bindingNavigatorMoveLastItem;
            navIngredients.MoveNextItem = this.bindingNavigatorMoveNextItem;
            navIngredients.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            navIngredients.Name = "navIngredients";
            navIngredients.PositionItem = this.bindingNavigatorPositionItem;
            navIngredients.Size = new System.Drawing.Size(269, 25);
            navIngredients.TabIndex = 0;
            navIngredients.Text = "bindingNavigator1";
            // 
            // srcIngredients
            // 
            this.srcIngredients.AllowNew = true;
            this.srcIngredients.DataSource = typeof(JAL.AquariaRecipes.Recipes.IngredientCollection);
            this.srcIngredients.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.SrcIngredients_ListChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // tscIngredinets
            // 
            // 
            // tscIngredinets.ContentPanel
            // 
            tscIngredinets.ContentPanel.Controls.Add(this.lstRecipes);
            tscIngredinets.ContentPanel.Size = new System.Drawing.Size(314, 214);
            tscIngredinets.Dock = System.Windows.Forms.DockStyle.Fill;
            tscIngredinets.Location = new System.Drawing.Point(0, 0);
            tscIngredinets.Name = "tscIngredinets";
            tscIngredinets.Size = new System.Drawing.Size(314, 239);
            tscIngredinets.TabIndex = 0;
            tscIngredinets.Text = "toolStripContainer1";
            // 
            // tscIngredinets.TopToolStripPanel
            // 
            tscIngredinets.TopToolStripPanel.Controls.Add(navIngredients);
            // 
            // lstRecipes
            // 
            this.lstRecipes.DataSource = this.srcIngredients;
            this.lstRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRecipes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstRecipes.FormattingEnabled = true;
            this.lstRecipes.IntegralHeight = false;
            this.lstRecipes.ItemHeight = 64;
            this.lstRecipes.Location = new System.Drawing.Point(0, 0);
            this.lstRecipes.Name = "lstRecipes";
            this.lstRecipes.Size = new System.Drawing.Size(314, 214);
            this.lstRecipes.TabIndex = 0;
            this.lstRecipes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LstRecipes_DrawItem);
            this.lstRecipes.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.LstRecipes_MeasureItem);
            this.lstRecipes.Resize += new System.EventHandler(this.LstRecipes_Resize);
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(lblName, 0, 0);
            this.tlpMain.Controls.Add(this.txtName, 0, 1);
            this.tlpMain.Controls.Add(lblCategory, 0, 2);
            this.tlpMain.Controls.Add(this.cmbCategory, 0, 3);
            this.tlpMain.Controls.Add(lblImage, 0, 4);
            this.tlpMain.Controls.Add(this.cmbImage, 0, 5);
            this.tlpMain.Controls.Add(lblNotes, 0, 6);
            this.tlpMain.Controls.Add(this.txtNotes, 0, 7);
            this.tlpMain.Controls.Add(this.lblIngredients, 1, 0);
            this.tlpMain.Controls.Add(this.pnlIngredients, 1, 1);
            this.tlpMain.Controls.Add(this.flpDialogButtons, 0, 8);
            this.tlpMain.Location = new System.Drawing.Point(12, 12);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 9;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(640, 287);
            this.tlpMain.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(3, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(314, 20);
            this.txtName.TabIndex = 1;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.srcCategory, "Name", true));
            this.cmbCategory.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.srcCategory, "Name", true));
            this.cmbCategory.DataSource = this.srcCategory;
            this.cmbCategory.DisplayMember = "Name";
            this.cmbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbCategory.DropDownHeight = 220;
            this.cmbCategory.IntegralHeight = false;
            this.cmbCategory.Location = new System.Drawing.Point(3, 55);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(314, 21);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.ValueMember = "Name";
            this.cmbCategory.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbCategory_DrawItem);
            this.cmbCategory.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.CmbCategory_MeasureItem);
            // 
            // srcCategory
            // 
            this.srcCategory.DataSource = typeof(JAL.AquariaRecipes.Recipes.Category);
            // 
            // cmbImage
            // 
            this.cmbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbImage.DataSource = this.srcImage;
            this.cmbImage.DisplayMember = "Name";
            this.cmbImage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbImage.DropDownHeight = 320;
            this.cmbImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.IntegralHeight = false;
            this.cmbImage.Location = new System.Drawing.Point(3, 95);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(314, 21);
            this.cmbImage.TabIndex = 5;
            this.cmbImage.ValueMember = "Name";
            this.cmbImage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CmbImage_DrawItem);
            this.cmbImage.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.CmbImage_MeasureItem);
            // 
            // srcImage
            // 
            this.srcImage.DataSource = typeof(JAL.AquariaRecipes.Recipes.Image);
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(3, 135);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.Size = new System.Drawing.Size(314, 120);
            this.txtNotes.TabIndex = 7;
            // 
            // lblIngredients
            // 
            this.lblIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIngredients.AutoSize = true;
            this.lblIngredients.Location = new System.Drawing.Point(323, 0);
            this.lblIngredients.Name = "lblIngredients";
            this.lblIngredients.Size = new System.Drawing.Size(314, 13);
            this.lblIngredients.TabIndex = 8;
            this.lblIngredients.Text = "Recipes:";
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlIngredients.Controls.Add(tscIngredinets);
            this.pnlIngredients.Location = new System.Drawing.Point(323, 16);
            this.pnlIngredients.Name = "pnlIngredients";
            this.tlpMain.SetRowSpan(this.pnlIngredients, 7);
            this.pnlIngredients.Size = new System.Drawing.Size(314, 239);
            this.pnlIngredients.TabIndex = 9;
            // 
            // flpDialogButtons
            // 
            this.flpDialogButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDialogButtons.AutoScroll = true;
            this.flpDialogButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.SetColumnSpan(this.flpDialogButtons, 2);
            this.flpDialogButtons.Controls.Add(btnOk);
            this.flpDialogButtons.Controls.Add(this.btnCancel);
            this.flpDialogButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpDialogButtons.Location = new System.Drawing.Point(0, 258);
            this.flpDialogButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpDialogButtons.Name = "flpDialogButtons";
            this.flpDialogButtons.Size = new System.Drawing.Size(640, 29);
            this.flpDialogButtons.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(481, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditIngredient
            // 
            this.AcceptButton = btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(664, 311);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIngredient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Ingredient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditIngredient_FormClosed);
            this.Shown += new System.EventHandler(this.EditIngredient_Shown);
            ((System.ComponentModel.ISupportInitialize)(navIngredients)).EndInit();
            navIngredients.ResumeLayout(false);
            navIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcIngredients)).EndInit();
            tscIngredinets.ContentPanel.ResumeLayout(false);
            tscIngredinets.TopToolStripPanel.ResumeLayout(false);
            tscIngredinets.TopToolStripPanel.PerformLayout();
            tscIngredinets.ResumeLayout(false);
            tscIngredinets.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcImage)).EndInit();
            this.pnlIngredients.ResumeLayout(false);
            this.flpDialogButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.FlowLayoutPanel flpDialogButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource srcImage;
        private System.Windows.Forms.BindingSource srcCategory;
        private System.Windows.Forms.ListBox lstRecipes;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.BindingSource srcIngredients;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Label lblIngredients;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton btnEdit;
    }
}