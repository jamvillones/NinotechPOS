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
            this.marker = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.repBtn = new System.Windows.Forms.Button();
            this.inventoryBtn = new System.Windows.Forms.Button();
            this.userButton = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.loginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginPrivilegesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLoginDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tabHoldersPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.inventoryTab = new POS.UserControls.InventoryUC();
            this.reportTab = new POS.UserControls.ReportUC();
            this.sideButtonsPanel.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabHoldersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideButtonsPanel
            // 
            this.sideButtonsPanel.BackColor = System.Drawing.Color.White;
            this.sideButtonsPanel.Controls.Add(this.marker);
            this.sideButtonsPanel.Controls.Add(this.button2);
            this.sideButtonsPanel.Controls.Add(this.button1);
            this.sideButtonsPanel.Controls.Add(this.repBtn);
            this.sideButtonsPanel.Controls.Add(this.inventoryBtn);
            this.sideButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.sideButtonsPanel.Name = "sideButtonsPanel";
            this.sideButtonsPanel.Size = new System.Drawing.Size(120, 591);
            this.sideButtonsPanel.TabIndex = 0;
            this.toolTip.SetToolTip(this.sideButtonsPanel, "Double click to hide/show");
            this.sideButtonsPanel.DoubleClick += new System.EventHandler(this.sideButtonsPanel_DoubleClick);
            // 
            // marker
            // 
            this.marker.BackColor = System.Drawing.Color.Black;
            this.marker.Location = new System.Drawing.Point(0, 0);
            this.marker.Name = "marker";
            this.marker.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.marker.Size = new System.Drawing.Size(2, 100);
            this.marker.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(0, 300);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 100);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Text = "\r\nZ-REPORT";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 200);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 100);
            this.button1.TabIndex = 3;
            this.button1.TabStop = false;
            this.button1.Text = "\r\nCUSTOMERS";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.createCustomer_Click);
            // 
            // repBtn
            // 
            this.repBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.repBtn.FlatAppearance.BorderSize = 0;
            this.repBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repBtn.ForeColor = System.Drawing.Color.Black;
            this.repBtn.Image = ((System.Drawing.Image)(resources.GetObject("repBtn.Image")));
            this.repBtn.Location = new System.Drawing.Point(0, 100);
            this.repBtn.Margin = new System.Windows.Forms.Padding(0);
            this.repBtn.Name = "repBtn";
            this.repBtn.Padding = new System.Windows.Forms.Padding(10);
            this.repBtn.Size = new System.Drawing.Size(120, 100);
            this.repBtn.TabIndex = 2;
            this.repBtn.TabStop = false;
            this.repBtn.Text = "\r\nTransactions";
            this.repBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.repBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.repBtn.UseVisualStyleBackColor = true;
            this.repBtn.Click += new System.EventHandler(this.repBtn_Click);
            // 
            // inventoryBtn
            // 
            this.inventoryBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.inventoryBtn.FlatAppearance.BorderSize = 0;
            this.inventoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventoryBtn.ForeColor = System.Drawing.Color.Black;
            this.inventoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("inventoryBtn.Image")));
            this.inventoryBtn.Location = new System.Drawing.Point(0, 0);
            this.inventoryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.inventoryBtn.Name = "inventoryBtn";
            this.inventoryBtn.Padding = new System.Windows.Forms.Padding(10);
            this.inventoryBtn.Size = new System.Drawing.Size(120, 100);
            this.inventoryBtn.TabIndex = 1;
            this.inventoryBtn.TabStop = false;
            this.inventoryBtn.Text = "\r\nProducts";
            this.inventoryBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.inventoryBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inventoryBtn.UseVisualStyleBackColor = false;
            this.inventoryBtn.Click += new System.EventHandler(this.inventoryBtn_Click);
            // 
            // userButton
            // 
            this.userButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userButton.AutoSize = true;
            this.userButton.FlatAppearance.BorderSize = 0;
            this.userButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userButton.Image = ((System.Drawing.Image)(resources.GetObject("userButton.Image")));
            this.userButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userButton.Location = new System.Drawing.Point(865, 0);
            this.userButton.Margin = new System.Windows.Forms.Padding(0);
            this.userButton.Name = "userButton";
            this.userButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.userButton.Size = new System.Drawing.Size(119, 25);
            this.userButton.TabIndex = 5;
            this.userButton.TabStop = false;
            this.userButton.Text = "   Username";
            this.userButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.userButton, "Log Out?");
            this.userButton.UseVisualStyleBackColor = false;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(15, 15);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripButton1,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton2});
            this.toolStrip.Location = new System.Drawing.Point(120, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(864, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginsToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.suppliersToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripDropDownButton2.Text = "Edit";
            // 
            // loginsToolStripMenuItem
            // 
            this.loginsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginPrivilegesToolStripMenuItem,
            this.addNewLoginToolStripMenuItem,
            this.editLoginDetailsToolStripMenuItem});
            this.loginsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loginsToolStripMenuItem.Image")));
            this.loginsToolStripMenuItem.Name = "loginsToolStripMenuItem";
            this.loginsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.loginsToolStripMenuItem.Text = "Logins";
            // 
            // loginPrivilegesToolStripMenuItem
            // 
            this.loginPrivilegesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loginPrivilegesToolStripMenuItem.Image")));
            this.loginPrivilegesToolStripMenuItem.Name = "loginPrivilegesToolStripMenuItem";
            this.loginPrivilegesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loginPrivilegesToolStripMenuItem.Text = "Login Privileges";
            this.loginPrivilegesToolStripMenuItem.Click += new System.EventHandler(this.loginPrivilegesToolStripMenuItem_Click);
            // 
            // addNewLoginToolStripMenuItem
            // 
            this.addNewLoginToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addNewLoginToolStripMenuItem.Image")));
            this.addNewLoginToolStripMenuItem.Name = "addNewLoginToolStripMenuItem";
            this.addNewLoginToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.addNewLoginToolStripMenuItem.Text = "Create New Login";
            this.addNewLoginToolStripMenuItem.Click += new System.EventHandler(this.addNewLoginToolStripMenuItem_Click);
            // 
            // editLoginDetailsToolStripMenuItem
            // 
            this.editLoginDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editLoginDetailsToolStripMenuItem.Image")));
            this.editLoginDetailsToolStripMenuItem.Name = "editLoginDetailsToolStripMenuItem";
            this.editLoginDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.editLoginDetailsToolStripMenuItem.Text = "Change Login Details";
            this.editLoginDetailsToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("customersToolStripMenuItem.Image")));
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.createCustomer_Click);
            // 
            // suppliersToolStripMenuItem
            // 
            this.suppliersToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.suppliersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("suppliersToolStripMenuItem.Image")));
            this.suppliersToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.suppliersToolStripMenuItem.Name = "suppliersToolStripMenuItem";
            this.suppliersToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.suppliersToolStripMenuItem.Text = "Suppliers";
            this.suppliersToolStripMenuItem.Click += new System.EventHandler(this.openSupplier_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(93, 22);
            this.toolStripButton1.Text = "Stockin Log";
            this.toolStripButton1.Click += new System.EventHandler(this.stockinLog_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripButton5.Size = new System.Drawing.Size(109, 22);
            this.toolStripButton5.Text = "Print Inventory";
            this.toolStripButton5.ToolTipText = "Print Inventory (ctrl+P)";
            this.toolStripButton5.Click += new System.EventHandler(this.printInventory_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripButton4.Size = new System.Drawing.Size(109, 22);
            this.toolStripButton4.Text = "Shift Summary";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(153, 22);
            this.toolStripButton2.Text = "Receipt Printer Settings";
            this.toolStripButton2.Click += new System.EventHandler(this.receiptConfig_Click);
            // 
            // tabHoldersPanel
            // 
            this.tabHoldersPanel.Controls.Add(this.inventoryTab);
            this.tabHoldersPanel.Controls.Add(this.reportTab);
            this.tabHoldersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabHoldersPanel.Location = new System.Drawing.Point(120, 25);
            this.tabHoldersPanel.Name = "tabHoldersPanel";
            this.tabHoldersPanel.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.tabHoldersPanel.Size = new System.Drawing.Size(864, 566);
            this.tabHoldersPanel.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "POS";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // inventoryTab
            // 
            this.inventoryTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTab.Location = new System.Drawing.Point(20, 20);
            this.inventoryTab.Name = "inventoryTab";
            this.inventoryTab.Size = new System.Drawing.Size(824, 546);
            this.inventoryTab.TabIndex = 2;
            // 
            // reportTab
            // 
            this.reportTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportTab.Location = new System.Drawing.Point(20, 20);
            this.reportTab.Name = "reportTab";
            this.reportTab.Size = new System.Drawing.Size(824, 546);
            this.reportTab.TabIndex = 1;
            this.reportTab.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.userButton);
            this.Controls.Add(this.tabHoldersPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.sideButtonsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(860, 490);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.sideButtonsPanel.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabHoldersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel sideButtonsPanel;
        private System.Windows.Forms.Button inventoryBtn;
        private System.Windows.Forms.Button repBtn;
        private System.Windows.Forms.Button userButton;
       // private UserControls.InventoryUC inventoryTab;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel tabHoldersPanel;
        private UserControls.InventoryUC inventoryTab;
        private UserControls.ReportUC reportTab;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suppliersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginPrivilegesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLoginDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel marker;
        private System.Windows.Forms.ToolStripMenuItem addNewLoginToolStripMenuItem;
    }
}

