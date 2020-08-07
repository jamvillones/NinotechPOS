namespace POS.Forms
{
    partial class CreateLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.editItem = new System.Windows.Forms.CheckBox();
            this.deleteItem = new System.Windows.Forms.CheckBox();
            this.addItem = new System.Windows.Forms.CheckBox();
            this.addLogin = new System.Windows.Forms.CheckBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.ConfirmPassTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkImage = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.editProduct = new System.Windows.Forms.CheckBox();
            this.addProduct = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stockin = new System.Windows.Forms.CheckBox();
            this.deleteLogin = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.editSupplier = new System.Windows.Forms.CheckBox();
            this.deleteSupplier = new System.Windows.Forms.CheckBox();
            this.addSupplier = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTxt.Location = new System.Drawing.Point(79, 13);
            this.UsernameTxt.MaxLength = 50;
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(177, 20);
            this.UsernameTxt.TabIndex = 1;
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTxt.Location = new System.Drawing.Point(124, 39);
            this.PasswordTxt.MaxLength = 50;
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(131, 20);
            this.PasswordTxt.TabIndex = 2;
            this.PasswordTxt.TextChanged += new System.EventHandler(this.PasswordTxt_TextChanged);
            // 
            // editItem
            // 
            this.editItem.AutoSize = true;
            this.editItem.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editItem.Location = new System.Drawing.Point(6, 19);
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(66, 18);
            this.editItem.TabIndex = 4;
            this.editItem.Text = "Can Edit";
            this.editItem.UseVisualStyleBackColor = true;
            // 
            // deleteItem
            // 
            this.deleteItem.AutoSize = true;
            this.deleteItem.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItem.Location = new System.Drawing.Point(6, 43);
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(77, 18);
            this.deleteItem.TabIndex = 5;
            this.deleteItem.Text = "Can Delete";
            this.deleteItem.UseVisualStyleBackColor = true;
            // 
            // addItem
            // 
            this.addItem.AutoSize = true;
            this.addItem.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItem.Location = new System.Drawing.Point(6, 67);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(64, 18);
            this.addItem.TabIndex = 6;
            this.addItem.Text = "Can Add";
            this.addItem.UseVisualStyleBackColor = true;
            // 
            // addLogin
            // 
            this.addLogin.AutoSize = true;
            this.addLogin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLogin.Location = new System.Drawing.Point(6, 19);
            this.addLogin.Name = "addLogin";
            this.addLogin.Size = new System.Drawing.Size(117, 18);
            this.addLogin.TabIndex = 7;
            this.addLogin.Text = "Can Add New Login";
            this.addLogin.UseVisualStyleBackColor = true;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.Location = new System.Drawing.Point(112, 331);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 8;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ConfirmPassTxt
            // 
            this.ConfirmPassTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmPassTxt.Location = new System.Drawing.Point(124, 65);
            this.ConfirmPassTxt.MaxLength = 50;
            this.ConfirmPassTxt.Name = "ConfirmPassTxt";
            this.ConfirmPassTxt.PasswordChar = '*';
            this.ConfirmPassTxt.Size = new System.Drawing.Size(131, 20);
            this.ConfirmPassTxt.TabIndex = 3;
            this.ConfirmPassTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Confirm Password";
            // 
            // checkImage
            // 
            this.checkImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkImage.Image = ((System.Drawing.Image)(resources.GetObject("checkImage.Image")));
            this.checkImage.Location = new System.Drawing.Point(261, 65);
            this.checkImage.Name = "checkImage";
            this.checkImage.Size = new System.Drawing.Size(20, 20);
            this.checkImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkImage.TabIndex = 11;
            this.checkImage.TabStop = false;
            this.checkImage.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editItem);
            this.groupBox1.Controls.Add(this.deleteItem);
            this.groupBox1.Controls.Add(this.addItem);
            this.groupBox1.Location = new System.Drawing.Point(17, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 100);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.editProduct);
            this.groupBox2.Controls.Add(this.addProduct);
            this.groupBox2.Location = new System.Drawing.Point(150, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product";
            // 
            // editProduct
            // 
            this.editProduct.AutoSize = true;
            this.editProduct.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editProduct.Location = new System.Drawing.Point(6, 19);
            this.editProduct.Name = "editProduct";
            this.editProduct.Size = new System.Drawing.Size(66, 18);
            this.editProduct.TabIndex = 4;
            this.editProduct.Text = "Can Edit";
            this.editProduct.UseVisualStyleBackColor = true;
            // 
            // addProduct
            // 
            this.addProduct.AutoSize = true;
            this.addProduct.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProduct.Location = new System.Drawing.Point(6, 43);
            this.addProduct.Name = "addProduct";
            this.addProduct.Size = new System.Drawing.Size(64, 18);
            this.addProduct.TabIndex = 6;
            this.addProduct.Text = "Can Add";
            this.addProduct.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stockin);
            this.groupBox3.Controls.Add(this.deleteLogin);
            this.groupBox3.Controls.Add(this.addLogin);
            this.groupBox3.Location = new System.Drawing.Point(17, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(127, 100);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Administrative";
            // 
            // stockin
            // 
            this.stockin.AutoSize = true;
            this.stockin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockin.Location = new System.Drawing.Point(6, 67);
            this.stockin.Name = "stockin";
            this.stockin.Size = new System.Drawing.Size(82, 18);
            this.stockin.TabIndex = 4;
            this.stockin.Text = "Can Stockin";
            this.stockin.UseVisualStyleBackColor = true;
            // 
            // deleteLogin
            // 
            this.deleteLogin.AutoSize = true;
            this.deleteLogin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLogin.Location = new System.Drawing.Point(6, 43);
            this.deleteLogin.Name = "deleteLogin";
            this.deleteLogin.Size = new System.Drawing.Size(107, 18);
            this.deleteLogin.TabIndex = 8;
            this.deleteLogin.Text = "Can Delete Login";
            this.deleteLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.editSupplier);
            this.groupBox4.Controls.Add(this.deleteSupplier);
            this.groupBox4.Controls.Add(this.addSupplier);
            this.groupBox4.Location = new System.Drawing.Point(150, 104);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(127, 100);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Supplier";
            // 
            // editSupplier
            // 
            this.editSupplier.AutoSize = true;
            this.editSupplier.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSupplier.Location = new System.Drawing.Point(6, 19);
            this.editSupplier.Name = "editSupplier";
            this.editSupplier.Size = new System.Drawing.Size(66, 18);
            this.editSupplier.TabIndex = 4;
            this.editSupplier.Text = "Can Edit";
            this.editSupplier.UseVisualStyleBackColor = true;
            // 
            // deleteSupplier
            // 
            this.deleteSupplier.AutoSize = true;
            this.deleteSupplier.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSupplier.Location = new System.Drawing.Point(6, 43);
            this.deleteSupplier.Name = "deleteSupplier";
            this.deleteSupplier.Size = new System.Drawing.Size(77, 18);
            this.deleteSupplier.TabIndex = 5;
            this.deleteSupplier.Text = "Can Delete";
            this.deleteSupplier.UseVisualStyleBackColor = true;
            // 
            // addSupplier
            // 
            this.addSupplier.AutoSize = true;
            this.addSupplier.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSupplier.Location = new System.Drawing.Point(6, 67);
            this.addSupplier.Name = "addSupplier";
            this.addSupplier.Size = new System.Drawing.Size(64, 18);
            this.addSupplier.TabIndex = 6;
            this.addSupplier.Text = "Can Add";
            this.addSupplier.UseVisualStyleBackColor = true;
            // 
            // CreateLogin
            // 
            this.AcceptButton = this.ConfirmBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 366);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkImage);
            this.Controls.Add(this.ConfirmPassTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateLogin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Login";
            ((System.ComponentModel.ISupportInitialize)(this.checkImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.CheckBox editItem;
        private System.Windows.Forms.CheckBox deleteItem;
        private System.Windows.Forms.CheckBox addItem;
        private System.Windows.Forms.CheckBox addLogin;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.TextBox ConfirmPassTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox checkImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox editProduct;
        private System.Windows.Forms.CheckBox addProduct;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox deleteLogin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox editSupplier;
        private System.Windows.Forms.CheckBox deleteSupplier;
        private System.Windows.Forms.CheckBox addSupplier;
        private System.Windows.Forms.CheckBox stockin;
    }
}