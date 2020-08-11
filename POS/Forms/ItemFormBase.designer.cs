namespace POS.Forms
{
    partial class ItemFormBase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.barcode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageHolder = new System.Windows.Forms.Panel();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sellingPrice = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.details = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.itemDepartment = new System.Windows.Forms.ComboBox();
            this.takePhotoBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.itemType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.imageHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellingPrice)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.barcode);
            this.groupBox1.Location = new System.Drawing.Point(224, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode";
            // 
            // barcode
            // 
            this.barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barcode.BackColor = System.Drawing.SystemColors.Control;
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.barcode.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcode.Location = new System.Drawing.Point(7, 20);
            this.barcode.MaxLength = 50;
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(557, 13);
            this.barcode.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imageHolder);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample Image";
            // 
            // imageHolder
            // 
            this.imageHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageHolder.Controls.Add(this.ImageBox);
            this.imageHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageHolder.Location = new System.Drawing.Point(3, 16);
            this.imageHolder.Name = "imageHolder";
            this.imageHolder.Size = new System.Drawing.Size(194, 104);
            this.imageHolder.TabIndex = 0;
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(-2, 1);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(194, 104);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.name);
            this.groupBox3.Location = new System.Drawing.Point(224, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item Name";
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.BackColor = System.Drawing.SystemColors.Control;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(7, 20);
            this.name.MaxLength = 50;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(557, 13);
            this.name.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sellingPrice);
            this.groupBox5.Location = new System.Drawing.Point(224, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(250, 40);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Item Selling Price";
            // 
            // sellingPrice
            // 
            this.sellingPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sellingPrice.BackColor = System.Drawing.SystemColors.Control;
            this.sellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sellingPrice.DecimalPlaces = 2;
            this.sellingPrice.Location = new System.Drawing.Point(6, 18);
            this.sellingPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.sellingPrice.Name = "sellingPrice";
            this.sellingPrice.Size = new System.Drawing.Size(238, 16);
            this.sellingPrice.TabIndex = 1;
            this.sellingPrice.ThousandsSeparator = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.details);
            this.groupBox6.Location = new System.Drawing.Point(12, 196);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(782, 242);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Item Details ";
            // 
            // details
            // 
            this.details.AcceptsReturn = true;
            this.details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.details.BackColor = System.Drawing.SystemColors.Control;
            this.details.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.details.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details.Location = new System.Drawing.Point(7, 20);
            this.details.MaxLength = 500;
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(769, 216);
            this.details.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.itemDepartment);
            this.groupBox8.Location = new System.Drawing.Point(480, 104);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(157, 40);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Item Department";
            // 
            // itemDepartment
            // 
            this.itemDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.itemDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.itemDepartment.BackColor = System.Drawing.SystemColors.Control;
            this.itemDepartment.FormattingEnabled = true;
            this.itemDepartment.Location = new System.Drawing.Point(6, 13);
            this.itemDepartment.MaxLength = 50;
            this.itemDepartment.Name = "itemDepartment";
            this.itemDepartment.Size = new System.Drawing.Size(145, 21);
            this.itemDepartment.TabIndex = 0;
            // 
            // takePhotoBtn
            // 
            this.takePhotoBtn.Location = new System.Drawing.Point(62, 138);
            this.takePhotoBtn.Name = "takePhotoBtn";
            this.takePhotoBtn.Size = new System.Drawing.Size(107, 23);
            this.takePhotoBtn.TabIndex = 0;
            this.takePhotoBtn.TabStop = false;
            this.takePhotoBtn.Text = "Take a photo";
            this.takePhotoBtn.UseVisualStyleBackColor = true;
            this.takePhotoBtn.Click += new System.EventHandler(this.takePhotoBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveBtn.Location = new System.Drawing.Point(364, 449);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.TabStop = false;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Choose a photo";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.itemType);
            this.groupBox4.Location = new System.Drawing.Point(643, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(151, 40);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Type";
            // 
            // itemType
            // 
            this.itemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.itemType.BackColor = System.Drawing.SystemColors.Control;
            this.itemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemType.FormattingEnabled = true;
            this.itemType.Location = new System.Drawing.Point(6, 13);
            this.itemType.MaxLength = 50;
            this.itemType.Name = "itemType";
            this.itemType.Size = new System.Drawing.Size(139, 21);
            this.itemType.TabIndex = 0;
            // 
            // ItemFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 484);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.takePhotoBtn);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item";
            this.Load += new System.EventHandler(this.AddItemForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.imageHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sellingPrice)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel imageHolder;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button saveBtn;
        protected System.Windows.Forms.TextBox barcode;
        protected System.Windows.Forms.TextBox name;
        protected System.Windows.Forms.TextBox details;
        protected System.Windows.Forms.ComboBox itemDepartment;
        protected System.Windows.Forms.NumericUpDown sellingPrice;
        protected System.Windows.Forms.Button takePhotoBtn;
        protected System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        protected System.Windows.Forms.ComboBox itemType;
        protected System.Windows.Forms.GroupBox groupBox6;
    }
}