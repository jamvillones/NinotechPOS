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
            this.itemName.Text = name;

            pic.Image = img;
            this.price.Value = price;

            this.tQuantity = totalQuantity;
            this.totalQuantity.Text = totalQuantity.ToString();

            discount.Maximum = this.price.Value;
            quantity.Maximum = tQuantity;

        }

        private void price_ValueChanged(object sender, EventArgs e)
        {
            decimal t = (price.Value - discount.Value) * quantity.Value;
            total.Text = string.Format("₱ {0:n}", t);
        }

        Control currentControl;
        Color selectedColor = SystemColors.GradientActiveCaption;
        Color normalColor = Color.White;
        private void price_Click(object sender, EventArgs e)
        {
            var v = sender as NumericUpDown;
            currentControl.BackColor = normalColor;
            currentControl = v;
            keypad1.SetTarget(currentControl);
            currentControl.BackColor = selectedColor;
        }

        private void ItemSaleSetupForm_Load(object sender, EventArgs e)
        {
            currentControl = price;
            currentControl.BackColor = selectedColor;
            keypad1.SetTarget(currentControl);
        }
    }
}
