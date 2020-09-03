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
        public decimal TotalPrice { get { return (Quantity * (SellingPrice - discount)); } }
    }

    public partial class MakeSale : Form
    {
        class ItemInCart
        {
            public ItemInCart(string barcode, string serial, int quantity, string supplier)
            {
                this.Barcode = barcode;
                this.Serial = serial;
                this.Quantity = quantity;
                this.Supplier = supplier;
            }
            public string Barcode { get; set; }
            public string Serial { get; set; }
            public int Quantity { get; set; }
            public string Supplier { get; set; }
        }
        List<ItemInCart> inCart = new List<ItemInCart>();

        // SaleType currentSaleType = SaleType.Regular;

        decimal cartTotalValue
        {
            get
            {
                decimal temp = new decimal();
                for (int i = 0; i < cartTable.RowCount; i++)
                {
                    decimal v = Convert.ToDecimal(cartTable.Rows[i].Cells[6].Value);
                    temp += v;
                }
                return temp;
            }
        }

        ItemInfoHolder tempItem;
        public event EventHandler OnSave;
        public MakeSale()
        {
            InitializeComponent();
        }

        public MakeSale(string barcode)
        {
            InitializeComponent();
            searchControl.SearchText = barcode;
            doSearch();
        }

        private void StockinForm_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                soldTo.Items.Clear();
                var soldtoItems = p.Customers.OrderBy(x => x.Name).Select(x => x.Name).ToArray();
                soldTo.Items.AddRange(soldtoItems);
                soldTo.AutoCompleteCustomSource.AddRange(soldtoItems);

                var inventoryItems = p.InventoryItems.Select(x => x.Product.Item.Name).ToArray();
                searchControl.SetAutoComplete(inventoryItems);
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
            if (cartTable.RowCount == 0)
                return;
            if (string.IsNullOrEmpty(soldTo.Text))
            {
                MessageBox.Show("Customer cannot be empty");
                return;
            }
            if (MessageBox.Show("Are you sure you want to continue?", "Sale is about to be made.", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
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
                newSale.SaleType = saleType.Text;

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
                    s.Quantity = Convert.ToInt32(cartColumns[3].Value);
                    s.ItemPrice = Convert.ToDecimal(cartColumns[4].Value);

                    s.Product = p.Products.FirstOrDefault(x => x.Item.Barcode == itemId && x.Supplier.Name == itemSupp);
                    //s.ItemName = cartColumns[2].Value.ToString();
                    //s.ItemSupplier = itemSupp;
                    ///Console.WriteLine(newSale.Id);
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
            if (leftCurrentRow == null)
                return;

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
                if (itemsTable.SelectedCells.Count == 0)
                {
                    return null;
                }

                return itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];
            }
        }

        int currentSelectedQuantity
        {
            get
            {
                if (leftCurrentRow?.Cells[3].Value.ToString() == "Infinite")
                    return 0;

                return Convert.ToInt32(leftCurrentRow.Cells[3].Value);
            }
        }

        void ProcessLeftTable()
        {
            ///infinity
            if (itemsTable.SelectedCells.Count == 0)
                return;

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
                quantity.Maximum = newQuant;
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
                    cartTable.Rows[index].Cells[6].Value = newQuant * (price.Value - discount.Value);
                    return;
                }
            }
            cartTable.Rows.Add(tempItem.Barcode, tempItem.Serial, tempItem.Name, tempItem.Quantity, tempItem.SellingPrice.ToString(), tempItem.discount, tempItem.TotalPrice.ToString(), tempItem.Supplier);
            inCart.Add(new ItemInCart(tempItem.Barcode, tempItem.Serial, tempItem.Quantity, tempItem.Supplier));
        }


        //string getSerias()
        //{

        //}
        void addItem()
        {
            if (itemsTable.SelectedCells.Count == 0)
                return;
            if (!string.IsNullOrEmpty(tempItem.Serial))
            {
                var i = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells[1].Value?.ToString() == tempItem.Serial);
                if (i != null)
                {
                    MessageBox.Show("already in cart");
                    return;
                }
            }

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
            cartTotal.Text = string.Format("₱ {0:n}", cartTotalValue);
            saleType.SelectedIndex = cartTotalValue - amountRecieved.Value > 0 ? 1 : 0;
        }

        private void amountChangedCallback(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cartTotal.Text))
                return;

            decimal amountRec = amountRecieved.Value;

            change.Text = string.Format("₱ {0:n}", (amountRec - cartTotalValue));
            calculateTotal();
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

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchControl.DoSearch();
            }
        }

        private void numerice_ValueChanged(object sender, EventArgs e)
        {
            tempItem.Quantity = (int)quantity.Value;
            discount.Maximum = price.Value;
            tempItem.discount = discount.Value;
            tempItem.SellingPrice = price.Value;
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
            soldTo.AutoCompleteCustomSource.Clear();

            using (var p = new POSEntities())
            {
                soldTo.Items.AddRange(p.Customers.Select(x => x.Name).ToArray());
                soldTo.AutoCompleteCustomSource.AddRange(p.Customers.Select(x => x.Name).ToArray());
            }
        }
        void doSearch()
        {
            searchControl.DoSearch();
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            doSearch();
        }

        private void MakeSale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                this.ActiveControl = searchControl.firsControl;
                e.SuppressKeyPress = true;
            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                // Do what you want here
                addBtn.PerformClick();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                // Do what you want here
                checkoutBtn.PerformClick();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            amountRecieved.Value = cartTotalValue;
        }

        private void cartTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this in cart?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            var i = inCart.FirstOrDefault(x => x.Barcode == e.Row.Cells[0].Value.ToString() && x.Serial == e.Row.Cells[1].Value?.ToString() && x.Supplier == e.Row.Cells[7].Value.ToString());
            inCart.Remove(i);
            itemsTable.Rows.Clear();
        }

        private void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            using (var p = new POSEntities())
            {
                var items = p.InventoryItems.Where(x => x.Product.Item.Barcode == e.Text);

                if (items.Count() == 0)
                {
                    items = p.InventoryItems.Where(x => x.SerialNumber == e.Text);
                    if (items.Count() == 0)
                    {
                        items = p.InventoryItems.Where(x => x.Product.Item.Name.Contains(e.Text));
                    }
                }
                var filtered = items.ToArray().Where(x => !inCart.Any(y => y.Barcode == x.Product.Item.Barcode && y.Serial == x.SerialNumber && y.Supplier == x.Product.Supplier.Name && y.Quantity >= x.Quantity));

                if (filtered.Count() == 0)
                {
                    MessageBox.Show("Item not found.");
                    return;
                }
                e.SearchFound = true;
                itemsTable.Rows.Clear();
                foreach (var i in filtered)
                {
                    // int newQuant  = filtered.FirstOrDefault(x=> inCart.Any(y => y.Barcode == x.Product.Item.Barcode && y.Serial == x.SerialNumber && y.Supplier == x.Product.Supplier.Name)).
                    var j = inCart.FirstOrDefault(x => inCart.Any(y => y.Barcode == i.Product.Item.Barcode && y.Serial == i.SerialNumber && y.Supplier == i.Product.Supplier.Name));
                    int newQuant = i.Quantity - (j == null ? 0 : j.Quantity);

                    itemsTable.Rows.Add(i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Quantity == 0 ? "Infinite" : newQuant.ToString(), i.Product.Item.SellingPrice, i.Product.Supplier.Name);
                }
            }
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            itemsTable.Rows.Clear();
        }
    }
}
