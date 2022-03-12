using test;

namespace POS.UserControls
{
    partial class SearchControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchControl));
            this.searchBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchText = new test.KeywordAutoCompleteTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.searchBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchBtn.FlatAppearance.BorderSize = 0;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.Location = new System.Drawing.Point(185, 0);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(0);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(32, 24);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.TabStop = false;
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Size = new System.Drawing.Size(185, 24);
            this.panel1.TabIndex = 2;
            // 
            // searchText
            // 
            this.searchText.AcceptsReturn = true;
            this.searchText.BackColor = System.Drawing.Color.White;
            this.searchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.Location = new System.Drawing.Point(5, 3);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(175, 19);
            this.searchText.TabIndex = 0;
            this.searchText.Values = null;
            this.searchText.TextChanged += new System.EventHandler(this.searchText_TextChanged);
            this.searchText.Enter += new System.EventHandler(this.searchText_Enter);
            this.searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchText_KeyDown);
            // 
            // SearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchBtn);
            this.MaximumSize = new System.Drawing.Size(9999, 28);
            this.MinimumSize = new System.Drawing.Size(219, 22);
            this.Name = "SearchControl";
            this.Size = new System.Drawing.Size(217, 24);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KeywordAutoCompleteTextBox searchText;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Panel panel1;
    }
}
