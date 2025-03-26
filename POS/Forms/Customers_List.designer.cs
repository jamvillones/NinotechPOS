namespace POS.Forms
{
    partial class Customers_List
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers_List));
            this.customerTable = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.recHistBtn = new System.Windows.Forms.Button();
            this.searchControl = new POS.UserControls.SearchControl();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_transact = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_del = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerTable
            // 
            this.customerTable.AllowUserToAddRows = false;
            this.customerTable.AllowUserToDeleteRows = false;
            this.customerTable.AllowUserToResizeRows = false;
            this.customerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.customerTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.customerTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.customerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_transact,
            this.col_name,
            this.col_contact,
            this.col_address,
            this.col_del});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.customerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerTable.EnableHeadersVisualStyles = false;
            this.customerTable.GridColor = System.Drawing.Color.LightGray;
            this.customerTable.Location = new System.Drawing.Point(20, 75);
            this.customerTable.MultiSelect = false;
            this.customerTable.Name = "customerTable";
            this.customerTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customerTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.customerTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerTable.Size = new System.Drawing.Size(944, 456);
            this.customerTable.StandardTab = true;
            this.customerTable.TabIndex = 1;
            this.customerTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.customerTable_CellBeginEdit);
            this.customerTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerTable_CellContentClick);
            this.customerTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerTable_CellEndEdit);
            this.customerTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.customerTable_CellMouseDoubleClick);
            this.customerTable.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.customerTable_CellValidated);
            this.customerTable.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.customerTable_CellValidating);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loadingLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 20);
            this.panel1.TabIndex = 2;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadingLabel.ForeColor = System.Drawing.Color.Blue;
            this.loadingLabel.Location = new System.Drawing.Point(0, 7);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(0, 13);
            this.loadingLabel.TabIndex = 0;
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
            this.recHistBtn.MaximumSize = new System.Drawing.Size(250, 40);
            this.recHistBtn.MinimumSize = new System.Drawing.Size(150, 35);
            this.recHistBtn.Name = "recHistBtn";
            this.recHistBtn.Size = new System.Drawing.Size(250, 40);
            this.recHistBtn.TabIndex = 17;
            this.recHistBtn.Text = "Add Cutomer";
            this.recHistBtn.UseVisualStyleBackColor = false;
            this.recHistBtn.Click += new System.EventHandler(this.recHistBtn_Click);
            // 
            // searchControl
            // 
            this.searchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl.BackColor = System.Drawing.Color.White;
            this.searchControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl.Location = new System.Drawing.Point(20, 20);
            this.searchControl.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl.MinimumSize = new System.Drawing.Size(2, 35);
            this.searchControl.Name = "searchControl";
            this.searchControl.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl.SearchedText = "";
            this.searchControl.Size = new System.Drawing.Size(350, 35);
            this.searchControl.TabIndex = 0;
            this.searchControl.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl_OnSearch);
            this.searchControl.OnTextEmpty += new System.EventHandler(this.searchControl_OnTextEmpty);
            // 
            // col_id
            // 
            this.col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            this.col_id.Width = 50;
            // 
            // col_transact
            // 
            this.col_transact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            this.col_transact.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_transact.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.col_transact.HeaderText = "";
            this.col_transact.Name = "col_transact";
            this.col_transact.Text = "TRANSACTIONS";
            this.col_transact.UseColumnTextForButtonValue = true;
            this.col_transact.Width = 12;
            // 
            // col_name
            // 
            dataGridViewCellStyle3.NullValue = "N/A";
            this.col_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_name.HeaderText = "NAME";
            this.col_name.Name = "col_name";
            // 
            // col_contact
            // 
            this.col_contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.NullValue = "N/A";
            this.col_contact.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_contact.HeaderText = "CONTACT DETAILS";
            this.col_contact.Name = "col_contact";
            // 
            // col_address
            // 
            dataGridViewCellStyle5.NullValue = "N/A";
            this.col_address.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_address.HeaderText = "ADDRESS";
            this.col_address.Name = "col_address";
            // 
            // col_del
            // 
            this.col_del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(1);
            this.col_del.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_del.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.col_del.HeaderText = "";
            this.col_del.Name = "col_del";
            this.col_del.Text = "REMOVE";
            this.col_del.UseColumnTextForButtonValue = true;
            this.col_del.Width = 12;
            // 
            // Customers_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.customerTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.recHistBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Customers_List";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Customers_FormClosing);
            this.Load += new System.EventHandler(this.CreateCustomerProfile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.DataGridView customerTable;
        private UserControls.SearchControl searchControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button recHistBtn;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_transact;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_address;
        private System.Windows.Forms.DataGridViewButtonColumn col_del;
    }
}