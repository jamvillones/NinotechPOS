namespace POS.Forms
{
    partial class Payment_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment_Form));
            this.addPaymentBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.paymentNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentNum)).BeginInit();
            this.SuspendLayout();
            // 
            // addPaymentBtn
            // 
            this.addPaymentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPaymentBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.addPaymentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addPaymentBtn.Location = new System.Drawing.Point(23, 123);
            this.addPaymentBtn.Margin = new System.Windows.Forms.Padding(0);
            this.addPaymentBtn.Name = "addPaymentBtn";
            this.addPaymentBtn.Size = new System.Drawing.Size(150, 33);
            this.addPaymentBtn.TabIndex = 25;
            this.addPaymentBtn.Text = "Add Payment";
            this.addPaymentBtn.UseVisualStyleBackColor = false;
            this.addPaymentBtn.Click += new System.EventHandler(this.addPaymentBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sales Discount",
            "Withholding Tax",
            "Cash Payment",
            "Cheque Payment",
            "Online Payment"});
            this.comboBox1.Location = new System.Drawing.Point(23, 76);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(317, 21);
            this.comboBox1.TabIndex = 26;
            // 
            // paymentNum
            // 
            this.paymentNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentNum.DecimalPlaces = 2;
            this.paymentNum.Location = new System.Drawing.Point(23, 31);
            this.paymentNum.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.paymentNum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.paymentNum.Name = "paymentNum";
            this.paymentNum.Size = new System.Drawing.Size(317, 20);
            this.paymentNum.TabIndex = 24;
            this.paymentNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.paymentNum.ThousandsSeparator = true;
            this.paymentNum.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Details:";
            // 
            // Payment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 174);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addPaymentBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.paymentNum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Payment_Form";
            this.Text = "Add Payment";
            ((System.ComponentModel.ISupportInitialize)(this.paymentNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPaymentBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown paymentNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}