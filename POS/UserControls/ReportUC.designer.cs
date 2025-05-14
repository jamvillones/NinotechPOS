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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saleTable = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.regularSalesTab = new System.Windows.Forms.TabPage();
            this.totalSale = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.dtFilter = new System.Windows.Forms.DateTimePicker();
            this.comboFilterType = new System.Windows.Forms.ComboBox();
            this.chargedPage = new System.Windows.Forms.TabPage();
            this.chargedTable = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.itemCount = new System.Windows.Forms.Label();
            this.searchingIndicator = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.saleTable)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.regularSalesTab.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.chargedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saleTable
            // 
            this.saleTable.AllowUserToAddRows = false;
            this.saleTable.AllowUserToDeleteRows = false;
            this.saleTable.AllowUserToResizeRows = false;
            this.saleTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.saleTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.saleTable.BackgroundColor = System.Drawing.Color.White;
            this.saleTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.saleTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.saleTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.saleTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.saleTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.saleTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saleTable.EnableHeadersVisualStyles = false;
            this.saleTable.Location = new System.Drawing.Point(10, 71);
            this.saleTable.MultiSelect = false;
            this.saleTable.Name = "saleTable";
            this.saleTable.ReadOnly = true;
            this.saleTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.saleTable.RowHeadersVisible = false;
            this.saleTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleTable.Size = new System.Drawing.Size(759, 418);
            this.saleTable.StandardTab = true;
            this.saleTable.TabIndex = 1;
            this.saleTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShowSale_DoubleClick);
            this.saleTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.saleTable_KeyDown);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Format = "MMM d, yyyy h:mm tt";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "DATE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "BY";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CUSTOMER";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "TOTAL";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.regularSalesTab);
            this.tabControl1.Controls.Add(this.chargedPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(787, 525);
            this.tabControl1.TabIndex = 3;
            // 
            // regularSalesTab
            // 
            this.regularSalesTab.BackColor = System.Drawing.Color.White;
            this.regularSalesTab.Controls.Add(this.saleTable);
            this.regularSalesTab.Controls.Add(this.totalSale);
            this.regularSalesTab.Controls.Add(this.flowLayoutPanel3);
            this.regularSalesTab.Location = new System.Drawing.Point(4, 22);
            this.regularSalesTab.Name = "regularSalesTab";
            this.regularSalesTab.Padding = new System.Windows.Forms.Padding(10);
            this.regularSalesTab.Size = new System.Drawing.Size(779, 499);
            this.regularSalesTab.TabIndex = 0;
            this.regularSalesTab.Text = "REGULAR";
            // 
            // totalSale
            // 
            this.totalSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.totalSale.ForeColor = System.Drawing.Color.Black;
            this.totalSale.Location = new System.Drawing.Point(10, 51);
            this.totalSale.Name = "totalSale";
            this.totalSale.Size = new System.Drawing.Size(759, 20);
            this.totalSale.TabIndex = 7;
            this.totalSale.Text = "Total: P 1,000.00";
            this.totalSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.dtFilter);
            this.flowLayoutPanel3.Controls.Add(this.comboFilterType);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel3.Size = new System.Drawing.Size(759, 41);
            this.flowLayoutPanel3.TabIndex = 16;
            // 
            // dtFilter
            // 
            this.dtFilter.CustomFormat = "MMMM d, yyyy";
            this.dtFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFilter.Location = new System.Drawing.Point(0, 10);
            this.dtFilter.Margin = new System.Windows.Forms.Padding(0);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.Size = new System.Drawing.Size(139, 20);
            this.dtFilter.TabIndex = 0;
            // 
            // comboFilterType
            // 
            this.comboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilterType.FormattingEnabled = true;
            this.comboFilterType.Items.AddRange(new object[] {
            "Daily",
            "Monthly",
            "Yearly"});
            this.comboFilterType.Location = new System.Drawing.Point(149, 10);
            this.comboFilterType.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.comboFilterType.Name = "comboFilterType";
            this.comboFilterType.Size = new System.Drawing.Size(201, 21);
            this.comboFilterType.TabIndex = 1;
            // 
            // chargedPage
            // 
            this.chargedPage.Controls.Add(this.chargedTable);
            this.chargedPage.Controls.Add(this.panel1);
            this.chargedPage.Controls.Add(this.loadingLabel);
            this.chargedPage.Controls.Add(this.flowLayoutPanel2);
            this.chargedPage.Location = new System.Drawing.Point(4, 22);
            this.chargedPage.Name = "chargedPage";
            this.chargedPage.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.chargedPage.Size = new System.Drawing.Size(779, 499);
            this.chargedPage.TabIndex = 1;
            this.chargedPage.Text = "CHARGED";
            this.chargedPage.UseVisualStyleBackColor = true;
            // 
            // chargedTable
            // 
            this.chargedTable.AllowUserToAddRows = false;
            this.chargedTable.AllowUserToDeleteRows = false;
            this.chargedTable.AllowUserToResizeRows = false;
            this.chargedTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chargedTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.chargedTable.BackgroundColor = System.Drawing.Color.White;
            this.chargedTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chargedTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chargedTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.chargedTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.chargedTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.Column6,
            this.Column10,
            this.Column7});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.chargedTable.DefaultCellStyle = dataGridViewCellStyle12;
            this.chargedTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chargedTable.EnableHeadersVisualStyles = false;
            this.chargedTable.Location = new System.Drawing.Point(10, 80);
            this.chargedTable.Margin = new System.Windows.Forms.Padding(0);
            this.chargedTable.MultiSelect = false;
            this.chargedTable.Name = "chargedTable";
            this.chargedTable.ReadOnly = true;
            this.chargedTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.chargedTable.RowHeadersVisible = false;
            this.chargedTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.chargedTable.Size = new System.Drawing.Size(759, 379);
            this.chargedTable.StandardTab = true;
            this.chargedTable.TabIndex = 1;
            this.chargedTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ShowSale_DoubleClick);
            this.chargedTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.chargedTable_Scroll);
            this.chargedTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chargedTable_KeyDown);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "ID";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "CUSTOMER";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.Format = "MMM d, yyyy h:mm tt";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "DATE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn3.HeaderText = "TOTAL";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle9.Format = "C2";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle9;
            this.Column6.HeaderText = "PAID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column10
            // 
            dataGridViewCellStyle10.Format = "C2";
            this.Column10.DefaultCellStyle = dataGridViewCellStyle10;
            this.Column10.HeaderText = "BALANCE";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle11;
            this.Column7.HeaderText = "BY";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.itemCount);
            this.panel1.Controls.Add(this.searchingIndicator);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 45);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel1.Size = new System.Drawing.Size(759, 35);
            this.panel1.TabIndex = 17;
            // 
            // itemCount
            // 
            this.itemCount.AutoSize = true;
            this.itemCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.itemCount.Location = new System.Drawing.Point(746, 10);
            this.itemCount.Name = "itemCount";
            this.itemCount.Size = new System.Drawing.Size(13, 13);
            this.itemCount.TabIndex = 0;
            this.itemCount.Text = "0";
            // 
            // searchingIndicator
            // 
            this.searchingIndicator.AutoSize = true;
            this.searchingIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.searchingIndicator.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchingIndicator.ForeColor = System.Drawing.Color.Blue;
            this.searchingIndicator.Location = new System.Drawing.Point(0, 10);
            this.searchingIndicator.Name = "searchingIndicator";
            this.searchingIndicator.Size = new System.Drawing.Size(0, 17);
            this.searchingIndicator.TabIndex = 0;
            // 
            // loadingLabel
            // 
            this.loadingLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadingLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadingLabel.Location = new System.Drawing.Point(10, 459);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(759, 40);
            this.loadingLabel.TabIndex = 16;
            this.loadingLabel.Text = "*** Loading Additional Entries ***";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.searchControl1);
            this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(759, 35);
            this.flowLayoutPanel2.TabIndex = 15;
            // 
            // searchControl1
            // 
            this.searchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl1.BackColor = System.Drawing.Color.White;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Location = new System.Drawing.Point(0, 0);
            this.searchControl1.Margin = new System.Windows.Forms.Padding(0);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.MinimumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 13;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Controls.Add(this.radioButton3);
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(360, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10, 6, 0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(185, 23);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 3);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Pending";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(80, 3);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(46, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Paid";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(139, 3);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // ReportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ReportUC";
            this.Size = new System.Drawing.Size(787, 525);
            this.Load += new System.EventHandler(this.ReportUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saleTable)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.regularSalesTab.ResumeLayout(false);
            this.regularSalesTab.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.chargedPage.ResumeLayout(false);
            this.chargedPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargedTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView saleTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage regularSalesTab;
        private System.Windows.Forms.Label totalSale;
        private System.Windows.Forms.TabPage chargedPage;
        private System.Windows.Forms.DataGridView chargedTable;
        private System.Windows.Forms.ComboBox comboFilterType;
        private System.Windows.Forms.DateTimePicker dtFilter;
        private SearchControl searchControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label searchingIndicator;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label itemCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}
