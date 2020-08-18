namespace POS.UserControls
{
    partial class Keypad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keypad));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.period = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.backspace = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.period, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.zero, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.backspace, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.three, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.two, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.one, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.six, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.five, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.four, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nine, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.eight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.seven, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(496, 496);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // period
            // 
            this.period.BackColor = System.Drawing.SystemColors.Control;
            this.period.CausesValidation = false;
            this.period.Dock = System.Windows.Forms.DockStyle.Fill;
            this.period.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.period.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.period.Location = new System.Drawing.Point(333, 375);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(160, 118);
            this.period.TabIndex = 11;
            this.period.TabStop = false;
            this.period.Text = ".";
            this.period.UseVisualStyleBackColor = false;
            this.period.Click += new System.EventHandler(this.period_Click);
            // 
            // zero
            // 
            this.zero.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.zero.CausesValidation = false;
            this.zero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zero.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zero.Location = new System.Drawing.Point(168, 375);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(159, 118);
            this.zero.TabIndex = 10;
            this.zero.TabStop = false;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = false;
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // backspace
            // 
            this.backspace.BackColor = System.Drawing.Color.LightCoral;
            this.backspace.CausesValidation = false;
            this.backspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backspace.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backspace.Image = ((System.Drawing.Image)(resources.GetObject("backspace.Image")));
            this.backspace.Location = new System.Drawing.Point(3, 375);
            this.backspace.Name = "backspace";
            this.backspace.Size = new System.Drawing.Size(159, 118);
            this.backspace.TabIndex = 9;
            this.backspace.TabStop = false;
            this.backspace.UseVisualStyleBackColor = false;
            this.backspace.Click += new System.EventHandler(this.backspace_Click);
            // 
            // three
            // 
            this.three.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.three.CausesValidation = false;
            this.three.Dock = System.Windows.Forms.DockStyle.Fill;
            this.three.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.three.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.three.Location = new System.Drawing.Point(333, 251);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(160, 118);
            this.three.TabIndex = 8;
            this.three.TabStop = false;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = false;
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // two
            // 
            this.two.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.two.CausesValidation = false;
            this.two.Dock = System.Windows.Forms.DockStyle.Fill;
            this.two.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.two.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.two.Location = new System.Drawing.Point(168, 251);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(159, 118);
            this.two.TabIndex = 7;
            this.two.TabStop = false;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = false;
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // one
            // 
            this.one.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.one.CausesValidation = false;
            this.one.Dock = System.Windows.Forms.DockStyle.Fill;
            this.one.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.one.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.one.Location = new System.Drawing.Point(3, 251);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(159, 118);
            this.one.TabIndex = 6;
            this.one.TabStop = false;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = false;
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // six
            // 
            this.six.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.six.CausesValidation = false;
            this.six.Dock = System.Windows.Forms.DockStyle.Fill;
            this.six.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.six.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.six.Location = new System.Drawing.Point(333, 127);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(160, 118);
            this.six.TabIndex = 5;
            this.six.TabStop = false;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = false;
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // five
            // 
            this.five.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.five.CausesValidation = false;
            this.five.Dock = System.Windows.Forms.DockStyle.Fill;
            this.five.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.five.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.five.Location = new System.Drawing.Point(168, 127);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(159, 118);
            this.five.TabIndex = 4;
            this.five.TabStop = false;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = false;
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // four
            // 
            this.four.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.four.CausesValidation = false;
            this.four.Dock = System.Windows.Forms.DockStyle.Fill;
            this.four.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.four.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.four.Location = new System.Drawing.Point(3, 127);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(159, 118);
            this.four.TabIndex = 3;
            this.four.TabStop = false;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = false;
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // nine
            // 
            this.nine.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.nine.CausesValidation = false;
            this.nine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nine.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nine.Location = new System.Drawing.Point(333, 3);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(160, 118);
            this.nine.TabIndex = 2;
            this.nine.TabStop = false;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = false;
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // eight
            // 
            this.eight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.eight.CausesValidation = false;
            this.eight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eight.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eight.Location = new System.Drawing.Point(168, 3);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(159, 118);
            this.eight.TabIndex = 1;
            this.eight.TabStop = false;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = false;
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // seven
            // 
            this.seven.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.seven.CausesValidation = false;
            this.seven.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seven.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seven.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seven.Location = new System.Drawing.Point(3, 3);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(159, 118);
            this.seven.TabIndex = 0;
            this.seven.TabStop = false;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = false;
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Keypad";
            this.Size = new System.Drawing.Size(496, 496);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button period;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button backspace;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button seven;
    }
}
