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
using OfficeOpenXml.Drawing.Controls;
using System.Runtime.InteropServices.WindowsRuntime;

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

        //SearchHandler sh = new SearchHandler();

        CancellationTokenSource _cancelSource;

        public InventoryUC()
        {
            InitializeComponent();

            //sh.ReferencedTextbox = searchControl1.firstControl as TextBox;
            //sh.OnSearch += Sh_OnSearch;
            //sh.OnTextCleared += Sh_OnTextCleared;
        }

        #region Tab functions
        public virtual async void RefreshData()
        {
            await LoadDataAsync();
        }

        public virtual Button EnterButton() => null;

        public virtual Control FirstControl() => searchControl1.firstControl;

        public async Task InitializeAsync()
        {
            await LoadDataAsync();

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

        protected virtual void sellItem_Click(object sender, EventArgs e)
        {
            //if (itemsTable.SelectedCells.Count == 0)
            //{
            //    createSellForm();
            //    return;
            //}

            //string itemQ = itemsTable.SelectedCells[quantityCol.Index].Value.ToString();
            //string barc = itemsTable.SelectedCells[barcodeCol.Index].Value.ToString();

            //if (s != null)
            //    s.BringToFront();

            //else
            //{
            //    createSellForm();
            //}

            //if (itemQ != "EMPTY") s.SellSpecific(barc);
        }

        void createSellForm()
        {
            using (var s = new MakeSale())
            {
                s.OnSave += SellForm_OnSave;
                s.FormClosed += S_FormClosed;
                s.ShowDialog();
            }
        }

        private void S_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var sell = sender as MakeSale;
            //sell.Dispose();

            //s = null;
        }

        #endregion

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dgt = (DataGridView)sender;

            var qty = dgt[quantityCol.Index, e.RowIndex].Value as int?;

            var barcode = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();


            ShowInventoryInfo(barcode, qty);
        }

        void ShowInventoryInfo(string barcode, int? quantity)
        {
            if (quantity == 0 || quantity is null) return;
            using (var View = new InventoryItemView(barcode))
            {
                View.ShowDialog();
            }

        }

        string SelectedBarcode => itemsTable.SelectedCells[0].Value.ToString();
        int? SelectedQty => itemsTable.SelectedCells[quantityCol.Index].Value as int?;

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            using (var addItem = new AddItemForm())
            {
                addItem.OnSave += Onsave_Callback;
                addItem.ShowDialog();
            }
        }

        private async void Onsave_Callback(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task<bool> LoadDataAsync()
        {
            isRefreshing = true;
            bool resultsFound = false;

            _cancelSource = new CancellationTokenSource();
            var token = _cancelSource.Token;

            using (var context = new POSEntities())
            {
                decimal totalInventoryValue = await context.InventoryItems.AsNoTracking()
                    .Where(y => y.Product.Item.Type == ItemType.Quantifiable.ToString())
                    .Select(x => x.Quantity * x.Product.Item.SellingPrice)
                    .DefaultIfEmpty(0)
                    .SumAsync();

                totalPriceTxt.InvokeIfRequired(() => totalPriceTxt.Text = totalInventoryValue.ToString("C2"));

                try
                {
                    var rawItems = context.Items
                        .AsNoTracking()
                        .AsQueryable()
                        .ApplySearch(keyword);

                    if (await rawItems.CountAsync() == 0)
                        rawItems = context.InventoryItems
                            .AsQueryable()
                            .Where(x => x.SerialNumber == keyword)
                            .Select(x => x.Product.Item);

                    var items = await rawItems.ToListAsync();

                    resultsFound = items.Count > 0;

                    if (resultsFound)
                    {
                        loadingLabelItem.Visible = true;

                        itemsTable.Rows.Clear();
                        var rows = await CreateItemRowsAsync(items, token);
                        itemsTable.Rows.AddRange(rows);
                    }



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
            loadingLabelItem.Visible = false;

            isRefreshing = false;
            return resultsFound;
        }

        private async Task<DataGridViewRow[]> CreateItemRowsAsync(IEnumerable<Item> items, CancellationToken ct)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                try
                {
                    //criticalQtyCounter = 0;
                    //criticalItemNames = new List<string>();

                    foreach (var i in items)
                    {
                        rows.Add(CreateRow(i));
                        ct.ThrowIfCancellationRequested();
                    }
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


        DataGridViewRow CreateRow(Item x)
        {
            var row = new DataGridViewRow();

            Nullable<int> quantity = x.Type == ItemType.Software.ToString() || x.Type == ItemType.Service.ToString() ? default(int?) : x.QuantityInInventory;

            if (x.InCriticalQuantity)
            {
                //row.DefaultCellStyle.BackColor = Color.IndianRed;
                row.DefaultCellStyle.ForeColor = Color.Maroon;
            }
            else if (quantity == 0)
            {
                row.DefaultCellStyle.ForeColor = Color.Gray;
            }
            else if (quantity is null)
            {
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            }


            row.CreateCells(itemsTable,
                 x.Barcode,
                 x.Name,
                 quantity,
                 x.SellingPrice,
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
                editItem.GetBarcode(SelectedBarcode);
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
            //sh.PerformSearch();
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

                FillTable(searchElements);
                return true;
            }
        }

        void FillTable(IEnumerable<Item> items)
        {
            itemsTable.InvokeIfRequired(() =>
            {
                itemsTable.Rows.Clear();

                var rows = items.Select(CreateRow).ToArray();

                itemsTable.Rows.AddRange(rows);
            });

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

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var s = new StockinForm())
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void SellForm_OnSave(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void viewStockBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count < 0)
                return;

            var table = sender as DataGridView;
            //var qty = table[col_qty.Index, e.RowIndex].Value as int?;
            //if (qty == 0 || qty is null) return;

            using (InventoryStockinLog log = new InventoryStockinLog(SelectedBarcode))
            {
                log.ShowDialog();
            }

            //ShowInventoryInfo(selectedBarcode, selectedQty);

            //using (var inventoryView = new InventoryItemView(selectedBarcode))
            //{
            //    //inventoryView.SetItemId(selectedBarcode);
            //    inventoryView.ShowDialog();
            //}
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
                await LoadDataAsync();

        }
        bool _critShowing = false;
        bool criticalIsShowing
        {
            get => _critShowing;
            set
            {
                _critShowing = value;

                //criticalLabel.ForeColor = _critShowing ? Color.Blue : Color.Maroon;
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

                        FillTable(critItems);
                    }
                });
            else
                await LoadDataAsync();

            criticalIsShowing = !criticalIsShowing;
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            if (e.SameSearch)
                return;

            keyword = e.Text.Trim();
            e.SearchFound = await LoadDataAsync();
        }

        string keyword = string.Empty;
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await LoadDataAsync();
        }
    }
    public static class ItemsQueryExtension
    {
        public static IQueryable<Item> ApplySearch(this IQueryable<Item> items, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.Barcode == keyword || i.Name.Contains(keyword));
        }
    }
}
