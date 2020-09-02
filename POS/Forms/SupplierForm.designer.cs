namespace POS.Forms
{
    partial class SupplierForm
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
            this.supplierTable = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.addSuppBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contactDetails = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierTable
            // 
            this.supplierTable.AllowUserToAddRows = false;
            this.supplierTable.AllowUserToDeleteRows = false;
            this.supplierTable.AllowUserToResizeColumns = false;
            this.supplierTable.AllowUserToResizeRows = false;
            this.supplierTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierTable.BackgroundColor = System.Drawing.Color.White;
            this.supplierTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.supplierTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.supplierTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.supplierTable.EnableHeadersVisualStyles = false;
            this.supplierTable.Location = new System.Drawing.Point(8, 53);
            this.supplierTable.MultiSelect = false;
            this.supplierTable.Name = "supplierTable";
            this.supplierTable.RowHeadersVisible = false;
            this.supplierTable.Size = new System.Drawing.Size(357, 250);
            this.supplierTable.TabIndex = 1;
            this.supplierTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.supplierTable_CellBeginEdit);
            this.supplierTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellContentClick);
            this.supplierTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellEndEdit);
            this.supplierTable.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.supplierTable_UserAddedRow);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Id";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Supplier Name";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Contact Details";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Width = 5;
            // 
            // addSuppBtn
            // 
            this.addSuppBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addSuppBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSuppBtn.Enabled = false;
            this.addSuppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addSuppBtn.Location = new System.Drawing.Point(12, 127);
            this.addSuppBtn.Name = "addSuppBtn";
            this.addSuppBtn.Size = new System.Drawing.Size(355, 23);
            this.addSuppBtn.TabIndex = 2;
            this.addSuppBtn.Text = "Add New Supplier";
            this.addSuppBtn.UseVisualStyleBackColor = false;
            this.addSuppBtn.Click += new System.EventHandler(this.addSuppBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.contactDetails);
            this.groupBox2.Location = new System.Drawing.Point(6, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact Details";
            // 
            // contactDetails
            // 
            this.contactDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contactDetails.Location = new System.Drawing.Point(6, 19);
            this.contactDetails.MaxLength = 50;
            this.contactDetails.Name = "contactDetails";
            this.contactDetails.Size = new System.Drawing.Size(355, 20);
            this.contactDetails.TabIndex = 0;
            this.contactDetails.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.contactDetails.Leave += new System.EventHandler(this.supplierName_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.supplierName);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supplier Name";
            // 
            // supplierName
            // 
            this.supplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierName.Location = new System.Drawing.Point(6, 19);
            this.supplierName.MaxLength = 50;
            this.supplierName.Name = "supplierName";
            this.supplierName.Size = new System.Drawing.Size(355, 20);
            this.supplierName.TabIndex = 0;
            this.supplierName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.supplierName.Leave += new System.EventHandler(this.supplierName_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.searchControl1);
            this.groupBox3.Controls.Add(this.supplierTable);
            this.groupBox3.Location = new System.Drawing.Point(12, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 309);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supplier List";
            // 
            // searchControl1
            // 
            this.searchControl1.Location = new System.Drawing.Point(5, 19);
            this.searchControl1.MaximumSize = new System.Drawing.Size(9999, 28);
            this.searchControl1.MinimumSize = new System.Drawing.Size(0, 28);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.SearchText = "";
            this.searchControl1.Size = new System.Drawing.Size(220, 28);
            this.searchControl1.TabIndex = 0;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addSuppBtn);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(379, 156);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add New Supplier";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 1);
            this.panel1.TabIndex = 2;
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView supplierTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox supplierName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox contactDetails;
        private System.Windows.Forms.Button addSuppBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
    }
}