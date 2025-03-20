using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Checkout : Form
    {
        DataGridView table;

        public Checkout(DataGridView dgt)
        {
            InitializeComponent();

            table = dgt;
        }        

        #region printing
        PrintAction printaction;
        private void doc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printaction = e.PrintAction;
        }
        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var r = new ReceiptDetails() { ControlNumber = "", CustomerName = "test", Tendered = 100, TransactBy = "admin" };

            for (var i = 0; i < table.RowCount; i++)
                r.AddItem(
                    table[4, i].Value?.ToString(),
                    table[3, i].Value?.ToString(),
                    (int)table[6, i].Value,
                    (decimal)table[7, i].Value,
                    (decimal)table[8, i].Value
                    );

            ReceiptPrinting.FormatReciept(e, printaction, r);
        }
        #endregion

        decimal change => tenderedNum.Value - total;
        decimal total => table.Rows.Cast<DataGridViewRow>().Select(x => (decimal)x.Cells[9].Value).DefaultIfEmpty(0).Sum();


        private async void Checkout_Load(object sender, EventArgs e)
        {
            doc.PrinterSettings.PrinterName = Properties.Settings.Default.ReceiptPrinter;
            printPreviewControl1.Document = doc;

            textBox1.Text = string.Format("₱ {0:n}", total);
            updateChange();
            setSaleType();
            await loadCustomerAsync();
        }

        private async Task loadCustomerAsync()
        {
            using (var p = new POSEntities())
            {
                string[] customers = null;
                await Task.Run(() =>
                {
                    customers = p.Customers.Select(x => x.Name).ToArray();
                });

                cusoterOption.InvokeIfRequired(() =>
                {
                    cusoterOption.Items.AddRange(customers);
                    cusoterOption.AutoCompleteCustomSource.AddRange(customers);
                });
            }
        }

        private void updateChange()
        {
            textBox2.Text = string.Format("₱ {0:n}", change);
        }

        private void tenderedNum_ValueChanged(object sender, EventArgs e)
        {
            //setSaleType();
            //updateChange();
        }

        private void setSaleType()
        {
            bool regular = tenderedNum.Value >= total;
            label1.Text = regular ? "REGULAR" : "CHARGED";
            label1.ForeColor = regular ? Color.Green : Color.Red;
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tenderedNum.Value = total;
        }

        private void tenderedNum_Validated(object sender, EventArgs e)
        {
            setSaleType();
            updateChange();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox6.Enabled = groupBox7.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to finalize this sale?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Checkout_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
