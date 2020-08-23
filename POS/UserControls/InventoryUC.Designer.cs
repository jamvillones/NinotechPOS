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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sellBtn = new System.Windows.Forms.Button();
            this.inventoryTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.inventoryPage = new System.Windows.Forms.TabPage();
            this.searchBtn = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.TextBox();
            this.stockinBtn = new System.Windows.Forms.Button();
            this.itemsPage = new System.Windows.Forms.TabPage();
            this.addVariationsBtn = new System.Windows.Forms.Button();
            this.editItemBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).BeginInit();
            this.tabControl.SuspendLayout();
            this.inventoryPage.SuspendLayout();
            this.itemsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // sellBtn
            // 
            this.sellBtn.BackColor = System.Drawing.SystemColors.Control;
            this.sellBtn.FlatAppearance.BorderSize = 0;
            this.sellBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sellBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellBtn.Image = ((System.Drawing.Image)(resources.GetObject("sellBtn.Image")));
            this.sellBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sellBtn.Location = new System.Drawing.Point(8, 8);
            this.sellBtn.Margin = new System.Windows.Forms.Padding(5);
            this.sellBtn.Name = "sellBtn";
            this.sellBtn.Size = new System.Drawing.Size(95, 33);
            this.sellBtn.TabIndex = 1;
            this.sellBtn.Text = "SELL ITEMS";
            this.sellBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sellBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.sellBtn.UseVisualStyleBackColor = false;
            this.sellBtn.Click += new System.EventHandler(this.firstBtn_Click);
            // 
            // inventoryTable
            // 
            this.inventoryTable.AllowUserToAddRows = false;
            this.inventoryTable.AllowUserToDeleteRows = false;
            this.inventoryTable.AllowUserToResizeColumns = false;
            this.inventoryTable.AllowUserToResizeRows = false;
            this.inventoryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryTable.BackgroundColor = System.Drawing.Color.White;
            this.inventoryTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inventoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inventoryTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.inventoryTable.EnableHeadersVisualStyles = false;
            this.inventoryTable.GridColor = System.Drawing.Color.White;
            this.inventoryTable.Location = new System.Drawing.Point(8, 63);
            this.inventoryTable.MultiSelect = false;
            this.inventoryTable.Name = "inventoryTable";
            this.inventoryTable.ReadOnly = true;
            this.inventoryTable.RowHeadersVisible = false;
            this.inventoryTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.inventoryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.inventoryTable.Size = new System.Drawing.Size(729, 337);
            this.inventoryTable.StandardTab = true;
            this.inventoryTable.TabIndex = 0;
            this.inventoryTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "BARCODE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 84;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "NAME";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "SELLING PRICE";
            this.Column3.MinimumWidth = 150;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "QUANTITY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "TOTAL PRICE";
            this.Column4.MinimumWidth = 150;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.inventoryPage);
            this.tabControl.Controls.Add(this.itemsPage);
            this.tabControl.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(18, 74);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(751, 433);
            this.tabControl.TabIndex = 3;
            // 
            // inventoryPage
            // 
            this.inventoryPage.Controls.Add(this.stockinBtn);
            this.inventoryPage.Controls.Add(this.inventoryTable);
            this.inventoryPage.Controls.Add(this.sellBtn);
            this.inventoryPage.Location = new System.Drawing.Point(4, 23);
            this.inventoryPage.Name = "inventoryPage";
            this.inventoryPage.Padding = new System.Windows.Forms.Padding(3);
            this.inventoryPage.Size = new System.Drawing.Size(743, 406);
            this.inventoryPage.TabIndex = 0;
            this.inventoryPage.Text = "INVENTORY";
            this.inventoryPage.UseVisualStyleBackColor = true;
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.Location = new System.Drawing.Point(732, 59);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(33, 26);
            this.searchBtn.TabIndex = 5;
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // search
            // 
            this.search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.Location = new System.Drawing.Point(441, 59);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(291, 26);
            this.search.TabIndex = 4;
            this.search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_KeyDown);
            // 
            // stockinBtn
            // 
            this.stockinBtn.BackColor = System.Drawing.SystemColors.Control;
            this.stockinBtn.FlatAppearance.BorderSize = 0;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stockinBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockinBtn.Image = ((System.Drawing.Image)(resources.GetObject("stockinBtn.Image")));
            this.stockinBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stockinBtn.Location = new System.Drawing.Point(113, 8);
            this.stockinBtn.Margin = new System.Windows.Forms.Padding(5);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Size = new System.Drawing.Size(95, 33);
            this.stockinBtn.TabIndex = 3;
            this.stockinBtn.Text = "STOCK IN";
            this.stockinBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stockinBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stockinBtn.UseVisualStyleBackColor = false;
            this.stockinBtn.Click += new System.EventHandler(this.secondBtn_Click);
            // 
            // itemsPage
            // 
            this.itemsPage.Controls.Add(this.addVariationsBtn);
            this.itemsPage.Controls.Add(this.editItemBtn);
            this.itemsPage.Controls.Add(this.addItemBtn);
            this.itemsPage.Controls.Add(this.itemsTable);
            this.itemsPage.Location = new System.Drawing.Point(4, 23);
            this.itemsPage.Name = "itemsPage";
            this.itemsPage.Padding = new System.Windows.Forms.Padding(3);
            this.itemsPage.Size = new System.Drawing.Size(743, 406);
            this.itemsPage.TabIndex = 1;
            this.itemsPage.Text = "ITEMS";
            this.itemsPage.UseVisualStyleBackColor = true;
            // 
            // addVariationsBtn
            // 
            this.addVariationsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addVariationsBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addVariationsBtn.FlatAppearance.BorderSize = 0;
            this.addVariationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addVariationsBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addVariationsBtn.Image = ((System.Drawing.Image)(resources.GetObject("addVariationsBtn.Image")));
            this.addVariationsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addVariationsBtn.Location = new System.Drawing.Point(585, 8);
            this.addVariationsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addVariationsBtn.Name = "addVariationsBtn";
            this.addVariationsBtn.Size = new System.Drawing.Size(150, 33);
            this.addVariationsBtn.TabIndex = 9;
            this.addVariationsBtn.Text = "ADD ITEM VARIATION";
            this.addVariationsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addVariationsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addVariationsBtn.UseVisualStyleBackColor = false;
            this.addVariationsBtn.Click += new System.EventHandler(this.addVariationsBtn_Click);
            // 
            // editItemBtn
            // 
            this.editItemBtn.BackColor = System.Drawing.SystemColors.Control;
            this.editItemBtn.FlatAppearance.BorderSize = 0;
            this.editItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editItemBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("editItemBtn.Image")));
            this.editItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editItemBtn.Location = new System.Drawing.Point(127, 8);
            this.editItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.editItemBtn.Name = "editItemBtn";
            this.editItemBtn.Size = new System.Drawing.Size(109, 33);
            this.editItemBtn.TabIndex = 8;
            this.editItemBtn.Text = "EDIT ITEM";
            this.editItemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editItemBtn.UseVisualStyleBackColor = false;
            this.editItemBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.BackColor = System.Drawing.SystemColors.Control;
            this.addItemBtn.FlatAppearance.BorderSize = 0;
            this.addItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addItemBtn.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("addItemBtn.Image")));
            this.addItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addItemBtn.Location = new System.Drawing.Point(8, 8);
            this.addItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(109, 33);
            this.addItemBtn.TabIndex = 7;
            this.addItemBtn.Text = "CREATE ITEM";
            this.addItemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addItemBtn.UseVisualStyleBackColor = false;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToDeleteRows = false;
            this.itemsTable.AllowUserToResizeColumns = false;
            this.itemsTable.AllowUserToResizeRows = false;
            this.itemsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column6,
            this.Column8,
            this.Column7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.Location = new System.Drawing.Point(8, 63);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(729, 337);
            this.itemsTable.StandardTab = true;
            this.itemsTable.TabIndex = 6;
            this.itemsTable.TabStop = false;
            this.itemsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "BARCODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 84;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.HeaderText = "PRICE";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 64;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "DEPARTMENT";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 108;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Type";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 56;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "DETAILS";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "PRODUCTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.tabControl);
            this.Name = "InventoryUC";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.Size = new System.Drawing.Size(787, 525);
            ((System.ComponentModel.ISupportInitialize)(this.inventoryTable)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.inventoryPage.ResumeLayout(false);
            this.itemsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Button sellBtn;
        protected System.Windows.Forms.DataGridView inventoryTable;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage inventoryPage;
        private System.Windows.Forms.TabPage itemsPage;
        protected System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        protected System.Windows.Forms.Button stockinBtn;
        protected System.Windows.Forms.Button addItemBtn;
        protected System.Windows.Forms.Button editItemBtn;
        protected System.Windows.Forms.Button addVariationsBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox search;
    }
}
