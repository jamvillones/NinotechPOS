namespace POS.Forms
{
    partial class ConsoleSell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleSell));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.index = new System.Windows.Forms.TextBox();
            this.next = new System.Windows.Forms.Button();
            this.prev = new System.Windows.Forms.Button();
            this.itemsHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.cartTable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalPrice = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // index
            // 
            this.index.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.index.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.index.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.index.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.index.Location = new System.Drawing.Point(561, 6);
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(79, 22);
            this.index.TabIndex = 5;
            this.index.Text = "1/1";
            this.index.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.next.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.next.Image = ((System.Drawing.Image)(resources.GetObject("next.Image")));
            this.next.Location = new System.Drawing.Point(685, 3);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(33, 28);
            this.next.TabIndex = 4;
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // prev
            // 
            this.prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.prev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.prev.Image = ((System.Drawing.Image)(resources.GetObject("prev.Image")));
            this.prev.Location = new System.Drawing.Point(646, 3);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(33, 28);
            this.prev.TabIndex = 3;
            this.prev.UseVisualStyleBackColor = false;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // itemsHolder
            // 
            this.itemsHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsHolder.AutoScroll = true;
            this.itemsHolder.BackColor = System.Drawing.Color.Silver;
            this.itemsHolder.Location = new System.Drawing.Point(6, 38);
            this.itemsHolder.Name = "itemsHolder";
            this.itemsHolder.Size = new System.Drawing.Size(712, 515);
            this.itemsHolder.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.cartTable);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 561);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(9, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(441, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "PROCEED";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(9, 67);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(441, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Edit Details";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // cartTable
            // 
            this.cartTable.AllowUserToAddRows = false;
            this.cartTable.AllowUserToResizeColumns = false;
            this.cartTable.AllowUserToResizeRows = false;
            this.cartTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.cartTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cartTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cartTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn1,
            this.Column8,
            this.dataGridViewTextBoxColumn2,
            this.quantityCol,
            this.priceCol,
            this.discountCol,
            this.totalPriceCol,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.cartTable.EnableHeadersVisualStyles = false;
            this.cartTable.GridColor = System.Drawing.Color.White;
            this.cartTable.Location = new System.Drawing.Point(9, 95);
            this.cartTable.MultiSelect = false;
            this.cartTable.Name = "cartTable";
            this.cartTable.ReadOnly = true;
            this.cartTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.cartTable.RowHeadersVisible = false;
            this.cartTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartTable.ShowCellToolTips = false;
            this.cartTable.Size = new System.Drawing.Size(441, 421);
            this.cartTable.StandardTab = true;
            this.cartTable.TabIndex = 16;
            this.cartTable.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.totalPrice);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(441, 58);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // totalPrice
            // 
            this.totalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPrice.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(7, 18);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(428, 37);
            this.totalPrice.TabIndex = 0;
            this.totalPrice.Text = "₱ 0.00";
            this.totalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.itemsHolder);
            this.panel2.Controls.Add(this.index);
            this.panel2.Controls.Add(this.searchControl1);
            this.panel2.Controls.Add(this.next);
            this.panel2.Controls.Add(this.prev);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(461, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 561);
            this.panel2.TabIndex = 5;
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(6, 4);
            this.searchControl1.MaximumSize = new System.Drawing.Size(9999, 28);
            this.searchControl1.MinimumSize = new System.Drawing.Size(0, 28);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.SearchText = "";
            this.searchControl1.Size = new System.Drawing.Size(349, 28);
            this.searchControl1.TabIndex = 2;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 76;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Serial";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 61;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 88;
            // 
            // quantityCol
            // 
            this.quantityCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityCol.HeaderText = "Quantity";
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.ReadOnly = true;
            this.quantityCol.Width = 79;
            // 
            // priceCol
            // 
            this.priceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceCol.HeaderText = "Price";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            this.priceCol.Width = 58;
            // 
            // discountCol
            // 
            this.discountCol.HeaderText = "Discount";
            this.discountCol.Name = "discountCol";
            this.discountCol.ReadOnly = true;
            // 
            // totalPriceCol
            // 
            this.totalPriceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalPriceCol.HeaderText = "Total Price";
            this.totalPriceCol.Name = "totalPriceCol";
            this.totalPriceCol.ReadOnly = true;
            this.totalPriceCol.Width = 88;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Supplier";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // ConsoleSell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsoleSell";
            this.Text = "Console Sell";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConsoleSell_Load);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox index;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button prev;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.FlowLayoutPanel itemsHolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView cartTable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}