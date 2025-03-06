namespace POS.UserControls
{
    partial class Customers_UserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.searchControl = new POS.UserControls.SearchControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.customerTable = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_transact = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.recHistBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            this.SuspendLayout();
            // 
            // searchControl
            // 
            this.searchControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl.BackColor = System.Drawing.Color.White;
            this.searchControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl.Location = new System.Drawing.Point(0, 0);
            this.searchControl.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl.MinimumSize = new System.Drawing.Size(2, 35);
            this.searchControl.Name = "searchControl";
            this.searchControl.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl.SearchedText = "";
            this.searchControl.Size = new System.Drawing.Size(350, 35);
            this.searchControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loadingLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 20);
            this.panel1.TabIndex = 3;
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
            // customerTable
            // 
            this.customerTable.AllowUserToAddRows = false;
            this.customerTable.AllowUserToDeleteRows = false;
            this.customerTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.customerTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.customerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.customerTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.customerTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.customerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_transact,
            this.col_name,
            this.col_contact,
            this.col_address,
            this.col_del});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.customerTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.customerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerTable.EnableHeadersVisualStyles = false;
            this.customerTable.GridColor = System.Drawing.Color.DarkGray;
            this.customerTable.Location = new System.Drawing.Point(0, 55);
            this.customerTable.MultiSelect = false;
            this.customerTable.Name = "customerTable";
            this.customerTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.customerTable.RowHeadersVisible = false;
            this.customerTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.customerTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerTable.Size = new System.Drawing.Size(1080, 665);
            this.customerTable.StandardTab = true;
            this.customerTable.TabIndex = 4;
            // 
            // col_id
            // 
            this.col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_id.HeaderText = "Id";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_transact
            // 
            this.col_transact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_transact.HeaderText = "";
            this.col_transact.Name = "col_transact";
            this.col_transact.Width = 13;
            // 
            // col_name
            // 
            dataGridViewCellStyle3.NullValue = "*not set";
            this.col_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_name.HeaderText = "NAME";
            this.col_name.Name = "col_name";
            // 
            // col_contact
            // 
            this.col_contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_contact.HeaderText = "CONTACT DETAILS";
            this.col_contact.Name = "col_contact";
            // 
            // col_address
            // 
            this.col_address.HeaderText = "ADDRESS";
            this.col_address.Name = "col_address";
            // 
            // col_del
            // 
            this.col_del.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_del.HeaderText = "";
            this.col_del.Name = "col_del";
            this.col_del.Width = 13;
            // 
            // recHistBtn
            // 
            this.recHistBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recHistBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.recHistBtn.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.recHistBtn.FlatAppearance.BorderSize = 2;
            this.recHistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recHistBtn.Location = new System.Drawing.Point(910, 0);
            this.recHistBtn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.recHistBtn.MaximumSize = new System.Drawing.Size(170, 50);
            this.recHistBtn.MinimumSize = new System.Drawing.Size(150, 35);
            this.recHistBtn.Name = "recHistBtn";
            this.recHistBtn.Size = new System.Drawing.Size(170, 35);
            this.recHistBtn.TabIndex = 18;
            this.recHistBtn.Text = "Create New";
            this.recHistBtn.UseVisualStyleBackColor = false;
            // 
            // Customers_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.recHistBtn);
            this.Controls.Add(this.customerTable);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchControl);
            this.Name = "Customers_UserControl";
            this.Size = new System.Drawing.Size(1080, 720);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SearchControl searchControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label loadingLabel;
        protected System.Windows.Forms.DataGridView customerTable;
        private System.Windows.Forms.Button recHistBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_transact;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_address;
        private System.Windows.Forms.DataGridViewButtonColumn col_del;
    }
}
