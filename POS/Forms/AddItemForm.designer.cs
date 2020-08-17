namespace POS.Forms
{
    partial class AddItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemForm));
            this.VariationGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cost = new System.Windows.Forms.NumericUpDown();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.supplierOption = new System.Windows.Forms.ComboBox();
            this.variationTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sellingPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.VariationGroup.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cost)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.variationTable)).BeginInit();
            this.SuspendLayout();
            // 
            // barcode
            // 
            this.barcode.Leave += new System.EventHandler(this.barcode_Leave);
            // 
            // details
            // 
            this.details.Size = new System.Drawing.Size(375, 216);
            // 
            // itemType
            // 
            this.itemType.SelectedIndexChanged += new System.EventHandler(this.itemType_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Size = new System.Drawing.Size(388, 242);
            // 
            // VariationGroup
            // 
            this.VariationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariationGroup.Controls.Add(this.button1);
            this.VariationGroup.Controls.Add(this.groupBox10);
            this.VariationGroup.Controls.Add(this.groupBox9);
            this.VariationGroup.Controls.Add(this.variationTable);
            this.VariationGroup.Location = new System.Drawing.Point(406, 196);
            this.VariationGroup.Name = "VariationGroup";
            this.VariationGroup.Size = new System.Drawing.Size(388, 242);
            this.VariationGroup.TabIndex = 8;
            this.VariationGroup.TabStop = false;
            this.VariationGroup.Text = "Item Variation";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Location = new System.Drawing.Point(243, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 9;
            this.button1.TabStop = false;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.cost);
            this.groupBox10.Location = new System.Drawing.Point(169, 20);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(68, 40);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Cost";
            // 
            // cost
            // 
            this.cost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cost.Location = new System.Drawing.Point(7, 14);
            this.cost.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(55, 20);
            this.cost.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.supplierOption);
            this.groupBox9.Location = new System.Drawing.Point(6, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(157, 40);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Supplier";
            // 
            // supplierOption
            // 
            this.supplierOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplierOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.supplierOption.BackColor = System.Drawing.SystemColors.Control;
            this.supplierOption.FormattingEnabled = true;
            this.supplierOption.Location = new System.Drawing.Point(6, 13);
            this.supplierOption.MaxLength = 50;
            this.supplierOption.Name = "supplierOption";
            this.supplierOption.Size = new System.Drawing.Size(145, 21);
            this.supplierOption.TabIndex = 0;
            this.supplierOption.Validated += new System.EventHandler(this.comboBox1_Validated);
            // 
            // variationTable
            // 
            this.variationTable.AllowUserToAddRows = false;
            this.variationTable.AllowUserToDeleteRows = false;
            this.variationTable.AllowUserToResizeColumns = false;
            this.variationTable.AllowUserToResizeRows = false;
            this.variationTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.variationTable.BackgroundColor = System.Drawing.Color.White;
            this.variationTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.variationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.variationTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.variationTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.variationTable.EnableHeadersVisualStyles = false;
            this.variationTable.GridColor = System.Drawing.Color.White;
            this.variationTable.Location = new System.Drawing.Point(6, 66);
            this.variationTable.MultiSelect = false;
            this.variationTable.Name = "variationTable";
            this.variationTable.ReadOnly = true;
            this.variationTable.RowHeadersVisible = false;
            this.variationTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.variationTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.variationTable.Size = new System.Drawing.Size(376, 170);
            this.variationTable.StandardTab = true;
            this.variationTable.TabIndex = 1;
            this.variationTable.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "SUPPLIER";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "COST";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 61;
            // 
            // AddItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(803, 484);
            this.Controls.Add(this.VariationGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddItemForm";
            this.Controls.SetChildIndex(this.VariationGroup, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.Controls.SetChildIndex(this.takePhotoBtn, 0);
            ((System.ComponentModel.ISupportInitialize)(this.sellingPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.VariationGroup.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cost)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.variationTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox VariationGroup;
        protected System.Windows.Forms.DataGridView variationTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox9;
        protected System.Windows.Forms.ComboBox supplierOption;
        private System.Windows.Forms.NumericUpDown cost;
        private System.Windows.Forms.Button button1;
    }
}