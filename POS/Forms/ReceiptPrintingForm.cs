using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ReceiptPrintingForm : Form
    {
        public ReceiptPrintingForm()
        {
            InitializeComponent();
        }

        private void ReceiptPrintingForm_Load(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm",285,600);
        }
    }
}
