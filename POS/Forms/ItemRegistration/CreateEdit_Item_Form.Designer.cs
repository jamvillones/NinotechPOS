namespace POS.Forms.ItemRegistration
{
    partial class CreateEdit_Item_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEdit_Item_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonsHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.costTable = new System.Windows.Forms.DataGridView();
            this.col_Supplier = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addCostButton = new System.Windows.Forms.Button();
            this.autoGenBarcodeButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this._departmentOption = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.removeImageButton = new System.Windows.Forms.Button();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this._name = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this._criticalQty = new System.Windows.Forms.NumericUpDown();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this._tags = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this._details = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this._price = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sellingPriceLabel = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonsHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costTable)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._criticalQty)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonsHolder
            // 
            this.buttonsHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonsHolder.AutoSize = true;
            this.buttonsHolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonsHolder.Controls.Add(this.cancelButton);
            this.buttonsHolder.Controls.Add(this.saveButton);
            this.buttonsHolder.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsHolder.Location = new System.Drawing.Point(20, 523);
            this.buttonsHolder.Name = "buttonsHolder";
            this.buttonsHolder.Size = new System.Drawing.Size(325, 35);
            this.buttonsHolder.TabIndex = 10;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.RosyBrown;
            this.cancelButton.Enabled = false;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.Location = new System.Drawing.Point(170, 0);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cancelButton.Size = new System.Drawing.Size(155, 35);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "    Cancel Changes";
            this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = true;
            this.saveButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.saveButton.Enabled = false;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.Location = new System.Drawing.Point(0, 0);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.saveButton.MaximumSize = new System.Drawing.Size(150, 35);
            this.saveButton.MinimumSize = new System.Drawing.Size(155, 35);
            this.saveButton.Name = "saveButton";
            this.saveButton.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.saveButton.Size = new System.Drawing.Size(155, 35);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "    Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // costTable
            // 
            this.costTable.AllowUserToAddRows = false;
            this.costTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.costTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.costTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.costTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.costTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.costTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.costTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Supplier,
            this.col_Value,
            this.Column1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.costTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.costTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.costTable.EnableHeadersVisualStyles = false;
            this.costTable.GridColor = System.Drawing.SystemColors.ButtonShadow;
            this.costTable.Location = new System.Drawing.Point(0, 30);
            this.costTable.MultiSelect = false;
            this.costTable.Name = "costTable";
            this.costTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.costTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.costTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.costTable.Size = new System.Drawing.Size(325, 244);
            this.costTable.StandardTab = true;
            this.costTable.TabIndex = 9;
            this.costTable.Tag = "Costs";
            this.costTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.costTable_CellClick);
            this.costTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.costTable_CellPainting);
            this.costTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.costTable_RowsAdded);
            this.costTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.costTable_KeyDown);
            // 
            // col_Supplier
            // 
            this.col_Supplier.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.col_Supplier.FillWeight = 200F;
            this.col_Supplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.col_Supplier.HeaderText = "SUPPLIER";
            this.col_Supplier.Name = "col_Supplier";
            this.col_Supplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Supplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_Value
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Value.HeaderText = "VALUE";
            this.col_Value.Name = "col_Value";
            this.col_Value.ToolTipText = "Edit Cost";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonFace;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Column1.HeaderText = "";
            this.Column1.MinimumWidth = 36;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 36;
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // addCostButton
            // 
            this.addCostButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCostButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.addCostButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.addCostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCostButton.Image = ((System.Drawing.Image)(resources.GetObject("addCostButton.Image")));
            this.addCostButton.Location = new System.Drawing.Point(288, 0);
            this.addCostButton.Name = "addCostButton";
            this.addCostButton.Size = new System.Drawing.Size(37, 25);
            this.addCostButton.TabIndex = 10;
            this.addCostButton.TabStop = false;
            this.addCostButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.addCostButton, "Add New Cost");
            this.addCostButton.UseVisualStyleBackColor = false;
            this.addCostButton.Click += new System.EventHandler(this.addCostButton_Click);
            // 
            // autoGenBarcodeButton
            // 
            this.autoGenBarcodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoGenBarcodeButton.BackColor = System.Drawing.Color.White;
            this.autoGenBarcodeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.autoGenBarcodeButton.FlatAppearance.BorderSize = 0;
            this.autoGenBarcodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoGenBarcodeButton.Image = ((System.Drawing.Image)(resources.GetObject("autoGenBarcodeButton.Image")));
            this.autoGenBarcodeButton.Location = new System.Drawing.Point(527, 5);
            this.autoGenBarcodeButton.Name = "autoGenBarcodeButton";
            this.autoGenBarcodeButton.Size = new System.Drawing.Size(25, 25);
            this.autoGenBarcodeButton.TabIndex = 21;
            this.autoGenBarcodeButton.TabStop = false;
            this.toolTip.SetToolTip(this.autoGenBarcodeButton, "Only use this when the item has no default barcode.");
            this.autoGenBarcodeButton.UseVisualStyleBackColor = false;
            this.autoGenBarcodeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this._departmentOption);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Location = new System.Drawing.Point(369, 109);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(567, 40);
            this.panel11.TabIndex = 3;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Black;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 39);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(567, 1);
            this.panel12.TabIndex = 19;
            // 
            // _departmentOption
            // 
            this._departmentOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._departmentOption.BackColor = System.Drawing.Color.White;
            this._departmentOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._departmentOption.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._departmentOption.FormattingEnabled = true;
            this._departmentOption.Location = new System.Drawing.Point(18, 16);
            this._departmentOption.Name = "_departmentOption";
            this._departmentOption.Size = new System.Drawing.Size(530, 21);
            this._departmentOption.TabIndex = 18;
            this._departmentOption.Tag = "Department";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Department:";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.removeImageButton);
            this.panel15.Controls.Add(this.chooseImageButton);
            this.panel15.Controls.Add(this._pictureBox);
            this.panel15.Location = new System.Drawing.Point(20, 34);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(325, 156);
            this.panel15.TabIndex = 7;
            this.panel15.TabStop = true;
            // 
            // removeImageButton
            // 
            this.removeImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeImageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeImageButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeImageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.removeImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeImageButton.Image = ((System.Drawing.Image)(resources.GetObject("removeImageButton.Image")));
            this.removeImageButton.Location = new System.Drawing.Point(288, 124);
            this.removeImageButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.removeImageButton.MaximumSize = new System.Drawing.Size(150, 35);
            this.removeImageButton.Name = "removeImageButton";
            this.removeImageButton.Size = new System.Drawing.Size(33, 28);
            this.removeImageButton.TabIndex = 2;
            this.removeImageButton.UseVisualStyleBackColor = false;
            this.removeImageButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseImageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.chooseImageButton.BackColor = System.Drawing.SystemColors.Control;
            this.chooseImageButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.AppWorkspace;
            this.chooseImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseImageButton.Image = ((System.Drawing.Image)(resources.GetObject("chooseImageButton.Image")));
            this.chooseImageButton.Location = new System.Drawing.Point(288, 93);
            this.chooseImageButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.chooseImageButton.MaximumSize = new System.Drawing.Size(150, 35);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(33, 28);
            this.chooseImageButton.TabIndex = 1;
            this.chooseImageButton.UseVisualStyleBackColor = false;
            this.chooseImageButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // _pictureBox
            // 
            this._pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this._pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pictureBox.BackgroundImage")));
            this._pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(325, 156);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pictureBox.TabIndex = 14;
            this._pictureBox.TabStop = false;
            this._pictureBox.Tag = "";
            this._pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this._name);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(369, 29);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(567, 35);
            this.panel6.TabIndex = 1;
            // 
            // _name
            // 
            this._name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._name.BackColor = System.Drawing.Color.White;
            this._name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._name.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._name.ForeColor = System.Drawing.Color.Black;
            this._name.Location = new System.Drawing.Point(18, 16);
            this._name.MaxLength = 50;
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(530, 18);
            this._name.TabIndex = 0;
            this._name.Tag = "Name";
            this._name.Validated += new System.EventHandler(this._name_Validated);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(567, 1);
            this.panel7.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._barcode);
            this.panel1.Controls.Add(this.autoGenBarcodeButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(369, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 35);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 1);
            this.panel2.TabIndex = 1;
            // 
            // _barcode
            // 
            this._barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._barcode.BackColor = System.Drawing.Color.White;
            this._barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._barcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._barcode.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._barcode.ForeColor = System.Drawing.Color.Black;
            this._barcode.Location = new System.Drawing.Point(18, 16);
            this._barcode.MaxLength = 50;
            this._barcode.Name = "_barcode";
            this._barcode.Size = new System.Drawing.Size(500, 18);
            this._barcode.TabIndex = 0;
            this._barcode.Tag = "Barcode";
            this._barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this._barcode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode:";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this._criticalQty);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(369, 154);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(567, 35);
            this.panel5.TabIndex = 4;
            // 
            // _criticalQty
            // 
            this._criticalQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._criticalQty.BackColor = System.Drawing.Color.White;
            this._criticalQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._criticalQty.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._criticalQty.ForeColor = System.Drawing.Color.Black;
            this._criticalQty.Location = new System.Drawing.Point(18, 13);
            this._criticalQty.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this._criticalQty.Name = "_criticalQty";
            this._criticalQty.Size = new System.Drawing.Size(530, 21);
            this._criticalQty.TabIndex = 3;
            this._criticalQty.Tag = "Critical Quantity";
            this._criticalQty.ThousandsSeparator = true;
            this._criticalQty.Leave += new System.EventHandler(this._criticalQty_Leave);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 34);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(567, 1);
            this.panel8.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Critical Qty:";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this._tags);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Location = new System.Drawing.Point(369, 194);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(567, 35);
            this.panel9.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 34);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(567, 1);
            this.panel10.TabIndex = 1;
            // 
            // _tags
            // 
            this._tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tags.BackColor = System.Drawing.Color.White;
            this._tags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tags.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tags.ForeColor = System.Drawing.Color.Black;
            this._tags.Location = new System.Drawing.Point(18, 16);
            this._tags.MaxLength = 300;
            this._tags.Name = "_tags";
            this._tags.Size = new System.Drawing.Size(530, 18);
            this._tags.TabIndex = 0;
            this._tags.Tag = "Tags";
            this._tags.Validating += new System.ComponentModel.CancelEventHandler(this._tags_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tags:";
            // 
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.Controls.Add(this._details);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.label7);
            this.panel13.Location = new System.Drawing.Point(369, 263);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(567, 245);
            this.panel13.TabIndex = 6;
            // 
            // _details
            // 
            this._details.BackColor = System.Drawing.Color.White;
            this._details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._details.Dock = System.Windows.Forms.DockStyle.Fill;
            this._details.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._details.ForeColor = System.Drawing.Color.Black;
            this._details.Location = new System.Drawing.Point(0, 23);
            this._details.MaxLength = 300;
            this._details.Multiline = true;
            this._details.Name = "_details";
            this._details.Size = new System.Drawing.Size(567, 221);
            this._details.TabIndex = 2;
            this._details.Tag = "Notes";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Black;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 244);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(567, 1);
            this.panel14.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label7.Size = new System.Drawing.Size(38, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Notes:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label10);
            this.flowLayoutPanel2.Controls.Add(this.label9);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(916, 23);
            this.flowLayoutPanel2.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.label10.Size = new System.Drawing.Size(123, 23);
            this.label10.TabIndex = 1;
            this.label10.Text = "Type: Quantifiable";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(123, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.label9.Size = new System.Drawing.Size(128, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "With Serial Number";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._price);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.sellingPriceLabel);
            this.panel3.Location = new System.Drawing.Point(20, 195);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(325, 35);
            this.panel3.TabIndex = 8;
            // 
            // _price
            // 
            this._price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._price.BackColor = System.Drawing.Color.White;
            this._price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._price.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._price.ForeColor = System.Drawing.Color.Black;
            this._price.Location = new System.Drawing.Point(11, 16);
            this._price.MaxLength = 50;
            this._price.Name = "_price";
            this._price.Size = new System.Drawing.Size(303, 18);
            this._price.TabIndex = 0;
            this._price.Tag = "Selling Price";
            this._price.Enter += new System.EventHandler(this._price_Enter);
            this._price.KeyDown += new System.Windows.Forms.KeyEventHandler(this._price_KeyDown);
            this._price.Validating += new System.ComponentModel.CancelEventHandler(this._price_Validating);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(325, 1);
            this.panel4.TabIndex = 1;
            // 
            // sellingPriceLabel
            // 
            this.sellingPriceLabel.AutoSize = true;
            this.sellingPriceLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sellingPriceLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.sellingPriceLabel.Location = new System.Drawing.Point(0, 0);
            this.sellingPriceLabel.Name = "sellingPriceLabel";
            this.sellingPriceLabel.Size = new System.Drawing.Size(68, 13);
            this.sellingPriceLabel.TabIndex = 0;
            this.sellingPriceLabel.Text = "Selling Price:";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel16.Controls.Add(this.costTable);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.addCostButton);
            this.panel16.Controls.Add(this.label11);
            this.panel16.Location = new System.Drawing.Point(20, 233);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(325, 275);
            this.panel16.TabIndex = 9;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.Black;
            this.panel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel17.Location = new System.Drawing.Point(0, 274);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(325, 1);
            this.panel17.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 17, 0, 0);
            this.label11.Size = new System.Drawing.Size(36, 30);
            this.label11.TabIndex = 0;
            this.label11.Text = "Costs:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            this.errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider.Icon")));
            // 
            // ItemBindingSource
            // 
            this.ItemBindingSource.AllowNew = false;
            this.ItemBindingSource.DataSource = typeof(POS.Item);
            // 
            // CreateEdit_Item_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(956, 581);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.buttonsHolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(972, 620);
            this.Name = "CreateEdit_Item_Form";
            this.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateEdit_Item_Form_FormClosing);
            this.Load += new System.EventHandler(this.CreateEdit_Item_Form_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateEdit_Item_Form_KeyDown);
            this.buttonsHolder.ResumeLayout(false);
            this.buttonsHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costTable)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._criticalQty)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel buttonsHolder;
        private System.Windows.Forms.DataGridView costTable;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ComboBox _departmentOption;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button removeImageButton;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox _name;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _barcode;
        private System.Windows.Forms.Button autoGenBarcodeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown _criticalQty;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox _tags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox _details;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button addCostButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox _price;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label sellingPriceLabel;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Value;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.BindingSource ItemBindingSource;
        private System.Windows.Forms.Panel panel12;
    }
}