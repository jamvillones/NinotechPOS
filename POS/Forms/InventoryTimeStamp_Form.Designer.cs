namespace POS.Forms {
    partial class InventoryTimeStamp_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryTimeStamp_Form));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inventorySnapshot_Items1 = new POS.UserControls.InventorySnapshot_Items();
            this.inventorySnapshot_Graph1 = new POS.UserControls.InventorySnapshot_Graph();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 23);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.Tag = "0";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "Items";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(66, 3);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Graphs";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 10);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inventorySnapshot_Items1);
            this.panel2.Controls.Add(this.inventorySnapshot_Graph1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 397);
            this.panel2.TabIndex = 15;
            // 
            // inventorySnapshot_Items1
            // 
            this.inventorySnapshot_Items1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventorySnapshot_Items1.Location = new System.Drawing.Point(0, 0);
            this.inventorySnapshot_Items1.Name = "inventorySnapshot_Items1";
            this.inventorySnapshot_Items1.Size = new System.Drawing.Size(780, 397);
            this.inventorySnapshot_Items1.TabIndex = 13;
            // 
            // inventorySnapshot_Graph1
            // 
            this.inventorySnapshot_Graph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventorySnapshot_Graph1.Location = new System.Drawing.Point(0, 0);
            this.inventorySnapshot_Graph1.Name = "inventorySnapshot_Graph1";
            this.inventorySnapshot_Graph1.Size = new System.Drawing.Size(780, 397);
            this.inventorySnapshot_Graph1.TabIndex = 14;
            // 
            // InventoryTimeStamp_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventoryTimeStamp_Form";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Inventory Time Table";
            this.Load += new System.EventHandler(this.InventoryTimeStamp_Form_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private UserControls.InventorySnapshot_Items inventorySnapshot_Items1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.InventorySnapshot_Graph inventorySnapshot_Graph1;
    }
}