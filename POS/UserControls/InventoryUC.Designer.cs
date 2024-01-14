namespace POS.UserControls
{
    partial class InventoryUC
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryUC));
            this.tablePanel = new System.Windows.Forms.Panel();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.barcodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.viewStockBtn = new System.Windows.Forms.Button();
            this.stockinBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.editItemBtn = new System.Windows.Forms.Button();
            this.addVariationsBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.totalPriceTxt = new System.Windows.Forms.Label();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.loadingLabelItem = new System.Windows.Forms.Label();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.contentPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.itemsTable);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(151, 0);
            this.tablePanel.Margin = new System.Windows.Forms.Padding(5);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(621, 440);
            this.tablePanel.TabIndex = 13;
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            this.itemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeCol,
            this.nameCol,
            this.quantityCol,
            this.priceCol,
            this.typeCol,
            this.Column1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.itemsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.itemsTable.Location = new System.Drawing.Point(0, 0);
            this.itemsTable.Margin = new System.Windows.Forms.Padding(2);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(621, 440);
            this.itemsTable.TabIndex = 6;
            this.itemsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellContentClick);
            this.itemsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDoubleClick);
            this.itemsTable.SelectionChanged += new System.EventHandler(this.itemsTable_SelectionChanged);
            this.itemsTable.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.itemsTable_UserDeletingRow);
            this.itemsTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemsTable_KeyDown);
            // 
            // barcodeCol
            // 
            this.barcodeCol.HeaderText = "BARCODE";
            this.barcodeCol.MinimumWidth = 50;
            this.barcodeCol.Name = "barcodeCol";
            this.barcodeCol.ReadOnly = true;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "NAME";
            this.nameCol.MinimumWidth = 100;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // quantityCol
            // 
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "Infinite";
            this.quantityCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.quantityCol.HeaderText = "QUANTITY";
            this.quantityCol.MinimumWidth = 50;
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.ReadOnly = true;
            // 
            // priceCol
            // 
            this.priceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Format = "C2";
            this.priceCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.priceCol.HeaderText = "PRICE";
            this.priceCol.MinimumWidth = 50;
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // typeCol
            // 
            this.typeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.typeCol.HeaderText = "TYPE";
            this.typeCol.Name = "typeCol";
            this.typeCol.ReadOnly = true;
            this.typeCol.Width = 68;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Critical Qty";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(150, 40);
            this.button1.TabIndex = 12;
            this.button1.TabStop = false;
            this.button1.Text = "     Sell Item";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.sellItem_Click);
            // 
            // viewStockBtn
            // 
            this.viewStockBtn.BackColor = System.Drawing.Color.White;
            this.viewStockBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewStockBtn.FlatAppearance.BorderSize = 0;
            this.viewStockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewStockBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewStockBtn.Image")));
            this.viewStockBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewStockBtn.Location = new System.Drawing.Point(0, 210);
            this.viewStockBtn.Margin = new System.Windows.Forms.Padding(5);
            this.viewStockBtn.Name = "viewStockBtn";
            this.viewStockBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.viewStockBtn.Size = new System.Drawing.Size(150, 40);
            this.viewStockBtn.TabIndex = 15;
            this.viewStockBtn.TabStop = false;
            this.viewStockBtn.Text = "     View Stockins";
            this.viewStockBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewStockBtn.UseVisualStyleBackColor = false;
            this.viewStockBtn.Click += new System.EventHandler(this.viewStockBtn_Click);
            // 
            // stockinBtn
            // 
            this.stockinBtn.BackColor = System.Drawing.Color.White;
            this.stockinBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.stockinBtn.FlatAppearance.BorderSize = 0;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockinBtn.Image = ((System.Drawing.Image)(resources.GetObject("stockinBtn.Image")));
            this.stockinBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stockinBtn.Location = new System.Drawing.Point(0, 40);
            this.stockinBtn.Margin = new System.Windows.Forms.Padding(5);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.stockinBtn.Size = new System.Drawing.Size(150, 40);
            this.stockinBtn.TabIndex = 13;
            this.stockinBtn.TabStop = false;
            this.stockinBtn.Text = "     Stock In";
            this.stockinBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stockinBtn.UseVisualStyleBackColor = false;
            this.stockinBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.BackColor = System.Drawing.Color.White;
            this.addItemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addItemBtn.FlatAppearance.BorderSize = 0;
            this.addItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("addItemBtn.Image")));
            this.addItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addItemBtn.Location = new System.Drawing.Point(0, 80);
            this.addItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addItemBtn.Size = new System.Drawing.Size(150, 40);
            this.addItemBtn.TabIndex = 8;
            this.addItemBtn.TabStop = false;
            this.addItemBtn.Text = "     Add Item";
            this.addItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addItemBtn.UseVisualStyleBackColor = false;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // editItemBtn
            // 
            this.editItemBtn.BackColor = System.Drawing.Color.White;
            this.editItemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.editItemBtn.FlatAppearance.BorderSize = 0;
            this.editItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("editItemBtn.Image")));
            this.editItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editItemBtn.Location = new System.Drawing.Point(0, 130);
            this.editItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.editItemBtn.Name = "editItemBtn";
            this.editItemBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.editItemBtn.Size = new System.Drawing.Size(150, 40);
            this.editItemBtn.TabIndex = 9;
            this.editItemBtn.TabStop = false;
            this.editItemBtn.Text = "     Edit Item";
            this.editItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editItemBtn.UseVisualStyleBackColor = false;
            this.editItemBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addVariationsBtn
            // 
            this.addVariationsBtn.BackColor = System.Drawing.Color.White;
            this.addVariationsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addVariationsBtn.FlatAppearance.BorderSize = 0;
            this.addVariationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVariationsBtn.Image = ((System.Drawing.Image)(resources.GetObject("addVariationsBtn.Image")));
            this.addVariationsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addVariationsBtn.Location = new System.Drawing.Point(0, 170);
            this.addVariationsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addVariationsBtn.Name = "addVariationsBtn";
            this.addVariationsBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addVariationsBtn.Size = new System.Drawing.Size(150, 40);
            this.addVariationsBtn.TabIndex = 10;
            this.addVariationsBtn.TabStop = false;
            this.addVariationsBtn.Text = "     Item Costs";
            this.addVariationsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addVariationsBtn.UseVisualStyleBackColor = false;
            this.addVariationsBtn.Click += new System.EventHandler(this.addVariationsBtn_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 260);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(150, 40);
            this.button2.TabIndex = 17;
            this.button2.TabStop = false;
            this.button2.Text = "     Refresh";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPanel.Controls.Add(this.tablePanel);
            this.contentPanel.Controls.Add(this.panel3);
            this.contentPanel.Controls.Add(this.panel6);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 83);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(774, 442);
            this.contentPanel.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(150, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 440);
            this.panel3.TabIndex = 14;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.viewStockBtn);
            this.panel6.Controls.Add(this.addVariationsBtn);
            this.panel6.Controls.Add(this.editItemBtn);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.addItemBtn);
            this.panel6.Controls.Add(this.stockinBtn);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(150, 440);
            this.panel6.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 10);
            this.panel1.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(15, 5);
            this.panel7.Margin = new System.Windows.Forms.Padding(5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(120, 1);
            this.panel7.TabIndex = 12;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(150, 10);
            this.panel8.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(15, 5);
            this.panel9.Margin = new System.Windows.Forms.Padding(5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(120, 1);
            this.panel9.TabIndex = 12;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(774, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Include Emtpy In Search Results";
            this.toolTip1.SetToolTip(this.checkBox1, "Search should include empty");
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.totalPriceTxt);
            this.flowLayoutPanel1.Controls.Add(this.loadingLabelItem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(774, 31);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // totalPriceTxt
            // 
            this.totalPriceTxt.AutoSize = true;
            this.totalPriceTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalPriceTxt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceTxt.ForeColor = System.Drawing.Color.Black;
            this.totalPriceTxt.Location = new System.Drawing.Point(726, 10);
            this.totalPriceTxt.Name = "totalPriceTxt";
            this.totalPriceTxt.Size = new System.Drawing.Size(45, 16);
            this.totalPriceTxt.TabIndex = 14;
            this.totalPriceTxt.Text = "₱ 0.00";
            this.totalPriceTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchControl1
            // 
            this.searchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl1.BackColor = System.Drawing.Color.White;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl1.Location = new System.Drawing.Point(0, 17);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.MinimumSize = new System.Drawing.Size(219, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 13;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // loadingLabelItem
            // 
            this.loadingLabelItem.AutoSize = true;
            this.loadingLabelItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabelItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.loadingLabelItem.Location = new System.Drawing.Point(656, 10);
            this.loadingLabelItem.Name = "loadingLabelItem";
            this.loadingLabelItem.Size = new System.Drawing.Size(64, 16);
            this.loadingLabelItem.TabIndex = 19;
            this.loadingLabelItem.Text = "Loading...";
            this.loadingLabelItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.checkBox1);
            this.Name = "InventoryUC";
            this.Size = new System.Drawing.Size(774, 525);
            this.Load += new System.EventHandler(this.InventoryUC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InventoryUC_KeyDown);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.contentPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.Panel tablePanel;
        protected System.Windows.Forms.Button addItemBtn;
        protected System.Windows.Forms.Button editItemBtn;
        protected System.Windows.Forms.Button addVariationsBtn;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Button stockinBtn;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Button viewStockBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        protected System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private SearchControl searchControl1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label totalPriceTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Label loadingLabelItem;
    }
}
