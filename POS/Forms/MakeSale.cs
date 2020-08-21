using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using VS2017POS.EntitiyFolder;
using POS.Misc;

namespace POS.Forms
{

    public struct ItemInfoHolder
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Supplier { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal discount { get; set; }
        private int q;
        public int Quantity
        {
            get
            {
                return Serial == null ? q : 1;
            }
            set { q = value; }
        }
        public decimal TotalPrice { get { return (Quantity * SellingPrice) * ((100 - discount) / 100); } }
    }

    public partial class MakeSale : Form
    {
        SaleType currentSaleType = SaleType.Regular;

        decimal cartTotalValue;

        ItemInfoHolder tempItem;
        public event EventHandler OnSave;
        public MakeSale()
        {
            InitializeComponent();
        }

        private void StockinForm_Load(object sender, EventArgs e)
        {
            filter.SelectedIndex = 0;
            itemsTable.Rows.Clear();
            using (var p = new POSEntities())
            {

                foreach (var i in p.InventoryItems)
                    itemsTable.Rows.Add(i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Quantity == 0 ? "Infinite" : i.Quantity.ToString(), i.Product.Item.SellingPrice, i.Product.Supplier.Name);

                soldTo.Items.Clear();
                foreach (var i in p.Customers)
                {
                    soldTo.AutoCompleteCustomSource.Add(i.Name);
                    soldTo.Items.Add(i.Name);
                }
            }
        }

        bool alreadyInTable(out int index)
        {
            for (int i = 0; i < cartTable.RowCount; i++)
            {
                var row = cartTable.Rows[i];
                if (tempItem.Barcode == row.Cells[0].Value.ToString() && tempItem.discount == Convert.ToDecimal(row.Cells[5].Value) && tempItem.Supplier == row.Cells[7].Value.ToString())
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void sell_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(soldTo.Text))
            {
                MessageBox.Show("Customer cannot be empty");
                return;
            }
            if (cartTable.RowCount == 0)
                return;

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

                OnSave?.Invoke(this, null);

                MessageBox.Show("Sold Items.");

                this.Close();
            }
        }

        int quantToAdd(int input, int rightQ, int leftQ)
        {
            if (input <= leftQ - rightQ)
            {
                return input;
            }
            MessageBox.Show("Maximum quantity already reached.");
            return rightQ - leftQ;
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {

            quantity.Maximum = currentSelectedQuantity == 0 ? 999999999 : currentSelectedQuantity;
            ///revert to 1 after selection changed
            quantity.Value = 1;

            var cRows = leftCurrentRow;
            if (cRows == null)
                return;

            tempItem.Barcode = cRows.Cells[0].Value.ToString();
            tempItem.Serial = cRows.Cells[1].Value?.ToString();
            tempItem.Name = cRows.Cells[2].Value.ToString();
            tempItem.SellingPrice = Convert.ToDecimal(cRows.Cells[4].Value);
            tempItem.Supplier = cRows.Cells[5].Value.ToString();
            tempItem.discount = discount.Value;

            quantity.Value = string.IsNullOrEmpty(tempItem.Serial) ? quantity.Value : 1;
            quantity.Enabled = string.IsNullOrEmpty(tempItem.Serial) ? true : false;
            tempItem.Quantity = (int)quantity.Value;

            price.Text = tempItem.SellingPrice.ToString();
            totalPrice.Text = tempItem.TotalPrice.ToString();
            itemName.Text = tempItem.Name;

        }


        DataGridViewRow leftCurrentRow
        {
            get
            {
                if (itemsTable.SelectedCells.Count <= 0)
                    return null;

                return itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];
            }
        }

        int currentSelectedQuantity
        {
            get
            {
                if (leftCurrentRow.Cells[3].Value.ToString() == "Infinite")
                    return 0;
                return Convert.ToInt32(leftCurrentRow.Cells[3].Value);
            }
        }

        void ProcessLeftTable()
        {
            ///infinity
            if (currentSelectedQuantity == 0)
                return;
            int newQuant = currentSelectedQuantity - (int)quantity.Value;
            if (newQuant <= 0)
            {
                itemsTable.Rows.RemoveAt(itemsTable.SelectedCells[0].RowIndex);
            }
            else
            {
                leftCurrentRow.Cells[3].Value = newQuant.ToString();
            }
        }

        void ProcessRightTable()
        {
            if (string.IsNullOrEmpty(tempItem.Serial))
            {
                int index;
                if (alreadyInTable(out index))
                {
                    int currQuant = Convert.ToInt32(cartTable.Rows[index].Cells[3].Value);
                    int newQuant = currQuant + (int)quantity.Value;
                    decimal disc = Convert.ToDecimal(cartTable.Rows[index].Cells[5].Value);
                    cartTable.Rows[index].Cells[3].Value = newQuant;
                    cartTable.Rows[index].Cells[6].Value = newQuant * Convert.ToDecimal(price.Text) * ((100 - disc) / 100);
                    return;
                }
            }
            cartTable.Rows.Add(tempItem.Barcode, tempItem.Serial, tempItem.Name, tempItem.Quantity, tempItem.SellingPrice.ToString(), tempItem.discount, tempItem.TotalPrice.ToString(), tempItem.Supplier);
        }

        void addItem()
        {
            if (itemsTable.SelectedCells.Count == 0)
                return;
            ProcessRightTable();
            ProcessLeftTable();
            calculateTotal();
        }

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            addItem();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (cartTable.RowCount == 0)
                return;
            int index = cartTable.CurrentCell.RowIndex;
            cartTable.Rows.RemoveAt(index);
        }


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

        private void inventoryTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //calculateTotal();
        }

        private void amountChangedCallback(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cartTotal.Text))
                return;

            decimal amountRec = amountRecieved.Value;
            ///decimal Tobepayed = tota;

            change.Text = string.Format("₱ {0:n}", (amountRec - cartTotalValue));
        }
        void SetSoldTo()
        {
            using (var p = new POSEntities())
            {
                soldTo.Items.Clear();
                foreach (var i in p.Customers)
                    soldTo.Items.Add(i.Name);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    CreateCustomerProfile cm = new CreateCustomerProfile();
        //    this.Enabled = false;
        //    cm.FormClosing += (a, b) => { this.Enabled = true; };
        //    cm.OnSave += (a, b) =>
        //    {
        //        SetSoldTo();
        //    };

        //    cm.Show();
        //}

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            int index = -1;

            for (int i = 0; i < itemsTable.RowCount; i++)
            {
                var cellInLower = itemsTable.Rows[i].Cells[filter.SelectedIndex].Value?.ToString().ToLower();

                if (cellInLower != null)
                {
                    var searchInLower = searchText.Text.ToLower();

                    if (cellInLower.Contains(searchInLower))
                    {
                        index = i;
                        break;
                    }
                }
            }

            if (index == -1)
            {
                MessageBox.Show("Item not found.");
                return;
            }

            itemsTable.FirstDisplayedScrollingRowIndex = index;
            itemsTable.Rows[index].Selected = true;

            if (autoAdd.Checked)
                addItem();
            searchText.SelectAll();
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            tempItem.Quantity = (int)quantity.Value;
            tempItem.discount = discount.Value;
            totalPrice.Text = tempItem.TotalPrice.ToString();
        }

        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            var createCustomer = new CreateCustomerProfile();
            createCustomer.OnSave += CreateCustomer_OnSave;
            createCustomer.ShowDialog();
        }

        private void CreateCustomer_OnSave(object sender, EventArgs e)
        {
            soldTo.Items.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.Customers)
                    soldTo.Items.Add(i.Name);
            }
        }
    }
}
