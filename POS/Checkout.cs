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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        PrintAction printaction;
        private void doc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printaction = e.PrintAction;
        }

        private void doc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var r = new ReceiptDetails() { ControlNumber = "", CustomerName="test", Tendered = 100, TransactBy = "admin" };

            for (var i = 0; i < table.RowCount; i++)
                r.Additem(
                    table[4, i].Value?.ToString(),
                    table[3, i].Value?.ToString(),
                    (int)table[6, i].Value,
                    (decimal)table[7, i].Value,
                    (decimal)table[8, i].Value
                    );

            ReceiptPrinting.FormatReciept(e, printaction, r);
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            printPreviewControl1.Document = doc;
        }
    }
}
