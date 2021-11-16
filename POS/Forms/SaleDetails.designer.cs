namespace POS.Forms
{
    partial class SaleDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleDetails));
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.soldTo = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.Datetext = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.total = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.amountRecieved = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.address = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.contact = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.saleType = new System.Windows.Forms.TextBox();
            this.addPaymentGroup = new System.Windows.Forms.GroupBox();
            this.paymentNum = new System.Windows.Forms.NumericUpDown();
            this.addPaymentButton = new System.Windows.Forms.Button();
            this.remainGroup = new System.Windows.Forms.GroupBox();
            this.remaining = new System.Windows.Forms.TextBox();
            this.recHistBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.soldBy = new System.Windows.Forms.TextBox();
            this.voidBtn = new System.Windows.Forms.Button();
            this.editItemsBtn = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.SaleId = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.doc = new System.Drawing.Printing.PrintDocument();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.itemsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.addPaymentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paymentNum)).BeginInit();
            this.remainGroup.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsPanel
            // 
            this.itemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsPanel.BackColor = System.Drawing.Color.White;
            this.itemsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemsPanel.Controls.Add(this.label1);
            this.itemsPanel.Controls.Add(this.itemsTable);
            this.itemsPanel.Location = new System.Drawing.Point(12, 229);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(860, 231);
            this.itemsPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Items Sold";
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToDeleteRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.itemsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.itemsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTable.BackgroundColor = System.Drawing.Color.White;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.itemsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.serialCol,
            this.supplierCol,
            this.qtyCol,
            this.priceCol,
            this.discountCol,
            this.totalCol,
            this.actualQty,
            this.actualPrice,
            this.actualDiscount});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.GridColor = System.Drawing.Color.DarkGray;
            this.itemsTable.Location = new System.Drawing.Point(3, 21);
            this.itemsTable.MultiSelect = false;
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.itemsTable.RowHeadersVisible = false;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.itemsTable.Size = new System.Drawing.Size(852, 205);
            this.itemsTable.StandardTab = true;
            this.itemsTable.TabIndex = 1;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "NAME";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 264;
            // 
            // serialCol
            // 
            this.serialCol.HeaderText = "SERIAL";
            this.serialCol.Name = "serialCol";
            this.serialCol.ReadOnly = true;
            this.serialCol.Width = 106;
            // 
            // supplierCol
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.supplierCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.supplierCol.HeaderText = "SUPPLIER";
            this.supplierCol.Name = "supplierCol";
            this.supplierCol.ReadOnly = true;
            // 
            // qtyCol
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.qtyCol.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyCol.HeaderText = "QTY";
            this.qtyCol.Name = "qtyCol";
            this.qtyCol.ReadOnly = true;
            this.qtyCol.Width = 56;
            // 
            // priceCol
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.priceCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.priceCol.HeaderText = "PRICE";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            this.priceCol.Width = 58;
            // 
            // discountCol
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.discountCol.DefaultCellStyle = dataGridViewCellStyle6;
            this.discountCol.HeaderText = "DISCOUNT";
            this.discountCol.Name = "discountCol";
            this.discountCol.ReadOnly = true;
            // 
            // totalCol
            // 
            this.totalCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.totalCol.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalCol.HeaderText = "TOTAL";
            this.totalCol.Name = "totalCol";
            this.totalCol.ReadOnly = true;
            // 
            // actualQty
            // 
            this.actualQty.HeaderText = "qty";
            this.actualQty.Name = "actualQty";
            this.actualQty.ReadOnly = true;
            this.actualQty.Visible = false;
            // 
            // actualPrice
            // 
            this.actualPrice.HeaderText = "price";
            this.actualPrice.Name = "actualPrice";
            this.actualPrice.ReadOnly = true;
            this.actualPrice.Visible = false;
            // 
            // actualDiscount
            // 
            this.actualDiscount.HeaderText = "discount";
            this.actualDiscount.Name = "actualDiscount";
            this.actualDiscount.ReadOnly = true;
            this.actualDiscount.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.soldTo);
            this.groupBox8.Location = new System.Drawing.Point(399, 65);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(473, 47);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Sold to";
            // 
            // soldTo
            // 
            this.soldTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soldTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soldTo.Location = new System.Drawing.Point(7, 28);
            this.soldTo.Name = "soldTo";
            this.soldTo.ReadOnly = true;
            this.soldTo.Size = new System.Drawing.Size(460, 13);
            this.soldTo.TabIndex = 0;
            this.soldTo.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.Datetext);
            this.groupBox7.Location = new System.Drawing.Point(12, 171);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(381, 47);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Date";
            // 
            // Datetext
            // 
            this.Datetext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Datetext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Datetext.Location = new System.Drawing.Point(10, 23);
            this.Datetext.Name = "Datetext";
            this.Datetext.ReadOnly = true;
            this.Datetext.Size = new System.Drawing.Size(365, 13);
            this.Datetext.TabIndex = 0;
            this.Datetext.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.total);
            this.groupBox2.Location = new System.Drawing.Point(725, 466);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 47);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grand Total";
            // 
            // total
            // 
            this.total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.total.Location = new System.Drawing.Point(6, 23);
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Size = new System.Drawing.Size(134, 13);
            this.total.TabIndex = 0;
            this.total.TabStop = false;
            this.total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.amountRecieved);
            this.groupBox1.Location = new System.Drawing.Point(573, 466);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 47);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amount Recieved";
            // 
            // amountRecieved
            // 
            this.amountRecieved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amountRecieved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amountRecieved.Location = new System.Drawing.Point(6, 23);
            this.amountRecieved.Name = "amountRecieved";
            this.amountRecieved.ReadOnly = true;
            this.amountRecieved.Size = new System.Drawing.Size(134, 13);
            this.amountRecieved.TabIndex = 0;
            this.amountRecieved.TabStop = false;
            this.amountRecieved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.address);
            this.groupBox3.Location = new System.Drawing.Point(12, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 47);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Address";
            // 
            // address
            // 
            this.address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.address.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.address.Location = new System.Drawing.Point(7, 28);
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Size = new System.Drawing.Size(368, 13);
            this.address.TabIndex = 0;
            this.address.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.contact);
            this.groupBox4.Location = new System.Drawing.Point(399, 118);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(473, 47);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact Details";
            // 
            // contact
            // 
            this.contact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contact.Location = new System.Drawing.Point(7, 28);
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            this.contact.Size = new System.Drawing.Size(460, 13);
            this.contact.TabIndex = 0;
            this.contact.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.saleType);
            this.groupBox5.Location = new System.Drawing.Point(399, 171);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(473, 47);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Sale Type";
            // 
            // saleType
            // 
            this.saleType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saleType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saleType.Location = new System.Drawing.Point(10, 23);
            this.saleType.Name = "saleType";
            this.saleType.ReadOnly = true;
            this.saleType.Size = new System.Drawing.Size(457, 13);
            this.saleType.TabIndex = 0;
            this.saleType.TabStop = false;
            // 
            // addPaymentGroup
            // 
            this.addPaymentGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addPaymentGroup.Controls.Add(this.paymentNum);
            this.addPaymentGroup.Controls.Add(this.addPaymentButton);
            this.addPaymentGroup.Location = new System.Drawing.Point(159, 466);
            this.addPaymentGroup.Name = "addPaymentGroup";
            this.addPaymentGroup.Size = new System.Drawing.Size(256, 47);
            this.addPaymentGroup.TabIndex = 14;
            this.addPaymentGroup.TabStop = false;
            this.addPaymentGroup.Text = "Add Payment";
            // 
            // paymentNum
            // 
            this.paymentNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentNum.DecimalPlaces = 2;
            this.paymentNum.Location = new System.Drawing.Point(6, 21);
            this.paymentNum.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.paymentNum.Name = "paymentNum";
            this.paymentNum.Size = new System.Drawing.Size(194, 20);
            this.paymentNum.TabIndex = 2;
            this.paymentNum.ThousandsSeparator = true;
            this.paymentNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.paymentNum_KeyDown);
            // 
            // addPaymentButton
            // 
            this.addPaymentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addPaymentButton.Location = new System.Drawing.Point(206, 18);
            this.addPaymentButton.Name = "addPaymentButton";
            this.addPaymentButton.Size = new System.Drawing.Size(41, 23);
            this.addPaymentButton.TabIndex = 1;
            this.addPaymentButton.Text = "Add";
            this.addPaymentButton.UseVisualStyleBackColor = true;
            this.addPaymentButton.Click += new System.EventHandler(this.addPaymentButton_Click);
            // 
            // remainGroup
            // 
            this.remainGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.remainGroup.Controls.Add(this.remaining);
            this.remainGroup.Location = new System.Drawing.Point(421, 466);
            this.remainGroup.Name = "remainGroup";
            this.remainGroup.Size = new System.Drawing.Size(146, 47);
            this.remainGroup.TabIndex = 15;
            this.remainGroup.TabStop = false;
            this.remainGroup.Text = "Remaining";
            // 
            // remaining
            // 
            this.remaining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.remaining.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remaining.Location = new System.Drawing.Point(6, 23);
            this.remaining.Name = "remaining";
            this.remaining.ReadOnly = true;
            this.remaining.Size = new System.Drawing.Size(134, 13);
            this.remaining.TabIndex = 0;
            this.remaining.TabStop = false;
            this.remaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // recHistBtn
            // 
            this.recHistBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.recHistBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.recHistBtn.Location = new System.Drawing.Point(463, 6);
            this.recHistBtn.Name = "recHistBtn";
            this.recHistBtn.Size = new System.Drawing.Size(146, 23);
            this.recHistBtn.TabIndex = 16;
            this.recHistBtn.Text = "Show Payment History";
            this.recHistBtn.UseVisualStyleBackColor = false;
            this.recHistBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.soldBy);
            this.groupBox6.Location = new System.Drawing.Point(13, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(380, 47);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sold by";
            // 
            // soldBy
            // 
            this.soldBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soldBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soldBy.Location = new System.Drawing.Point(7, 28);
            this.soldBy.Name = "soldBy";
            this.soldBy.ReadOnly = true;
            this.soldBy.Size = new System.Drawing.Size(367, 13);
            this.soldBy.TabIndex = 0;
            this.soldBy.TabStop = false;
            // 
            // voidBtn
            // 
            this.voidBtn.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.voidBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.voidBtn.ForeColor = System.Drawing.Color.Black;
            this.voidBtn.Location = new System.Drawing.Point(6, 6);
            this.voidBtn.Name = "voidBtn";
            this.voidBtn.Size = new System.Drawing.Size(147, 23);
            this.voidBtn.TabIndex = 17;
            this.voidBtn.Text = "Void Sale";
            this.voidBtn.UseVisualStyleBackColor = false;
            this.voidBtn.Click += new System.EventHandler(this.voidBtn_Click);
            // 
            // editItemsBtn
            // 
            this.editItemsBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.editItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editItemsBtn.Location = new System.Drawing.Point(159, 6);
            this.editItemsBtn.Name = "editItemsBtn";
            this.editItemsBtn.Size = new System.Drawing.Size(146, 23);
            this.editItemsBtn.TabIndex = 17;
            this.editItemsBtn.Text = "Edit Items";
            this.editItemsBtn.UseVisualStyleBackColor = false;
            this.editItemsBtn.Click += new System.EventHandler(this.editItemsBtn_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.SaleId);
            this.groupBox9.Location = new System.Drawing.Point(13, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(859, 47);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Sale Id";
            // 
            // SaleId
            // 
            this.SaleId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SaleId.Location = new System.Drawing.Point(7, 28);
            this.SaleId.Name = "SaleId";
            this.SaleId.ReadOnly = true;
            this.SaleId.Size = new System.Drawing.Size(846, 13);
            this.SaleId.TabIndex = 0;
            this.SaleId.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(311, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Print Receipt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // doc
            // 
            this.doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.doc_BeginPrint);
            this.doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.doc_PrintPage);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.voidBtn);
            this.flowLayoutPanel1.Controls.Add(this.editItemsBtn);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.recHistBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 526);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(884, 35);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // SaleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.remainGroup);
            this.Controls.Add(this.addPaymentGroup);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.itemsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "SaleDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Details";
            this.Load += new System.EventHandler(this.SaleDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaleDetails_KeyDown);
            this.itemsPanel.ResumeLayout(false);
            this.itemsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.addPaymentGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paymentNum)).EndInit();
            this.remainGroup.ResumeLayout(false);
            this.remainGroup.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox soldTo;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox Datetext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox amountRecieved;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox contact;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox saleType;
        private System.Windows.Forms.GroupBox addPaymentGroup;
        private System.Windows.Forms.Button addPaymentButton;
        private System.Windows.Forms.NumericUpDown paymentNum;
        private System.Windows.Forms.GroupBox remainGroup;
        private System.Windows.Forms.TextBox remaining;
        private System.Windows.Forms.Button recHistBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox soldBy;
        private System.Windows.Forms.Button voidBtn;
        private System.Windows.Forms.Button editItemsBtn;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox SaleId;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument doc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualDiscount;
    }
}