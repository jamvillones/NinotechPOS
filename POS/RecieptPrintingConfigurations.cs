using POS.Properties;
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
    public partial class RecieptPrintingConfigurations : Form
    {
        public RecieptPrintingConfigurations()
        {
            InitializeComponent();
        }
        Settings settings;
        private void RecieptPrintingConfigurations_Load(object sender, EventArgs e)
        {
            settings = Properties.Settings.Default;

            titlelTxt.Text = settings.HeaderText;
            detailsTxt.Text = settings.DetailsText;

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //MessageBox.Show(printer);
                comboBox1.Items.Add(printer);
            }

            comboBox1.Text = settings.ReceiptPrinter;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var header = titlelTxt.Text.Trim();
            var det = detailsTxt.Text.Trim();
            var receiptPrinter = comboBox1.Text.Trim();

            settings.HeaderText = header;
            settings.DetailsText = det;
            settings.ReceiptPrinter = receiptPrinter;

            settings.Save();

            this.Close();
        }
    }
}
