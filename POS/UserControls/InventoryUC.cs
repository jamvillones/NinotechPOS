using POS.Forms;
using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
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
            }
            else
            {
                sellForm = new SellForm();
                sellForm.FormClosed += SellForm_FormClosed;
                sellForm.Show();
            }
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
            if (e.RowIndex == -1) return;

            try
            {
                showImageCancelSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }

            if (e.ColumnIndex == nameCol.Index) await OpenEditForm();

            else if (e.ColumnIndex == quantityCol.Index)
            {
                var dgt = (DataGridView)sender;
                var qty = dgt[quantityCol.Index, e.RowIndex].Value as int?;
                var barcode = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();
                ShowInventoryInfo(barcode, qty);
            }

            else if (e.ColumnIndex == priceCol.Index)
            {
                using (var variation = new ItemSoldItemsForm(SelectedId))
                {
                    variation.Text += SelectedName;
                    variation.ShowDialog();
                }
            }
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

        private async void addItemBtn_Click(object sender, EventArgs e)
        {
            var newItem = new Item() { Id = Guid.NewGuid().ToString("N") };

            try
            {
                newItem
                    .SetBasicInfo()
                    .AskIfSerialRequired()
                    .SetImage()
                    .SetCosts()
                    .ConfirmDetailsBeforeSaving();

                using (var context = POSEntities.Create())
                {
                    //if (newItem.Type != ItemType.Quantifiable.ToString())
                    //{
                    //    var serviceProduct = new Product() { Cost = 0 };

                    //    newItem.Products.Add(serviceProduct);
                    //    context.InventoryItems.Add(new InventoryItem() { Product = serviceProduct, Quantity = 0 });
                    //}

                    var item = context.Items.Add(newItem);

                    await context.SaveChangesAsync();

                    var dto = new ItemDTO()
                    {
                        Id = item.Id,
                        Barcode = item.Barcode,
                        Name = item.Name,
                        SellingPrice = item.SellingPrice,

                        Type = item.Type.ToString(),
                        Qty = item.Products.Select(a => a.InventoryItems
                                                        .Select(b => b.Quantity)
                                                        .DefaultIfEmpty(0)
                                                        .Sum()).Sum()
                    };

                    itemsTable.Rows.Insert(0, CreateRow(dto));
                    Departments_Store.AddNewDepartment(item.Department);
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch { }
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
                using (var context = POSEntities.Create())
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
                                        .Take(pagination.PageSize)
                                        .Select(i => new ItemDTO()
                                        {
                                            Id = i.Id,
                                            Barcode = i.Barcode,
                                            Name = i.Name,
                                            SellingPrice = i.SellingPrice,
                                            Type = i.Type,
                                            Notes = i.Details,
                                            Qty = i.Products.Select(a => a.InventoryItems
                                                                        .Select(b => b.Quantity)
                                                                        .DefaultIfEmpty(0)
                                                                        .Sum())
                                                            .Sum()
                                        });

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

        private async Task<bool> LoadDataAsync()
        {
            IsBusyLoading = true;
            Cursor.Current = Cursors.WaitCursor;

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

            Cursor.Current = Cursors.Default;
            IsBusyLoading = false;

            return itemsTable.RowCount > 0;
        }

        DataGridViewRow CreateRow(ItemDTO item)
        {
            var row = new DataGridViewRow();

            if (item.Type != ItemType.Quantifiable.ToString())
                row.DefaultCellStyle.ForeColor = Color.DarkGreen;

            else if (item.Qty is null)
                row.DefaultCellStyle.ForeColor = Color.Blue;

            else if (item.Qty == 0)
                row.DefaultCellStyle.ForeColor = Color.Gray;

            row.CreateCells(itemsTable,
                 item.Id,
                 null,
                 item.Barcode,
                 item.Name,
                 item.Type == ItemType.Quantifiable.ToString() ? item.Qty : null,
                 item.SellingPrice,
                 item.Notes,
                 item.Type
                );

            return row;
        }

        private class ItemDTO
        {
            public string Id { get; set; }
            public string Barcode { get; set; }
            public string Name { get; set; }

            public int? Qty { get; set; }
            public string Notes { get; set; }
            public decimal SellingPrice { get; set; }
            public string Type { get; set; }
        }

        async Task<bool> OpenEditForm()
        {
            if (itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            using (var editForm = new CreateEdit_Item_Form())
            {
                if (!await editForm.InitializeData(SelectedId))
                {
                    return false;
                }

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var x = editForm.Tag as Item;
                    var selectedRow = itemsTable.SelectedRows[0];

                    selectedRow.SetValues(
                        x.Id,
                        null,
                        x.Barcode,
                        x.Name,
                        selectedRow.Cells[quantityCol.Index].Value,
                        x.SellingPrice,
                        x.Details,
                        x.Type
                        );

                    Departments_Store.AddNewDepartment(x.Department);
                }
            }

            return true;
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Enabled = await OpenEditForm();
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

        private async void InventoryUC_Load(object sender, EventArgs e)
        {
            try
            {
                SetupButtonByLogin();

                departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                departmentOption.AutoCompleteSource = AutoCompleteSource.ListItems;

                await Departments_Store.LoadDepartments_Async();
                departmentOption.DataSource = Departments_Store.Departments;

                departmentOption.SelectedIndex = 0;
                departmentOption.SelectedIndexChanged += departmentOption_SelectedIndexChanged;
            }
            catch { }
        }

        public void SetupButtonByLogin()
        {
            var currLogin = UserManager.instance.CurrentLogin;

            addItemBtn.Enabled = currLogin.CanEditItem;
            stockinBtn.Enabled = currLogin.CanStockIn;
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            var currLogin = UserManager.instance.CurrentLogin;
            var selected = itemsTable.SelectedRows.Count == 0 ? "" : " [ " + itemsTable.SelectedRows.Count + " ]";

            bool canPerformMultipleItemAction = itemsTable.SelectedRows.Count > 0;
            button6.Enabled = canPerformMultipleItemAction && currLogin.CanEditItem;
            button4.Enabled = canPerformMultipleItemAction && currLogin.CanEditItem;

            if (currLogin.CanEditItem)
            {
                button6.Text = "     Remove Items" + selected;
                button4.Text = "     Set Department" + selected;
            }

            bool isSingleRowSelected = itemsTable.SelectedRows.Count == 1;

            addVariationsBtn.Enabled = isSingleRowSelected;

            editItemBtn.Enabled = isSingleRowSelected;

            bool IsEnumerable = itemsTable.SelectedRows.Count > 0 && itemsTable.SelectedCells[col_Type.Index].Value.ToString() == ItemType.Quantifiable.ToString();
            viewStockBtn.Enabled = IsEnumerable && isSingleRowSelected;
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

                try { Clipboard.SetText(barcodeToCopy); } catch (Exception) { }
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

        string keyword = string.Empty;
        private bool isTotalEntriesInitialized = false;

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            e.SearchFound = true;

            CancelLoading();

            if (trackItemCheckbox.Checked)
            {
                await TrackItemAsync(e.Text);
                return;
            }

            keyword = e.Text.Trim();
            IsTotalEntriesInitialized = false;

            await LoadDataAsync();
        }

        async Task TrackItemAsync(string serialNumber)
        {
            try
            {
                using (var context = POSEntities.Create())
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
                        using (var saleDetails = new SaleDetails(soldItem.Sale.Id) { FormBorderStyle = FormBorderStyle.Sizable })
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
            catch { }
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

        private void itemsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            itemCount.Text = itemsTable.RowCount.ToString("N0");
        }

        private void itemsTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            itemCount.Text = itemsTable.RowCount.ToString("N0");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var stock_inLog = new StockInLog();
            stock_inLog.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var printInventory = new PrintInventory();
            printInventory.ShowDialog();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await DeleteSelectedRows();
        }

        private async void SetDepartment_Click(object sender, EventArgs e)
        {
            using (var departmentForm = new SetDepartment_Form())
            {
                if (departmentForm.ShowDialog() == DialogResult.OK)
                {
                    string newDepartment = departmentForm.Tag as string;
                    Departments_Store.AddNewDepartment(newDepartment);

                    Cursor = Cursors.WaitCursor;

                    using (var context = POSEntities.Create())
                    {
                        var selectedRows = itemsTable.SelectedRows.Cast<DataGridViewRow>();
                        var ids = selectedRows.Select(row => row.Cells[0].Value.ToString());

                        var toSet = context.Items.Where(i => ids.Any(id => id == i.Id));

                        foreach (var t in toSet)
                            t.Department = newDepartment.NullIfEmpty();

                        await context.SaveChangesAsync();
                    }

                    Cursor = Cursors.Default;

                    MessageBox.Show("Department Changed Successfully!", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void itemsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (IsBusyLoading)
                    return;

                IsTotalEntriesInitialized = false;
                await LoadDataAsync();
                return;
            }
            else if (e.KeyCode == Keys.F2)
            {
                await OpenEditForm();
                return;
            }

            if (e.KeyCode != Keys.Delete)
                return;

            e.Handled = true;
            await DeleteSelectedRows();
        }

        async Task DeleteSelectedRows()
        {
            var currLogin = UserManager.instance.CurrentLogin;

            if (!currLogin.CanEditItem)
                return;

            if (itemsTable.SelectedRows.Count == 0)
                return;

            if (MessageBox.Show("Selected Items Will Be Removed From The List", "Remove Selected Items?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            var selectedRows = itemsTable.SelectedRows.Cast<DataGridViewRow>();

            try
            {
                using (var context = POSEntities.Create())
                {
                    var ids = selectedRows
                        .Select(row => row.Cells[0].Value.ToString());

                    var toBeDeleted = context.Items
                        .Where(i => ids.Any(id => id == i.Id));

                    context.Items.RemoveRange(toBeDeleted);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("One of the selected Item is already in stock. Undo the restock first before deleting.", "Remove Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var row in selectedRows)
                itemsTable.Rows.Remove(row);
        }

        private void trackItemCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            searchBar.firstControl.Focus();
            var textBox = searchBar.firstControl as TextBox;
            textBox.SelectAll();
        }

        Form showImage = null;
        CancellationTokenSource showImageCancelSource;
        private async void itemsTable_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != nameCol.Index)
                return;

            var dg = sender as DataGridView;

            showImageCancelSource = new CancellationTokenSource();
            var token = showImageCancelSource.Token;

            try
            {
                await Task.Delay(1000, token);

                token.ThrowIfCancellationRequested();
                var id = dg[0, e.RowIndex].Value?.ToString();

                Image toShow = null;

                using (var context = POSEntities.Create())
                {
                    var item = await context.Items.FirstOrDefaultAsync(x => x.Id == id, token);
                    toShow = item.SampleImage?.ToImage();
                }

                token.ThrowIfCancellationRequested();

                if (toShow is null || token.IsCancellationRequested)
                    return;

                showImage = new Show_Image(toShow) { Location = new Point(MousePosition.X + 10, MousePosition.Y) };
                showImage.Show();
            }
            catch (OperationCanceledException)
            {

            }
            catch
            {

            }
            finally
            {
                showImageCancelSource?.Dispose();
            }
        }

        private void itemsTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            showImage?.Close();

            try
            {
                showImageCancelSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            col_Notes.Visible = checkBox1.Checked;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void itemsTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == col_ShowProgression.Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var image = Properties.Resources.graph_15px;
                var w = image.Width;
                var h = image.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

        }

        private void itemsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (itemsTable.Rows.Count == 0 || e.RowIndex == -1 || e.ColumnIndex != col_ShowProgression.Index) return;

            var selectedId = itemsTable[col_Id.Index, e.RowIndex].Value?.ToString();

            new ItemProgressionForm(selectedId).ShowDialog();
            //tablePanel.EmbedForm(new ItemProgressionForm(selectedId));
        }

        private void itemsTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var dgv = sender as DataGridView;
            if (e.Button == MouseButtons.Right)
            {
                dgv.ClearSelection();
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;

                // Optional: show context menu at mouse position
                restockThisItemToolStripMenuItem.Enabled = dgv.SelectedRows[0].Cells[col_Type.Index].Value.ToString() == ItemType.Quantifiable.ToString();
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void sellThisItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSellForm();

            var searchKeyword = SelectedBarcode.IsEmpty() ? SelectedName : SelectedBarcode;
            sellForm.SetSearchKeyword(searchKeyword);
        }

        private async void restockThisItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchKeyword = SelectedBarcode.IsEmpty() ? SelectedName : SelectedBarcode;

            using (var stockinForm = new StockinForm())
            {
                await stockinForm.DoSearch(searchKeyword);
                stockinForm.ShowDialog();
            }

        }

        private async void button7_Click(object sender, EventArgs e)
        {
            await ContextManipulationMethods.ExtractInventory(departmentOption.Text.Trim());
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
