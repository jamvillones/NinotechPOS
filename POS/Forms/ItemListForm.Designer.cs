namespace POS.Forms
{
    partial class ItemListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemListForm));
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToDeleteRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.itemsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.itemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Id,
            this.barcodeCol,
            this.nameCol,
            this.quantityCol,
            this.priceCol,
            this.typeCol});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle6;
            this.itemsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.itemsTable.Location = new System.Drawing.Point(20, 78);
            this.itemsTable.Margin = new System.Windows.Forms.Padding(2);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(760, 352);
            this.itemsTable.TabIndex = 1;
            this.itemsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDoubleClick);
            this.itemsTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemsTable_KeyDown);
            // 
            // col_Id
            // 
            this.col_Id.HeaderText = "ID";
            this.col_Id.Name = "col_Id";
            this.col_Id.ReadOnly = true;
            this.col_Id.Visible = false;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = "---";
            this.quantityCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantityCol.HeaderText = "QUANTITY";
            this.quantityCol.MinimumWidth = 50;
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.ReadOnly = true;
            // 
            // priceCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.priceCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.priceCol.HeaderText = "PRICE";
            this.priceCol.MinimumWidth = 50;
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // typeCol
            // 
            this.typeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.typeCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.typeCol.HeaderText = "TYPE";
            this.typeCol.Name = "typeCol";
            this.typeCol.ReadOnly = true;
            // 
            // searchControl1
            // 
            this.searchControl1.BackColor = System.Drawing.SystemColors.Window;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl1.Location = new System.Drawing.Point(20, 20);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 60);
            this.searchControl1.MinimumSize = new System.Drawing.Size(200, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 0;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl_OnTextEmpty);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(454, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "**Double click item to select its barcode. If the barcode is empty, name will be " +
    "selected instead.";
            // 
            // ItemListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.itemsTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ItemListForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Chooose Item";
            this.Load += new System.EventHandler(this.ItemListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView itemsTable;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeCol;
        private System.Windows.Forms.Label label1;
    }
}