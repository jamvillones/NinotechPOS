using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void RecieptPrintingConfigurations_Load(object sender, EventArgs e)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                //MessageBox.Show(printer);
                comboBox1.Items.Add(printer);
            }
            
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            this.Close();
        }
    }
}
