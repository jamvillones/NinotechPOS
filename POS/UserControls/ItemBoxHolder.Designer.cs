namespace POS.UserControls
{
    partial class ItemBoxHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemBoxHolder));
            this.nameTxt = new System.Windows.Forms.Label();
            this.quantityTxt = new System.Windows.Forms.Label();
            this.priceTxt = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.barcodeTxt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.serialTxt = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTxt
            // 
            this.nameTxt.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.nameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(0, 110);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(0);
            this.nameTxt.MinimumSize = new System.Drawing.Size(100, 20);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(130, 20);
            this.nameTxt.TabIndex = 6;
            this.nameTxt.Text = "Name";
            this.nameTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quantityTxt
            // 
            this.quantityTxt.BackColor = System.Drawing.Color.Yellow;
            this.quantityTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quantityTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantityTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityTxt.Location = new System.Drawing.Point(91, 0);
            this.quantityTxt.Margin = new System.Windows.Forms.Padding(0);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(39, 13);
            this.quantityTxt.TabIndex = 3;
            this.quantityTxt.Text = "quantity";
            this.quantityTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // priceTxt
            // 
            this.priceTxt.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.priceTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.priceTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.priceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceTxt.Location = new System.Drawing.Point(0, 0);
            this.priceTxt.Margin = new System.Windows.Forms.Padding(0);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(91, 13);
            this.priceTxt.TabIndex = 0;
            this.priceTxt.Text = "Price";
            this.priceTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picture
            // 
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Image = ((System.Drawing.Image)(resources.GetObject("picture.Image")));
            this.picture.InitialImage = null;
            this.picture.Location = new System.Drawing.Point(0, 13);
            this.picture.Margin = new System.Windows.Forms.Padding(1);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(130, 81);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 2;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // barcodeTxt
            // 
            this.barcodeTxt.BackColor = System.Drawing.Color.CadetBlue;
            this.barcodeTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcodeTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barcodeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeTxt.ForeColor = System.Drawing.Color.Black;
            this.barcodeTxt.Location = new System.Drawing.Point(0, 0);
            this.barcodeTxt.Margin = new System.Windows.Forms.Padding(0);
            this.barcodeTxt.Name = "barcodeTxt";
            this.barcodeTxt.Size = new System.Drawing.Size(65, 16);
            this.barcodeTxt.TabIndex = 4;
            this.barcodeTxt.Text = "barcode";
            this.barcodeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.serialTxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.barcodeTxt, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(130, 16);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // serialTxt
            // 
            this.serialTxt.BackColor = System.Drawing.Color.LimeGreen;
            this.serialTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serialTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serialTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialTxt.ForeColor = System.Drawing.Color.Black;
            this.serialTxt.Location = new System.Drawing.Point(65, 0);
            this.serialTxt.Margin = new System.Windows.Forms.Padding(0);
            this.serialTxt.Name = "serialTxt";
            this.serialTxt.Size = new System.Drawing.Size(65, 16);
            this.serialTxt.TabIndex = 6;
            this.serialTxt.Text = "label3\r\nlabel3";
            this.serialTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.priceTxt, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.quantityTxt, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 13);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // ItemBoxHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.picture);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.nameTxt);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ItemBoxHolder";
            this.Size = new System.Drawing.Size(130, 130);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label quantityTxt;
        private System.Windows.Forms.Label priceTxt;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label barcodeTxt;
        private System.Windows.Forms.Label nameTxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label serialTxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
