namespace POS.Forms
{
    partial class ModifyCartDetails
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
            this.keypad1 = new POS.UserControls.Keypad();
            this.SuspendLayout();
            // 
            // keypad1
            // 
            this.keypad1.BackColor = System.Drawing.SystemColors.Control;
            this.keypad1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.keypad1.Dock = System.Windows.Forms.DockStyle.Right;
            this.keypad1.Location = new System.Drawing.Point(438, 0);
            this.keypad1.Name = "keypad1";
            this.keypad1.Size = new System.Drawing.Size(250, 244);
            this.keypad1.TabIndex = 0;
            // 
            // ModifyCartDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 244);
            this.Controls.Add(this.keypad1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyCartDetails";
            this.Text = "Modify Cart Item Details";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Keypad keypad1;
    }
}