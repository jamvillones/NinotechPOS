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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockinForm));
            this.stockinBtn = new System.Windows.Forms.Button();
            this.inventoryTable = new System.Windows.Forms.DataGridView();
            this.col_Inventory_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Inventory_Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createItemBtn = new System.Windows.Forms.Button();
            this.serialNumber = new System.Windows.Forms.TextBox();
            this.itemName = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.addBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this._grandTotalTxt = new System.Windows.Forms.Label();
            this._messageLabel = new System.Windows.Forms.Label();
            this.searchControl = new POS.UserControls.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.stockinBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.stockinBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stockinBtn.Location = new System.Drawing.Point(0, 407);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Size = new System.Drawing.Size(425, 35);
            this.stockinBtn.TabIndex = 4;
            this.stockinBtn.TabStop = false;
            this.stockinBtn.Text = "Stock In [ Ctrl+Enter ]";
            this.toolTip.SetToolTip(this.stockinBtn, "(ctrl+Enter) to stock in");
            this.stockinBtn.UseVisualStyleBackColor = false;
            this.stockinBtn.Click += new System.EventHandler(this.stockinBtn_Click);
            // 
            // inventoryTable
            // 
            this.inventoryTable.AllowUserToAddRows = false;
            this.inventoryTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.inventoryTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.inventoryTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.inventoryTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.inventoryTable.BackgroundColor = System.Drawing.Color.White;
            this.inventoryTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventoryTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.inventoryTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.inventoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Inventory_Id,
            this.col_Inventory_Barcode,
            this.col_Inventory_Serial,
            this.col_Inventory_Name,
            this.col_Inventory_Qty,
            this.col_Inventory_Cost,
            this.col_Inventory_Total,
            this.col_Inventory_Supplier,
            this.col_remove});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.inventoryTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTable.EnableHeadersVisualStyles = false;
            this.inventoryTable.Location = new System.Drawing.Point(0, 40);
            this.inventoryTable.MultiSelect = false;
            this.inventoryTable.Name = "inventoryTable";
            this.inventoryTable.ReadOnly = true;
            this.inventoryTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.inventoryTable.RowHeadersVisible = false;
            this.inventoryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryTable.Size = new System.Drawing.Size(425, 367);
            this.inventoryTable.StandardTab = true;
            this.inventoryTable.TabIndex = 4;
            this.inventoryTable.TabStop = false;
            this.inventoryTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.inventoryTable_CellMouseDoubleClick);
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
            // col_Inventory_Qty
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.col_Inventory_Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Inventory_Qty.HeaderText = "QTY";
            this.col_Inventory_Qty.Name = "col_Inventory_Qty";
            this.col_Inventory_Qty.ReadOnly = true;
            // 
            // col_Inventory_Cost
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Inventory_Cost.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Inventory_Cost.HeaderText = "COST";
            this.col_Inventory_Cost.Name = "col_Inventory_Cost";
            this.col_Inventory_Cost.ReadOnly = true;
            // 
            // col_Inventory_Total
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_Inventory_Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Inventory_Total.HeaderText = "TOTAL";
            this.col_Inventory_Total.Name = "col_Inventory_Total";
            this.col_Inventory_Total.ReadOnly = true;
            // 
            // col_Inventory_Supplier
            // 
            this.col_Inventory_Supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Inventory_Supplier.HeaderText = "SUPPLIER";
            this.col_Inventory_Supplier.Name = "col_Inventory_Supplier";
            this.col_Inventory_Supplier.ReadOnly = true;
            // 
            // col_remove
            // 
            this.col_remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_remove.HeaderText = "";
            this.col_remove.Name = "col_remove";
            this.col_remove.ReadOnly = true;
            this.col_remove.Text = "Remove";
            this.col_remove.UseColumnTextForButtonValue = true;
            this.col_remove.Width = 12;
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
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
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
            this.col_cost,
            this.col_supplier});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle10;
            this.itemsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.Location = new System.Drawing.Point(0, 155);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(495, 252);
            this.itemsTable.StandardTab = true;
            this.itemsTable.TabIndex = 6;
            this.itemsTable.TabStop = false;
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
            // col_cost
            // 
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.col_cost.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_cost.HeaderText = "COST";
            this.col_cost.Name = "col_cost";
            this.col_cost.ReadOnly = true;
            // 
            // col_supplier
            // 
            this.col_supplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_supplier.HeaderText = "SUPPLIER";
            this.col_supplier.Name = "col_supplier";
            this.col_supplier.ReadOnly = true;
            // 
            // createItemBtn
            // 
            this.createItemBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.createItemBtn.FlatAppearance.BorderSize = 0;
            this.createItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createItemBtn.Location = new System.Drawing.Point(356, 0);
            this.createItemBtn.Name = "createItemBtn";
            this.createItemBtn.Size = new System.Drawing.Size(140, 35);
            this.createItemBtn.TabIndex = 1;
            this.createItemBtn.TabStop = false;
            this.createItemBtn.Text = "Create Item";
            this.createItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.createItemBtn, "Create Item");
            this.createItemBtn.UseVisualStyleBackColor = false;
            this.createItemBtn.Click += new System.EventHandler(this.createItemBtn_Click);
            // 
            // serialNumber
            // 
            this.serialNumber.BackColor = System.Drawing.SystemColors.Control;
            this.serialNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.serialNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber.Location = new System.Drawing.Point(0, 18);
            this.serialNumber.MaxLength = 50;
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(495, 14);
            this.serialNumber.TabIndex = 0;
            this.serialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.serialNumber, "(f2) to focus serial number");
            this.serialNumber.TextChanged += new System.EventHandler(this.serialNumber_TextChanged);
            this.serialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialNumber_KeyDown);
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.SystemColors.Control;
            this.itemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemName.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.ForeColor = System.Drawing.Color.Blue;
            this.itemName.Location = new System.Drawing.Point(0, 18);
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Size = new System.Drawing.Size(495, 13);
            this.itemName.TabIndex = 0;
            this.itemName.TabStop = false;
            this.itemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // quantity
            // 
            this.quantity.BackColor = System.Drawing.SystemColors.Control;
            this.quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(0, 18);
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
            this.quantity.Size = new System.Drawing.Size(495, 17);
            this.quantity.TabIndex = 0;
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.quantity, "(f3) to focus quantity");
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Location = new System.Drawing.Point(0, 407);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(495, 35);
            this.addBtn.TabIndex = 3;
            this.addBtn.TabStop = false;
            this.addBtn.Text = "ADD (SHIFT+ENTER)";
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
            // panel6
            // 
            this.panel6.Controls.Add(this.serialNumber);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 45);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel6.Size = new System.Drawing.Size(495, 45);
            this.panel6.TabIndex = 7;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(495, 1);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.quantity);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 90);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel1.Size = new System.Drawing.Size(495, 45);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(495, 1);
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
            this.panel3.Controls.Add(this.itemName);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.panel3.Size = new System.Drawing.Size(495, 45);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(495, 1);
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
            this.splitContainer1.Location = new System.Drawing.Point(20, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.itemsTable);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.panel6);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.addBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.inventoryTable);
            this.splitContainer1.Panel2.Controls.Add(this._grandTotalTxt);
            this.splitContainer1.Panel2.Controls.Add(this.stockinBtn);
            this.splitContainer1.Size = new System.Drawing.Size(944, 444);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(0, 135);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(495, 20);
            this.label1.TabIndex = 10;
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this._messageLabel);
            this.panel5.Controls.Add(this.searchControl);
            this.panel5.Controls.Add(this.createItemBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(944, 60);
            this.panel5.TabIndex = 4;
            // 
            // _grandTotalTxt
            // 
            this._grandTotalTxt.BackColor = System.Drawing.SystemColors.ControlDark;
            this._grandTotalTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this._grandTotalTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._grandTotalTxt.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grandTotalTxt.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this._grandTotalTxt.Location = new System.Drawing.Point(0, 0);
            this._grandTotalTxt.Name = "_grandTotalTxt";
            this._grandTotalTxt.Size = new System.Drawing.Size(425, 40);
            this._grandTotalTxt.TabIndex = 3;
            this._grandTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _messageLabel
            // 
            this._messageLabel.AutoSize = true;
            this._messageLabel.ForeColor = System.Drawing.Color.Maroon;
            this._messageLabel.Location = new System.Drawing.Point(0, 38);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(0, 13);
            this._messageLabel.TabIndex = 2;
            // 
            // searchControl
            // 
            this.searchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl.BackColor = System.Drawing.Color.White;
            this.searchControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl.Location = new System.Drawing.Point(0, 0);
            this.searchControl.MaximumSize = new System.Drawing.Size(350, 35);
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
            // StockinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 544);
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
            this.Load += new System.EventHandler(this.StockinForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockinForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button stockinBtn;
        private System.Windows.Forms.DataGridView inventoryTable;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.TextBox serialNumber;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button createItemBtn;
        private UserControls.SearchControl searchControl;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_supplier;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Inventory_Supplier;
        private System.Windows.Forms.DataGridViewButtonColumn col_remove;
        private System.Windows.Forms.Label _grandTotalTxt;
    }
}