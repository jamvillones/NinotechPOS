using POS.Misc;
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
    public partial class SellForm : Form
    {

        //class TempItem
        //{
        //    public string Barcode { get; set; }
        //    public string Name { get; set; }
        //    public string Serial { get; set; }
        //    public string Supplier { get; set; }
        //    public decimal SellingPrice { get; set; }
        //    public decimal discount { get; set; }
        //    private int q;
        //    public int Quantity
        //    {
        //        get
        //        {
        //            return Serial == null ? q : 1;
        //        }
        //        set { q = value; }
        //    }
        //    public decimal TotalPrice { get { return (Quantity * SellingPrice) * ((100 - discount) / 100); } }
        //}
        public SellForm()
        {
            InitializeComponent();
            keypad1.SetTarget(searchText);
        }

        private void SellForm_Load(object sender, EventArgs e)
        {
            //keypad1.SetTarget(textBox1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //var price = Convert.ToDecimal(priceTxt.ValueText);
            totalPrice.Text = (quantity.Value * price.Value * ((100 - discount.Value) / 100)).ToString();
        }

        private void seachBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                return;
            }
            using (var p = new POSEntities())
            {
                var i = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Barcode == searchText.Text);
                if (i == null)
                {
                    searchText.SelectAll();
                    MessageBox.Show("Item not found");
                    return;
                }

                searchedItemInfo.Barcode = i.Product.Item.Barcode;
                searchedItemInfo.Name = i.Product.Item.Name;
                searchedItemInfo.Serial = i.SerialNumber;
                searchedItemInfo.Supplier = i.Product.Supplier.Name;
                searchedItemInfo.Quantity = i.Quantity;
                serialNumber.Text = searchedItemInfo.Serial;

                quantity.Maximum = i.Product.Item.Type != ItemType.Hardware.ToString() ? 999999999999 : i.Quantity;
                quantity.Enabled = string.IsNullOrEmpty(searchedItemInfo.Serial);
                itemName.Text = searchedItemInfo.Name;
                price.Value = i.Product.Item.SellingPrice;
            }
        }

        ItemInfoHolder searchedItemInfo;
        void Clear()
        {
            searchText.Clear();
            itemName.Clear();
            serialNumber.Clear();
            quantity.Value = 1;
            price.Value = 0;
            discount.Value = 0;
            quantity.Enabled = true;
        }
        bool alreadyCart(out int index)
        {
            if (!string.IsNullOrEmpty(searchedItemInfo.Serial))
            {
                index = -1;
                return false;
            }

            for (int i = 0; i < cartTable.RowCount; i++)
            {
                var currentSelectedRow = cartTable.Rows[i].Cells;
                ////compare barcode and supplier
                if (searchedItemInfo.Barcode == currentSelectedRow[0].Value.ToString() && searchedItemInfo.Supplier == currentSelectedRow[7].Value.ToString())
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(itemName.Text))
            {
                return;
            }

            ////using (var p = new POSEntities())
            ////{
            ////    var item = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Barcode == searchedItemInfo.Barcode && x.Product.Supplier.Name == searchedItemInfo.Supplier && x.SerialNumber == searchedItemInfo.Serial);
            ////    if (item.Quantity > 0)
            ////    {
            ////        var newQuantity = searchedItemInfo.Quantity - (int)quantity.Value;

            ////        if (newQuantity <= 0)
            ////            p.InventoryItems.Remove(item);
            ////        else
            ////            item.Quantity = newQuantity;

            ////        p.SaveChanges();
            ////    }
            ////}

            int index;
            if (alreadyCart(out index))
            {
                var c = cartTable.Rows[index].Cells;
                int currQuant = Convert.ToInt32(c[3].Value);
                decimal currPrice = Convert.ToDecimal(c[4].Value);
                decimal currDiscount = Convert.ToDecimal(c[5].Value);

                int newQuant = (int)quantity.Value * currQuant;
                c[3].Value = newQuant;
                c[6].Value = newQuant * currPrice * ((100 - currDiscount) / 100);

            }
            else
                cartTable.Rows.Add(searchedItemInfo.Barcode, searchedItemInfo.Serial, searchedItemInfo.Name, quantity.Value, price.Value, discount.Value, (quantity.Value * price.Value * ((100 - discount.Value) / 100)), searchedItemInfo.Supplier);

            Clear();
        }
        decimal getTotalPrice(int quantity, decimal price, decimal discount)
        {
            return quantity * price * ((100 - discount) / 100);
        }
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                seachBtn.PerformClick();
        }

        private void SellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cartTable.RowCount == 0)
                return;
            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (this.DialogResult == DialogResult.Cancel)
            {
                // Assume that X has been clicked and act accordingly.
                // Confirm user wants to close
                switch (MessageBox.Show(this, "Do you wish to discard changes and exit?", "There are unsold items in cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
