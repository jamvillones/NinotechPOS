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
    public partial class ItemSaleSetupForm : Form
    {
        public ItemSaleSetupForm()
        {
            InitializeComponent();
        }

        int tQuantity;

        public void SetValues(string barcode, string serial, string name, Image img, decimal price, int totalQuantity)
        {
            this.barcode.Text = barcode;
            this.serial.Text = serial;

            quantity.ReadOnly = string.IsNullOrEmpty(serial) ? false : true;

            this.itemName.Text = name;

            pic.Image = img;

            this.price.Value = price;
            this.discount.Maximum = this.price.Value;
            this.tQuantity = totalQuantity;
            this.quantity.Maximum = this.tQuantity;

            this.totalQuantity.Text = totalQuantity.ToString();
        }

        void CalculateTotal()
        {
            decimal t = (price.Value - discount.Value) * quantity.Value;
            total.Text = string.Format("₱ {0:n}", t);
        }

        private void price_ValueChanged(object sender, EventArgs e)
        {
            discount.Maximum = price.Value;
            CalculateTotal();
        }
    }
}
