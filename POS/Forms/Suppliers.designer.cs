namespace POS.Forms
{
    partial class Suppliers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Suppliers));
            this.supplierTable = new System.Windows.Forms.DataGridView();
            this.id_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_suppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.recHistBtn = new System.Windows.Forms.Button();
            this.searchControl1 = new POS.UserControls.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierTable
            // 
            this.supplierTable.AllowUserToAddRows = false;
            this.supplierTable.AllowUserToDeleteRows = false;
            this.supplierTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.supplierTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.supplierTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supplierTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.supplierTable.BackgroundColor = System.Drawing.Color.White;
            this.supplierTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.supplierTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.supplierTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.supplierTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_col,
            this.col_suppName,
            this.col_contact,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.supplierTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.supplierTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supplierTable.EnableHeadersVisualStyles = false;
            this.supplierTable.GridColor = System.Drawing.Color.LightGray;
            this.supplierTable.Location = new System.Drawing.Point(20, 75);
            this.supplierTable.MultiSelect = false;
            this.supplierTable.Name = "supplierTable";
            this.supplierTable.RowHeadersVisible = false;
            this.supplierTable.Size = new System.Drawing.Size(944, 456);
            this.supplierTable.StandardTab = true;
            this.supplierTable.TabIndex = 1;
            this.supplierTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.supplierTable_CellBeginEdit);
            this.supplierTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellContentClick);
            this.supplierTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellEndEdit);
            // 
            // id_col
            // 
            this.id_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.id_col.DefaultCellStyle = dataGridViewCellStyle3;
            this.id_col.HeaderText = "Id";
            this.id_col.Name = "id_col";
            this.id_col.Visible = false;
            this.id_col.Width = 31;
            // 
            // col_suppName
            // 
            this.col_suppName.HeaderText = "SUPPLIER NAME";
            this.col_suppName.Name = "col_suppName";
            // 
            // col_contact
            // 
            this.col_contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_contact.HeaderText = "CONTACT DETAILS";
            this.col_contact.MinimumWidth = 100;
            this.col_contact.Name = "col_contact";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Width = 12;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 20);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(20, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 20);
            this.panel2.TabIndex = 3;
            // 
            // recHistBtn
            // 
            this.recHistBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.recHistBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.recHistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recHistBtn.Location = new System.Drawing.Point(20, 551);
            this.recHistBtn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.recHistBtn.MaximumSize = new System.Drawing.Size(150, 35);
            this.recHistBtn.MinimumSize = new System.Drawing.Size(150, 40);
            this.recHistBtn.Name = "recHistBtn";
            this.recHistBtn.Size = new System.Drawing.Size(150, 40);
            this.recHistBtn.TabIndex = 18;
            this.recHistBtn.Text = "Add Supplier";
            this.recHistBtn.UseVisualStyleBackColor = false;
            this.recHistBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl1.BackColor = System.Drawing.Color.White;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl1.Location = new System.Drawing.Point(20, 20);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.MinimumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 0;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.supplierTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.recHistBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Suppliers";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView supplierTable;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button recHistBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_suppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_contact;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}