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
            //searchFilter.SelectedIndex = 0;
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
        List<InventoryItem> searchedItems = new List<InventoryItem>();
        private void seachBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchText.Text))
            {
                return;
            }



            using (var p = new POSEntities())
            {
                ///search inventoryitems with given barcode
                searchedItems = p.InventoryItems.Where(x => x.Product.ItemId == searchText.Text).ToList();

                if (searchedItems.Count == 0)
                {
                    //MessageBox.Show("Item not found.");
                    switch (MessageBox.Show("Would you like to add item?","Item not found.",MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:
                            using(var additem = new StockinForm())
                            {
                                additem.ShowDialog();
                            }
                            break;
                        default:
                            break;
                    }
                    return;
                }
                ///get the item reference of the first element for assignment
                var item = searchedItems[0].Product.Item;

                ///actual assignment of item values
                itemName.Text = item.Name;
                price.Value = item.SellingPrice;

                ///reset the serial number option
                serialNumber.Items.Clear();
                /// to reset the height after clear
                serialNumber.IntegralHeight = false;
                /// to prep the height just in case there are items to be added
                serialNumber.IntegralHeight = true;
                ///add serials in serial number options
                foreach (var i in searchedItems.Where(x => !string.IsNullOrEmpty(x.SerialNumber)))
                {
                    serialNumber.Items.Add(i.SerialNumber);
                }

                ///if there are serial, select the first element of the serials
                if (serialNumber.Items.Count > 0)
                {
                    serialNumber.SelectedIndex = 0;
                }
                ///if no serial then set maximum quantity to the sum of searched items
                quantity.Maximum = serialNumber.Items.Count == 0 ? (searchedItems.Sum(x => x.Quantity) == 0 ? 9999999 : searchedItems.Sum(x => x.Quantity)) : 1;
                maxQuant.Text = quantity.Maximum >= 9999999 ? "" : "/" + quantity.Maximum;
                ///if there are serials then disable the quantity value
                quantity.Enabled = serialNumber.Items.Count == 0 ? true : false;

            }
            addToCartBtn.Enabled = true;
        }

        void Clear()
        {
            searchText.Clear();
            itemName.Clear();
            serialNumber.Items.Clear();
            quantity.Value = 1;
            price.Value = 0;
            discount.Value = 0;
            quantity.Enabled = true;
        }
        bool alreadyCart(out int index)
        {
            index = -1;
            return false;
        }

        private void addToCartBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(itemName.Text))
            {
                return;
            }

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
            {
                //InventoryItem item = new InventoryItem();
                using (var p = new POSEntities())
                {
                    if (!string.IsNullOrEmpty(serialNumber.Text))
                    {
                        var item = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == serialNumber.Text);
                        cartTable.Rows.Add(item.Product.Item.Barcode, serialNumber.Text, item.Product.Item.Name, quantity.Value, price.Value, discount.Value, (quantity.Value * price.Value * ((100 - discount.Value) / 100)), item.Product.Supplier.Name, "Edit", "Delete");
                    }
                    else
                    {

                    }
                }

            }
            calculateTotal();
            Clear();
            addToCartBtn.Enabled = false;
            ActiveControl = searchText;
        }
        decimal getTotalPrice(int quantity, decimal price, decimal discount)
        {
            return quantity * price * ((100 - discount) / 100);
        }
        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchBtn.PerformClick();
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

        private void soldTo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soldTo.Text))
            {
                return;
            }

            using (var p = new POSEntities())
            {
                var customer = p.Customers.FirstOrDefault(x => x.Name == soldTo.Text);
                if (customer == null)
                {
                    switch (MessageBox.Show("Would you like to add Customer?", "Customer is not found in the registry.", MessageBoxButtons.YesNo))
                    {
                        case DialogResult.Yes:

                            ActiveControl = soldTo;
                            addCustomerBtn.PerformClick();
                            break;
                        default:
                            soldTo.Text = string.Empty;
                            break;

                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var advance = new AdvancedSearchForm();
            advance.ItemSelected += Advance_ItemSelected;
            advance.Show();
        }

        private void Advance_ItemSelected(object sender, ItemInfoHolder e)
        {
            var adv = (AdvancedSearchForm)sender;

            for (int i = 0; i < cartTable.RowCount; i++)
            {
                if (cartTable.Rows[i].Cells[1].Value != null)
                {
                    if (e.Serial == cartTable.Rows[i].Cells[1].Value.ToString())
                    {
                        MessageBox.Show("Already in cart");
                        return;
                    }
                }
            }
            cartTable.Rows.Add(e.Barcode, e.Serial, e.Name, e.Quantity, e.SellingPrice, e.discount, e.TotalPrice, e.Supplier, "Edit", "Delete");
            adv.Close();
        }

        private void SellForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                advSearchBtn.PerformClick();
            }
            if(e.KeyCode == Keys.F2)
            {
                stockinBtn.PerformClick();
            }
        }

        private void stockinBtn_Click(object sender, EventArgs e)
        {
            using (var additem = new StockinForm())
            {
                additem.ShowDialog();
            }
        }
    }
}
