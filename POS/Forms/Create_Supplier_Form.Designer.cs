namespace POS.Forms
{
    partial class Create_Supplier_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Create_Supplier_Form));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contactDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.supplierName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addSuppBtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.contactDetails);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(23, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(338, 35);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 1);
            this.panel3.TabIndex = 1;
            // 
            // contactDetails
            // 
            this.contactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.contactDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contactDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactDetails.Location = new System.Drawing.Point(0, 13);
            this.contactDetails.MaxLength = 50;
            this.contactDetails.Name = "contactDetails";
            this.contactDetails.Size = new System.Drawing.Size(338, 13);
            this.contactDetails.TabIndex = 0;
            this.contactDetails.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contact Details: (optional)";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.supplierName);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(23, 23);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(338, 35);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 34);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(338, 1);
            this.panel7.TabIndex = 1;
            // 
            // supplierName
            // 
            this.supplierName.BackColor = System.Drawing.SystemColors.Control;
            this.supplierName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplierName.Dock = System.Windows.Forms.DockStyle.Top;
            this.supplierName.Location = new System.Drawing.Point(0, 13);
            this.supplierName.MaxLength = 50;
            this.supplierName.Name = "supplierName";
            this.supplierName.Size = new System.Drawing.Size(338, 13);
            this.supplierName.TabIndex = 0;
            this.supplierName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // addSuppBtn
            // 
            this.addSuppBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addSuppBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addSuppBtn.Location = new System.Drawing.Point(23, 107);
            this.addSuppBtn.MaximumSize = new System.Drawing.Size(150, 35);
            this.addSuppBtn.MinimumSize = new System.Drawing.Size(150, 35);
            this.addSuppBtn.Name = "addSuppBtn";
            this.addSuppBtn.Size = new System.Drawing.Size(150, 35);
            this.addSuppBtn.TabIndex = 2;
            this.addSuppBtn.Text = "SAVE";
            this.addSuppBtn.UseVisualStyleBackColor = false;
            this.addSuppBtn.Click += new System.EventHandler(this.addSuppBtn_Click);
            // 
            // Create_Supplier_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 166);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.addSuppBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Create_Supplier_Form";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Supplier";
            this.Load += new System.EventHandler(this.Create_Supplier_Form_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox contactDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox supplierName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addSuppBtn;
    }
}