namespace POS.Forms
{
    partial class CreateCustomerProfile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateCustomerProfile));
            this.saveBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customerTable = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.transactCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchControl = new POS.UserControls.SearchControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.Location = new System.Drawing.Point(330, 102);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "ADD CUSTOMER";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.Control;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Dock = System.Windows.Forms.DockStyle.Top;
            this.name.Location = new System.Drawing.Point(5, 16);
            this.name.MaxLength = 50;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(582, 13);
            this.name.TabIndex = 0;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.searchControl);
            this.groupBox1.Controls.Add(this.customerTable);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 499);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List of Customers";
            // 
            // customerTable
            // 
            this.customerTable.AllowUserToAddRows = false;
            this.customerTable.AllowUserToDeleteRows = false;
            this.customerTable.AllowUserToResizeRows = false;
            this.customerTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerTable.BackgroundColor = System.Drawing.Color.White;
            this.customerTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.customerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column1,
            this.delCol,
            this.transactCol});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerTable.DefaultCellStyle = dataGridViewCellStyle9;
            this.customerTable.EnableHeadersVisualStyles = false;
            this.customerTable.Location = new System.Drawing.Point(6, 53);
            this.customerTable.MultiSelect = false;
            this.customerTable.Name = "customerTable";
            this.customerTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.customerTable.RowHeadersVisible = false;
            this.customerTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerTable.Size = new System.Drawing.Size(848, 440);
            this.customerTable.StandardTab = true;
            this.customerTable.TabIndex = 1;
            this.customerTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.customerTable_CellBeginEdit);
            this.customerTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerTable_CellContentClick);
            this.customerTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerTable_CellEndEdit);
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Id";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 22;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "NAME";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ADDRESS";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "CONTACT";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            // 
            // delCol
            // 
            this.delCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delCol.HeaderText = "";
            this.delCol.Name = "delCol";
            this.delCol.Width = 5;
            // 
            // transactCol
            // 
            this.transactCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.transactCol.HeaderText = "";
            this.transactCol.Name = "transactCol";
            this.transactCol.Width = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.panel6);
            this.groupBox5.Controls.Add(this.panel4);
            this.groupBox5.Controls.Add(this.panel2);
            this.groupBox5.Controls.Add(this.saveBtn);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(860, 132);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Register Customer";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.name);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(592, 35);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 1);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.address);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(6, 60);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel4.Size = new System.Drawing.Size(848, 35);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(5, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(838, 1);
            this.panel5.TabIndex = 1;
            // 
            // address
            // 
            this.address.BackColor = System.Drawing.SystemColors.Control;
            this.address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address.Dock = System.Windows.Forms.DockStyle.Top;
            this.address.Location = new System.Drawing.Point(5, 16);
            this.address.MaxLength = 50;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(838, 13);
            this.address.TabIndex = 0;
            this.address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Address:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.contact);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(604, 19);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel6.Size = new System.Drawing.Size(250, 35);
            this.panel6.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(5, 31);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(240, 1);
            this.panel7.TabIndex = 1;
            // 
            // contact
            // 
            this.contact.BackColor = System.Drawing.SystemColors.Control;
            this.contact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contact.Dock = System.Windows.Forms.DockStyle.Top;
            this.contact.Location = new System.Drawing.Point(5, 16);
            this.contact.MaxLength = 50;
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(240, 13);
            this.contact.TabIndex = 0;
            this.contact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact Info:";
            // 
            // searchControl
            // 
            this.searchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl.BackColor = System.Drawing.Color.White;
            this.searchControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl.Location = new System.Drawing.Point(6, 18);
            this.searchControl.MaximumSize = new System.Drawing.Size(9999, 28);
            this.searchControl.MinimumSize = new System.Drawing.Size(2, 28);
            this.searchControl.Name = "searchControl";
            this.searchControl.SearchedText = "";
            this.searchControl.Size = new System.Drawing.Size(270, 28);
            this.searchControl.TabIndex = 0;
            this.searchControl.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl_OnSearch);
            this.searchControl.OnTextEmpty += new System.EventHandler(this.searchControl_OnTextEmpty);
            // 
            // CreateCustomerProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateCustomerProfile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Customer Profile";
            this.Load += new System.EventHandler(this.CreateCustomerProfile_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.DataGridView customerTable;
        private System.Windows.Forms.GroupBox groupBox5;
        private UserControls.SearchControl searchControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn delCol;
        private System.Windows.Forms.DataGridViewButtonColumn transactCol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label2;
    }
}