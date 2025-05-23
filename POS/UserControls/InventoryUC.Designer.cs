﻿namespace POS.UserControls
{
    partial class InventoryUC
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryUC));
            this.tablePanel = new System.Windows.Forms.Panel();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ShowProgression = new System.Windows.Forms.DataGridViewButtonColumn();
            this.barcodeCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.departmentOption = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sellThisItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restockThisItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.viewStockBtn = new System.Windows.Forms.Button();
            this.stockinBtn = new System.Windows.Forms.Button();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.editItemBtn = new System.Windows.Forms.Button();
            this.addVariationsBtn = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.totalCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemCount = new System.Windows.Forms.Label();
            this.trackItemCheckbox = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.searchBar = new POS.UserControls.SearchControl();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.panel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.itemsTable);
            this.tablePanel.Controls.Add(this.panel5);
            this.tablePanel.Controls.Add(this.panel2);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(190, 0);
            this.tablePanel.Margin = new System.Windows.Forms.Padding(5);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(863, 645);
            this.tablePanel.TabIndex = 13;
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            this.itemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Id,
            this.col_ShowProgression,
            this.barcodeCol,
            this.nameCol,
            this.quantityCol,
            this.priceCol,
            this.col_Notes,
            this.col_Type});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5, 2, 20, 2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.itemsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.GridColor = System.Drawing.Color.LightGray;
            this.itemsTable.Location = new System.Drawing.Point(1, 39);
            this.itemsTable.Margin = new System.Windows.Forms.Padding(2);
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(862, 606);
            this.itemsTable.StandardTab = true;
            this.itemsTable.TabIndex = 3;
            this.itemsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellClick);
            this.itemsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellContentClick);
            this.itemsTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDoubleClick);
            this.itemsTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseDown);
            this.itemsTable.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellMouseEnter);
            this.itemsTable.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellMouseLeave);
            this.itemsTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.itemsTable_CellPainting);
            this.itemsTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.itemsTable_RowsAdded);
            this.itemsTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.itemsTable_RowsRemoved);
            this.itemsTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.itemsTable_Scroll);
            this.itemsTable.SelectionChanged += new System.EventHandler(this.itemsTable_SelectionChanged);
            this.itemsTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemsTable_KeyDown);
            // 
            // col_Id
            // 
            this.col_Id.HeaderText = "ID";
            this.col_Id.Name = "col_Id";
            this.col_Id.ReadOnly = true;
            this.col_Id.Visible = false;
            // 
            // col_ShowProgression
            // 
            this.col_ShowProgression.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            this.col_ShowProgression.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_ShowProgression.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.col_ShowProgression.HeaderText = "";
            this.col_ShowProgression.MinimumWidth = 40;
            this.col_ShowProgression.Name = "col_ShowProgression";
            this.col_ShowProgression.ReadOnly = true;
            this.col_ShowProgression.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_ShowProgression.Text = "";
            this.col_ShowProgression.UseColumnTextForButtonValue = true;
            this.col_ShowProgression.Width = 40;
            // 
            // barcodeCol
            // 
            this.barcodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(1);
            this.barcodeCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.barcodeCol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.barcodeCol.HeaderText = "BARCODE";
            this.barcodeCol.MinimumWidth = 50;
            this.barcodeCol.Name = "barcodeCol";
            this.barcodeCol.ReadOnly = true;
            this.barcodeCol.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.barcodeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.barcodeCol.ToolTipText = "Copy Barcode To Clipboard";
            this.barcodeCol.Width = 93;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "NAME";
            this.nameCol.MinimumWidth = 100;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // quantityCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "N/A";
            this.quantityCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.quantityCol.HeaderText = "QUANTITY";
            this.quantityCol.MinimumWidth = 50;
            this.quantityCol.Name = "quantityCol";
            this.quantityCol.ReadOnly = true;
            // 
            // priceCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            this.priceCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.priceCol.HeaderText = "SELLING PRICE";
            this.priceCol.MinimumWidth = 50;
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // col_Notes
            // 
            this.col_Notes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Notes.HeaderText = "NOTES";
            this.col_Notes.Name = "col_Notes";
            this.col_Notes.ReadOnly = true;
            this.col_Notes.Visible = false;
            // 
            // col_Type
            // 
            this.col_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.col_Type.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Type.HeaderText = "TYPE";
            this.col_Type.Name = "col_Type";
            this.col_Type.ReadOnly = true;
            this.col_Type.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.departmentOption);
            this.panel5.Controls.Add(this.flowLayoutPanel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(1, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(862, 39);
            this.panel5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Filter By Dept:";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(752, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show Item Notes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // departmentOption
            // 
            this.departmentOption.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.departmentOption.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentOption.FormattingEnabled = true;
            this.departmentOption.Location = new System.Drawing.Point(561, 7);
            this.departmentOption.Name = "departmentOption";
            this.departmentOption.Size = new System.Drawing.Size(180, 25);
            this.departmentOption.TabIndex = 6;
            this.toolTip1.SetToolTip(this.departmentOption, "Filter By Department");
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.radioButton1);
            this.flowLayoutPanel2.Controls.Add(this.radioButton2);
            this.flowLayoutPanel2.Controls.Add(this.radioButton3);
            this.flowLayoutPanel2.Controls.Add(this.radioButton4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 8);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(347, 23);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 3);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(72, 3);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(68, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Available";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(163, 3);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "In Critical Qty";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(273, 3);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(54, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Tag = "3";
            this.radioButton4.Text = "Empty";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 645);
            this.panel2.TabIndex = 8;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sellThisItemToolStripMenuItem,
            this.restockThisItemToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(172, 48);
            // 
            // sellThisItemToolStripMenuItem
            // 
            this.sellThisItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sellThisItemToolStripMenuItem.Image")));
            this.sellThisItemToolStripMenuItem.Name = "sellThisItemToolStripMenuItem";
            this.sellThisItemToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.sellThisItemToolStripMenuItem.Text = "Sell This Item?";
            this.sellThisItemToolStripMenuItem.Click += new System.EventHandler(this.sellThisItemToolStripMenuItem_Click);
            // 
            // restockThisItemToolStripMenuItem
            // 
            this.restockThisItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restockThisItemToolStripMenuItem.Image")));
            this.restockThisItemToolStripMenuItem.Name = "restockThisItemToolStripMenuItem";
            this.restockThisItemToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.restockThisItemToolStripMenuItem.Text = "Restock This Item?";
            this.restockThisItemToolStripMenuItem.Click += new System.EventHandler(this.restockThisItemToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(190, 40);
            this.button1.TabIndex = 12;
            this.button1.TabStop = false;
            this.button1.Text = "     Sell Items";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.sellItem_Click);
            // 
            // viewStockBtn
            // 
            this.viewStockBtn.BackColor = System.Drawing.Color.White;
            this.viewStockBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewStockBtn.Enabled = false;
            this.viewStockBtn.FlatAppearance.BorderSize = 0;
            this.viewStockBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewStockBtn.Image = ((System.Drawing.Image)(resources.GetObject("viewStockBtn.Image")));
            this.viewStockBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewStockBtn.Location = new System.Drawing.Point(0, 215);
            this.viewStockBtn.Margin = new System.Windows.Forms.Padding(5);
            this.viewStockBtn.Name = "viewStockBtn";
            this.viewStockBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.viewStockBtn.Size = new System.Drawing.Size(190, 40);
            this.viewStockBtn.TabIndex = 15;
            this.viewStockBtn.TabStop = false;
            this.viewStockBtn.Text = "     View Item Restocks";
            this.viewStockBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewStockBtn.UseVisualStyleBackColor = false;
            this.viewStockBtn.Click += new System.EventHandler(this.viewStockBtn_Click);
            // 
            // stockinBtn
            // 
            this.stockinBtn.BackColor = System.Drawing.Color.White;
            this.stockinBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.stockinBtn.FlatAppearance.BorderSize = 0;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockinBtn.Image = ((System.Drawing.Image)(resources.GetObject("stockinBtn.Image")));
            this.stockinBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stockinBtn.Location = new System.Drawing.Point(0, 40);
            this.stockinBtn.Margin = new System.Windows.Forms.Padding(5);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.stockinBtn.Size = new System.Drawing.Size(190, 40);
            this.stockinBtn.TabIndex = 13;
            this.stockinBtn.TabStop = false;
            this.stockinBtn.Text = "     Restock";
            this.stockinBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stockinBtn.UseVisualStyleBackColor = false;
            this.stockinBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.BackColor = System.Drawing.Color.White;
            this.addItemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addItemBtn.FlatAppearance.BorderSize = 0;
            this.addItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("addItemBtn.Image")));
            this.addItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addItemBtn.Location = new System.Drawing.Point(0, 80);
            this.addItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addItemBtn.Size = new System.Drawing.Size(190, 40);
            this.addItemBtn.TabIndex = 8;
            this.addItemBtn.TabStop = false;
            this.addItemBtn.Text = "     Create Item";
            this.addItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addItemBtn.UseVisualStyleBackColor = false;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // editItemBtn
            // 
            this.editItemBtn.BackColor = System.Drawing.Color.White;
            this.editItemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.editItemBtn.Enabled = false;
            this.editItemBtn.FlatAppearance.BorderSize = 0;
            this.editItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("editItemBtn.Image")));
            this.editItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editItemBtn.Location = new System.Drawing.Point(0, 135);
            this.editItemBtn.Margin = new System.Windows.Forms.Padding(5);
            this.editItemBtn.Name = "editItemBtn";
            this.editItemBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.editItemBtn.Size = new System.Drawing.Size(190, 40);
            this.editItemBtn.TabIndex = 9;
            this.editItemBtn.TabStop = false;
            this.editItemBtn.Text = "     View Item Details";
            this.editItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editItemBtn.UseVisualStyleBackColor = false;
            this.editItemBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addVariationsBtn
            // 
            this.addVariationsBtn.BackColor = System.Drawing.Color.White;
            this.addVariationsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.addVariationsBtn.Enabled = false;
            this.addVariationsBtn.FlatAppearance.BorderSize = 0;
            this.addVariationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVariationsBtn.Image = ((System.Drawing.Image)(resources.GetObject("addVariationsBtn.Image")));
            this.addVariationsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addVariationsBtn.Location = new System.Drawing.Point(0, 175);
            this.addVariationsBtn.Margin = new System.Windows.Forms.Padding(5);
            this.addVariationsBtn.Name = "addVariationsBtn";
            this.addVariationsBtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.addVariationsBtn.Size = new System.Drawing.Size(190, 40);
            this.addVariationsBtn.TabIndex = 10;
            this.addVariationsBtn.TabStop = false;
            this.addVariationsBtn.Text = "     View Item Sales";
            this.addVariationsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addVariationsBtn.UseVisualStyleBackColor = false;
            this.addVariationsBtn.Click += new System.EventHandler(this.ShodSoldItemsForItem_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.White;
            this.contentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentPanel.Controls.Add(this.tablePanel);
            this.contentPanel.Controls.Add(this.panel6);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 73);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1055, 647);
            this.contentPanel.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.button3);
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button5);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.button6);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.viewStockBtn);
            this.panel6.Controls.Add(this.addVariationsBtn);
            this.panel6.Controls.Add(this.editItemBtn);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.addItemBtn);
            this.panel6.Controls.Add(this.stockinBtn);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(190, 645);
            this.panel6.TabIndex = 12;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Enabled = false;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(0, 470);
            this.button7.Margin = new System.Windows.Forms.Padding(5);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(190, 40);
            this.button7.TabIndex = 26;
            this.button7.TabStop = false;
            this.button7.Text = "    Extract Data";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 430);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(190, 40);
            this.button3.TabIndex = 19;
            this.button3.TabStop = false;
            this.button3.Text = "    Items Time Table";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 390);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(190, 40);
            this.button2.TabIndex = 21;
            this.button2.TabStop = false;
            this.button2.Text = "    Print Inventory";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 350);
            this.button5.Margin = new System.Windows.Forms.Padding(5);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(190, 40);
            this.button5.TabIndex = 23;
            this.button5.TabStop = false;
            this.button5.Text = "    Stock-In Log";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 335);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 15);
            this.panel1.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(0, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(190, 1);
            this.panel4.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Enabled = false;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 295);
            this.button6.Margin = new System.Windows.Forms.Padding(5);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(190, 40);
            this.button6.TabIndex = 25;
            this.button6.TabStop = false;
            this.button6.Text = "     Remove Items";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 255);
            this.button4.Margin = new System.Windows.Forms.Padding(5);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(190, 40);
            this.button4.TabIndex = 24;
            this.button4.TabStop = false;
            this.button4.Text = "     Set Department";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.SetDepartment_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 120);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(190, 15);
            this.panel8.TabIndex = 17;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.Black;
            this.panel9.Location = new System.Drawing.Point(0, 7);
            this.panel9.Margin = new System.Windows.Forms.Padding(5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(190, 1);
            this.panel9.TabIndex = 12;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.totalCount);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.itemCount);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1055, 16);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // totalCount
            // 
            this.totalCount.AutoSize = true;
            this.totalCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.totalCount.ForeColor = System.Drawing.Color.Blue;
            this.totalCount.Location = new System.Drawing.Point(1039, 0);
            this.totalCount.Name = "totalCount";
            this.totalCount.Size = new System.Drawing.Size(13, 13);
            this.totalCount.TabIndex = 23;
            this.totalCount.Text = "0";
            this.totalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1023, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "|";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemCount
            // 
            this.itemCount.AutoSize = true;
            this.itemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemCount.ForeColor = System.Drawing.Color.Blue;
            this.itemCount.Location = new System.Drawing.Point(1004, 0);
            this.itemCount.Name = "itemCount";
            this.itemCount.Size = new System.Drawing.Size(13, 13);
            this.itemCount.TabIndex = 21;
            this.itemCount.Text = "0";
            this.itemCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackItemCheckbox
            // 
            this.trackItemCheckbox.AutoSize = true;
            this.trackItemCheckbox.Location = new System.Drawing.Point(15, 0);
            this.trackItemCheckbox.Name = "trackItemCheckbox";
            this.trackItemCheckbox.Size = new System.Drawing.Size(77, 17);
            this.trackItemCheckbox.TabIndex = 13;
            this.trackItemCheckbox.TabStop = false;
            this.trackItemCheckbox.Text = "Track Item";
            this.trackItemCheckbox.UseVisualStyleBackColor = true;
            this.trackItemCheckbox.CheckedChanged += new System.EventHandler(this.trackItemCheckbox_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.contentPanel);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1055, 720);
            this.panel3.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.searchBar);
            this.panel7.Controls.Add(this.trackItemCheckbox);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel7.Size = new System.Drawing.Size(1055, 57);
            this.panel7.TabIndex = 14;
            // 
            // searchBar
            // 
            this.searchBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchBar.BackColor = System.Drawing.Color.White;
            this.searchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBar.Location = new System.Drawing.Point(15, 17);
            this.searchBar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.searchBar.MaximumSize = new System.Drawing.Size(450, 35);
            this.searchBar.MinimumSize = new System.Drawing.Size(200, 40);
            this.searchBar.Name = "searchBar";
            this.searchBar.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchBar.SearchedText = "";
            this.searchBar.Size = new System.Drawing.Size(450, 40);
            this.searchBar.TabIndex = 1;
            this.searchBar.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchBar.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // InventoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Name = "InventoryUC";
            this.Size = new System.Drawing.Size(1055, 720);
            this.Load += new System.EventHandler(this.InventoryUC_Load);
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.Panel tablePanel;
        protected System.Windows.Forms.Button addItemBtn;
        protected System.Windows.Forms.Button editItemBtn;
        protected System.Windows.Forms.Button addVariationsBtn;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.Button stockinBtn;
        private System.Windows.Forms.Panel contentPanel;
        protected System.Windows.Forms.Button viewStockBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private SearchControl searchBar;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label itemCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox trackItemCheckbox;
        protected System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox departmentOption;
        private System.Windows.Forms.Label totalCount;
        protected System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Button button4;
        protected System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewButtonColumn col_ShowProgression;
        private System.Windows.Forms.DataGridViewButtonColumn barcodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Type;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem sellThisItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restockThisItemToolStripMenuItem;
    }
}
