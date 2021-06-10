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
    public partial class RecieptTest : Form
    {
        public RecieptTest()
        {
            InitializeComponent();
        }
        PrintAction printAction;
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printAction = e.PrintAction;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ReceiptDetails details = new ReceiptDetails();
            details.ControlNumber = 000335656.ToString();
            details.CustomerName = "Jamil Villones";
            details.TransactBy = "admin";
            details.Tendered = 1000000;

            for (int i = 1; i <= 5; i++)
            {
                details.Additem("Lerom Ipsum","serial", i, 2500.25m, 365);
            }

            e.FormatReciept(printAction, details);
        }

        private void RecieptTest_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            if (string.IsNullOrEmpty(settings.ReceiptPrinter))
                printDocument1.PrinterSettings.PrinterName = settings.ReceiptPrinter;
        }
    }
}
