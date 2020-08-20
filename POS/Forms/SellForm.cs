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
        public SellForm()
        {
            InitializeComponent();
            keypad.SetTarget(searchText);
        }
        bool checkedOut = false;
        private void SellForm_Load(object sender, EventArgs e)
        {
            searchFilter.SelectedIndex = 0;
            //keypad1.SetTarget(textBox1);
            using (var p = new POSEntities())
            {
                soldTo.Items.Clear();
                foreach (var i in p.Customers)
                {
                    soldTo.AutoCompleteCustomSource.Add(i.Name);
                    soldTo.Items.Add(i.Name);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //var price = Convert.ToDecimal(priceTxt.ValueText);
            totalPrice.Text = (quantity.Value * price.Value * ((100 - discount.Value) / 100)).ToString();
        }
        private void amountChangedCallback(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cartTotal.Text))
                return;

            decimal amountRec = amountRecieved.Value;
            ///decimal Tobepayed = tota;

            change.Text = string.Format("₱ {0:n}", (amountRec - cartTotalValue));
        }

        private void seachBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                return;
            }
            InventoryItem i = new InventoryItem();
            using (var p = new POSEntities())
            {
                if (searchFilter.Text == "BARCODE")
                    i = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Barcode == searchText.Text);
                else
                    i = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == searchText.Text);

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

                int newQuant = (int)quantity.Value + currQuant;
                c[3].Value = newQuant;
                c[6].Value = newQuant * currPrice * ((100 - currDiscount) / 100);

            }
            else
                cartTable.Rows.Add(searchedItemInfo.Barcode, searchedItemInfo.Serial, searchedItemInfo.Name, quantity.Value, price.Value, discount.Value, (quantity.Value * price.Value * ((100 - discount.Value) / 100)), searchedItemInfo.Supplier);
            calculateTotal();
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
            if (checkedOut)
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
        SaleType currentSaleType = SaleType.Regular;
        decimal cartTotalValue;
        void calculateTotal()
        {
            cartTotalValue = 0;
            for (int i = 0; i < cartTable.RowCount; i++)
            {
                decimal v = Convert.ToDecimal(cartTable.Rows[i].Cells[6].Value);
                cartTotalValue += v;
            }
            cartTotal.Text = string.Format("₱ {0:n}", cartTotalValue);
        }
        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soldTo.Text))
            {
                MessageBox.Show("Customer cannot be empty");
                return;
            }
            if (cartTable.RowCount == 0)
                return;

            switch (MessageBox.Show(this, "Are you sure you want to finalize this purchase?", "Please double check.", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //Stay on this form
                case DialogResult.No:
                    return;

                default:
                    break;
            }

            using (var p = new POSEntities())
            {
                Sale newSale = new Sale();
                string username = UserManager.instance.currentLogin.Username;
                newSale.Login = p.Logins.FirstOrDefault(x => x.Username == username);

                Customer customer = p.Customers.FirstOrDefault(x => x.Name == soldTo.Text);
                newSale.CustomerId = customer.Id;

                newSale.Date = DateTime.Now;
                newSale.AmountRecieved = amountRecieved.Value;
                newSale.TotalPrice = cartTotalValue;

                currentSaleType = cartTotalValue - amountRecieved.Value > 0 ? SaleType.Charged : SaleType.Regular;
                newSale.SaleType = currentSaleType.ToString();

                p.Sales.Add(newSale);

                for (int i = 0; i < cartTable.RowCount; i++)
                {
                    SoldItem s = new SoldItem();

                    var cartColumns = cartTable.Rows[i].Cells;
                    var itemId = cartColumns[0].Value.ToString();
                    var itemSupp = cartColumns[7].Value.ToString();
                    var serial = cartColumns[1].Value?.ToString();

                    s.Discount = Convert.ToDecimal(cartColumns[5].Value);
                    s.SerialNumber = serial;
                    s.ItemName = cartColumns[2].Value.ToString();
                    s.Quantity = Convert.ToInt32(cartColumns[3].Value);
                    s.ItemPrice = Convert.ToDecimal(cartColumns[4].Value);
                    s.ItemSupplier = itemSupp;

                    s.SaleId = newSale.Id;

                    var inventoryItem = p.InventoryItems.FirstOrDefault(x => x.Product.ItemId == itemId && x.Product.Supplier.Name == itemSupp && x.SerialNumber == serial);
                    if (inventoryItem != null && inventoryItem.Product.Item.Type == ItemType.Hardware.ToString())
                    {

                        inventoryItem.Quantity -= s.Quantity;

                        if (inventoryItem.Quantity == 0)
                            p.InventoryItems.Remove(inventoryItem);
                    }

                    p.SoldItems.Add(s);
                }

                p.SaveChanges();

                //OnSave?.Invoke(this, null);

                MessageBox.Show("Sold Items.");
                checkedOut = true;
                this.Close();
            }
        }

        private void exactAmountBtn_Click(object sender, EventArgs e)
        {
            amountRecieved.Value = cartTotalValue;
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            using (CreateCustomerProfile c = new CreateCustomerProfile())
            {
                c.OnSave += C_OnSave;
                c.ShowDialog();
            }
        }

        private void C_OnSave(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                soldTo.Items.Clear();
                foreach (var i in p.Customers)
                {
                    soldTo.AutoCompleteCustomSource.Add(i.Name);
                    soldTo.Items.Add(i.Name);
                }
            }
        }
    }
}
