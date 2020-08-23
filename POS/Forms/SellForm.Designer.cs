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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.discount = new System.Windows.Forms.NumericUpDown();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.totalPrice = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.maxQuant = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.advSearchBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchText = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serialNumber = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.itemName = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.addToCartBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cartTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addCustomerBtn = new System.Windows.Forms.Button();
            this.exactAmountBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.keypad = new POS.UserControls.Keypad();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkoutBtn = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.change = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.amountRecieved = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cartTotal = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.soldTo = new System.Windows.Forms.ComboBox();
            this.stockinBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discount)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountRecieved)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 274);
            this.panel1.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(678, 270);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox7);
            this.panel3.Controls.Add(this.groupBox12);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(672, 61);
            this.panel3.TabIndex = 16;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.discount);
            this.groupBox7.Location = new System.Drawing.Point(363, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(150, 54);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "DISCOUNT";
            // 
            // discount
            // 
            this.discount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.discount.BackColor = System.Drawing.SystemColors.Control;
            this.discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(3, 16);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(144, 31);
            this.discount.TabIndex = 0;
            this.discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.discount.ThousandsSeparator = true;
            this.discount.ValueChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.totalPrice);
            this.groupBox12.Location = new System.Drawing.Point(519, 4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(150, 54);
            this.groupBox12.TabIndex = 10;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "TOTAL";
            // 
            // totalPrice
            // 
            this.totalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(6, 18);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Size = new System.Drawing.Size(138, 28);
            this.totalPrice.TabIndex = 0;
            this.totalPrice.TabStop = false;
            this.totalPrice.Text = "0";
            this.totalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.price);
            this.groupBox5.Location = new System.Drawing.Point(210, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 54);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ITEM PRICE";
            // 
            // price
            // 
            this.price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.price.BackColor = System.Drawing.SystemColors.Control;
            this.price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.price.DecimalPlaces = 2;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(3, 16);
            this.price.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(144, 31);
            this.price.TabIndex = 2;
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.price.ThousandsSeparator = true;
            this.price.ValueChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.maxQuant);
            this.groupBox4.Controls.Add(this.quantity);
            this.groupBox4.Location = new System.Drawing.Point(7, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 54);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "QUANTITY";
            // 
            // maxQuant
            // 
            this.maxQuant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maxQuant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxQuant.Location = new System.Drawing.Point(109, 15);
            this.maxQuant.Name = "maxQuant";
            this.maxQuant.ReadOnly = true;
            this.maxQuant.Size = new System.Drawing.Size(82, 28);
            this.maxQuant.TabIndex = 2;
            this.maxQuant.TabStop = false;
            this.maxQuant.Text = "/1";
            this.maxQuant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // quantity
            // 
            this.quantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quantity.BackColor = System.Drawing.SystemColors.Control;
            this.quantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(3, 16);
            this.quantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(100, 31);
            this.quantity.TabIndex = 1;
            this.quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.quantity.ThousandsSeparator = true;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.stockinBtn);
            this.groupBox11.Controls.Add(this.advSearchBtn);
            this.groupBox11.Controls.Add(this.searchBtn);
            this.groupBox11.Controls.Add(this.searchText);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(672, 61);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "SEARCH";
            // 
            // advSearchBtn
            // 
            this.advSearchBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.advSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advSearchBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advSearchBtn.Location = new System.Drawing.Point(417, 18);
            this.advSearchBtn.Name = "advSearchBtn";
            this.advSearchBtn.Size = new System.Drawing.Size(120, 35);
            this.advSearchBtn.TabIndex = 13;
            this.advSearchBtn.Text = "(F1)  SEARCH";
            this.toolTip.SetToolTip(this.advSearchBtn, "For picking specific item");
            this.advSearchBtn.UseVisualStyleBackColor = true;
            this.advSearchBtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.Location = new System.Drawing.Point(375, 18);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(36, 35);
            this.searchBtn.TabIndex = 12;
            this.searchBtn.TabStop = false;
            this.toolTip.SetToolTip(this.searchBtn, "Search");
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.seachBtn_Click);
            // 
            // searchText
            // 
            this.searchText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchText.Location = new System.Drawing.Point(7, 18);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(368, 35);
            this.searchText.TabIndex = 0;
            this.toolTip.SetToolTip(this.searchText, "Search via barcode only");
            this.searchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchText_KeyDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 70);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(672, 61);
            this.panel5.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.serialNumber);
            this.groupBox1.Location = new System.Drawing.Point(334, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 55);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEM SERIAL NUMBER";
            // 
            // serialNumber
            // 
            this.serialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serialNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.serialNumber.BackColor = System.Drawing.SystemColors.Control;
            this.serialNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialNumber.FormattingEnabled = true;
            this.serialNumber.Location = new System.Drawing.Point(6, 15);
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.Size = new System.Drawing.Size(323, 32);
            this.serialNumber.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.itemName);
            this.groupBox3.Location = new System.Drawing.Point(7, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(321, 55);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ITEM NAME";
            // 
            // itemName
            // 
            this.itemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.Location = new System.Drawing.Point(7, 19);
            this.itemName.Name = "itemName";
            this.itemName.ReadOnly = true;
            this.itemName.Size = new System.Drawing.Size(308, 28);
            this.itemName.TabIndex = 0;
            this.itemName.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.addToCartBtn);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 204);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(672, 63);
            this.panel6.TabIndex = 18;
            // 
            // addToCartBtn
            // 
            this.addToCartBtn.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.addToCartBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addToCartBtn.Enabled = false;
            this.addToCartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToCartBtn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartBtn.Location = new System.Drawing.Point(0, 0);
            this.addToCartBtn.Name = "addToCartBtn";
            this.addToCartBtn.Size = new System.Drawing.Size(672, 63);
            this.addToCartBtn.TabIndex = 16;
            this.addToCartBtn.Text = "ADD TO CART";
            this.addToCartBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addToCartBtn.UseVisualStyleBackColor = false;
            this.addToCartBtn.Click += new System.EventHandler(this.addToCartBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(672, 66);
            this.button1.TabIndex = 14;
            this.button1.Text = "ADD TO CART";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cartTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 275);
            this.panel2.TabIndex = 15;
            // 
            // cartTable
            // 
            this.cartTable.AllowUserToAddRows = false;
            this.cartTable.AllowUserToDeleteRows = false;
            this.cartTable.AllowUserToResizeColumns = false;
            this.cartTable.AllowUserToResizeRows = false;
            this.cartTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartTable.BackgroundColor = System.Drawing.Color.White;
            this.cartTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cartTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cartTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cartTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column8,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column3,
            this.Column11,
            this.Column5,
            this.Column9,
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.cartTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.cartTable.EnableHeadersVisualStyles = false;
            this.cartTable.GridColor = System.Drawing.Color.White;
            this.cartTable.Location = new System.Drawing.Point(3, 3);
            this.cartTable.MultiSelect = false;
            this.cartTable.Name = "cartTable";
            this.cartTable.ReadOnly = true;
            this.cartTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.cartTable.RowHeadersVisible = false;
            this.cartTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cartTable.ShowCellToolTips = false;
            this.cartTable.Size = new System.Drawing.Size(672, 265);
            this.cartTable.StandardTab = true;
            this.cartTable.TabIndex = 16;
            this.cartTable.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "Serial";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 49;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 83;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 66;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 46;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Discount";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "Total Price";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 80;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Supplier";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 5;
            // 
            // addCustomerBtn
            // 
            this.addCustomerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCustomerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCustomerBtn.Image = ((System.Drawing.Image)(resources.GetObject("addCustomerBtn.Image")));
            this.addCustomerBtn.Location = new System.Drawing.Point(238, 17);
            this.addCustomerBtn.Name = "addCustomerBtn";
            this.addCustomerBtn.Size = new System.Drawing.Size(36, 37);
            this.addCustomerBtn.TabIndex = 11;
            this.addCustomerBtn.TabStop = false;
            this.toolTip.SetToolTip(this.addCustomerBtn, "Add Customer");
            this.addCustomerBtn.UseVisualStyleBackColor = true;
            this.addCustomerBtn.Click += new System.EventHandler(this.addCustomerBtn_Click);
            // 
            // exactAmountBtn
            // 
            this.exactAmountBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exactAmountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exactAmountBtn.Image = ((System.Drawing.Image)(resources.GetObject("exactAmountBtn.Image")));
            this.exactAmountBtn.Location = new System.Drawing.Point(119, 19);
            this.exactAmountBtn.Name = "exactAmountBtn";
            this.exactAmountBtn.Size = new System.Drawing.Size(36, 37);
            this.exactAmountBtn.TabIndex = 12;
            this.exactAmountBtn.TabStop = false;
            this.toolTip.SetToolTip(this.exactAmountBtn, "Recieve exact amount");
            this.exactAmountBtn.UseVisualStyleBackColor = true;
            this.exactAmountBtn.Click += new System.EventHandler(this.exactAmountBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.keypad, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(984, 561);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // keypad
            // 
            this.keypad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.keypad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.keypad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad.Location = new System.Drawing.Point(691, 3);
            this.keypad.Name = "keypad";
            this.keypad.Size = new System.Drawing.Size(290, 274);
            this.keypad.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.checkoutBtn);
            this.panel4.Controls.Add(this.groupBox10);
            this.panel4.Controls.Add(this.groupBox9);
            this.panel4.Controls.Add(this.groupBox6);
            this.panel4.Controls.Add(this.groupBox8);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(691, 283);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 275);
            this.panel4.TabIndex = 16;
            // 
            // checkoutBtn
            // 
            this.checkoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkoutBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.checkoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkoutBtn.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkoutBtn.Location = new System.Drawing.Point(3, 213);
            this.checkoutBtn.Name = "checkoutBtn";
            this.checkoutBtn.Size = new System.Drawing.Size(280, 51);
            this.checkoutBtn.TabIndex = 17;
            this.checkoutBtn.Text = "CHECK OUT";
            this.checkoutBtn.UseVisualStyleBackColor = false;
            this.checkoutBtn.Click += new System.EventHandler(this.checkoutBtn_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.change);
            this.groupBox10.Location = new System.Drawing.Point(170, 143);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(113, 64);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CHANGE";
            // 
            // change
            // 
            this.change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.change.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.Location = new System.Drawing.Point(6, 28);
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.Size = new System.Drawing.Size(101, 28);
            this.change.TabIndex = 0;
            this.change.TabStop = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.exactAmountBtn);
            this.groupBox9.Controls.Add(this.amountRecieved);
            this.groupBox9.Location = new System.Drawing.Point(3, 143);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(161, 64);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "AMOUNT RECIEVED";
            // 
            // amountRecieved
            // 
            this.amountRecieved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.amountRecieved.DecimalPlaces = 2;
            this.amountRecieved.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountRecieved.Location = new System.Drawing.Point(6, 21);
            this.amountRecieved.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.amountRecieved.Name = "amountRecieved";
            this.amountRecieved.Size = new System.Drawing.Size(107, 35);
            this.amountRecieved.TabIndex = 3;
            this.amountRecieved.ThousandsSeparator = true;
            this.amountRecieved.ValueChanged += new System.EventHandler(this.amountChangedCallback);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.cartTotal);
            this.groupBox6.Location = new System.Drawing.Point(3, 73);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 64);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "GRAND TOTAL";
            // 
            // cartTotal
            // 
            this.cartTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cartTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartTotal.Location = new System.Drawing.Point(6, 30);
            this.cartTotal.Name = "cartTotal";
            this.cartTotal.ReadOnly = true;
            this.cartTotal.Size = new System.Drawing.Size(268, 28);
            this.cartTotal.TabIndex = 0;
            this.cartTotal.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.soldTo);
            this.groupBox8.Controls.Add(this.addCustomerBtn);
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(280, 64);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "SOLD TO";
            // 
            // soldTo
            // 
            this.soldTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soldTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.soldTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.soldTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldTo.FormattingEnabled = true;
            this.soldTo.Location = new System.Drawing.Point(6, 17);
            this.soldTo.Name = "soldTo";
            this.soldTo.Size = new System.Drawing.Size(226, 37);
            this.soldTo.TabIndex = 12;
            this.soldTo.Leave += new System.EventHandler(this.soldTo_Leave);
            // 
            // stockinBtn
            // 
            this.stockinBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.stockinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockinBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockinBtn.Location = new System.Drawing.Point(543, 18);
            this.stockinBtn.Name = "stockinBtn";
            this.stockinBtn.Size = new System.Drawing.Size(120, 35);
            this.stockinBtn.TabIndex = 14;
            this.stockinBtn.Text = "(F2) STOCKIN";
            this.toolTip.SetToolTip(this.stockinBtn, "For picking specific item");
            this.stockinBtn.UseVisualStyleBackColor = true;
            this.stockinBtn.Click += new System.EventHandler(this.stockinBtn_Click);
            // 
            // SellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(860, 600);
            this.Name = "SellForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sell Item";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellForm_FormClosing);
            this.Load += new System.EventHandler(this.SellForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SellForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discount)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cartTable)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.amountRecieved)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView cartTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox searchText;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown discount;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox totalPrice;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button addToCartBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UserControls.Keypad keypad;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox soldTo;
        private System.Windows.Forms.Button addCustomerBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox cartTotal;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown amountRecieved;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox change;
        private System.Windows.Forms.Button checkoutBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.NumericUpDown price;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button exactAmountBtn;
        private System.Windows.Forms.Button advSearchBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
        private System.Windows.Forms.ComboBox serialNumber;
        private System.Windows.Forms.TextBox maxQuant;
        private System.Windows.Forms.Button stockinBtn;
    }
}