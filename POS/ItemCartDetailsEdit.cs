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
    public partial class ItemCartDetailsEdit : Form
    {
        private int quantity { get => (int)numericUpDown3.Value; set => numericUpDown3.Value = value; }

        private decimal price { get => numericUpDown1.Value; set => numericUpDown1.Value = value; }

        private decimal discount { get => numericUpDown2.Value; set => numericUpDown2.Value = value; }

        private decimal grandTotal { get => quantity * (price - discount); }

        public ItemCartDetailsEdit(string itemName, int quantity, decimal price, decimal discount, int maxQ = 999999999)
        {
            InitializeComponent();

            label5.Text = itemName;
            numericUpDown3.Maximum = maxQ;

            this.quantity = quantity;
            this.price = price;
            this.discount = discount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Tag = new NewCartDetails()
            {
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            this.DialogResult = DialogResult.OK;
        }

        private void numChanged_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = string.Format("P {0:n}", grandTotal);
        }
    }
}
