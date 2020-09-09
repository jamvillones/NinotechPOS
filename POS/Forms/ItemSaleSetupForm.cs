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
        //int currentQuantity = 1;
        //decimal currentPrice;
        //decimal currentDiscount;

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

        //private void price_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox s = sender as TextBox;
        //    if (s.Text == string.Empty)
        //    {
        //        return;
        //    }

        //    CalculateTotal();
        //}

        void CalculateTotal()
        {
            //currentQuantity = quantity.Text == string.Empty ? 1 : Convert.ToInt32(this.quantity.Text);
            //currentPrice = price.Text == string.Empty ? 0 : Convert.ToDecimal(this.price.Text);
            //currentDiscount = discount.Text == string.Empty ? 0 : Convert.ToDecimal(this.discount.Text);

            decimal t = (price.Value - discount.Value) * quantity.Value;
            total.Text = string.Format("₱ {0:n}", t);
        }

        private void price_ValueChanged(object sender, EventArgs e)
        {
            discount.Maximum = price.Value;
            CalculateTotal();
        }

        ////TextBox currentControl;
        //Color selectedColor = SystemColors.GradientActiveCaption;
        //Color normalColor = Color.White;

        //private void price_Click(object sender, EventArgs e)
        //{
        //    //var v = sender as TextBox;
        //    //currentControl.BackColor = normalColor;
        //    //currentControl = v;
        //    //keypad1.SetTarget(currentControl);
        //    //currentControl.BackColor = selectedColor;
        //}

        //private void ItemSaleSetupForm_Load(object sender, EventArgs e)
        //{
        //    //currentControl = price;
        //    //currentControl.BackColor = selectedColor;
        //    //keypad1.SetTarget(currentControl);
        //}


        //private void NumberOnlyFilter(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        //        (e.KeyChar != '.'))
        //    {
        //        e.Handled = true;
        //    }

        //    // only allow one decimal point
        //    if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void price_Leave(object sender, EventArgs e)
        //{
        //    if (price.Text == string.Empty)
        //    {
        //        currentPrice = 0;
        //        price.Text = (0.00).ToString();
        //    }
        //}

        //private void discount_Leave(object sender, EventArgs e)
        //{
        //    if (discount.Text == string.Empty)
        //    {
        //        currentDiscount = 0;
        //        discount.Text = (0.00).ToString();
        //    }
        //}

        //private void groupBox5_Leave(object sender, EventArgs e)
        //{
        //    if (quantity.Text == string.Empty)
        //    {
        //        currentQuantity = 1;
        //        quantity.Text = (1).ToString();
        //    }
        //}

        //private void price_TextChanged(object sender, EventArgs e)
        //{
        //    if (price.Text == string.Empty)
        //    {
        //        currentPrice = 0;
        //    }

        //    CalculateTotal();
        //}

        //private void discount_TextChanged(object sender, EventArgs e)
        //{

        //    if (discount.Text == string.Empty)
        //    {
        //        currentDiscount = 0;
        //    }

        //    CalculateTotal();
        //}

        //private void quantity_TextChanged(object sender, EventArgs e)
        //{

        //    if (quantity.Text == string.Empty)
        //    {
        //        currentQuantity = 1;
        //    }

        //    CalculateTotal();
        //}

        //private void pic_Click(object sender, EventArgs e)
        //{
        //    SendKeys.Send("{B}");
        //}
    }
}
