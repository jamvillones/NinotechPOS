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
        int Id;
        int tQuantity;

        public event EventHandler<InventoryItemDetailArgs> OnConfirm;

        public void SetValues(int id, string barcode, string serial, string name, Image img, decimal price, int totalQuantity,  decimal discount = 0,  int quantity = 1, bool alreadyInTable = false)
        {
            Id = id;
            this.barcode.Text = barcode;
            this.serial.Text = serial ?? "N/A";

            this.quantity.ReadOnly = string.IsNullOrEmpty(serial) ? false : true;

            this.itemName.Text = name;

            pic.Image = img;

            this.price.Value = price;
            this.discount.Value = discount;

            this.discount.Maximum = this.price.Value;
            this.tQuantity = totalQuantity;
            this.quantity.Maximum = this.tQuantity == 0 ? 999999999 : tQuantity;
            this.quantity.Value = quantity;

            this.totalQuantity.Text = tQuantity == 0 ? "Infinite" : tQuantity.ToString();

            if (alreadyInTable)
            {
                this.price.ReadOnly = true;
                this.discount.ReadOnly = true;
                this.price.Increment = 0;
                this.discount.Increment = 0;
            }
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

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want to add this item in cart?","", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    return;
            var i = new InventoryItemDetailArgs(Id, (int)(quantity.Value), price.Value, discount.Value);
            OnConfirm.Invoke(this, i);
            this.Close();
        }
    }
}
