namespace POS.UserControls
{
    partial class ReportUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportUC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saleTable = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.regularSalesTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboFilterType = new System.Windows.Forms.ComboBox();
            this.dtFilter = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalSale = new System.Windows.Forms.Label();
            this.chargedPage = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.toBeSettledTxt = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.saleStatus = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chargedSaleSearch = new System.Windows.Forms.TextBox();
            this.chargedSearchBtn = new System.Windows.Forms.Button();
            this.chargedTable = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saleTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.regularSalesTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.chargedPage.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedTable)).BeginInit();
            this.SuspendLayout();
            // 
            // saleTable
            // 
            this.saleTable.AllowUserToAddRows = false;
            this.saleTable.AllowUserToDeleteRows = false;
            this.saleTable.AllowUserToResizeColumns = false;
            this.saleTable.AllowUserToResizeRows = false;
            this.saleTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saleTable.BackgroundColor = System.Drawing.Color.White;
            this.saleTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saleTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.saleTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.saleTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.saleTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.saleTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.saleTable.EnableHeadersVisualStyles = false;
            this.saleTable.Location = new System.Drawing.Point(7, 56);
            this.saleTable.MultiSelect = false;
            this.saleTable.Name = "saleTable";
            this.saleTable.ReadOnly = true;
            this.saleTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.saleTable.RowHeadersVisible = false;
            this.saleTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleTable.Size = new System.Drawing.Size(730, 334);
            this.saleTable.StandardTab = true;
            this.saleTable.TabIndex = 1;
            this.saleTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.saleTable_CellMouseDoubleClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "SaleId";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Date";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 54;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Sold By";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Purchased By";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Total Sale";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 78;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.regularSalesTab);
            this.tabControl1.Controls.Add(this.chargedPage);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(18, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(751, 474);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // regularSalesTab
            // 
            this.regularSalesTab.BackColor = System.Drawing.Color.White;
            this.regularSalesTab.Controls.Add(this.groupBox2);
            this.regularSalesTab.Controls.Add(this.groupBox1);
            this.regularSalesTab.Controls.Add(this.saleTable);
            this.regularSalesTab.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regularSalesTab.Location = new System.Drawing.Point(4, 24);
            this.regularSalesTab.Name = "regularSalesTab";
            this.regularSalesTab.Padding = new System.Windows.Forms.Padding(3);
            this.regularSalesTab.Size = new System.Drawing.Size(743, 446);
            this.regularSalesTab.TabIndex = 0;
            this.regularSalesTab.Text = "REGULAR SALE";
            this.regularSalesTab.Click += new System.EventHandler(this.regularSalesTab_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboFilterType);
            this.groupBox2.Controls.Add(this.dtFilter);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(502, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 43);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date Filter";
            // 
            // comboFilterType
            // 
            this.comboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilterType.Font = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFilterType.FormattingEnabled = true;
            this.comboFilterType.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Yearly"});
            this.comboFilterType.Location = new System.Drawing.Point(146, 16);
            this.comboFilterType.Name = "comboFilterType";
            this.comboFilterType.Size = new System.Drawing.Size(81, 20);
            this.comboFilterType.TabIndex = 1;
            this.comboFilterType.SelectedIndexChanged += new System.EventHandler(this.comboFilterType_SelectedIndexChanged);
            // 
            // dtFilter
            // 
            this.dtFilter.CustomFormat = "MMMM d, yyyy";
            this.dtFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFilter.Location = new System.Drawing.Point(6, 16);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.Size = new System.Drawing.Size(134, 20);
            this.dtFilter.TabIndex = 0;
            this.dtFilter.ValueChanged += new System.EventHandler(this.dtFilter_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.totalSale);
            this.groupBox1.Location = new System.Drawing.Point(623, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 44);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Sale";
            // 
            // totalSale
            // 
            this.totalSale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalSale.Location = new System.Drawing.Point(6, 20);
            this.totalSale.Name = "totalSale";
            this.totalSale.Size = new System.Drawing.Size(102, 14);
            this.totalSale.TabIndex = 7;
            this.totalSale.Text = "0";
            this.totalSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chargedPage
            // 
            this.chargedPage.Controls.Add(this.groupBox5);
            this.chargedPage.Controls.Add(this.groupBox4);
            this.chargedPage.Controls.Add(this.groupBox3);
            this.chargedPage.Controls.Add(this.chargedTable);
            this.chargedPage.Location = new System.Drawing.Point(4, 24);
            this.chargedPage.Name = "chargedPage";
            this.chargedPage.Padding = new System.Windows.Forms.Padding(3);
            this.chargedPage.Size = new System.Drawing.Size(743, 446);
            this.chargedPage.TabIndex = 1;
            this.chargedPage.Text = "CHARGED SALE";
            this.chargedPage.UseVisualStyleBackColor = true;
            this.chargedPage.Click += new System.EventHandler(this.chargedPage_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.toBeSettledTxt);
            this.groupBox5.Location = new System.Drawing.Point(571, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 44);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Amount to be settled";
            // 
            // toBeSettledTxt
            // 
            this.toBeSettledTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toBeSettledTxt.Location = new System.Drawing.Point(6, 20);
            this.toBeSettledTxt.Name = "toBeSettledTxt";
            this.toBeSettledTxt.Size = new System.Drawing.Size(154, 14);
            this.toBeSettledTxt.TabIndex = 7;
            this.toBeSettledTxt.Text = "0";
            this.toBeSettledTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.saleStatus);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(314, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(134, 43);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sale Status";
            // 
            // saleStatus
            // 
            this.saleStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saleStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.saleStatus.FormattingEnabled = true;
            this.saleStatus.Location = new System.Drawing.Point(7, 15);
            this.saleStatus.Name = "saleStatus";
            this.saleStatus.Size = new System.Drawing.Size(121, 22);
            this.saleStatus.TabIndex = 0;
            this.saleStatus.SelectedIndexChanged += new System.EventHandler(this.saleStatus_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chargedSaleSearch);
            this.groupBox3.Controls.Add(this.chargedSearchBtn);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 43);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // chargedSaleSearch
            // 
            this.chargedSaleSearch.Location = new System.Drawing.Point(6, 15);
            this.chargedSaleSearch.Name = "chargedSaleSearch";
            this.chargedSaleSearch.Size = new System.Drawing.Size(269, 20);
            this.chargedSaleSearch.TabIndex = 6;
            this.chargedSaleSearch.TextChanged += new System.EventHandler(this.chargedSaleSearch_TextChanged);
            this.chargedSaleSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chargedSaleSearch_KeyDown);
            // 
            // chargedSearchBtn
            // 
            this.chargedSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chargedSearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("chargedSearchBtn.Image")));
            this.chargedSearchBtn.Location = new System.Drawing.Point(275, 15);
            this.chargedSearchBtn.Name = "chargedSearchBtn";
            this.chargedSearchBtn.Size = new System.Drawing.Size(20, 20);
            this.chargedSearchBtn.TabIndex = 5;
            this.chargedSearchBtn.UseVisualStyleBackColor = true;
            this.chargedSearchBtn.Click += new System.EventHandler(this.chargedSearchBtn_Click);
            // 
            // chargedTable
            // 
            this.chargedTable.AllowUserToAddRows = false;
            this.chargedTable.AllowUserToDeleteRows = false;
            this.chargedTable.AllowUserToResizeColumns = false;
            this.chargedTable.AllowUserToResizeRows = false;
            this.chargedTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chargedTable.BackgroundColor = System.Drawing.Color.White;
            this.chargedTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chargedTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.chargedTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chargedTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.chargedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chargedTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.dataGridViewTextBoxColumn1,
            this.Column7,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column6,
            this.Column10,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chargedTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.chargedTable.EnableHeadersVisualStyles = false;
            this.chargedTable.Location = new System.Drawing.Point(7, 56);
            this.chargedTable.MultiSelect = false;
            this.chargedTable.Name = "chargedTable";
            this.chargedTable.ReadOnly = true;
            this.chargedTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chargedTable.RowHeadersVisible = false;
            this.chargedTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chargedTable.Size = new System.Drawing.Size(730, 384);
            this.chargedTable.StandardTab = true;
            this.chargedTable.TabIndex = 1;
            this.chargedTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.saleTable_CellMouseDoubleClick);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "SaleId";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 54;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "Sold By";
            this.Column7.MinimumWidth = 70;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "Purchased By";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Total Sale";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 78;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Paid";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Remaining";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Fully Paid";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "REPORTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportUC";
            this.Size = new System.Drawing.Size(787, 525);
            ((System.ComponentModel.ISupportInitialize)(this.saleTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.regularSalesTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.chargedPage.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView saleTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage regularSalesTab;
        private System.Windows.Forms.Label totalSale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage chargedPage;
        private System.Windows.Forms.DataGridView chargedTable;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox chargedSaleSearch;
        private System.Windows.Forms.Button chargedSearchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label toBeSettledTxt;
        private System.Windows.Forms.ComboBox comboFilterType;
        private System.Windows.Forms.DateTimePicker dtFilter;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox saleStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
    }
}
