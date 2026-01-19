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
    public partial class Payment_Form : Form
    {
        public Payment_Form(decimal maxAmount)
        {
            InitializeComponent();
            paymentNum.Maximum = maxAmount;
        }

        private void addPaymentBtn_Click(object sender, EventArgs e)
        {
            if (paymentNum.Value == 0 || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Must Provide Details and Amount Should be Above 0.00", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Tag = new ChargedPayRecord() { AmountPayed = paymentNum.Value, Details = comboBox1.Text.Trim() };
            DialogResult = DialogResult.OK;
        }
    }
}
