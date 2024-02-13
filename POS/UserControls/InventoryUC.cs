using OfficeOpenXml.ConditionalFormatting;
using POS.Forms;
using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UserControls {
    public enum ItemFilter { All, Available, InCriticalQty, Empty }
    public partial class InventoryUC : UserControl, Interfaces.ITab {
        public InventoryUC() {
            InitializeComponent();
        }

        ItemFilter currentItemFilter = ItemFilter.All;

        CancellationTokenSource _cancelSource;

        #region Tab functions
        public virtual async void RefreshData() => await LoadDataAsync();
        public virtual Button EnterButton() => null;
        public virtual Control FirstControl() => searchBar.firstControl;
        public async Task InitializeAsync() => await LoadDataAsync();
        #endregion

        //void showNotif() {
        //    if (criticalItemNames.Count == 0)
        //        return;

        //    var isPlural = criticalItemNames.Count > 1;
        //    notifyIcon.BalloonTipTitle = (isPlural ? "These " : "This ") + (isPlural ? "items" : "item") + " " + (isPlural ? "are" : "is") + " in critical quantity!";

        //    foreach (var i in criticalItemNames)
        //        notifyIcon.BalloonTipText += i + "\n";

        //    notifyIcon.ShowBalloonTip(2);
        //}

        public void CancelLoading() {
            try {
                _cancelSource?.Cancel();
            }
            catch (ObjectDisposedException) {

            }
        }


        #region Selling
        protected virtual void sellItem_Click(object sender, EventArgs e) {
            OpenSellForm();
        }
        SellForm sellForm = null;
        void OpenSellForm() {

            if (sellForm != null) {
                if (sellForm.WindowState == FormWindowState.Minimized)
                    sellForm.WindowState = FormWindowState.Maximized;

                sellForm.BringToFront();

                var searchKeyword = SelectedBarcode.IsEmpty() ? SelectedName : SelectedBarcode;
                sellForm.SetSearchKeyword(searchKeyword);
                return;
            }

            sellForm = new SellForm();
            sellForm.FormClosed += SellForm_FormClosed;
            sellForm.Show();
        }
        private async void SellForm_OnSave(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        private void SellForm_FormClosed(object sender, FormClosedEventArgs e) {
            sellForm.Dispose();
            sellForm = null;
        }
        #endregion


        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == col_remove.Index) {

                if (!UserManager.instance.currentLogin.CanEditItem) return;
                if (MessageBox.Show(
                    "Are you sure you want to delete the selected item?",
                    "This will also delete items in inventory.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.Cancel) return;

                try {
                    using (var p = new POSEntities()) {
                        var i = p.Items.FirstOrDefault(x => x.Id == SelectedId);
                        p.Items.Remove(i);
                        p.SaveChanges();
                    }
                    itemsTable.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception) { }
                return;
            }

            var dgt = (DataGridView)sender;
            var qty = dgt[quantityCol.Index, e.RowIndex].Value as int?;
            var barcode = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();
            ShowInventoryInfo(barcode, qty);
        }

        void ShowInventoryInfo(string barcode, int? quantity) {
            if (quantity == 0 || quantity is null) return;
            using (var View = new InventoryItemView(barcode)) {
                View.ShowDialog();
            }

        }

        string SelectedId => itemsTable.SelectedCells[col_Id.Index].Value.ToString();
        string SelectedName => itemsTable.SelectedCells[nameCol.Index].Value.ToString();
        string SelectedBarcode => itemsTable.SelectedCells[barcodeCol.Index].Value?.ToString();

        int? SelectedQty => itemsTable.SelectedCells[quantityCol.Index].Value as int?;

        private void addItemBtn_Click(object sender, EventArgs e) {
            //using (var addItem = new AddItemForm()) {
            //    addItem.OnSave += Onsave_Callback;
            //    addItem.ShowDialog();
            //}

            using (var form = new CreateEdit_Item_Form()) {


                if (form.ShowDialog() == DialogResult.OK) {
                    var item = form.Tag as Item;
                    itemsTable.Rows.Add(CreateRow(item));

                    //var row = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];
                    ////int? quantity = x.Type == ItemType.Software.ToString() || x.Type == ItemType.Service.ToString() ? default(int?) : x.QuantityInInventory;
                    //row.SetValues(
                    //    x.Id,
                    //    x.Barcode,
                    //    x.Name,
                    //    row.Cells[quantityCol.Index].Value,
                    //    x.SellingPrice,
                    //    x.Type);

                }
            }
        }

        private async void Onsave_Callback(object sender, EventArgs e) {
            await LoadDataAsync();
        }
        //string _selectedSerial = string.Empty;
        private async Task<bool> LoadDataAsync() {
            //_selectedSerial = string.Empty;
            isRefreshing = true;
            bool resultsFound = false;

            _cancelSource = new CancellationTokenSource();
            var token = _cancelSource.Token;

            using (var context = new POSEntities()) {
                decimal totalInventoryValue = await context.InventoryItems.AsNoTracking()
                    .Where(y => y.Product.Item.Type == ItemType.Quantifiable.ToString())
                    .Select(x => x.Quantity * x.Product.Item.SellingPrice)
                    .DefaultIfEmpty(0)
                    .SumAsync(token);

                totalPriceTxt.Text = totalInventoryValue.ToCurrency();

                try {
                    var rawItems = context.Items
                        .AsNoTracking()
                        .AsQueryable()
                        .ApplyFilter(currentItemFilter)
                        .ApplySearch(keyword);

                    var items = await rawItems.ToListAsync(token);
                    itemCount.Text = items.Count.ToString("N0");

                    token.ThrowIfCancellationRequested();

                    if (resultsFound = items.Count > 0) {
                        loadingLabelItem.Visible = true;

                        itemsTable.Rows.Clear();
                        var rows = await CreateItemRowsAsync(items, token);
                        itemsTable.Rows.AddRange(rows);
                    }
                    else {
                        MessageBox.Show("No Results Found for these Entry!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (OperationCanceledException) {
                    loadingLabelItem.Visible = false;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Connection Not Established!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    _cancelSource?.Dispose();
                    //_cancelSource = null;
                }
            }

            loadingLabelItem.Visible = false;
            isRefreshing = false;
            return resultsFound;
        }

        private async Task<DataGridViewRow[]> CreateItemRowsAsync(IEnumerable<Item> items, CancellationToken token) {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            await Task.Run(() => {
                try {

                    foreach (var i in items) {
                        rows.Add(CreateRow(i));
                        token.ThrowIfCancellationRequested();
                    }
                }
                catch (TaskCanceledException) {

                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            });

            token.ThrowIfCancellationRequested();
            return rows.ToArray();
        }

        DataGridViewRow CreateRow(Item item) {
            var row = new DataGridViewRow();

            int? quantity = item.IsFinite ? item.QuantityInInventory : default(int?);

            if (item.InCriticalQuantity)
                row.DefaultCellStyle.ForeColor = Color.Maroon;
            else if (quantity == 0)
                row.DefaultCellStyle.ForeColor = Color.Gray;
            else if (quantity is null)
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;

            row.CreateCells(itemsTable,
                 item.Id,
                 item.Barcode,
                 item.Name,
                 quantity,
                 item.SellingPrice,
                 item.Type
                );

            return row;
        }

        private void editBtn_Click(object sender, EventArgs e) {
            if (itemsTable.RowCount <= 0) {
                MessageBox.Show("You do not have an item.");
                return;
            }

            using (var editForm = new CreateEdit_Item_Form(SelectedId)) {


                if (editForm.ShowDialog() == DialogResult.OK) {
                    var x = editForm.Tag as Item;

                    var row = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];

                    row.SetValues(
                        x.Id,
                        x.Barcode,
                        x.Name,
                        row.Cells[quantityCol.Index].Value,
                        x.SellingPrice,
                        x.Type);

                }
            }
        }

        private void ShodSoldItemsForItem_Click(object sender, EventArgs e) {

            if (itemsTable.SelectedRows.Count == 0)
                return;

            using (var variation = new ItemSoldItemsForm(SelectedId)) {
                variation.Text += SelectedName;
                variation.ShowDialog();
            }
        }

        public async void Refresh_Callback(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        void FillTable(IEnumerable<Item> items) {
            itemsTable.InvokeIfRequired(() => {
                itemsTable.Rows.Clear();

                var rows = items.Select(CreateRow).ToArray();

                itemsTable.Rows.AddRange(rows);
            });

        }

        private void itemsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            if (!UserManager.instance.currentLogin.CanEditItem) {
                e.Cancel = true;
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected item?", "This will also delete items in inventory.", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
                e.Cancel = true;
                return;
            }

            using (var p = new POSEntities()) {
                var selected = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                var i = p.Items.FirstOrDefault(x => x.Id == selected);
                p.Items.Remove(i);
                p.SaveChanges();
            }
        }

        private void InventoryUC_Load(object sender, EventArgs e) {
            try {
                var currLogin = UserManager.instance.currentLogin;

                //addVariationsBtn.Enabled = currLogin.CanEditProduct;
                addItemBtn.Enabled = currLogin.CanEditItem;
                editItemBtn.Enabled = currLogin.CanEditItem;
                //stockinBtn.Enabled = currLogin.CanStockIn;

            }
            catch {

            }
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e) {
            if (itemsTable.SelectedCells.Count == 0)
                return;

            var currLogin = UserManager.instance.currentLogin;
            var type = itemsTable.SelectedCells[5].Value?.ToString();
            bool isItemQuantifyable = type == ItemType.Quantifiable.ToString();

            viewStockBtn.Enabled = isItemQuantifyable;
            editItemBtn.Enabled = currLogin.CanEditProduct;
            //addVariationsBtn.Enabled = isItemQuantifyable && currLogin.CanEditProduct;
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private async void button2_Click(object sender, EventArgs e) {
            using (var s = new StockinForm()) {
                if (s.ShowDialog() == DialogResult.OK) {
                    await LoadDataAsync();
                }
            }
        }

        private void viewStockBtn_Click(object sender, EventArgs e) {
            if (itemsTable.SelectedCells.Count < 0)
                return;
            InventoryStockinLog log = new InventoryStockinLog(SelectedId, SelectedName);
            log.FormClosed += FormClosed_Dispose;
            log.Show();

        }

        private void FormClosed_Dispose(object sender, FormClosedEventArgs e) {
            if (sender is Form form)
                form.Dispose();
        }

        bool isRefreshing { get; set; } = false;
        private async void button2_Click_1(object sender, EventArgs e) {
            if (!isRefreshing) {
                keyword = string.Empty;
                await LoadDataAsync();
            }

        }
        bool _critShowing = false;
        bool criticalIsShowing {
            get => _critShowing;
            set {
                _critShowing = value;
            }
        }

        private async void criticalLabel_Click(object sender, EventArgs e) {
            if (!criticalIsShowing)
                await Task.Run(() => {
                    using (var c = new POSEntities()) {
                        IEnumerable<Item> critItems = c.Items.AsEnumerable().Where(x => x.InCriticalQuantity);

                        FillTable(critItems);
                    }
                });
            else
                await LoadDataAsync();

            criticalIsShowing = !criticalIsShowing;
        }

        string keyword = string.Empty;
        private async void searchControl1_OnSearch(object sender, SearchEventArgs e) {
            CancelLoading();

            if (trackItemCheckbox.Checked) {
                await TrackItemAsync(e.Text);
                return;
            }

            keyword = e.Text.Trim();
            e.SearchFound = await LoadDataAsync();
        }

        async Task TrackItemAsync(string serialNumber) {
            try {
                using (var context = new POSEntities()) {

                    var inventoryItem = await context.InventoryItems.AsNoTracking()
                        .FirstOrDefaultAsync(i => i.SerialNumber == serialNumber);

                    if (inventoryItem != null) {
                        using (var inventoryView = new InventoryItemView(inventoryItem.Product.Item.Barcode, serialNumber)) {
                            if (inventoryView.ShowDialog() == DialogResult.OK) {

                            }
                        }
                        return;
                    }

                    var soldItem = await context.SoldItems.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);

                    if (soldItem != null) {
                        using (var saleDetails = new SaleDetails(soldItem.Sale.Id)) {
                            ///the result is okay when the sale is voided, thus entry on the table must also be removed
                            if (saleDetails.ShowDialog() == DialogResult.OK) {

                            }
                        }
                        return;
                    }

                    MessageBox.Show("Item Not Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch {

            }
        }
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                if (int.TryParse(rb.Tag.ToString(), out int value)) {

                    ItemFilter filter = (ItemFilter)value;
                    currentItemFilter = filter;
                    CancelLoading();
                    await LoadDataAsync();
                }
            }
        }
    }
    public static class ItemsQueryExtension {
        public static IQueryable<Item> ApplySearch(this IQueryable<Item> items, string keyword) {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.Barcode == keyword || i.Name.Contains(keyword) || i.Tags.Contains(keyword));
        }

        public static IQueryable<Item> IsInCriticalQty(this IQueryable<Item> items) {
            return items.Where(item => item.CriticalQuantity > 0 && item.Type == ItemType.Quantifiable.ToString())
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() > 0)
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() <= i.CriticalQuantity);
        }

        public static IQueryable<Item> IsAvailable(this IQueryable<Item> items) {
            return items.Where(item => item.Type == ItemType.Quantifiable.ToString())
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() > 0);
        }

        public static IQueryable<Item> IsEmpty(this IQueryable<Item> items) {
            return items.Where(item => item.Type == ItemType.Quantifiable.ToString())
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() <= 0);
        }

        public static IQueryable<Item> ApplyFilter(this IQueryable<Item> items, ItemFilter filter) {
            switch (filter) {
                case ItemFilter.Available:
                    return items.IsAvailable();
                case ItemFilter.InCriticalQty:
                    return items.IsInCriticalQty();
                case ItemFilter.Empty:
                    return items.IsEmpty();
            }

            return items;
        }
    }
}
