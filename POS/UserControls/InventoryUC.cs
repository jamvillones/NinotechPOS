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
using POS.Forms.ItemRegistration;

namespace POS.UserControls {
    public partial class InventoryUC : UserControl, Interfaces.ITab {
        public InventoryUC() {
            InitializeComponent();
        }

        //class InventoryDetails {
        //    public string Barcode { get; set; }
        //    public string Name { get; set; }
        //    public decimal SellingPrice { get; set; }
        //    public int Quantity { get; set; }
        //}

        CancellationTokenSource _cancelSource;

        #region Tab functions
        public virtual async void RefreshData() {
            await LoadDataAsync();
        }

        public virtual Button EnterButton() => null;

        public virtual Control FirstControl() => searchControl1.firstControl;

        public async Task InitializeAsync() {
            await LoadDataAsync();
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

        public void CancelLoading() {
            try {
                _cancelSource?.Cancel();
            }
            catch (ObjectDisposedException) {

            }
        }

        #endregion

        #region Selling
        protected virtual void sellItem_Click(object sender, EventArgs e) {
            OpenSellForm();
        }
        MakeSale sellForm = null;
        void OpenSellForm() {
            //if (sellForm != null)
            //{
            //    if (sellForm.WindowState == FormWindowState.Minimized)
            //        sellForm.WindowState = FormWindowState.Maximized;

            //    sellForm.BringToFront();
            //    return;
            //}
            //sellForm = new MakeSale();
            //sellForm.OnSave += SellForm_OnSave;
            //sellForm.FormClosed += SellForm_FormClosed;

            //if (itemsTable.SelectedCells.Count > 0 && SelectedQty > 0 || SelectedQty != null)
            //    sellForm.SellSpecific(SelectedId);

            //sellForm.Show();

            using (var sell = new SellForm()) {
                if (sell.ShowDialog() == DialogResult.OK) {
                    ///handle after sales like reload etc.
                }
            }
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

            var dgt = (DataGridView)sender;

            var qty = dgt[quantityCol.Index, e.RowIndex].Value as int?;

            var barcode = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();


            ShowInventoryInfo(barcode, qty);
        }

        void ShowInventoryInfo(string barcode, int? quantity) {
            if (quantity == 0 || quantity is null) return;
            using (var View = new InventoryItemView(barcode, _selectedSerial)) {
                View.ShowDialog();
            }

        }

        string SelectedId => itemsTable.SelectedCells[col_Id.Index].Value.ToString();
        string SelectedName => itemsTable.SelectedCells[nameCol.Index].Value.ToString();
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
        string _selectedSerial = string.Empty;
        private async Task<bool> LoadDataAsync() {
            _selectedSerial = string.Empty;
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

                totalPriceTxt.Text = totalInventoryValue.ToString("C2");

                try {
                    var rawItems = context.Items
                        .AsNoTracking()
                        .AsQueryable()
                        .ApplySearch(keyword);

                    if (await rawItems.CountAsync() == 0) {
                        rawItems = context.InventoryItems
                            .AsQueryable()
                            .Where(x => x.SerialNumber == keyword)
                            .Select(x => x.Product.Item);

                        _selectedSerial = rawItems.Any() ? keyword : string.Empty;
                    }

                    var items = await rawItems.ToListAsync(token);

                    resultsFound = items.Count > 0;

                    token.ThrowIfCancellationRequested();

                    if (resultsFound) {
                        loadingLabelItem.Visible = true;

                        itemsTable.Rows.Clear();
                        var rows = await CreateItemRowsAsync(items, token);
                        itemsTable.Rows.AddRange(rows);
                    }
                    else
                        MessageBox.Show("No Results Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (OperationCanceledException) {
                    loadingLabelItem.Visible = false;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Connection Not Established!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally {
                    _cancelSource?.Dispose();
                    _cancelSource = null;
                }
            }
            loadingLabelItem.Visible = false;

            isRefreshing = false;
            return resultsFound;
        }

        private async Task<DataGridViewRow[]> CreateItemRowsAsync(IEnumerable<Item> items, CancellationToken ct) {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            await Task.Run(() => {
                try {
                    //criticalQtyCounter = 0;
                    //criticalItemNames = new List<string>();

                    foreach (var i in items) {
                        rows.Add(CreateRow(i));
                        ct.ThrowIfCancellationRequested();
                    }
                }
                catch {

                }
            });

            ct.ThrowIfCancellationRequested();

            return rows.ToArray();
        }

        DataGridViewRow CreateRow(Item x) {
            var row = new DataGridViewRow();

            Nullable<int> quantity = x.Type == ItemType.Software.ToString() || x.Type == ItemType.Service.ToString() ? default(int?) : x.QuantityInInventory;

            if (x.InCriticalQuantity) {
                row.DefaultCellStyle.ForeColor = Color.Maroon;
            }
            else if (quantity == 0) {
                row.DefaultCellStyle.ForeColor = Color.Gray;
            }
            else if (quantity is null) {
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;
            }


            row.CreateCells(itemsTable,
                 x.Id,
                 x.Barcode,
                 x.Name,
                 quantity,
                 x.SellingPrice,
                 x.Type
                );

            return row;
        }

        private async void editBtn_Click(object sender, EventArgs e) {
            if (itemsTable.RowCount <= 0) {
                MessageBox.Show("You do not have an item.");
                return;
            }

            //using (var editItem = new EditItemForm())
            //{
            //    editItem.OnSave += Onsave_Callback;
            //    editItem.GetBarcode(SelectedBarcode);
            //    editItem.ShowDialog();
            //}

            using (var editForm = new CreateEdit_Item_Form()) {
                using (var context = new POSEntities())
                    editForm.Item = await context.Items.FirstOrDefaultAsync(i => i.Id == SelectedId);

                if (editForm.ShowDialog() == DialogResult.OK) {
                    var x = editForm.Tag as Item;

                    var row = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];
                    //int? quantity = x.Type == ItemType.Software.ToString() || x.Type == ItemType.Service.ToString() ? default(int?) : x.QuantityInInventory;
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

        private void addVariationsBtn_Click(object sender, EventArgs e) {
            if (itemsTable.RowCount <= 0) {
                MessageBox.Show("You do not have an item.");
                return;
            }
            using (var variation = new ItemVariationsForm(itemsTable.SelectedCells[0].Value.ToString()))
                variation.ShowDialog();
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

                addVariationsBtn.Enabled = currLogin.CanEditProduct;
                addItemBtn.Enabled = currLogin.CanEditItem;
                editItemBtn.Enabled = currLogin.CanEditItem;
                stockinBtn.Enabled = currLogin.CanStockIn;

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
            addVariationsBtn.Enabled = isItemQuantifyable && currLogin.CanEditProduct;
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != col_remove.Index) return;
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
                        Console.WriteLine(critItems.Count());

                        FillTable(critItems);
                    }
                });
            else
                await LoadDataAsync();

            criticalIsShowing = !criticalIsShowing;
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e) {
            if (e.SameSearch)
                return;

            keyword = e.Text.Trim();
            e.SearchFound = await LoadDataAsync();
        }

        string keyword = string.Empty;
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadDataAsync();
        }
    }
    public static class ItemsQueryExtension {
        public static IQueryable<Item> ApplySearch(this IQueryable<Item> items, string keyword) {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.Barcode == keyword || i.Name.Contains(keyword) || i.Tags.Contains(keyword));
        }
    }
}
