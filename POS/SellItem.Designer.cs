namespace POS
{
    partial class SellItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellItem));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cart = new System.Windows.Forms.DataGridView();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.barcodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cart)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 18, 10, 10);
            this.panel2.Size = new System.Drawing.Size(784, 316);
            this.panel2.TabIndex = 1;
            // 
            // cart
            // 
            this.cart.AllowUserToAddRows = false;
            this.cart.AllowUserToDeleteRows = false;
            this.cart.AllowUserToResizeRows = false;
            this.cart.BackgroundColor = System.Drawing.SystemColors.Control;
            this.cart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.cart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.Column1,
            this.barcodeCol,
            this.serialCol,
            this.nameCol,
            this.supplierCol,
            this.qtyCol,
            this.priceCol,
            this.discCol,
            this.totalCol});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cart.DefaultCellStyle = dataGridViewCellStyle1;
            this.cart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cart.EnableHeadersVisualStyles = false;
            this.cart.Location = new System.Drawing.Point(10, 18);
            this.cart.MultiSelect = false;
            this.cart.Name = "cart";
            this.cart.RowHeadersVisible = false;
            this.cart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cart.Size = new System.Drawing.Size(764, 288);
            this.cart.TabIndex = 0;
            // 
            // idCol
            // 
            this.idCol.HeaderText = "ID";
            this.idCol.Name = "idCol";
            this.idCol.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 5;
            // 
            // barcodeCol
            // 
            this.barcodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barcodeCol.HeaderText = "BARCODE";
            this.barcodeCol.Name = "barcodeCol";
            this.barcodeCol.ReadOnly = true;
            this.barcodeCol.Width = 84;
            // 
            // serialCol
            // 
            this.serialCol.HeaderText = "SERIAL";
            this.serialCol.Name = "serialCol";
            this.serialCol.ReadOnly = true;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "NAME";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // supplierCol
            // 
            this.supplierCol.HeaderText = "SUPPLIER";
            this.supplierCol.Name = "supplierCol";
            this.supplierCol.ReadOnly = true;
            // 
            // qtyCol
            // 
            this.qtyCol.HeaderText = "QTY";
            this.qtyCol.Name = "qtyCol";
            this.qtyCol.ReadOnly = true;
            this.qtyCol.Width = 70;
            // 
            // priceCol
            // 
            this.priceCol.HeaderText = "PRICE";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // discCol
            // 
            this.discCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.discCol.HeaderText = "DISCOUNT";
            this.discCol.Name = "discCol";
            this.discCol.ReadOnly = true;
            // 
            // totalCol
            // 
            this.totalCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalCol.HeaderText = "TOTAL";
            this.totalCol.Name = "totalCol";
            this.totalCol.ReadOnly = true;
            this.totalCol.Width = 67;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(10, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(764, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "CHECK OUT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 26);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(367, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 26);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // totalLabel
            // 
            this.totalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(0, 23);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(262, 46);
            this.totalLabel.TabIndex = 0;
            this.totalLabel.Text = "0.00";
            this.totalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "*Item not found.";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 89);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.totalLabel);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(510, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(264, 71);
            this.panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "GRAND TOTAL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(116, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "EDIT";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.RosyBrown;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(10, 57);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 26);
            this.button5.TabIndex = 5;
            this.button5.Text = "REMOVE";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 405);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(784, 56);
            this.panel3.TabIndex = 2;
            // 
            // SellItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "SellItem";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sell Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellItem_FormClosing);
            this.Load += new System.EventHandler(this.SellItem_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView cart;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCol;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
    }
}