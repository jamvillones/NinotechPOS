﻿namespace POS.Forms
{
    partial class StockInLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockInLog));
            this.historyTable = new System.Windows.Forms.DataGridView();
            this.col_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.regular_Dt = new System.Windows.Forms.DateTimePicker();
            this.dateRangeHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.range_from_Dt = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.range_to_Dt = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._totalCost = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchControl1 = new POS.UserControls.SearchControl();
            this.countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.historyTable)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.dateRangeHolder.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyTable
            // 
            this.historyTable.AllowUserToAddRows = false;
            this.historyTable.AllowUserToDeleteRows = false;
            this.historyTable.AllowUserToResizeRows = false;
            this.historyTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.historyTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.historyTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.historyTable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.historyTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.historyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Id,
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column6,
            this.Column4,
            this.col_Cost});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyTable.DefaultCellStyle = dataGridViewCellStyle9;
            this.historyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyTable.EnableHeadersVisualStyles = false;
            this.historyTable.GridColor = System.Drawing.Color.DarkGray;
            this.historyTable.Location = new System.Drawing.Point(20, 149);
            this.historyTable.Name = "historyTable";
            this.historyTable.ReadOnly = true;
            this.historyTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.historyTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.historyTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyTable.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.historyTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyTable.Size = new System.Drawing.Size(830, 280);
            this.historyTable.StandardTab = true;
            this.historyTable.TabIndex = 2;
            this.historyTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.historyTable_CellMouseDoubleClick);
            this.historyTable.Scroll += new System.Windows.Forms.ScrollEventHandler(this.itemsTable_Scroll);
            this.historyTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.histTable_KeyDown);
            // 
            // col_Id
            // 
            this.col_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.col_Id.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_Id.HeaderText = "ID";
            this.col_Id.Name = "col_Id";
            this.col_Id.ReadOnly = true;
            this.col_Id.Width = 52;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Format = "f";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "DATE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "USER";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column2.HeaderText = "NAME";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "SERIAL NUMBER";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column4.HeaderText = "QUANTITY";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // col_Cost
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.col_Cost.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_Cost.HeaderText = "COST";
            this.col_Cost.Name = "col_Cost";
            this.col_Cost.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.radioButton1);
            this.flowLayoutPanel2.Controls.Add(this.radioButton2);
            this.flowLayoutPanel2.Controls.Add(this.radioButton3);
            this.flowLayoutPanel2.Controls.Add(this.radioButton4);
            this.flowLayoutPanel2.Controls.Add(this.radioButton5);
            this.flowLayoutPanel2.Controls.Add(this.regular_Dt);
            this.flowLayoutPanel2.Controls.Add(this.dateRangeHolder);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 55);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(830, 44);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(5, 14);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.all_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(51, 14);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "By Day";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.daily_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(120, 14);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(70, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.Text = "By Month";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.monthly_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(200, 14);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(62, 17);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.Text = "By Year";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.annually_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(272, 14);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(98, 17);
            this.radioButton5.TabIndex = 12;
            this.radioButton5.Text = "By Date Range";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.dateRange_CheckedChanged);
            // 
            // regular_Dt
            // 
            this.regular_Dt.Checked = false;
            this.regular_Dt.CustomFormat = "MMM d, yyyy";
            this.regular_Dt.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.regular_Dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.regular_Dt.Location = new System.Drawing.Point(375, 13);
            this.regular_Dt.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.regular_Dt.Name = "regular_Dt";
            this.regular_Dt.Size = new System.Drawing.Size(130, 20);
            this.regular_Dt.TabIndex = 4;
            this.regular_Dt.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // dateRangeHolder
            // 
            this.dateRangeHolder.AutoSize = true;
            this.dateRangeHolder.Controls.Add(this.range_from_Dt);
            this.dateRangeHolder.Controls.Add(this.label1);
            this.dateRangeHolder.Controls.Add(this.range_to_Dt);
            this.dateRangeHolder.Location = new System.Drawing.Point(505, 13);
            this.dateRangeHolder.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.dateRangeHolder.Name = "dateRangeHolder";
            this.dateRangeHolder.Size = new System.Drawing.Size(282, 20);
            this.dateRangeHolder.TabIndex = 11;
            this.dateRangeHolder.Visible = false;
            // 
            // range_from_Dt
            // 
            this.range_from_Dt.Checked = false;
            this.range_from_Dt.CustomFormat = "MMM d, yyyy";
            this.range_from_Dt.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.range_from_Dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.range_from_Dt.Location = new System.Drawing.Point(0, 0);
            this.range_from_Dt.Margin = new System.Windows.Forms.Padding(0);
            this.range_from_Dt.Name = "range_from_Dt";
            this.range_from_Dt.Size = new System.Drawing.Size(130, 20);
            this.range_from_Dt.TabIndex = 10;
            this.range_from_Dt.ValueChanged += new System.EventHandler(this.range_from_Dt_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "-";
            // 
            // range_to_Dt
            // 
            this.range_to_Dt.Checked = false;
            this.range_to_Dt.CustomFormat = "MMM d, yyyy";
            this.range_to_Dt.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.range_to_Dt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.range_to_Dt.Location = new System.Drawing.Point(152, 0);
            this.range_to_Dt.Margin = new System.Windows.Forms.Padding(0);
            this.range_to_Dt.Name = "range_to_Dt";
            this.range_to_Dt.Size = new System.Drawing.Size(130, 20);
            this.range_to_Dt.TabIndex = 11;
            this.range_to_Dt.ValueChanged += new System.EventHandler(this.range_to_Dt_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this._totalCost);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 429);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(830, 33);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // _totalCost
            // 
            this._totalCost.AutoSize = true;
            this._totalCost.ForeColor = System.Drawing.SystemColors.Highlight;
            this._totalCost.Location = new System.Drawing.Point(783, 10);
            this._totalCost.Name = "_totalCost";
            this._totalCost.Size = new System.Drawing.Size(44, 13);
            this._totalCost.TabIndex = 1;
            this._totalCost.Text = "₱ 0.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(719, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Cost:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(830, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "***To Undo Stock-In, Select Items to undo then press Delete.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchControl1
            // 
            this.searchControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.searchControl1.BackColor = System.Drawing.Color.White;
            this.searchControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl1.Location = new System.Drawing.Point(20, 20);
            this.searchControl1.MaximumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.MinimumSize = new System.Drawing.Size(350, 35);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.searchControl1.SearchedText = "";
            this.searchControl1.Size = new System.Drawing.Size(350, 35);
            this.searchControl1.TabIndex = 3;
            this.searchControl1.OnSearch += new System.EventHandler<POS.Misc.SearchEventArgs>(this.searchControl1_OnSearch);
            this.searchControl1.OnTextEmpty += new System.EventHandler(this.searchControl1_OnTextEmpty);
            // 
            // countLabel
            // 
            this.countLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.countLabel.ForeColor = System.Drawing.Color.Black;
            this.countLabel.Location = new System.Drawing.Point(20, 124);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(830, 25);
            this.countLabel.TabIndex = 12;
            this.countLabel.Text = "0 / 0";
            this.countLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StockInLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 482);
            this.Controls.Add(this.historyTable);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.searchControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "StockInLog";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stockin Log";
            this.Load += new System.EventHandler(this.StockInLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.historyTable)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.dateRangeHolder.ResumeLayout(false);
            this.dateRangeHolder.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.DataGridView historyTable;
        private UserControls.SearchControl searchControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel dateRangeHolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.DateTimePicker regular_Dt;
        private System.Windows.Forms.DateTimePicker range_from_Dt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker range_to_Dt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _totalCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Cost;
    }
}