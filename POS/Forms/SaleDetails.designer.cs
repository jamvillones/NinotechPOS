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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleDetails));
            this.itemsTable = new System.Windows.Forms.DataGridView();
            this.IdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAddedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.markAsDefectiveCo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.soldTo = new System.Windows.Forms.TextBox();
            this.amountDue = new System.Windows.Forms.TextBox();
            this.amountRecieved = new System.Windows.Forms.TextBox();
            this.remaining = new System.Windows.Forms.TextBox();
            this.paymentsBtn = new System.Windows.Forms.Button();
            this.soldBy = new System.Windows.Forms.TextBox();
            this.voidBtn = new System.Windows.Forms.Button();
            this.editItemsBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.doc = new System.Drawing.Printing.PrintDocument();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.remainGroup = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this._messageLabel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.discount = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.remainGroup.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemsTable
            // 
            this.itemsTable.AllowUserToAddRows = false;
            this.itemsTable.AllowUserToDeleteRows = false;
            this.itemsTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            this.itemsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.itemsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.itemsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.itemsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.itemsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.itemsTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.itemsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.itemsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdCol,
            this.dateAddedCol,
            this.Column2,
            this.Column1,
            this.nameCol,
            this.supplierCol,
            this.qtyCol,
            this.serialCol,
            this.priceCol,
            this.discountCol,
            this.totalCol,
            this.markAsDefectiveCo});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemsTable.DefaultCellStyle = dataGridViewCellStyle23;
            this.itemsTable.EnableHeadersVisualStyles = false;
            this.itemsTable.GridColor = System.Drawing.Color.LightGray;
            this.itemsTable.Location = new System.Drawing.Point(20, 220);
            this.itemsTable.Name = "itemsTable";
            this.itemsTable.ReadOnly = true;
            this.itemsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.itemsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemsTable.Size = new System.Drawing.Size(944, 309);
            this.itemsTable.StandardTab = true;
            this.itemsTable.TabIndex = 2;
            this.itemsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsTable_CellClick);
            this.itemsTable.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.itemsTable_CellMouseClick);
            this.itemsTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.itemsTable_CellPainting);
            this.itemsTable.SelectionChanged += new System.EventHandler(this.itemsTable_SelectionChanged);
            this.itemsTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemsTable_KeyDown);
            // 
            // IdCol
            // 
            this.IdCol.HeaderText = "Id";
            this.IdCol.Name = "IdCol";
            this.IdCol.ReadOnly = true;
            this.IdCol.Visible = false;
            // 
            // dateAddedCol
            // 
            dataGridViewCellStyle15.Format = "MMM d, yyyy h:mm tt";
            dataGridViewCellStyle15.NullValue = null;
            this.dateAddedCol.DefaultCellStyle = dataGridViewCellStyle15;
            this.dateAddedCol.HeaderText = "ADDED ON";
            this.dateAddedCol.Name = "dateAddedCol";
            this.dateAddedCol.ReadOnly = true;
            this.dateAddedCol.Visible = false;
            // 
            // Column2
            // 
            dataGridViewCellStyle16.NullValue = "N/A";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column2.HeaderText = "REASON";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "WARRANTY STATUS";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // nameCol
            // 
            this.nameCol.HeaderText = "NAME";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // supplierCol
            // 
            dataGridViewCellStyle17.NullValue = "--";
            this.supplierCol.DefaultCellStyle = dataGridViewCellStyle17;
            this.supplierCol.HeaderText = "SUPPLIER";
            this.supplierCol.Name = "supplierCol";
            this.supplierCol.ReadOnly = true;
            // 
            // qtyCol
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "0 Unit/s";
            dataGridViewCellStyle18.NullValue = null;
            dataGridViewCellStyle18.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.qtyCol.DefaultCellStyle = dataGridViewCellStyle18;
            this.qtyCol.HeaderText = "QTY";
            this.qtyCol.Name = "qtyCol";
            this.qtyCol.ReadOnly = true;
            // 
            // serialCol
            // 
            dataGridViewCellStyle19.NullValue = "--";
            this.serialCol.DefaultCellStyle = dataGridViewCellStyle19;
            this.serialCol.HeaderText = "SERIAL";
            this.serialCol.Name = "serialCol";
            this.serialCol.ReadOnly = true;
            // 
            // priceCol
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "C2";
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.priceCol.DefaultCellStyle = dataGridViewCellStyle20;
            this.priceCol.HeaderText = "PRICE";
            this.priceCol.Name = "priceCol";
            this.priceCol.ReadOnly = true;
            // 
            // discountCol
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "C2";
            dataGridViewCellStyle21.NullValue = "--";
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.discountCol.DefaultCellStyle = dataGridViewCellStyle21;
            this.discountCol.HeaderText = "PER ITEM DISCOUNT";
            this.discountCol.Name = "discountCol";
            this.discountCol.ReadOnly = true;
            // 
            // totalCol
            // 
            this.totalCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.Format = "C2";
            dataGridViewCellStyle22.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.totalCol.DefaultCellStyle = dataGridViewCellStyle22;
            this.totalCol.HeaderText = "TOTAL";
            this.totalCol.Name = "totalCol";
            this.totalCol.ReadOnly = true;
            // 
            // markAsDefectiveCo
            // 
            this.markAsDefectiveCo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.markAsDefectiveCo.HeaderText = "";
            this.markAsDefectiveCo.MinimumWidth = 40;
            this.markAsDefectiveCo.Name = "markAsDefectiveCo";
            this.markAsDefectiveCo.ReadOnly = true;
            this.markAsDefectiveCo.Width = 40;
            // 
            // soldTo
            // 
            this.soldTo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soldTo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.soldTo.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldTo.Location = new System.Drawing.Point(0, 10);
            this.soldTo.Name = "soldTo";
            this.soldTo.ReadOnly = true;
            this.soldTo.Size = new System.Drawing.Size(350, 18);
            this.soldTo.TabIndex = 0;
            this.soldTo.TabStop = false;
            this.soldTo.Text = "Lerom Ipsum";
            this.soldTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.soldTo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.soldTo_MouseDoubleClick);
            // 
            // amountDue
            // 
            this.amountDue.BackColor = System.Drawing.SystemColors.Control;
            this.amountDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amountDue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.amountDue.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountDue.Location = new System.Drawing.Point(0, 10);
            this.amountDue.Name = "amountDue";
            this.amountDue.ReadOnly = true;
            this.amountDue.Size = new System.Drawing.Size(230, 18);
            this.amountDue.TabIndex = 0;
            this.amountDue.TabStop = false;
            this.amountDue.Text = "Lorem Ipsum";
            this.amountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amountRecieved
            // 
            this.amountRecieved.BackColor = System.Drawing.SystemColors.Control;
            this.amountRecieved.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.amountRecieved.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.amountRecieved.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountRecieved.Location = new System.Drawing.Point(0, 10);
            this.amountRecieved.Name = "amountRecieved";
            this.amountRecieved.ReadOnly = true;
            this.amountRecieved.Size = new System.Drawing.Size(230, 18);
            this.amountRecieved.TabIndex = 0;
            this.amountRecieved.TabStop = false;
            this.amountRecieved.Text = "Lorem Ipsum";
            this.amountRecieved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // remaining
            // 
            this.remaining.BackColor = System.Drawing.SystemColors.Control;
            this.remaining.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remaining.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.remaining.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remaining.Location = new System.Drawing.Point(0, 10);
            this.remaining.Name = "remaining";
            this.remaining.ReadOnly = true;
            this.remaining.Size = new System.Drawing.Size(230, 18);
            this.remaining.TabIndex = 0;
            this.remaining.TabStop = false;
            this.remaining.Text = "Lorem Ipsum";
            this.remaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // paymentsBtn
            // 
            this.paymentsBtn.BackColor = System.Drawing.Color.White;
            this.paymentsBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.paymentsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("paymentsBtn.Image")));
            this.paymentsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.paymentsBtn.Location = new System.Drawing.Point(504, 20);
            this.paymentsBtn.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.paymentsBtn.Name = "paymentsBtn";
            this.paymentsBtn.Size = new System.Drawing.Size(150, 35);
            this.paymentsBtn.TabIndex = 16;
            this.paymentsBtn.Text = "   Payments";
            this.paymentsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.paymentsBtn.UseVisualStyleBackColor = false;
            this.paymentsBtn.Click += new System.EventHandler(this.OpenPayments_Click);
            // 
            // soldBy
            // 
            this.soldBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.soldBy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.soldBy.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soldBy.Location = new System.Drawing.Point(0, 10);
            this.soldBy.Name = "soldBy";
            this.soldBy.ReadOnly = true;
            this.soldBy.Size = new System.Drawing.Size(350, 18);
            this.soldBy.TabIndex = 0;
            this.soldBy.TabStop = false;
            this.soldBy.Text = "Lorem Ipsum";
            this.soldBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // voidBtn
            // 
            this.voidBtn.BackColor = System.Drawing.Color.RosyBrown;
            this.voidBtn.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
            this.voidBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.voidBtn.ForeColor = System.Drawing.Color.White;
            this.voidBtn.Image = ((System.Drawing.Image)(resources.GetObject("voidBtn.Image")));
            this.voidBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.voidBtn.Location = new System.Drawing.Point(704, 20);
            this.voidBtn.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.voidBtn.Name = "voidBtn";
            this.voidBtn.Size = new System.Drawing.Size(150, 35);
            this.voidBtn.TabIndex = 17;
            this.voidBtn.Text = "   Void";
            this.voidBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.voidBtn.UseVisualStyleBackColor = false;
            this.voidBtn.Click += new System.EventHandler(this.voidBtn_Click);
            // 
            // editItemsBtn
            // 
            this.editItemsBtn.BackColor = System.Drawing.Color.White;
            this.editItemsBtn.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.editItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editItemsBtn.Image = ((System.Drawing.Image)(resources.GetObject("editItemsBtn.Image")));
            this.editItemsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editItemsBtn.Location = new System.Drawing.Point(352, 20);
            this.editItemsBtn.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.editItemsBtn.Name = "editItemsBtn";
            this.editItemsBtn.Size = new System.Drawing.Size(150, 35);
            this.editItemsBtn.TabIndex = 17;
            this.editItemsBtn.Text = "   Add Items";
            this.editItemsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editItemsBtn.UseVisualStyleBackColor = false;
            this.editItemsBtn.Click += new System.EventHandler(this.editItemsBtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(200, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 35);
            this.button2.TabIndex = 21;
            this.button2.Text = "   Print";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // doc
            // 
            this.doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.doc_BeginPrint);
            this.doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.doc_PrintPage);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.editItemsBtn);
            this.flowLayoutPanel1.Controls.Add(this.paymentsBtn);
            this.flowLayoutPanel1.Controls.Add(this.voidBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 536);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(944, 55);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(0, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 35);
            this.button1.TabIndex = 22;
            this.button1.Text = "   Close";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.soldTo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(20, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 29);
            this.panel1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sold To:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 1);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.soldBy);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(20, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 29);
            this.panel3.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sold By:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 1);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.amountRecieved);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(734, 127);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(230, 29);
            this.panel5.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Recieved:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 28);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(230, 1);
            this.panel6.TabIndex = 0;
            // 
            // remainGroup
            // 
            this.remainGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remainGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.remainGroup.BackColor = System.Drawing.SystemColors.Control;
            this.remainGroup.Controls.Add(this.label5);
            this.remainGroup.Controls.Add(this.remaining);
            this.remainGroup.Controls.Add(this.panel8);
            this.remainGroup.Location = new System.Drawing.Point(734, 162);
            this.remainGroup.Name = "remainGroup";
            this.remainGroup.Size = new System.Drawing.Size(230, 29);
            this.remainGroup.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Remaining:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 28);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(230, 1);
            this.panel8.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel9.BackColor = System.Drawing.SystemColors.Control;
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.amountDue);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Location = new System.Drawing.Point(734, 92);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(230, 29);
            this.panel9.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Amount Due:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.Black;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 28);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(230, 1);
            this.panel10.TabIndex = 0;
            // 
            // _messageLabel
            // 
            this._messageLabel.AutoSize = true;
            this._messageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._messageLabel.Location = new System.Drawing.Point(17, 140);
            this._messageLabel.Name = "_messageLabel";
            this._messageLabel.Size = new System.Drawing.Size(0, 13);
            this._messageLabel.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.discount);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Location = new System.Drawing.Point(734, 57);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(230, 29);
            this.panel7.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Discount:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // discount
            // 
            this.discount.BackColor = System.Drawing.SystemColors.Control;
            this.discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.discount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.discount.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(0, 10);
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Size = new System.Drawing.Size(230, 18);
            this.discount.TabIndex = 0;
            this.discount.TabStop = false;
            this.discount.Text = "Lorem Ipsum";
            this.discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Black;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 28);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(230, 1);
            this.panel11.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Title";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(20, 200);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Compact View";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(903, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "0 Selected";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(20, 535);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(944, 1);
            this.panel12.TabIndex = 28;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(130, 200);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(113, 17);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "Show Date Added";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // searchControl1
            // 
            this.searchControl1.BackColor = System.Drawing.SystemColors.Window;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Location = new System.Drawing.Point(20, 156);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 60);
            this.searchControl1.MinimumSize = new System.Drawing.Size(200, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 1;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(259, 200);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(132, 17);
            this.checkBox3.TabIndex = 30;
            this.checkBox3.Text = "Show Warranty Status";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // SaleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.itemsTable);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this._messageLabel);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.remainGroup);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(790, 500);
            this.Name = "SaleDetails";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaleDetails_FormClosing);
            this.Load += new System.EventHandler(this.SaleDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SaleDetails_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.itemsTable)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.remainGroup.ResumeLayout(false);
            this.remainGroup.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView itemsTable;
        private System.Windows.Forms.TextBox soldTo;
        private System.Windows.Forms.TextBox amountDue;
        private System.Windows.Forms.TextBox amountRecieved;
        private System.Windows.Forms.TextBox remaining;
        private System.Windows.Forms.Button paymentsBtn;
        private System.Windows.Forms.TextBox soldBy;
        private System.Windows.Forms.Button voidBtn;
        private System.Windows.Forms.Button editItemsBtn;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument doc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel remainGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel10;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.Label _messageLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAddedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCol;
        private System.Windows.Forms.DataGridViewButtonColumn markAsDefectiveCo;
    }
}