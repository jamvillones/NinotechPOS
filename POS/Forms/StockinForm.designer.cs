namespace POS.Forms
{
    partial class StockinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockinForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.stockinBtn = new System.Windows.Forms.Button();
            this.inventoryTable = new System.Windows.Forms.DataGridView();
            this.col_Inventory_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_serialReq = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createItemBtn = new System.Windows.Forms.Button();
            this.serialNumber = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.addBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.searchControl = new POS.UserControls.SearchControl();
            this.serialGroup = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.qtyGroup = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.itemName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._grandTotalTxt = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this._messageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.serialGroup.SuspendLayout();
            this.qtyGroup.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // stockinBtn
            // 
            this.stockinBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.stockinBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stockinBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.stockinBtn.FlatAppearance.BorderSize = 2;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockinBtn.Image = ((System.Drawing.Image)(resources.GetObject("stockinBtn.Image")));
            this.stockinBtn.Location = new System.Drawing.Point(0, 425);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Size = new System.Drawing.Size(537, 35);
            this.stockinBtn.TabIndex = 5;
            this.stockinBtn.TabStop = false;
            this.stockinBtn.Text = "    Stock In [ Ctrl+Enter ]";
            this.stockinBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stockinBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.stockinBtn, "(ctrl+Enter) to stock in");
            this.stockinBtn.UseVisualStyleBackColor = false;
            this.stockinBtn.Click += new System.EventHandler(this.stockinBtn_Click);
            // 
            // inventoryTable
            // 
            this.inventoryTable.AllowUserToAddRows = false;
            this.inventoryTable.AllowUserToResizeRows = false;
            this.inventoryTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.inventoryTable.BackgroundColor = System.Drawing.Color.White;
            this.inventoryTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventoryTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inventoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Inventory_Id,
            this.col_Inventory_Barcode,
            this.col_Inventory_Serial,
            this.col_Inventory_Name,
            this.col_Inventory_Supplier,
            this.col_Inventory_Qty,
            this.col_Inventory_Cost,
            this.col_Inventory_Total,
            this.col_remove});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.inventoryTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTable.EnableHeadersVisualStyles = false;
            this.inventoryTable.Location = new System.Drawing.Point(0, 43);
            this.inventoryTable.Name = "inventoryTable";
            this.inventoryTable.ReadOnly = true;
            this.inventoryTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inventoryTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.inventoryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryTable.Size = new System.Drawing.Size(537, 352);
            this.inventoryTable.TabIndex = 4;
            this.inventoryTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.inventoryTable_CellMouseDoubleClick);
            this.inventoryTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.inventoryTable_RowsAdded);
            this.inventoryTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.inventoryTable_RowsRemoved);
            // 
            // col_Inventory_Id
            // 
            this.col_Inventory_Id.HeaderText = "ID";
            this.col_Inventory_Id.Name = "col_Inventory_Id";
            this.col_Inventory_Id.ReadOnly = true;
            this.col_Inventory_Id.Visible = false;
            // 
            // col_Inventory_Barcode
            // 
            this.col_Inventory_Barcode.HeaderText = "BARCODE";
            this.col_Inventory_Barcode.Name = "col_Inventory_Barcode";
            this.col_Inventory_Barcode.ReadOnly = true;
            this.col_Inventory_Barcode.Visible = false;
            // 
            // col_Inventory_Serial
            // 
            this.col_Inventory_Serial.HeaderText = "SERIAL";
            this.col_Inventory_Serial.Name = "col_Inventory_Serial";
            this.col_Inventory_Serial.ReadOnly = true;
            // 
            // col_Inventory_Name
            // 
            this.col_Inventory_Name.HeaderText = "NAME";
            this.col_Inventory_Name.Name = "col_Inventory_Name";
            this.col_Inventory_Name.ReadOnly = true;
            // 
            // col_Inventory_Supplier
            // 
            this.col_Inventory_Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Inventory_Supplier.HeaderText = "SUPPLIER";
            this.col_Inventory_Supplier.Name = "col_Inventory_Supplier";
            this.col_Inventory_Supplier.ReadOnly = true;
            // 
            // col_Inventory_Qty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Inventory_Qty.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Inventory_Qty.HeaderText = "QTY";
            this.col_Inventory_Qty.Name = "col_Inventory_Qty";
            this.col_Inventory_Qty.ReadOnly = true;
            // 
            // col_Inventory_Cost
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.col_Inventory_Cost.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Inventory_Cost.HeaderText = "COST";
            this.col_Inventory_Cost.Name = "col_Inventory_Cost";
            this.col_Inventory_Cost.ReadOnly = true;
            // 
            // col_Inventory_Total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Inventory_Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Inventory_Total.HeaderText = "TOTAL";
            this.col_Inventory_Total.Name = "col_Inventory_Total";
            this.col_Inventory_Total.ReadOnly = true;
            // 
            // col_remove
            // 
            this.col_remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_remove.HeaderText = "";
            this.col_remove.Name = "col_remove";
            this.col_remove.ReadOnly = true;
            this.col_remove.Text = "Remove";
            this.col_remove.UseColumnTextForButtonValue = true;
            this.col_remove.Visible = false;
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToDeleteRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.itemsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.itemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.itemsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Id,
            this.col_barcode,
            this.col_name,
            this.col_supplier,
            this.col_cost,
            this.col_serialReq});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle10;
            this.itemsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.Location = new System.Drawing.Point(0, 190);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(398, 235);
            this.itemsTable.TabIndex = 4;
            this.itemsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDoubleClick);
            this.itemsTable.SelectionChanged += new System.EventHandler(this.itemsTable_SelectionChanged);
            // 
            // col_Id
            // 
            this.col_Id.HeaderText = "ID";
            this.col_Id.Name = "col_Id";
            this.col_Id.ReadOnly = true;
            this.col_Id.Visible = false;
            // 
            // col_barcode
            // 
            this.col_barcode.HeaderText = "BARCODE";
            this.col_barcode.Name = "col_barcode";
            this.col_barcode.ReadOnly = true;
            this.col_barcode.Visible = false;
            // 
            // col_name
            // 
            this.col_name.HeaderText = "NAME";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            // 
            // col_supplier
            // 
            this.col_supplier.HeaderText = "SUPPLIER";
            this.col_supplier.Name = "col_supplier";
            this.col_supplier.ReadOnly = true;
            // 
            // col_cost
            // 
            this.col_cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.col_cost.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_cost.HeaderText = "COST";
            this.col_cost.Name = "col_cost";
            this.col_cost.ReadOnly = true;
            // 
            // col_serialReq
            // 
            this.col_serialReq.HeaderText = "col_SerialRequired";
            this.col_serialReq.Name = "col_serialReq";
            this.col_serialReq.ReadOnly = true;
            this.col_serialReq.Visible = false;
            // 
            // createItemBtn
            // 
            this.createItemBtn.BackColor = System.Drawing.Color.White;
            this.createItemBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.createItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("createItemBtn.Image")));
            this.createItemBtn.Location = new System.Drawing.Point(358, 0);
            this.createItemBtn.Name = "createItemBtn";
            this.createItemBtn.Size = new System.Drawing.Size(140, 35);
            this.createItemBtn.TabIndex = 1;
            this.createItemBtn.Text = "    Create Item";
            this.createItemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.createItemBtn, "Create Item");
            this.createItemBtn.UseVisualStyleBackColor = false;
            this.createItemBtn.Click += new System.EventHandler(this.createItemBtn_Click);
            // 
            // serialNumber
            // 
            this.serialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialNumber.BackColor = System.Drawing.Color.White;
            this.serialNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.serialNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber.ForeColor = System.Drawing.Color.Blue;
            this.serialNumber.Location = new System.Drawing.Point(7, 19);
            this.serialNumber.MaxLength = 50;
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(383, 19);
            this.serialNumber.TabIndex = 0;
            this.serialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.serialNumber, "(f2) to focus serial number");
            this.serialNumber.TextChanged += new System.EventHandler(this.serialNumber_TextChanged);
            this.serialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialNumber_KeyDown);
            // 
            // quantity
            // 
            this.quantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quantity.BackColor = System.Drawing.Color.White;
            this.quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantity.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.ForeColor = System.Drawing.Color.Blue;
            this.quantity.Location = new System.Drawing.Point(7, 19);
            this.quantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(383, 22);
            this.quantity.TabIndex = 0;
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.quantity, "(f3) to focus quantity");
            this.quantity.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.White;
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.addBtn.FlatAppearance.BorderSize = 2;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.Location = new System.Drawing.Point(0, 425);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(398, 35);
            this.addBtn.TabIndex = 5;
            this.addBtn.TabStop = false;
            this.addBtn.Text = "    Select [ Shift + Enter ]";
            this.addBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.addBtn, "(shift+Enter) to add");
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 300;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // searchControl
            // 
            this.searchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl.BackColor = System.Drawing.Color.White;
            this.searchControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl.Location = new System.Drawing.Point(0, 0);
            this.searchControl.MaximumSize = new System.Drawing.Size(350, 60);
            this.searchControl.MinimumSize = new System.Drawing.Size(350, 35);
            this.searchControl.Name = "searchControl";
            this.searchControl.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl.SearchedText = "";
            this.searchControl.Size = new System.Drawing.Size(350, 35);
            this.searchControl.TabIndex = 0;
            this.toolTip.SetToolTip(this.searchControl, "(ctrl+F) to focus search");
            this.searchControl.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // serialGroup
            // 
            this.serialGroup.BackColor = System.Drawing.Color.White;
            this.serialGroup.Controls.Add(this.serialNumber);
            this.serialGroup.Controls.Add(this.panel7);
            this.serialGroup.Controls.Add(this.label5);
            this.serialGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.serialGroup.Location = new System.Drawing.Point(0, 70);
            this.serialGroup.Name = "serialGroup";
            this.serialGroup.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.serialGroup.Size = new System.Drawing.Size(398, 50);
            this.serialGroup.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 44);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(398, 1);
            this.panel7.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Serial Number:";
            // 
            // qtyGroup
            // 
            this.qtyGroup.BackColor = System.Drawing.Color.White;
            this.qtyGroup.Controls.Add(this.quantity);
            this.qtyGroup.Controls.Add(this.panel2);
            this.qtyGroup.Controls.Add(this.label6);
            this.qtyGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.qtyGroup.Location = new System.Drawing.Point(0, 120);
            this.qtyGroup.Name = "qtyGroup";
            this.qtyGroup.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.qtyGroup.Size = new System.Drawing.Size(398, 50);
            this.qtyGroup.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 1);
            this.panel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Quantity:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.itemName);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(398, 70);
            this.panel3.TabIndex = 9;
            // 
            // itemName
            // 
            this.itemName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.Location = new System.Drawing.Point(0, 18);
            this.itemName.Name = "itemName";
            this.itemName.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.itemName.Size = new System.Drawing.Size(398, 51);
            this.itemName.TabIndex = 2;
            this.itemName.Text = "**";
            this.itemName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 69);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(398, 1);
            this.panel4.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Item Details:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(20, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemsTable);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.qtyGroup);
            this.splitContainer1.Panel1.Controls.Add(this.serialGroup);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.addBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.inventoryTable);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this._grandTotalTxt);
            this.splitContainer1.Panel2.Controls.Add(this.stockinBtn);
            this.splitContainer1.Size = new System.Drawing.Size(944, 462);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(0, 170);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(398, 20);
            this.label1.TabIndex = 10;
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(537, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // _grandTotalTxt
            // 
            this._grandTotalTxt.BackColor = System.Drawing.SystemColors.ControlDark;
            this._grandTotalTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._grandTotalTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this._grandTotalTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._grandTotalTxt.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grandTotalTxt.ForeColor = System.Drawing.Color.Black;
            this._grandTotalTxt.Location = new System.Drawing.Point(0, 0);
            this._grandTotalTxt.Name = "_grandTotalTxt";
            this._grandTotalTxt.Size = new System.Drawing.Size(537, 43);
            this._grandTotalTxt.TabIndex = 3;
            this._grandTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchControl);
            this.panel5.Controls.Add(this.createItemBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(944, 42);
            this.panel5.TabIndex = 1;
            // 
            // _messageLabel
            // 
            this._messageLabel.AutoSize = true;
            this._messageLabel.ForeColor = System.Drawing.Color.Maroon;
            this._messageLabel.Location = new System.Drawing.Point(18, 4);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(0, 13);
            this._messageLabel.TabIndex = 2;
            // 
            // StockinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 544);
            this.Controls.Add(this._messageLabel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "StockinForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock In";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StockInForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockinForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.serialGroup.ResumeLayout(false);
            this.serialGroup.PerformLayout();
            this.qtyGroup.ResumeLayout(false);
            this.qtyGroup.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button stockinBtn;
        private System.Windows.Forms.DataGridView inventoryTable;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.TextBox serialNumber;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button createItemBtn;
        private UserControls.SearchControl searchControl;
        private System.Windows.Forms.Panel serialGroup;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel qtyGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _grandTotalTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_serialReq;
        private System.Windows.Forms.Label itemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Total;
        private System.Windows.Forms.DataGridViewButtonColumn col_remove;
    }
}