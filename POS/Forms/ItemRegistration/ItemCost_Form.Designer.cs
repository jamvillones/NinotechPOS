namespace POS.Forms.ItemRegistration
{
    partial class ItemCost_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemCost_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._supplierOption = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.costTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this._price = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.costTable)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._price)).BeginInit();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.AutoSize = true;
            this.saveBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.Location = new System.Drawing.Point(20, 497);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.saveBtn.MaximumSize = new System.Drawing.Size(150, 35);
            this.saveBtn.MinimumSize = new System.Drawing.Size(150, 35);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 35);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "  Next Step";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(20, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "*You can edit the cost by clicking the cell";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(20, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "*Choose The Supplier Then Add It To The List";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Items can have multiple cost depending on where it was bought";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(121, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 30);
            this.label1.TabIndex = 41;
            this.label1.Text = "COST AND SELLING PRICE";
            // 
            // _supplierOption
            // 
            this._supplierOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._supplierOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._supplierOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._supplierOption.BackColor = System.Drawing.Color.White;
            this._supplierOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._supplierOption.FormattingEnabled = true;
            this._supplierOption.Location = new System.Drawing.Point(20, 120);
            this._supplierOption.Margin = new System.Windows.Forms.Padding(0);
            this._supplierOption.Name = "_supplierOption";
            this._supplierOption.Size = new System.Drawing.Size(421, 28);
            this._supplierOption.TabIndex = 39;
            this._supplierOption.KeyDown += new System.Windows.Forms.KeyEventHandler(this._supplierOption_KeyDown);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(440, 120);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.MaximumSize = new System.Drawing.Size(150, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 28);
            this.button4.TabIndex = 40;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // costTable
            // 
            this.costTable.AllowUserToAddRows = false;
            this.costTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.costTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.costTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.costTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.costTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.costTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.costTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.costTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.costTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Id,
            this.col_Supplier,
            this.col_Value});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.costTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.costTable.EnableHeadersVisualStyles = false;
            this.costTable.Location = new System.Drawing.Point(20, 184);
            this.costTable.MultiSelect = false;
            this.costTable.Name = "costTable";
            this.costTable.RowHeadersVisible = false;
            this.costTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.costTable.Size = new System.Drawing.Size(471, 204);
            this.costTable.StandardTab = true;
            this.costTable.TabIndex = 38;
            // 
            // col_Id
            // 
            this.col_Id.HeaderText = "ID";
            this.col_Id.Name = "col_Id";
            this.col_Id.ReadOnly = true;
            this.col_Id.Visible = false;
            // 
            // col_Supplier
            // 
            this.col_Supplier.HeaderText = "SUPPLIER";
            this.col_Supplier.Name = "col_Supplier";
            this.col_Supplier.ReadOnly = true;
            // 
            // col_Value
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.col_Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Value.HeaderText = "VALUE";
            this.col_Value.Name = "col_Value";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this._price);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(20, 414);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(471, 35);
            this.panel3.TabIndex = 46;
            // 
            // _price
            // 
            this._price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._price.BackColor = System.Drawing.SystemColors.Control;
            this._price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._price.DecimalPlaces = 2;
            this._price.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._price.ForeColor = System.Drawing.Color.Black;
            this._price.Location = new System.Drawing.Point(11, 15);
            this._price.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this._price.Name = "_price";
            this._price.Size = new System.Drawing.Size(449, 19);
            this._price.TabIndex = 2;
            this._price.ThousandsSeparator = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(471, 1);
            this.panel4.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Selling Price:";
            // 
            // ItemCost_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 552);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._supplierOption);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.costTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ItemCost_Form";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Niñotech POS - Create Item (4/4)";
            this.Load += new System.EventHandler(this.ItemCost_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.costTable)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _supplierOption;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView costTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Value;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown _price;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
    }
}