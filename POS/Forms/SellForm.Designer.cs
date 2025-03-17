namespace POS.Forms
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
            this.components = new System.ComponentModel.Container();
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
            this.itemcountLabel = new System.Windows.Forms.Label();
            this.cartTable = new System.Windows.Forms.DataGridView();
            this.col_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.editQtyBtn = new System.Windows.Forms.Button();
            this.priceBtn = new System.Windows.Forms.Button();
            this.discBtn = new System.Windows.Forms.Button();
            this.loadingTxt = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.totalTxt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.changeTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.grandTotalTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.customerTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.tendered = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.discount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tendered)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
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
            this.splitContainer1.Size = new System.Drawing.Size(1113, 686);
            this.splitContainer1.SplitterDistance = 667;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.itemcountLabel);
            this.panel1.Controls.Add(this.cartTable);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.loadingTxt);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 686);
            this.panel1.TabIndex = 0;
            // 
            // itemcountLabel
            // 
            this.itemcountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.itemcountLabel.Location = new System.Drawing.Point(477, 53);
            this.itemcountLabel.Name = "itemcountLabel";
            this.itemcountLabel.Size = new System.Drawing.Size(187, 18);
            this.itemcountLabel.TabIndex = 5;
            this.itemcountLabel.Text = "0";
            this.itemcountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.itemcountLabel.Click += new System.EventHandler(this.itemcountLabel_Click);
            // 
            // cartTable
            // 
            this.cartTable.AllowUserToAddRows = false;
            this.cartTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.cartTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.cartTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cartTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.cartTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.cartTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartTable.DefaultCellStyle = dataGridViewCellStyle7;
            this.cartTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartTable.EnableHeadersVisualStyles = false;
            this.cartTable.Location = new System.Drawing.Point(0, 74);
            this.cartTable.Name = "cartTable";
            this.cartTable.ReadOnly = true;
            this.cartTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cartTable.RowHeadersVisible = false;
            this.cartTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartTable.ShowCellToolTips = false;
            this.cartTable.Size = new System.Drawing.Size(667, 512);
            this.cartTable.StandardTab = true;
            this.cartTable.TabIndex = 2;
            this.cartTable.TabStop = false;
            this.cartTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.cartTable_RowsAdded);
            this.cartTable.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.cartTable_RowsRemoved);
            this.cartTable.SelectionChanged += new System.EventHandler(this.cartTable_SelectionChanged);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.editQtyBtn);
            this.flowLayoutPanel1.Controls.Add(this.priceBtn);
            this.flowLayoutPanel1.Controls.Add(this.discBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 586);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(667, 50);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // editQtyBtn
            // 
            this.editQtyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editQtyBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.editQtyBtn.Enabled = false;
            this.editQtyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editQtyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editQtyBtn.Location = new System.Drawing.Point(0, 5);
            this.editQtyBtn.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.editQtyBtn.Name = "editQtyBtn";
            this.editQtyBtn.Size = new System.Drawing.Size(149, 40);
            this.editQtyBtn.TabIndex = 10;
            this.editQtyBtn.Text = "Edit Quantity";
            this.editQtyBtn.UseVisualStyleBackColor = false;
            this.editQtyBtn.Click += new System.EventHandler(this.editQtyBtn_Click);
            // 
            // priceBtn
            // 
            this.priceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.priceBtn.Enabled = false;
            this.priceBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.priceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.priceBtn.Location = new System.Drawing.Point(154, 5);
            this.priceBtn.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.priceBtn.Name = "priceBtn";
            this.priceBtn.Size = new System.Drawing.Size(149, 40);
            this.priceBtn.TabIndex = 8;
            this.priceBtn.Text = "Edit Price";
            this.priceBtn.UseVisualStyleBackColor = false;
            this.priceBtn.Click += new System.EventHandler(this.priceBtn_Click);
            // 
            // discBtn
            // 
            this.discBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.discBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.discBtn.Enabled = false;
            this.discBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.discBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discBtn.Location = new System.Drawing.Point(308, 5);
            this.discBtn.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.discBtn.Name = "discBtn";
            this.discBtn.Size = new System.Drawing.Size(149, 40);
            this.discBtn.TabIndex = 9;
            this.discBtn.Text = "Edit Discount";
            this.discBtn.UseVisualStyleBackColor = false;
            this.discBtn.Click += new System.EventHandler(this.discBtn_Click);
            // 
            // loadingTxt
            // 
            this.loadingTxt.AutoSize = true;
            this.loadingTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadingTxt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingTxt.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingTxt.Location = new System.Drawing.Point(0, 50);
            this.loadingTxt.Name = "loadingTxt";
            this.loadingTxt.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.loadingTxt.Size = new System.Drawing.Size(5, 24);
            this.loadingTxt.TabIndex = 0;
            this.loadingTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.totalTxt);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 636);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(667, 50);
            this.panel10.TabIndex = 4;
            // 
            // totalTxt
            // 
            this.totalTxt.BackColor = System.Drawing.Color.White;
            this.totalTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalTxt.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTxt.ForeColor = System.Drawing.Color.Blue;
            this.totalTxt.Location = new System.Drawing.Point(0, 13);
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.Padding = new System.Windows.Forms.Padding(5);
            this.totalTxt.Size = new System.Drawing.Size(665, 35);
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
            this.panel11.Controls.Add(this.button1);
            this.panel11.Controls.Add(this.searchControl1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(667, 50);
            this.panel11.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(477, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Choose Item";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl1.BackColor = System.Drawing.SystemColors.Window;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Location = new System.Drawing.Point(0, 0);
            this.searchControl1.MaximumSize = new System.Drawing.Size(650, 50);
            this.searchControl1.MinimumSize = new System.Drawing.Size(2, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(467, 50);
            this.searchControl1.TabIndex = 1;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.checkoutBtn);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 686);
            this.panel2.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.changeTxt);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 200);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(426, 50);
            this.panel7.TabIndex = 4;
            // 
            // changeTxt
            // 
            this.changeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeTxt.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.changeTxt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.changeTxt.Location = new System.Drawing.Point(0, 13);
            this.changeTxt.Name = "changeTxt";
            this.changeTxt.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.changeTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.changeTxt.Size = new System.Drawing.Size(424, 35);
            this.changeTxt.TabIndex = 2;
            this.changeTxt.Text = "0.00";
            this.changeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Change:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.grandTotalTxt);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 150);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(426, 50);
            this.panel9.TabIndex = 1;
            // 
            // grandTotalTxt
            // 
            this.grandTotalTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grandTotalTxt.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.grandTotalTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grandTotalTxt.Location = new System.Drawing.Point(0, 13);
            this.grandTotalTxt.Name = "grandTotalTxt";
            this.grandTotalTxt.Padding = new System.Windows.Forms.Padding(5);
            this.grandTotalTxt.Size = new System.Drawing.Size(424, 35);
            this.grandTotalTxt.TabIndex = 2;
            this.grandTotalTxt.Text = "0.00";
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.customerTxt);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 559);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel4.Size = new System.Drawing.Size(426, 50);
            this.panel4.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(389, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.toolTip1.SetToolTip(this.button2, "Change Customer");
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.changeCustomer_Click);
            // 
            // customerTxt
            // 
            this.customerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerTxt.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.customerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerTxt.ForeColor = System.Drawing.Color.Blue;
            this.customerTxt.Location = new System.Drawing.Point(5, 13);
            this.customerTxt.Name = "customerTxt";
            this.customerTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.customerTxt.Size = new System.Drawing.Size(378, 30);
            this.customerTxt.TabIndex = 3;
            this.customerTxt.Text = "loading...";
            this.customerTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(5, 0);
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
            this.checkBox1.Location = new System.Drawing.Point(0, 609);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.checkBox1.Size = new System.Drawing.Size(426, 27);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Print Reciept";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.checkoutBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkoutBtn.Enabled = false;
            this.checkoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutBtn.Location = new System.Drawing.Point(0, 636);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(426, 50);
            this.checkoutBtn.TabIndex = 8;
            this.checkoutBtn.Text = "CHECKOUT";
            this.checkoutBtn.UseVisualStyleBackColor = false;
            this.checkoutBtn.Click += new System.EventHandler(this.checkout_Click);
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
            this.panel8.Size = new System.Drawing.Size(426, 50);
            this.panel8.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(4, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
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
            this.tendered.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.tendered.ForeColor = System.Drawing.Color.Green;
            this.tendered.Location = new System.Drawing.Point(110, 15);
            this.tendered.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.tendered.Name = "tendered";
            this.tendered.Size = new System.Drawing.Size(302, 30);
            this.tendered.TabIndex = 1;
            this.tendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tendered.ThousandsSeparator = true;
            this.tendered.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.tendered.ValueChanged += new System.EventHandler(this.tendered_ValueChanged);
            this.tendered.Validated += new System.EventHandler(this.upDown_Validated);
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
            this.panel6.Size = new System.Drawing.Size(426, 50);
            this.panel6.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(4, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 30);
            this.button4.TabIndex = 3;
            this.button4.TabStop = false;
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
            this.discount.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.discount.ForeColor = System.Drawing.Color.Green;
            this.discount.Location = new System.Drawing.Point(110, 15);
            this.discount.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(302, 30);
            this.discount.TabIndex = 5;
            this.discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.discount.ThousandsSeparator = true;
            this.discount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.discount.ValueChanged += new System.EventHandler(this.discount_ValueChanged);
            this.discount.Validated += new System.EventHandler(this.upDown_Validated);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 50);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(5, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(407, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0000000000";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "OR Number:";
            // 
            // printDoc
            // 
            this.printDoc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDoc_BeginPrint);
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sell";
            this.notifyIcon1.Visible = true;
            // 
            // SellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 706);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "SellForm";
            this.Padding = new System.Windows.Forms.Padding(10);
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tendered)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView cartTable;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label changeTxt;
        private System.Windows.Forms.NumericUpDown discount;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.NumericUpDown tendered;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button checkoutBtn;
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
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label totalTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel11;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.Label loadingTxt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button priceBtn;
        private System.Windows.Forms.Button discBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.Button editQtyBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label customerTxt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label itemcountLabel;
    }
}