namespace POS
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.sideButtonsPanel = new System.Windows.Forms.Panel();
            this.repBtn = new System.Windows.Forms.Button();
            this.inventoryBtn = new System.Windows.Forms.Button();
            this.topMostPanel = new System.Windows.Forms.Panel();
            this.userButton = new System.Windows.Forms.Button();
            this.appTitleLabel = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.changePasswordToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLoginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loginPrivilegesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.addNewSupplierToolstripbuttn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tabHoldersPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.inventoryTab = new POS.UserControls.InventoryUC();
            this.reportTab = new POS.UserControls.ReportUC();
            this.sideButtonsPanel.SuspendLayout();
            this.topMostPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabHoldersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideButtonsPanel
            // 
            this.sideButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sideButtonsPanel.Controls.Add(this.repBtn);
            this.sideButtonsPanel.Controls.Add(this.inventoryBtn);
            this.sideButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.sideButtonsPanel.Name = "sideButtonsPanel";
            this.sideButtonsPanel.Size = new System.Drawing.Size(115, 650);
            this.sideButtonsPanel.TabIndex = 0;
            this.toolTip.SetToolTip(this.sideButtonsPanel, "Double click to hide/show");
            this.sideButtonsPanel.DoubleClick += new System.EventHandler(this.sideButtonsPanel_DoubleClick);
            // 
            // repBtn
            // 
            this.repBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.repBtn.FlatAppearance.BorderSize = 0;
            this.repBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repBtn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repBtn.ForeColor = System.Drawing.Color.White;
            this.repBtn.Image = ((System.Drawing.Image)(resources.GetObject("repBtn.Image")));
            this.repBtn.Location = new System.Drawing.Point(0, 100);
            this.repBtn.Margin = new System.Windows.Forms.Padding(0);
            this.repBtn.Name = "repBtn";
            this.repBtn.Size = new System.Drawing.Size(115, 100);
            this.repBtn.TabIndex = 2;
            this.repBtn.TabStop = false;
            this.repBtn.Text = "TRANSACTIONS";
            this.repBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.repBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.repBtn.UseVisualStyleBackColor = true;
            this.repBtn.Click += new System.EventHandler(this.repBtn_Click);
            // 
            // inventoryBtn
            // 
            this.inventoryBtn.BackColor = System.Drawing.Color.Gray;
            this.inventoryBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.inventoryBtn.FlatAppearance.BorderSize = 0;
            this.inventoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventoryBtn.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryBtn.ForeColor = System.Drawing.Color.White;
            this.inventoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("inventoryBtn.Image")));
            this.inventoryBtn.Location = new System.Drawing.Point(0, 0);
            this.inventoryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.inventoryBtn.Name = "inventoryBtn";
            this.inventoryBtn.Size = new System.Drawing.Size(115, 100);
            this.inventoryBtn.TabIndex = 1;
            this.inventoryBtn.TabStop = false;
            this.inventoryBtn.Text = "PRODUCTS";
            this.inventoryBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.inventoryBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inventoryBtn.UseVisualStyleBackColor = false;
            this.inventoryBtn.Click += new System.EventHandler(this.inventoryBtn_Click);
            // 
            // topMostPanel
            // 
            this.topMostPanel.BackColor = System.Drawing.Color.DimGray;
            this.topMostPanel.Controls.Add(this.userButton);
            this.topMostPanel.Controls.Add(this.appTitleLabel);
            this.topMostPanel.Controls.Add(this.button6);
            this.topMostPanel.Controls.Add(this.button4);
            this.topMostPanel.Controls.Add(this.button5);
            this.topMostPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMostPanel.Location = new System.Drawing.Point(115, 0);
            this.topMostPanel.Name = "topMostPanel";
            this.topMostPanel.Size = new System.Drawing.Size(1060, 34);
            this.topMostPanel.TabIndex = 1;
            this.topMostPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // userButton
            // 
            this.userButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userButton.AutoSize = true;
            this.userButton.BackColor = System.Drawing.SystemColors.Control;
            this.userButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userButton.Image = ((System.Drawing.Image)(resources.GetObject("userButton.Image")));
            this.userButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userButton.Location = new System.Drawing.Point(820, 4);
            this.userButton.Name = "userButton";
            this.userButton.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.userButton.Size = new System.Drawing.Size(150, 25);
            this.userButton.TabIndex = 5;
            this.userButton.TabStop = false;
            this.userButton.Text = "Username";
            this.userButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.userButton.UseVisualStyleBackColor = false;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // appTitleLabel
            // 
            this.appTitleLabel.AutoSize = true;
            this.appTitleLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTitleLabel.ForeColor = System.Drawing.Color.White;
            this.appTitleLabel.Location = new System.Drawing.Point(6, 8);
            this.appTitleLabel.Name = "appTitleLabel";
            this.appTitleLabel.Size = new System.Drawing.Size(130, 19);
            this.appTitleLabel.TabIndex = 3;
            this.appTitleLabel.Text = "POINT OF  SALE";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.DimGray;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(976, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(27, 25);
            this.button6.TabIndex = 2;
            this.button6.TabStop = false;
            this.button6.Text = "_";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.DimGray;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(1003, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 25);
            this.button4.TabIndex = 1;
            this.button4.TabStop = false;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.DarkRed;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1030, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 25);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.addNewSupplierToolstripbuttn,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.toolStripButton6});
            this.toolStrip.Location = new System.Drawing.Point(115, 34);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(1060, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem2,
            this.addNewLoginToolStripMenuItem1,
            this.loginPrivilegesToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Logins";
            // 
            // changePasswordToolStripMenuItem2
            // 
            this.changePasswordToolStripMenuItem2.Name = "changePasswordToolStripMenuItem2";
            this.changePasswordToolStripMenuItem2.Size = new System.Drawing.Size(177, 22);
            this.changePasswordToolStripMenuItem2.Text = "Change Credentials";
            this.changePasswordToolStripMenuItem2.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // addNewLoginToolStripMenuItem1
            // 
            this.addNewLoginToolStripMenuItem1.Name = "addNewLoginToolStripMenuItem1";
            this.addNewLoginToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.addNewLoginToolStripMenuItem1.Text = "Add New Login";
            this.addNewLoginToolStripMenuItem1.Click += new System.EventHandler(this.addNewLoginToolStripMenuItem_Click);
            // 
            // loginPrivilegesToolStripMenuItem1
            // 
            this.loginPrivilegesToolStripMenuItem1.Name = "loginPrivilegesToolStripMenuItem1";
            this.loginPrivilegesToolStripMenuItem1.ShowShortcutKeys = false;
            this.loginPrivilegesToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.loginPrivilegesToolStripMenuItem1.Text = "Login Privileges";
            this.loginPrivilegesToolStripMenuItem1.Click += new System.EventHandler(this.loginPrivilegesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Customers";
            this.toolStripButton1.Click += new System.EventHandler(this.createCustomer_Click);
            // 
            // addNewSupplierToolstripbuttn
            // 
            this.addNewSupplierToolstripbuttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addNewSupplierToolstripbuttn.Image = ((System.Drawing.Image)(resources.GetObject("addNewSupplierToolstripbuttn.Image")));
            this.addNewSupplierToolstripbuttn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addNewSupplierToolstripbuttn.Name = "addNewSupplierToolstripbuttn";
            this.addNewSupplierToolstripbuttn.Size = new System.Drawing.Size(23, 22);
            this.addNewSupplierToolstripbuttn.Text = "Suppliers";
            this.addNewSupplierToolstripbuttn.Click += new System.EventHandler(this.openSupplier_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.ToolTipText = "Print Inventory (ctrl+P)";
            this.toolStripButton5.Click += new System.EventHandler(this.printInventory_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Stockin History";
            this.toolStripButton3.Click += new System.EventHandler(this.stockinLog_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Receipt Printer Settings";
            this.toolStripButton2.Click += new System.EventHandler(this.receiptConfig_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Shift Summary";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "toolStripButton6";
            this.toolStripButton6.ToolTipText = "Show/Hide Notes";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.Location = new System.Drawing.Point(115, 59);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tabHoldersPanel);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.label1);
            this.splitContainer.Panel2.Controls.Add(this.textBox1);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainer.Panel2Collapsed = true;
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(1060, 591);
            this.splitContainer.SplitterDistance = 893;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 4;
            // 
            // tabHoldersPanel
            // 
            this.tabHoldersPanel.Controls.Add(this.inventoryTab);
            this.tabHoldersPanel.Controls.Add(this.reportTab);
            this.tabHoldersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHoldersPanel.Location = new System.Drawing.Point(0, 0);
            this.tabHoldersPanel.Name = "tabHoldersPanel";
            this.tabHoldersPanel.Size = new System.Drawing.Size(1058, 589);
            this.tabHoldersPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note:";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(15, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(64, 68);
            this.textBox1.TabIndex = 1;
            // 
            // inventoryTab
            // 
            this.inventoryTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTab.Location = new System.Drawing.Point(0, 0);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Padding = new System.Windows.Forms.Padding(15);
            this.inventoryTab.Size = new System.Drawing.Size(1058, 589);
            this.inventoryTab.TabIndex = 2;
            // 
            // reportTab
            // 
            this.reportTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTab.Location = new System.Drawing.Point(0, 0);
            this.reportTab.Name = "reportTab";
            this.reportTab.Size = new System.Drawing.Size(1058, 589);
            this.reportTab.TabIndex = 1;
            this.reportTab.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 650);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.topMostPanel);
            this.Controls.Add(this.sideButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.sideButtonsPanel.ResumeLayout(false);
            this.topMostPanel.ResumeLayout(false);
            this.topMostPanel.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabHoldersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sideButtonsPanel;
        private System.Windows.Forms.Button inventoryBtn;
        private System.Windows.Forms.Button repBtn;
        private System.Windows.Forms.Panel topMostPanel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label appTitleLabel;
        private System.Windows.Forms.Button userButton;
       // private UserControls.InventoryUC inventoryTab;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton addNewSupplierToolstripbuttn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem addNewLoginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loginPrivilegesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel tabHoldersPanel;
        private UserControls.InventoryUC inventoryTab;
        private UserControls.ReportUC reportTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
    }
}

