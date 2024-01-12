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
using System.Threading;
using System.Data.Entity;

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

        SearchHandler sh = new SearchHandler();

        CancellationTokenSource _cancelSource;

        public InventoryUC()
        {
            InitializeComponent();

            sh.ReferencedTextbox = searchControl1.firstControl as TextBox;
            sh.OnSearch += Sh_OnSearch;
            sh.OnTextCleared += Sh_OnTextCleared;
        }

        private async void Sh_OnTextCleared(object sender, EventArgs e)
        {
            criticalIsShowing = false;

            await LoadItemsAsync();
        }

        private void Sh_OnSearch(object sender, SearchHandler e)
        {
            if (e.SameSearch)
                return;

            criticalIsShowing = false;
            e.SeachFound = SearchItem(e.SearchedString);

        }

        #region Tab functions
        public virtual void RefreshData()
        {

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
            await LoadItemsAsync();

            //showNotif();
        }

        //void showNotif()
        //{
        //    if (criticalItemNames.Count == 0)
        //        return;

        //    var isPlural = criticalItemNames.Count > 1;
        //    notifyIcon.BalloonTipTitle = (isPlural ? "These " : "This ") + (isPlural ? "items" : "item") + " " + (isPlural ? "are" : "is") + " in critical quantity!";

        //    foreach (var i in criticalItemNames)
        //        notifyIcon.BalloonTipText += i + "\n";

        //    notifyIcon.ShowBalloonTip(2);
        //}

        public void CancelLoading()
        {
            loadingLabelItem.Visible = false;

            try
            {
                _cancelSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        #endregion

        #region Control Actions
        MakeSale s = null;
        protected virtual void sellItem_Click(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count == 0)
            {
                createSellForm();
                return;
            }

            string itemQ = itemsTable.SelectedCells[quantityCol.Index].Value.ToString();
            string barc = itemsTable.SelectedCells[barcodeCol.Index].Value.ToString();

            if (s != null)
                s.BringToFront();

            else
            {
                createSellForm();
            }

            if (itemQ != "EMPTY") s.SellSpecific(barc);
        }

        void createSellForm()
        {
            s = new MakeSale();
            s.OnSave += S_OnSave;
            s.FormClosed += S_FormClosed;
            s.Show();
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            var sell = sender as MakeSale;
            sell.Dispose();

            s = null;
        }

        private async void OnInventoryChangedCallback(object sender, EventArgs e)
        {
            await LoadItemsAsync();
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
            var init = LoadItemsAsync();
        }

        string getItemQuantityString(Item i)
        {
            int quantity = i.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();

            if (quantity == 0 && (i.Type == "Software" || i.Type == "Service"))
                return "INFINITE";

            return quantity == 0 ? "EMPTY" : quantity.ToString();
        }
        //int getItemQuantity(Item i)
        //{
        //    return i.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();
        //}

        private async Task LoadItemsAsync()
        {
            isRefreshing = true;
            Console.WriteLine("started: Items");


            _cancelSource = new CancellationTokenSource();
            var token = _cancelSource.Token;

            loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = true; });

            itemsTable.InvokeIfRequired(() =>
            {
                itemsTable.SelectionChanged -= itemsTable_SelectionChanged;
                itemsTable.Rows.Clear();
            });


            using (var context = new POSEntities())
            {
                decimal totalInventoryValue = context.InventoryItems.AsNoTracking()
                    .Where(y => y.Product.Item.Type == ItemType.Quantifiable.ToString())
                    .Select(x => x.Quantity * x.Product.Item.SellingPrice)
                    .DefaultIfEmpty(0)
                    .Sum();

                totalPriceTxt.InvokeIfRequired(() => { totalPriceTxt.Text = "Total Inventory Value: " + string.Format("₱ {0:n}", totalInventoryValue); });

                try
                {
                    var items = await context.Items.AsNoTracking().ToListAsync();
                    var rows = await CreateItemRowsAsync(items, token);

                    //itemsTable.InvokeIfRequired(() =>
                    //{
                    //    itemsTable.Rows.AddRange(rows);
                    //    itemsTable.SelectionChanged += itemsTable_SelectionChanged;
                    //});

                    itemsTable.Rows.AddRange(rows);

                    loadingLabelItem.InvokeIfRequired(() => { loadingLabelItem.Visible = false; });

                    Console.WriteLine("finished: Items");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Connection Not Established!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _cancelSource.Dispose();
                    _cancelSource = null;
                }
            }

            isRefreshing = false;
        }

        private async Task<DataGridViewRow[]> CreateItemRowsAsync(IEnumerable<Item> items, CancellationToken ct)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                try
                {
                    criticalQtyCounter = 0;
                    criticalItemNames = new List<string>();
                    ///criticalLabel.InvokeIfRequired(() => criticalLabel.Text = "0");
                    foreach (var i in items)
                    {
                        rows.Add(createItemRow(i));

                        ct.ThrowIfCancellationRequested();
                    }

                    criticalLabel.InvokeIfRequired(() => criticalLabel.Text = criticalQtyCounter.ToString());
                }
                catch
                {

                }
            });

            ct.ThrowIfCancellationRequested();

            return rows.ToArray();
        }

        //bool isInCriticalQuantity(Item x)
        //{
        //    if (x.Type == ItemType.Quantifiable.ToString())
        //    {
        //        var q = x.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();
        //        if (q == 0 || x.CriticalQuantity == null)
        //            return false;

        //        return (q <= (x.CriticalQuantity ?? 1));
        //    }
        //    return false;
        //}

        List<string> criticalItemNames { get; set; } = new List<string>();
        int criticalQtyCounter = 0;
        DataGridViewRow createItemRow(Item x)
        {
            var row = new DataGridViewRow();
            string q = getItemQuantityString(x);

            if (x.InCriticalQuantity)
            {
                row.DefaultCellStyle.BackColor = Color.IndianRed;
                row.DefaultCellStyle.ForeColor = Color.White;
                criticalQtyCounter++;

                criticalItemNames.Add(x.Name + " (" + x.QuantityInInventory + ") ");
            }

            switch (q)
            {
                case "EMPTY":
                    row.DefaultCellStyle.ForeColor = Color.Maroon;
                    break;

                case "INFINITE":
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    break;
            }

            row.CreateCells(itemsTable,
                 x.Barcode,
                 x.Name,
                 q,
                 string.Format("₱ {0:n}", x.SellingPrice),
                 x.Type
                );

            return row;
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

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            sh.PerformSearch();
        }


        bool SearchItem(string s)
        {
            CancelLoading();
            IEnumerable<Item> searchElements;

            ///barcode
            using (var p = new POSEntities())
            {
                searchElements = p.Items.Where(x => x.Barcode == s);

                if (searchElements.Count() == 0)
                    searchElements = p.Items.Where(x => x.Name.Contains(s));

                if (!checkBox1.Checked)
                    searchElements = searchElements.Where(x => x.QuantityInInventory != 0);

                if (searchElements.Count() == 0)
                {
                    MessageBox.Show("Sorry, Product not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }

                fillTable(searchElements);
                return true;
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

        //private void search_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Enter)
        //    //{
        //    //    searchBtn.PerformClick();

        //    //    e.Handled = true;
        //    //    e.SuppressKeyPress = true;
        //    //}
        //}

        //private async void search_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(search.Text))
        //        return;

        //    //await initItemsTableAsync();

        //    await initItemsTableAsync();
        //}

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
            addVariationsBtn.Enabled = type != ItemType.Quantifiable.ToString() ? false : true;
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
                    var init = LoadItemsAsync();
                }
            }
        }

        private async void S_OnSave(object sender, EventArgs e)
        {
            ////throw new NotImplementedException();
            await LoadItemsAsync();
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

        //private async void button2_Click_1(object sender, EventArgs e)
        //{
        //   //await initItemsTableAsync();
        //}

        private void InventoryUC_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void itemsTable_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //    button2.PerformClick();
        }

        bool isRefreshing { get; set; } = false;
        private async void button2_Click_1(object sender, EventArgs e)
        {
            if (!isRefreshing)
                await LoadItemsAsync();

        }
        bool _critShowing = false;
        bool criticalIsShowing
        {
            get => _critShowing;
            set
            {
                _critShowing = value;

                criticalLabel.ForeColor = _critShowing ? Color.Blue : Color.Maroon;
            }
        }

        private async void criticalLabel_Click(object sender, EventArgs e)
        {
            if (!criticalIsShowing)
                await Task.Run(() =>
                {
                    using (var c = new POSEntities())
                    {
                        IEnumerable<Item> critItems = c.Items.AsEnumerable().Where(x => x.InCriticalQuantity);
                        Console.WriteLine(critItems.Count());

                        fillTable(critItems);
                    }
                });
            else
                await LoadItemsAsync();

            criticalIsShowing = !criticalIsShowing;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
