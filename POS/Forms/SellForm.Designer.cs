﻿namespace POS.Forms
{
    partial class SellForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cartTable = new System.Windows.Forms.DataGridView();
            this.col_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadingTxt = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.totalTxt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this._customerOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.changeTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.tendered = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.discount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.grandTotalTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tendered)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discount)).BeginInit();
            this.panel9.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(10, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1MinSize = 500;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(964, 427);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cartTable);
            this.panel1.Controls.Add(this.loadingTxt);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 427);
            this.panel1.TabIndex = 0;
            // 
            // cartTable
            // 
            this.cartTable.AllowUserToAddRows = false;
            this.cartTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.cartTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cartTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cartTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.cartTable.BackgroundColor = System.Drawing.Color.White;
            this.cartTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.cartTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.cartTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Barcode,
            this.col_Name,
            this.col_Serial,
            this.col_Qty,
            this.col_Price,
            this.col_Discount,
            this.col_SubTotal});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.cartTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartTable.EnableHeadersVisualStyles = false;
            this.cartTable.Location = new System.Drawing.Point(0, 48);
            this.cartTable.MultiSelect = false;
            this.cartTable.Name = "cartTable";
            this.cartTable.ReadOnly = true;
            this.cartTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cartTable.RowHeadersVisible = false;
            this.cartTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartTable.ShowCellToolTips = false;
            this.cartTable.Size = new System.Drawing.Size(550, 319);
            this.cartTable.StandardTab = true;
            this.cartTable.TabIndex = 3;
            this.cartTable.TabStop = false;
            this.cartTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.cartTable_RowsAdded);
            // 
            // col_Barcode
            // 
            this.col_Barcode.HeaderText = "ID";
            this.col_Barcode.Name = "col_Barcode";
            this.col_Barcode.ReadOnly = true;
            this.col_Barcode.Visible = false;
            // 
            // col_Name
            // 
            this.col_Name.HeaderText = "NAME";
            this.col_Name.Name = "col_Name";
            this.col_Name.ReadOnly = true;
            // 
            // col_Serial
            // 
            this.col_Serial.HeaderText = "SERIAL";
            this.col_Serial.Name = "col_Serial";
            this.col_Serial.ReadOnly = true;
            // 
            // col_Qty
            // 
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Qty.HeaderText = "QTY";
            this.col_Qty.Name = "col_Qty";
            this.col_Qty.ReadOnly = true;
            // 
            // col_Price
            // 
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.col_Price.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Price.HeaderText = "PRICE";
            this.col_Price.Name = "col_Price";
            this.col_Price.ReadOnly = true;
            // 
            // col_Discount
            // 
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.col_Discount.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Discount.HeaderText = "DISC";
            this.col_Discount.Name = "col_Discount";
            this.col_Discount.ReadOnly = true;
            // 
            // col_SubTotal
            // 
            this.col_SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.col_SubTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_SubTotal.HeaderText = "SUBTOTAL";
            this.col_SubTotal.Name = "col_SubTotal";
            this.col_SubTotal.ReadOnly = true;
            // 
            // loadingTxt
            // 
            this.loadingTxt.AutoSize = true;
            this.loadingTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadingTxt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingTxt.Location = new System.Drawing.Point(0, 35);
            this.loadingTxt.Name = "loadingTxt";
            this.loadingTxt.Size = new System.Drawing.Size(0, 13);
            this.loadingTxt.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 367);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(550, 10);
            this.panel5.TabIndex = 19;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.totalTxt);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 377);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(550, 50);
            this.panel10.TabIndex = 4;
            // 
            // totalTxt
            // 
            this.totalTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTxt.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTxt.ForeColor = System.Drawing.Color.Blue;
            this.totalTxt.Location = new System.Drawing.Point(0, 13);
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.Padding = new System.Windows.Forms.Padding(5);
            this.totalTxt.Size = new System.Drawing.Size(548, 35);
            this.totalTxt.TabIndex = 2;
            this.totalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Total:";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.searchControl1);
            this.panel11.Controls.Add(this.button1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(550, 35);
            this.panel11.TabIndex = 23;
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl1.BackColor = System.Drawing.SystemColors.Window;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Location = new System.Drawing.Point(0, 0);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.MinimumSize = new System.Drawing.Size(2, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 1;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(360, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Advanced [F1]";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 427);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this._customerOption);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 300);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.panel4.Size = new System.Drawing.Size(404, 50);
            this.panel4.TabIndex = 5;
            // 
            // _customerOption
            // 
            this._customerOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this._customerOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._customerOption.BackColor = System.Drawing.Color.White;
            this._customerOption.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._customerOption.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._customerOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._customerOption.FormattingEnabled = true;
            this._customerOption.Location = new System.Drawing.Point(10, 18);
            this._customerOption.Name = "_customerOption";
            this._customerOption.Size = new System.Drawing.Size(384, 32);
            this._customerOption.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkBox1.ForeColor = System.Drawing.Color.Navy;
            this.checkBox1.Location = new System.Drawing.Point(0, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.checkBox1.Size = new System.Drawing.Size(404, 27);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Print Reciept";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(404, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Checkout";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.changeTxt);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 150);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(404, 50);
            this.panel7.TabIndex = 4;
            // 
            // changeTxt
            // 
            this.changeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeTxt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.changeTxt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.changeTxt.Location = new System.Drawing.Point(0, 13);
            this.changeTxt.Name = "changeTxt";
            this.changeTxt.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.changeTxt.Size = new System.Drawing.Size(402, 35);
            this.changeTxt.TabIndex = 2;
            this.changeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Change:";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.tendered);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 100);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(404, 50);
            this.panel8.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(5, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Exact Amount";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tendered
            // 
            this.tendered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tendered.BackColor = System.Drawing.Color.White;
            this.tendered.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tendered.DecimalPlaces = 2;
            this.tendered.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendered.Location = new System.Drawing.Point(159, 19);
            this.tendered.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.tendered.Name = "tendered";
            this.tendered.Size = new System.Drawing.Size(232, 25);
            this.tendered.TabIndex = 1;
            this.tendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tendered.ThousandsSeparator = true;
            this.tendered.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.tendered.ValueChanged += new System.EventHandler(this.tendered_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tendered:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.discount);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(404, 50);
            this.panel6.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(5, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(149, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Full Discount";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // discount
            // 
            this.discount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discount.BackColor = System.Drawing.Color.White;
            this.discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.discount.DecimalPlaces = 2;
            this.discount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(159, 19);
            this.discount.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(232, 25);
            this.discount.TabIndex = 1;
            this.discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount.ThousandsSeparator = true;
            this.discount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.discount.ValueChanged += new System.EventHandler(this.discount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Discount:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.grandTotalTxt);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(404, 50);
            this.panel9.TabIndex = 1;
            // 
            // grandTotalTxt
            // 
            this.grandTotalTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grandTotalTxt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.grandTotalTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grandTotalTxt.Location = new System.Drawing.Point(0, 13);
            this.grandTotalTxt.Name = "grandTotalTxt";
            this.grandTotalTxt.Padding = new System.Windows.Forms.Padding(5);
            this.grandTotalTxt.Size = new System.Drawing.Size(402, 35);
            this.grandTotalTxt.TabIndex = 2;
            this.grandTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Amount Due:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 427);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.sessionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.sessionToolStripMenuItem.Text = "Session";
            // 
            // SellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "SellForm";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sell";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SellForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tendered)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discount)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView cartTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _customerOption;
        private System.Windows.Forms.Label changeTxt;
        private System.Windows.Forms.NumericUpDown discount;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.NumericUpDown tendered;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SubTotal;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label grandTotalTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label totalTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel11;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.Label loadingTxt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}