using POS.Misc;
using System;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Add_Payment_Form : Form
    {
        public Add_Payment_Form(decimal maxAmount)
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

            Tag = new ChargedPayRecord()
            {
                AmountPayed = paymentNum.Value,
                Details = comboBox1.Text.Trim().ToUpper(),
                TransactionTime = DateTime.Now,
                Username = UserManager.instance.CurrentLogin.Username
            };

            DialogResult = DialogResult.OK;
        }

        private void Payment_Form_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Add Full Payment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            Tag = new ChargedPayRecord()
            {
                AmountPayed = paymentNum.Maximum,
                Details = comboBox1.Text.Trim().ToUpper(),
                TransactionTime = DateTime.Now,
                Username = UserManager.instance.CurrentLogin.Username
            };

            DialogResult = DialogResult.OK;
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(comboBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(comboBox1.Text);
        }
    }
}
