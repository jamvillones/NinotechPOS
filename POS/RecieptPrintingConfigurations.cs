using Newtonsoft.Json;
using POS.Misc;
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
    public partial class ReceiptPrintingConfigurations : Form
    {
        public ReceiptPrintingConfigurations()
        {
            InitializeComponent();
        }

        Settings settings;
        private void ReceiptPrintingConfigurations_Load(object sender, EventArgs e)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
                comboBox1.Items.Add(printer);

            settings = Settings.Default;



            if (ReceiptPrintingConfig is null)
                return;

            titlelTxt.Text = ReceiptPrintingConfig.Header;
            detailsTxt.Text = ReceiptPrintingConfig.Details;
            textBox1.Text = ReceiptPrintingConfig.Footer;
            comboBox1.Text = ReceiptPrintingConfig.Printer;
        }

        public static ReceiptPrintingConfig ReceiptPrintingConfig { get; private set; }
        public static void Initialize()
        {
            var s = Settings.Default;
            ReceiptPrintingConfig = JsonConvert.DeserializeObject<ReceiptPrintingConfig>(s.ReceiptPrintingConfig);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ReceiptPrintingConfig = new ReceiptPrintingConfig()
            {
                Header = titlelTxt.Text.NullIfEmpty(),
                Details = detailsTxt.Text.NullIfEmpty(),
                Footer = textBox1.Text.NullIfEmpty(),
                Printer = comboBox1.Text.NullIfEmpty()
            };

            settings.ReceiptPrintingConfig = JsonConvert.SerializeObject(ReceiptPrintingConfig);

            settings.Save();

            this.Close();
        }
    }

    public class ReceiptPrintingConfig
    {
        public string Header { get; set; }
        public string Details { get; set; }
        public string Footer { get; set; }
        public string Printer { get; set; }
    }
}
