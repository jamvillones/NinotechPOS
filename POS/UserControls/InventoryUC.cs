using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Forms;
using POS.Misc;

namespace POS.UserControls
{
    public partial class InventoryUC : UserControl, Interfaces.ITab
    {
        class InventoryDetails
        {
            public string Barcode { get; set; }
            public string Name { get; set; }
            public decimal SellingPrice { get; set; }
            public int Quantity { get; set; }
        }

        //Login currLogin;
        public InventoryUC()
        {
            InitializeComponent();
            //currLogin = UserManager.instance.currentLogin;
        }

        #region Tab functions
        public virtual void RefreshData()
        {
            // initInventoryTable();
            // initItemsTable();
        }

        public virtual Button EnterButton()
        {
            return null;
        }

        public virtual Control FirstControl()
        {
            return null;
        }

        public async Task InitializeAsync()
        {
            await initItemsTableAsync();

            // await Task.Run(() => { initItemsTable(); });
        }
        #endregion

        #region Control Actions
        SellItem s = null;
        protected virtual void sellItem_Click(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count == 0)
            {
                return;
            }

            //if (itemsTable.SelectedCells[quantityCol.Index].Value.ToString() == "EMPTY")
            //{
            //    using (var s = new MakeSale())
            //    {
            //        s.OnSave += OnInventoryChangedCallback;
            //        s.ShowDialog();
            //    }
            //    return;
            //}
            //using (var sell = new MakeSale(itemsTable.SelectedCells[0].Value.ToString()))
            //{
            //    sell.OnSave += OnInventoryChangedCallback;
            //    sell.ShowDialog();
            //}
            if (s != null)
            {
                s.BringToFront();
                return;
            }

            s = new SellItem();
            s.FormClosed += S_FormClosed;
            s.Show();
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            var sell = sender as SellItem;
            sell.Dispose();

            s = null;
            //throw new NotImplementedException();
        }

        private async void OnInventoryChangedCallback(object sender, EventArgs e)
        {
            await initItemsTableAsync();
        }
        /// <summary>
        /// attempts to shortens the creation of entity
        /// </summary>
        POSEntities posEnt => new POSEntities();

        #endregion

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dgt = (DataGridView)sender;

            using (var View = new ViewItem())
            {
                View.SetItemId(dgt.Rows[e.RowIndex].Cells[0].Value.ToString());
                View.ShowDialog();
            }
        }

        //object getValueByCurrentRowAndSpecificColumn(DataGridView target, int column)
        //{
        //    return target.Rows[target.SelectedCells[0].RowIndex].Cells[column].Value;
        //}

        string selectedBarcode => itemsTable.SelectedCells[0].Value.ToString();

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            using (var addItem = new AddItemForm())
            {
                addItem.OnSave += Onsave_Callback;
                addItem.ShowDialog();
            }
        }

        private void Onsave_Callback(object sender, EventArgs e)
        {
            var init = initItemsTableAsync();
        }

        string getItemQuantity(Item i)
        {
            int quantity = i.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();

            if (quantity == 0 && (i.Type == "Software" || i.Type == "Service"))
                return "∞";

            return quantity == 0 ? "EMPTY" : quantity.ToString();
        }

        private async Task<DataGridViewRow[]> createItemRowsAsync(IEnumerable<Item> items)
        {
            DataGridViewRow[] rows = null;

            await Task.Run(() =>
            {
                rows = items.Select(createItemRow).ToArray();
            });

            return rows;
        }

        DataGridViewRow createItemRow(Item x)
        {
            var row = new DataGridViewRow();
            string q = getItemQuantity(x);
            //Console.WriteLine(q);
            switch (q)
            {
                case "EMPTY":
                    row.DefaultCellStyle.ForeColor = Color.Maroon;
                    break;

                case "∞":
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    break;
            }

            row.CreateCells(itemsTable,
                 x.Barcode,
                 q,
                 string.Format("₱ {0:n}", x.SellingPrice),
                 x.Name,
                 x.Type
                );

            return row;
        }
        private async Task initItemsTableAsync()
        {
            Console.WriteLine("started: Items");
            loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = true; });

            itemsTable.InvokeIfRequired(() =>
            {
                itemsTable.SelectionChanged -= itemsTable_SelectionChanged;
                itemsTable.Rows.Clear();
            });

            using (var p = posEnt)
            {
                ///create the rows in the background
                var rows = await createItemRowsAsync(p.Items);
                ///if created then set to table
                itemsTable.InvokeIfRequired(() =>
                {
                    itemsTable.Rows.AddRange(rows);
                    itemsTable.SelectionChanged += itemsTable_SelectionChanged;
                });
                decimal total = p.InventoryItems.Select(x => x.Quantity * x.Product.Item.SellingPrice).DefaultIfEmpty(0).Sum();

                totalPriceTxt.InvokeIfRequired(() => { totalPriceTxt.Text = "TOTAL INVENTORY PRICE: " + string.Format("₱ {0:n}", total); });
            }

            ///off the loading label
            loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = false; });
            Console.WriteLine("finished: Items");
        }

        void initItemsTable()
        {
            Console.WriteLine("started: Items");

            loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = true; });

            using (var p = posEnt)
            {
                itemsTable.InvokeIfRequired(() =>
                {
                    itemsTable.SelectionChanged -= itemsTable_SelectionChanged;
                    itemsTable.Rows.Clear();
                });

                var rows = p.Items.AsEnumerable().Select(x => itemsTable.createRow(
                    x.Barcode,
                    x.Name,
                    getItemQuantity(x),
                    string.Format("₱ {0:n}", x.SellingPrice),
                    x.Type
                   )).ToArray();

                itemsTable.InvokeIfRequired(() =>
                {
                    itemsTable.Rows.AddRange(rows);
                    itemsTable.SelectionChanged += itemsTable_SelectionChanged;
                });

                decimal total = p.InventoryItems.Select(x => x.Quantity * x.Product.Item.SellingPrice).DefaultIfEmpty(0).Sum();

                totalPriceTxt.InvokeIfRequired(() => { totalPriceTxt.Text = "Total inventory price: " + string.Format("₱ {0:n}", total); });
            }

            loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = false; });

            Console.WriteLine("finished: Items");
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.");
                return;
            }

            using (var editItem = new EditItemForm())
            {
                editItem.OnSave += Onsave_Callback;
                editItem.GetBarcode(selectedBarcode);
                editItem.ShowDialog();
            }
        }

        private void addVariationsBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.");
                return;
            }
            using (var variation = new ItemVariationsForm(itemsTable.SelectedCells[0].Value.ToString()))
                variation.ShowDialog();
        }

        public void Refresh_Callback(object sender, EventArgs e)
        {
            //Console.WriteLine("Refreshed: " + this.Name);
            //initInventoryTable();
            //initItemsTable();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(search.Text))
                return;

            searchItem();
        }

        void searchItem()
        {
            IQueryable<Item> searchElements;
            ///barcode
            using (var p = new POSEntities())
            {
                searchElements = p.Items.Where(x => x.Barcode == search.Text);

                if (searchElements.Count() == 0)
                    searchElements = p.Items.Where(x => x.Name.Contains(search.Text));

                if (searchElements.Count() == 0)
                {
                    MessageBox.Show("Sorry, Product not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                fillTable(searchElements);
            }
        }

        void fillTable(IEnumerable<Item> items)
        {
            itemsTable.InvokeIfRequired(() =>
            {
                itemsTable.Rows.Clear();

                var rows = items.Select(createItemRow).ToArray();

                itemsTable.Rows.AddRange(rows);
            });

        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBtn.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async void search_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(search.Text))
                return;

            //await initItemsTableAsync();

            await initItemsTableAsync();
        }

        private void itemsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!UserManager.instance.currentLogin.CanEditItem)
            {
                e.Cancel = true;
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "This will also delete items in inventory.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            using (var p = new POSEntities())
            {
                var selected = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                var i = p.Items.FirstOrDefault(x => x.Barcode == selected);
                p.Items.Remove(i);
                p.SaveChanges();
            }
            ///initItemsTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InventoryUC_Load(object sender, EventArgs e)
        {
            try
            {
                var currLogin = UserManager.instance.currentLogin;

                addVariationsBtn.Enabled = currLogin.CanEditProduct;
                addItemBtn.Enabled = currLogin.CanEditItem;
                editItemBtn.Enabled = currLogin.CanEditItem;
                stockinBtn.Enabled = currLogin.CanStockIn;

            }
            catch
            {

            }
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count == 0)
                return;
            var currLogin = UserManager.instance.currentLogin;

            if (!currLogin.CanEditProduct)
                return;

            var type = itemsTable.SelectedCells[4].Value?.ToString();
            addVariationsBtn.Enabled = type != ItemType.Hardware.ToString() ? false : true;
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6)
            {
                return;
            }
            if (!UserManager.instance.currentLogin.CanEditItem)
            {
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "This will also delete items in inventory.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }

            using (var p = new POSEntities())
            {
                var selected = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                var i = p.Items.FirstOrDefault(x => x.Barcode == selected);
                p.Items.Remove(i);
                p.SaveChanges();
            }

            itemsTable.Rows.RemoveAt(e.RowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var s = new StockinForm())
            {
                //s.OnSave += S_OnSave;
                if (s.ShowDialog() == DialogResult.OK)
                {
                    var init = initItemsTableAsync();
                }
            }
        }

        private void S_OnSave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void viewStockBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.RowCount == 0)
                return;

            using (var inventoryView = new InventoryItemView())
            {
                inventoryView.SetItemId(selectedBarcode);
                inventoryView.ShowDialog();
            }
        }
    }
}
