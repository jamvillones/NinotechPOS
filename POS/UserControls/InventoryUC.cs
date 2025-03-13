using POS.Forms;
using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UserControls
{
    public enum ItemFilter { All, Available, InCriticalQty, Empty }
    public partial class InventoryUC : UserControl, Interfaces.ITab
    {
        public InventoryUC()
        {
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

        public void CancelLoading()
        {
            try
            {
                _cancelSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        #region Selling
        protected virtual void sellItem_Click(object sender, EventArgs e)
        {
            OpenSellForm();
        }

        SellForm sellForm = null;
        void OpenSellForm()
        {
            if (sellForm != null)
            {
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
        private async void SellForm_OnSave(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void SellForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sellForm.Dispose();
            sellForm = null;
        }
        #endregion

        private async void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == col_remove.Index)
            {

                if (!UserManager.instance.CurrentLogin.CanEditItem) return;
                if (MessageBox.Show(
                    "Are you sure you want to delete the selected item?",
                    "This will also delete items in inventory.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.Cancel) return;

                try
                {
                    using (var context = new POSEntities())
                    {
                        var i = await context.Items
                            .Include(item => item.Products.Select(product => product.StockinHistories))
                            .FirstOrDefaultAsync(x => x.Id == SelectedId);

                        context.Items.Remove(i);
                        await context.SaveChangesAsync();
                    }
                    itemsTable.Rows.RemoveAt(e.RowIndex);
                }
                catch (DbUpdateException ex)
                {
                    MessageBox.Show(ex.InnerException.Message, "Delete is aborted!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                catch
                {

                }

                return;
            }

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

        string SelectedId => itemsTable.SelectedCells[col_Id.Index].Value.ToString();
        string SelectedName => itemsTable.SelectedCells[nameCol.Index].Value.ToString();
        string SelectedBarcode => itemsTable.SelectedCells[barcodeCol.Index].Value?.ToString();

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            //var newItem = new Item() { Id = Guid.NewGuid().ToString("N") };

            //using (var form = new Step_BasicInformation(newItem))
            //{
            //}

            using (var form = new CreateEdit_Item_Form())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var item = form.Tag as Item;
                    itemsTable.Rows.Add(CreateRow(item));
                }
            }
        }

        /// <summary>
        /// by setting this to false, you will reinitialize the pagination
        /// </summary>
        public bool IsTotalEntriesInitialized
        {
            get => isTotalEntriesInitialized;
            private set
            {
                isTotalEntriesInitialized = value;

                if (!isTotalEntriesInitialized)
                    itemsTable.Rows.Clear();
            }
        }
        private readonly Pagination pagination = new Pagination();

        private async Task GetItemsThenCreateRows_Async(CancellationToken token)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    //decimal totalInventoryValue = await context.InventoryItems.AsNoTracking()
                    //    .Where(y => y.Product.Item.Type == ItemType.Quantifiable.ToString())
                    //    .Select(x => x.Quantity * x.Product.Item.SellingPrice)
                    //    .DefaultIfEmpty(0)
                    //    .SumAsync(token);

                    //totalPriceTxt.Text = totalInventoryValue.ToCurrency();

                    var itemQuery = context.Items
                                   .AsNoTracking()
                                   .AsQueryable()
                                   .ApplyFilter(currentItemFilter)
                                   .ApplyDepartmentFilter(departmentOption.Text.Trim())
                                   .ApplySearch(keyword);

                    if (!IsTotalEntriesInitialized)
                    {
                        //get the total count of entries
                        int totalItems = await itemQuery.CountAsync(token);
                        totalCount.Text = totalItems.ToString();
                        //initialize the pagination
                        pagination.Initialize(totalItems, 100);
                        //ensure one time initialization of pagination
                        IsTotalEntriesInitialized = true;
                    }

                    var paginatedItems = itemQuery
                                        .OrderBy(o => o.Name)
                                        .Skip(pagination.Start)
                                        .Take(pagination.PageSize);

                    var task_GettingItems = paginatedItems.ToListAsync(token);
                    var task_MinimumLoadingTime = Task.Delay(500);

                    await Task.WhenAll(task_GettingItems, task_MinimumLoadingTime);

                    token.ThrowIfCancellationRequested();
                    var items = task_GettingItems.Result;

                    if (items.Count > 0) itemsTable.Rows.AddRange(items.Select(CreateRow).ToArray());
                    else MessageBox.Show("No Results Found For These Given Entries.", "Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                throw;
            }
        }

        //string _selectedSerial = string.Empty;
        private async Task<bool> LoadDataAsync()
        {
            IsBusyLoading = true;
            loadingLabelItem.Visible = true;

            _cancelSource = new CancellationTokenSource();
            var token = _cancelSource.Token;

            try
            {
                await GetItemsThenCreateRows_Async(token);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Items", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cancelSource?.Dispose();
            }

            itemCount.Text = itemsTable.RowCount.ToString("N0");

            loadingLabelItem.Visible = false;
            IsBusyLoading = false;

            return itemsTable.RowCount > 0;
        }

        DataGridViewRow CreateRow(Item item)
        {
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.");
                return;
            }

            try
            {
                using (var editForm = new CreateEdit_Item_Form(SelectedId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        var x = editForm.Tag as Item;

                        var row = itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex];

                        row.SetValues(
                            x.Id,
                            x.Barcode,
                            x.Name,
                            row.Cells[quantityCol.Index].Value,
                            x.SellingPrice,
                            x.Type
                        );
                    }
                }
            }
            catch
            { }
        }

        private void ShodSoldItemsForItem_Click(object sender, EventArgs e)
        {

            if (itemsTable.SelectedRows.Count == 0)
                return;

            using (var variation = new ItemSoldItemsForm(SelectedId))
            {
                variation.Text += SelectedName;
                variation.ShowDialog();
            }
        }

        public async void Refresh_Callback(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        private void itemsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!UserManager.instance.CurrentLogin.CanEditItem)
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
                var i = p.Items.FirstOrDefault(x => x.Id == selected);
                p.Items.Remove(i);
                p.SaveChanges();
            }
        }

        private async void InventoryUC_Load(object sender, EventArgs e)
        {
            try
            {
                var currLogin = UserManager.instance.CurrentLogin;

                addItemBtn.Enabled = currLogin.CanEditItem;
                editItemBtn.Enabled = currLogin.CanEditItem;

                using (var context = new POSEntities())
                {
                    var departments = await context.Items.GetDepartments().ToArrayAsync();
                    departmentOption.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    departmentOption.AutoCompleteCustomSource.AddRange(departments);
                    departmentOption.Items.Add(string.Empty);
                    departmentOption.Items.AddRange(departments);
                }
            }
            catch { }
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count == 0)
                return;

            var currLogin = UserManager.instance.CurrentLogin;
            var type = itemsTable.SelectedCells[5].Value?.ToString();
            bool isEnumerable = type == ItemType.Quantifiable.ToString();

            viewStockBtn.Enabled = isEnumerable;
            editItemBtn.Enabled = currLogin.CanEditProduct;
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == barcodeCol.Index)
            {
                //get the value of the barcode
                //then copy to clipboard
                string barcodeToCopy = itemsTable[e.ColumnIndex, e.RowIndex].Value?.ToString();

                if (string.IsNullOrEmpty(barcodeToCopy))
                    return;

                try
                {
                    Clipboard.SetText(barcodeToCopy);
                }
                catch (Exception)
                {
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var s = new StockinForm())
            {
                if (s.ShowDialog() == DialogResult.OK)
                {
                    CancelLoading();
                    IsTotalEntriesInitialized = false;
                    await LoadDataAsync();
                }
            }
        }

        private void viewStockBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count < 0)
                return;
            InventoryStockinLog log = new InventoryStockinLog(SelectedId, SelectedName);
            log.FormClosed += FormClosed_Dispose;
            log.Show();

        }

        private void FormClosed_Dispose(object sender, FormClosedEventArgs e)
        {
            if (sender is Form form)
                form.Dispose();
        }

        /// <summary>
        /// determines whether the loading is in order
        /// </summary>
        public bool IsBusyLoading { get; private set; } = false;

        bool _critShowing = false;
        bool criticalIsShowing
        {
            get => _critShowing;
            set
            {
                _critShowing = value;
            }
        }

        string keyword = string.Empty;
        private bool isTotalEntriesInitialized = false;

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            CancelLoading();

            if (trackItemCheckbox.Checked)
            {
                await TrackItemAsync(e.Text);
                return;
            }

            keyword = e.Text.Trim();
            IsTotalEntriesInitialized = false;
            e.SearchFound = await LoadDataAsync();
        }

        async Task TrackItemAsync(string serialNumber)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var inventoryItem = await context.InventoryItems.AsNoTracking()
                        .FirstOrDefaultAsync(i => i.SerialNumber == serialNumber);

                    if (inventoryItem != null)
                    {
                        using (var inventoryView = new InventoryItemView(inventoryItem.Product.Item.Id, serialNumber))
                        {
                            if (inventoryView.ShowDialog() == DialogResult.OK)
                            {

                            }
                        }
                        return;
                    }

                    var soldItem = await context.SoldItems.AsNoTracking()
                        .FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);

                    if (soldItem != null)
                    {
                        using (var saleDetails = new SaleDetails(soldItem.Sale.Id))
                        {
                            if (saleDetails.ShowDialog() == DialogResult.OK)
                            {

                            }
                        }
                        return;
                    }

                    MessageBox.Show("Item Not Found!", "Tracking Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
        }
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;

            IsTotalEntriesInitialized = false;
            CancelLoading();
            await LoadDataAsync();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (int.TryParse(rb.Tag.ToString(), out int value))
                {

                    ItemFilter filter = (ItemFilter)value;
                    currentItemFilter = filter;

                    IsTotalEntriesInitialized = false;
                    CancelLoading();
                    await LoadDataAsync();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var snapshot = new InventoryTimeStamp_Form())
            {
                snapshot.ShowDialog();
            }
        }

        private async void departmentOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsTotalEntriesInitialized = false;
            CancelLoading();
            await LoadDataAsync();
        }

        private async void itemsTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (sender is DataGridView dgv && dgv.IsScrolledToBottom())
            {
                if (!IsBusyLoading && pagination.CanNext)
                {
                    pagination.Next();

                    await LoadDataAsync();
                }
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            using (var context = new POSEntities())
            {
                var departments = await context.Items.GetDepartments().ToArrayAsync();
                departmentOption.Items.Add(string.Empty);
                /* this causes double loading */
                //departmentOption.SelectedIndex = 0;
                departmentOption.Items.Clear();
                departmentOption.AutoCompleteCustomSource.Clear();

                departmentOption.Items.Add("");
                departmentOption.Items.AddRange(departments);

                departmentOption.AutoCompleteCustomSource.Add("");
                departmentOption.AutoCompleteCustomSource.AddRange(departments);
            }
        }
    }

    public class Pagination
    {
        public void Initialize(int totalCount, int pageSize = 100)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentIndex = 1;
        }

        public int CurrentIndex { get; private set; } = 1;
        public int MaxPage => TotalCount == 0 ? 1 :
            TotalCount % PageSize > 0 ? (TotalCount / PageSize) + 1 : TotalCount / PageSize;

        public int PageSize { get; private set; } = 100;
        public int TotalCount { get; private set; } = 1000;

        public int Start => PageSize * (CurrentIndex - 1);
        public bool CanNext => CurrentIndex < MaxPage;

        public int Next()
        {
            CurrentIndex++;

            return Start;
        }
    }

    public static partial class ControlExtensions
    {
        public static bool IsScrolledToBottom(this DataGridView dgv)
        {
            if (dgv.RowCount == 0)
                return false;

            int visibleRowCount = dgv.DisplayedRowCount(false);
            int firstVisibleRowIndex = dgv.FirstDisplayedScrollingRowIndex;

            return firstVisibleRowIndex + visibleRowCount >= dgv.RowCount;
        }
    }

    public static class ItemsQueryExtension
    {
        public static IQueryable<Item> ApplySearch(this IQueryable<Item> items, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.Barcode == keyword || i.Name.Contains(keyword) || i.Tags.Contains(keyword));
        }

        public static IQueryable<Item> ApplyDepartmentFilter(this IQueryable<Item> items, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.Department != null).Where(i => i.Department == keyword);
        }

        public static IQueryable<Item> IsInCriticalQty(this IQueryable<Item> items)
        {
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

        public static IQueryable<Item> IsAvailable(this IQueryable<Item> items)
        {
            return items.Where(item => item.Type == ItemType.Quantifiable.ToString())
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() > 0);
        }

        public static IQueryable<Item> IsEmpty(this IQueryable<Item> items)
        {
            return items.Where(item => item.Type == ItemType.Quantifiable.ToString())
                        .Where(i => i.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() <= 0);
        }

        public static IQueryable<Item> ApplyFilter(this IQueryable<Item> items, ItemFilter filter)
        {
            switch (filter)
            {
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
