namespace POS.Forms.ItemRegistration
{
    partial class BasicInformation_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicInformation_Form));
            this.button2 = new System.Windows.Forms.Button();
            this._departmentOption = new System.Windows.Forms.ComboBox();
            this._type = new System.Windows.Forms.ComboBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this._description = new System.Windows.Forms.TextBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this._tags = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this._criticalQty = new System.Windows.Forms.NumericUpDown();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this._name = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._criticalQty)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(399, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 35);
            this.button2.TabIndex = 32;
            this.button2.TabStop = false;
            this.button2.Text = "Auto Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _departmentOption
            // 
            this._departmentOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._departmentOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._departmentOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this._departmentOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._departmentOption.FormattingEnabled = true;
            this._departmentOption.Location = new System.Drawing.Point(208, 271);
            this._departmentOption.Name = "_departmentOption";
            this._departmentOption.Size = new System.Drawing.Size(161, 23);
            this._departmentOption.TabIndex = 4;
            // 
            // _type
            // 
            this._type.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._type.BackColor = System.Drawing.SystemColors.Control;
            this._type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._type.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._type.ForeColor = System.Drawing.Color.Black;
            this._type.FormattingEnabled = true;
            this._type.Items.AddRange(new object[] {
            "Quantifiable",
            "Service",
            "Software"});
            this._type.Location = new System.Drawing.Point(31, 271);
            this._type.Name = "_type";
            this._type.Size = new System.Drawing.Size(161, 23);
            this._type.TabIndex = 3;
            this._type.SelectedIndexChanged += new System.EventHandler(this._type_SelectedIndexChanged);
            // 
            // panel13
            // 
            this.panel13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel13.AutoSize = true;
            this.panel13.Controls.Add(this._description);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.label7);
            this.panel13.Location = new System.Drawing.Point(31, 442);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(462, 35);
            this.panel13.TabIndex = 8;
            // 
            // _description
            // 
            this._description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._description.BackColor = System.Drawing.SystemColors.Control;
            this._description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._description.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._description.ForeColor = System.Drawing.Color.Black;
            this._description.Location = new System.Drawing.Point(11, 16);
            this._description.MaxLength = 300;
            this._description.Name = "_description";
            this._description.Size = new System.Drawing.Size(440, 16);
            this._description.TabIndex = 2;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Black;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 34);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(462, 1);
            this.panel14.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Notes:";
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this._tags);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Location = new System.Drawing.Point(31, 382);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(462, 35);
            this.panel9.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 34);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(462, 1);
            this.panel10.TabIndex = 1;
            // 
            // _tags
            // 
            this._tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._tags.BackColor = System.Drawing.SystemColors.Control;
            this._tags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._tags.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tags.ForeColor = System.Drawing.Color.Black;
            this._tags.Location = new System.Drawing.Point(11, 16);
            this._tags.MaxLength = 300;
            this._tags.Name = "_tags";
            this._tags.Size = new System.Drawing.Size(440, 16);
            this._tags.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tags";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this._criticalQty);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(31, 322);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(462, 35);
            this.panel5.TabIndex = 6;
            // 
            // _criticalQty
            // 
            this._criticalQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._criticalQty.BackColor = System.Drawing.SystemColors.Control;
            this._criticalQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._criticalQty.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._criticalQty.ForeColor = System.Drawing.Color.Black;
            this._criticalQty.Location = new System.Drawing.Point(11, 15);
            this._criticalQty.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this._criticalQty.Name = "_criticalQty";
            this._criticalQty.Size = new System.Drawing.Size(440, 19);
            this._criticalQty.TabIndex = 3;
            this._criticalQty.ThousandsSeparator = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 34);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(462, 1);
            this.panel8.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Critical Qty:";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this._barcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(31, 189);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 35);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 1);
            this.panel2.TabIndex = 1;
            // 
            // _barcode
            // 
            this._barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._barcode.BackColor = System.Drawing.SystemColors.Control;
            this._barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._barcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this._barcode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._barcode.ForeColor = System.Drawing.Color.Black;
            this._barcode.Location = new System.Drawing.Point(11, 16);
            this._barcode.MaxLength = 50;
            this._barcode.Name = "_barcode";
            this._barcode.Size = new System.Drawing.Size(340, 16);
            this._barcode.TabIndex = 0;
            this._barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this._barcode_KeyDown);
            this._barcode.Validating += new System.ComponentModel.CancelEventHandler(this._barcode_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barcode:";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this._name);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(31, 129);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(462, 35);
            this.panel6.TabIndex = 1;
            // 
            // _name
            // 
            this._name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._name.BackColor = System.Drawing.SystemColors.Control;
            this._name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._name.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._name.ForeColor = System.Drawing.Color.Black;
            this._name.Location = new System.Drawing.Point(11, 16);
            this._name.MaxLength = 50;
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(440, 16);
            this._name.TabIndex = 0;
            this._name.TextChanged += new System.EventHandler(this._name_TextChanged);
            this._name.Validating += new System.ComponentModel.CancelEventHandler(this._name_Validating);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(462, 1);
            this.panel7.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(28, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Type:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(205, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Department:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(122, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(281, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Fill out basic information about the item that will be created";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(147, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 30);
            this.label10.TabIndex = 36;
            this.label10.Text = "BASIC INFORMATION";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveBtn.AutoSize = true;
            this.saveBtn.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveBtn.Enabled = false;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.Location = new System.Drawing.Point(31, 511);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.saveBtn.MaximumSize = new System.Drawing.Size(150, 35);
            this.saveBtn.MinimumSize = new System.Drawing.Size(150, 35);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 35);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.TabStop = false;
            this.saveBtn.Text = "  Next Step";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // BasicInformation_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 580);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._departmentOption);
            this.Controls.Add(this._type);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 570);
            this.Name = "BasicInformation_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Niñotech POS - Create Item (1/4)";
            this.Load += new System.EventHandler(this.BasicInformation_Form_Load);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._criticalQty)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox _departmentOption;
        private System.Windows.Forms.ComboBox _type;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox _description;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox _tags;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown _criticalQty;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox _name;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button saveBtn;
    }
}