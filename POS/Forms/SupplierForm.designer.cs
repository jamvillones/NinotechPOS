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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierForm));
            this.supplierTable = new System.Windows.Forms.DataGridView();
            this.addSuppBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contactDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.supplierName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.searchControl1 = new POS.UserControls.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierTable
            // 
            this.supplierTable.AllowUserToAddRows = false;
            this.supplierTable.AllowUserToDeleteRows = false;
            this.supplierTable.AllowUserToResizeRows = false;
            this.supplierTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierTable.BackgroundColor = System.Drawing.Color.White;
            this.supplierTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
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
            this.supplierTable.Location = new System.Drawing.Point(6, 53);
            this.supplierTable.MultiSelect = false;
            this.supplierTable.Name = "supplierTable";
            this.supplierTable.RowHeadersVisible = false;
            this.supplierTable.Size = new System.Drawing.Size(649, 537);
            this.supplierTable.StandardTab = true;
            this.supplierTable.TabIndex = 1;
            this.supplierTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.supplierTable_CellBeginEdit);
            this.supplierTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellContentClick);
            this.supplierTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplierTable_CellEndEdit);
            // 
            // addSuppBtn
            // 
            this.addSuppBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addSuppBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSuppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addSuppBtn.Location = new System.Drawing.Point(230, 104);
            this.addSuppBtn.Name = "addSuppBtn";
            this.addSuppBtn.Size = new System.Drawing.Size(200, 23);
            this.addSuppBtn.TabIndex = 2;
            this.addSuppBtn.Text = "ADD SUPPLIER";
            this.addSuppBtn.UseVisualStyleBackColor = false;
            this.addSuppBtn.Click += new System.EventHandler(this.addSuppBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.searchControl1);
            this.groupBox3.Controls.Add(this.supplierTable);
            this.groupBox3.Location = new System.Drawing.Point(12, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 596);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Supplier List";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Controls.Add(this.panel6);
            this.groupBox4.Controls.Add(this.addSuppBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(660, 135);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Add New Supplier";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.contactDetails);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(648, 35);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(638, 1);
            this.panel3.TabIndex = 1;
            // 
            // contactDetails
            // 
            this.contactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.contactDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactDetails.Location = new System.Drawing.Point(5, 16);
            this.contactDetails.MaxLength = 50;
            this.contactDetails.Name = "contactDetails";
            this.contactDetails.Size = new System.Drawing.Size(638, 13);
            this.contactDetails.TabIndex = 0;
            this.contactDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact Details:";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.supplierName);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(6, 19);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel6.Size = new System.Drawing.Size(648, 35);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(5, 31);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(638, 1);
            this.panel7.TabIndex = 1;
            // 
            // supplierName
            // 
            this.supplierName.BackColor = System.Drawing.SystemColors.Control;
            this.supplierName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierName.Dock = System.Windows.Forms.DockStyle.Top;
            this.supplierName.Location = new System.Drawing.Point(5, 16);
            this.supplierName.MaxLength = 50;
            this.supplierName.Name = "supplierName";
            this.supplierName.Size = new System.Drawing.Size(638, 13);
            this.supplierName.TabIndex = 0;
            this.supplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Id";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Supplier Name";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 542;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // searchControl1
            // 
            this.searchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl1.BackColor = System.Drawing.Color.White;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Location = new System.Drawing.Point(6, 19);
            this.searchControl1.MaximumSize = new System.Drawing.Size(9999, 28);
            this.searchControl1.MinimumSize = new System.Drawing.Size(2, 28);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(270, 28);
            this.searchControl1.TabIndex = 0;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // SupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 761);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.SupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.supplierTable)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView supplierTable;
        private System.Windows.Forms.Button addSuppBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox contactDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox supplierName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}