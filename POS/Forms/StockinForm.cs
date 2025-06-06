﻿using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class StockinForm : Form
    {

        Login CurrLogin => UserManager.instance.CurrentLogin;

        public StockinForm()
        {
            InitializeComponent();

            inventoryTable.AutoGenerateColumns = false;
            col_Inventory_Id.DataPropertyName = nameof(ToStockinViewModel.ProductId);
            col_Inventory_Serial.DataPropertyName = nameof(ToStockinViewModel.Serial);
            col_Inventory_Name.DataPropertyName = nameof(ToStockinViewModel.ProductName);
            col_Inventory_Qty.DataPropertyName = nameof(ToStockinViewModel.Quantity);
            col_Inventory_Cost.DataPropertyName = nameof(ToStockinViewModel.Cost);
            col_Inventory_Total.DataPropertyName = nameof(ToStockinViewModel.Total);
            col_Inventory_Supplier.DataPropertyName = nameof(ToStockinViewModel.SupplierName);

            inventoryTable.DataSource = ToStockins;
        }

        DataGridViewRow CreateProductRow(Product product) => itemsTable.CreateRow(
            product.Id,
            product.Item.Barcode,
            product.Item.Name,
            product.Supplier.Name,
            product.Cost,
            product.Item.IsSerialRequired);

        //bool IsLoadingData = false;
        private async Task<bool> LoadDataAsync()
        {

            bool entriesFound = false;
            source = new CancellationTokenSource();
            var token = source.Token;

            try
            {

                using (var context = POSEntities.Create())
                {

                    var products = await context.Products
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(x => x.Item.Type == ItemType.Quantifiable.ToString())
                        .OrderBy(o => o.Item.Name)
                        .ApplySearch(keyword)
                        .ToListAsync(token);

                    entriesFound = products.Count > 0;

                    token.ThrowIfCancellationRequested();

                    if (entriesFound)
                    {
                        itemsTable.Rows.Clear();

                        await Task.Run(() =>
                        {
                            try
                            {

                                var rows = products
                                    .Select(CreateProductRow)
                                    .ToArray();

                                if (token.IsCancellationRequested)
                                    return;

                                itemsTable.InvokeIfRequired(() => itemsTable.Rows.AddRange(rows));
                            }
                            catch
                            {

                            }
                        });
                    }

                    label1.Text = itemsTable.RowCount.ToString("N0") + " entries";
                }
            }
            catch (TaskCanceledException)
            {
            }
            finally
            {
                source?.Dispose();
                source = null;
            }

            return entriesFound;
        }

        void SetAutoComplete()
        {
            using (var p = POSEntities.Create())
            {
                searchControl.SetAutoComplete(p.Products.Where(x => x.Item.Type == ItemType.Quantifiable.ToString()).GroupBy(y => y.Item.Name).Select(a => a.Key).ToArray());
            }
        }

        private async void StockInForm_Load(object sender, EventArgs e)
        {
            createItemBtn.Enabled = CurrLogin.CanEditItem;
            await LoadDataAsync();
        }

        string CurrentProductBarcode => itemsTable.SelectedCells[col_barcode.Index].Value?.ToString() ?? "*";
        int CurrentProductId => (int)itemsTable.SelectedCells[col_Id.Index].Value;
        string CurrentProductName => itemsTable.SelectedCells[col_name.Index].Value.ToString();
        string CurrentProductSupplier => itemsTable.SelectedCells[col_supplier.Index].Value.ToString();
        decimal CurrentProductCost => (decimal)itemsTable.SelectedCells[col_cost.Index].Value;
        bool CurrentSerialRequired => (bool)itemsTable.SelectedCells[col_serialReq.Index].Value;

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (itemsTable.SelectedCells.Count <= 0) return;

            itemName.Text = CurrentProductBarcode + " - " + CurrentProductName + " - " + CurrentProductCost.ToString("C2");

            Foo(CurrentSerialRequired);
        }
        void Foo(bool serialRequired)
        {
            quantity.Value = 1;
            qtyGroup.Visible = !serialRequired;
            serialGroup.Visible = serialRequired;

            if (serialGroup.Visible)
            {
                serialNumber.Focus();
                serialNumber.SelectAll();
            }
            else if (qtyGroup.Visible)
            {
                quantity.Focus();
            }
        }
        bool AlreadyInTable(int id, out ToStockinViewModel stockinEntry)
        {

            stockinEntry = ToStockins
                .Where(t => string.IsNullOrWhiteSpace(t.Serial))
                .FirstOrDefault(stockin => stockin.ProductId == id);

            return stockinEntry != null;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (AddProduct())
                this.ActiveControl = searchControl.firstControl;
        }

        private async void stockinBtn_Click(object sender, EventArgs e)
        {
            if (ToStockins.Count <= 0) return;

            if (MessageBox.Show("Are you sure you want to stock these items?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            using (var context = POSEntities.Create())
            {

                foreach (var s in ToStockins)
                {
                    int productId = s.ProductId;
                    string serialNum = s.Serial;
                    int quantity = s.Quantity;

                    //date picker is checked, it means the stockin is only a correction and must not change the inventory values

                    await AddToInventory(context, serialNum, productId, quantity);


                    var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);

                    var stockInHistory = new StockinHistory
                    {
                        ProductId = product.Id,
                        ItemName = product.Item.Name,
                        Cost = product.Cost,
                        Supplier = product.Supplier.Name,
                        Quantity = quantity,
                        SerialNumber = string.IsNullOrWhiteSpace(serialNum) ? null : serialNum,
                        Date = DateTime.Now,
                        LoginUsername = context.Logins.FirstOrDefault(x => x.Username == CurrLogin.Username).Username
                    };

                    context.StockinHistories.Add(stockInHistory);
                }

                await context.SaveChangesAsync();
                MessageBox.Show("Stock-In Successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        async Task AddToInventory(POSEntities context, string serialNum, int productId, int quantity)
        {
            ///add as stacking qty
            if (string.IsNullOrEmpty(serialNum))
            {
                var it = await context.InventoryItems.FirstOrDefaultAsync(x => x.Product.Id == productId && x.SerialNumber == null);

                ///item is not yet added
                if (it is null)
                {
                    it = new InventoryItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                    };

                    context.InventoryItems.Add(it);
                }
                ///increment the qty
                else it.Quantity += quantity;
            }
            ///add as with serial
            else
            {
                var it = new InventoryItem()
                {
                    ProductId = productId,
                    Quantity = quantity,
                    SerialNumber = serialNum
                };

                context.InventoryItems.Add(it);
            }
        }

        bool SerialAlreadyTaken(string serial)
        {
            using (var p = POSEntities.Create())
            {
                if (p.InventoryItems.Any(x => x.SerialNumber == serial) || p.SoldItems.Any(x => x.SerialNumber == serial))
                {
                    MessageBox.Show("Serial number already found in record.", "Serial Number Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            for (int i = 0; i < inventoryTable.RowCount; i++)
            {
                if (serial == inventoryTable.Rows[i].Cells[col_Inventory_Serial.Index].Value?.ToString())
                {
                    MessageBox.Show("Serial number already on the list.", "Serial Number Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        bool AddProduct()
        {
            var serial = serialNumber.Text.Trim();
            var qty = (int)quantity.Value;

            if (CurrentSerialRequired && string.IsNullOrWhiteSpace(serial)) return false;

            /// check if the item to be added has serial 
            if (!string.IsNullOrEmpty(serialNumber.Text))
            {
                /// check if its already registered
                if (SerialAlreadyTaken(serial))
                    return false;
            }
            else
            {
                ///if not then check if the item to be added is already in the table, if yes just increment qty
                if (AlreadyInTable(CurrentProductId, out ToStockinViewModel already))
                {

                    already.Quantity += qty;
                    UpdateGrandTotal();
                    return false;
                }
            }
            ///else, add the item
            ToStockins.Add(new ToStockinViewModel()
            {
                ProductId = CurrentProductId,
                SupplierName = CurrentProductSupplier,
                ProductName = CurrentProductName,
                Serial = serial,
                Quantity = qty,
                Cost = CurrentProductCost

            });

            UpdateGrandTotal();
            serialNumber.Text = string.Empty;
            return true;
        }

        BindingList<ToStockinViewModel> ToStockins = new BindingList<ToStockinViewModel>();

        private class ToStockinViewModel : INotifyPropertyChanged
        {
            private int quantity;

            public ToStockinViewModel()
            {

            }

            public string ProductName { get; set; }
            public string SupplierName { get; set; }
            public int ProductId { get; set; }
            public string Serial { get; set; }
            public int Quantity
            {
                get => quantity; set
                {
                    quantity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                }
            }
            public decimal Cost { get; set; }
            public decimal Total => Quantity * Cost;

            public event PropertyChangedEventHandler PropertyChanged;
        }

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1)
            //    return;
            //AddProduct();
        }

        //private void removeBtn_Click(object sender, EventArgs e) {
        //    if (inventoryTable.RowCount == 0)
        //        return;
        //    int index = inventoryTable.CurrentCell.RowIndex;
        //    inventoryTable.Rows.RemoveAt(index);
        //}

        /// <summary>
        /// this ensures that when there is serial number supplied, the quantity will be 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialNumber_TextChanged(object sender, EventArgs e)
        {
            if (serialNumber.Text.Count() != 0)
            {
                quantity.Value = 1;
                quantity.Enabled = false;
                return;
            }
            quantity.Enabled = true;
        }

        /// <summary>
        /// key shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockinForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                addBtn.PerformClick();
                e.SuppressKeyPress = true;
            }
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                // Do what you want here
                stockinBtn.PerformClick();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
            if (e.KeyCode == Keys.F1)
                this.ActiveControl = searchControl.firstControl;

            if (e.KeyCode == Keys.F2)
                this.ActiveControl = serialNumber;

            if (e.KeyCode == Keys.F3)
                this.ActiveControl = quantity;
        }

        private async void createItemBtn_Click(object sender, EventArgs e)
        {
            //using (var form = new CreateEdit_Item_Form())
            //{
            //    if (form.ShowDialog() == DialogResult.OK)
            //    {
            //        if (form.Tag is Item addedItem && addedItem.Type == ItemType.Quantifiable.ToString())
            //        {
            //            SetAutoComplete();
            //            await LoadDataAsync();
            //        }
            //    }
            //}
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
                    var item = context.Items.Add(newItem);

                    await context.SaveChangesAsync();

                    Departments_Store.AddNewDepartment(item.Department);
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch { }


        }

        CancellationTokenSource source = null;

        void TryCancel()
        {
            try
            {
                source?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        public async Task<bool> DoSearch(string searchText)
        {
            TryCancel();

            keyword = searchText;
            bool searchFound = await LoadDataAsync();

            //if (searchFound)
            //{
            //    if (quantity.Visible)
            //        quantity.Focus();

            //    else if (serialNumber.Visible)
            //    {
            //        serialNumber.Focus();
            //        serialNumber.SelectAll();
            //    }
            //}

            _messageLabel.Text = searchFound ? string.Empty : "**No Results Found!";
            return searchFound;
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            e.SearchFound = await DoSearch(e.Text);
        }

        string keyword = string.Empty;
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await LoadDataAsync();
        }


        /// <summary>
        /// used for when the scanner hits enter after scans
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(serialNumber.Text))
            {
                AddProduct();
            }
        }

        private void inventoryTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex != col_remove.Index)
                return;

            ToStockins.RemoveAt(e.RowIndex);

            UpdateGrandTotal();
        }

        void UpdateGrandTotal()
        {

            _grandTotalTxt.Text = ToStockins
                .Select(t => t.Quantity * t.Cost)
                .DefaultIfEmpty(0)
                .Sum()
                .ToString("C2");
        }

        private void inventoryTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            label2.Text = inventoryTable.RowCount.ToString("0 Entries");
        }

        private void inventoryTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label2.Text = inventoryTable.RowCount.ToString("0 Entries");
        }
    }

    public static class StockinQueryExtensions
    {
        public static IQueryable<Product> ApplySearch(this IQueryable<Product> products, string keyword)
        {

            if (string.IsNullOrWhiteSpace(keyword))
                return products;

            return products.Where(p => p.Item.Barcode == keyword || p.Item.Name.Contains(keyword));
        }
    }
}
