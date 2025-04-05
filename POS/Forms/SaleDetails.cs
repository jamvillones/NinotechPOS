using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Forms
{
    public partial class SaleDetails : Form
    {
        public SaleDetails(int id)
        {
            InitializeComponent();
            _saleId = id;

            voidBtn.Visible = CurrentLogin.CanVoidSale;
            dateAddedCol.Visible = checkBox2.Checked;
        }

        Login CurrentLogin => UserManager.instance.CurrentLogin;
        private readonly int _saleId;

        private void OpenPayments_Click(object sender, EventArgs e)
        {
            using (var ts = new PaymentsForm())
            {
                ts.SetId(_saleId);
                ts.ShowDialog();
            }
        }

        private async void voidBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "All items in this this sale will be re-stocked and this sale will be removed.",
                "Are you sure you want to void this Sale?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            try
            {

                using (var context = POSEntities.Create())
                {
                    //get the reference of the sale
                    var saleToVoid = context.Sales.FirstOrDefault(x => x.Id == _saleId);
                    var soldItemsToReturn = await context.SoldItems.Where(x => x.SaleId == saleToVoid.Id).ToArrayAsync();

                    await context.ReturnSoldItems(soldItemsToReturn);

                    context.Sales.Remove(saleToVoid);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(
                   "Sale Successfully Voided.",
                   "",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void SaleDetails_Load(object sender, EventArgs e)
        {
            itemsTable.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            using (var p = POSEntities.Create())
            {
                var sale = await p.Sales.FirstOrDefaultAsync(x => x.Id == _saleId);

                label7.Text = this.Text + " - " + sale.Id.ToString() + " [ " + sale.Date.Value.ToString("MMM d, yyyy hh:mm tt") + " - " + sale.SaleType + " ]";
                bool isCharged = sale.SaleType.Equals(SaleType.Charged.ToString(), StringComparison.OrdinalIgnoreCase);
                editItemsBtn.Visible = isCharged;


                soldBy.Text = sale.Login.ToString();
                soldTo.Text = sale.Customer?.ToString();

                paymentsBtn.Visible = isCharged;
                discount.Text = sale.Discount.ToCurrency();
                amountDue.Text = sale.AmountDue.ToCurrency();
                amountRecieved.Text = sale.AmountRecieved.ToCurrency();

                remaining.Text = (sale.AmountDue - sale.AmountRecieved).ToCurrency();
            }

            await LoadDataAsync();
        }

        private void editItemsBtn_Click(object sender, EventArgs e)
        {
            using (var adv = new AdvancedSearchForm())
            {
                adv.ItemSelected += Adv_ItemSelected;
                adv.ShowDialog();
            }
        }

        private async void Adv_ItemSelected(object sender, ItemInfoHolder e)
        {
            using (var context = POSEntities.Create())
            {
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == _saleId);

                if (e.Serial != null)
                {
                    var inventoryItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.SerialNumber == e.Serial);
                    context.InventoryItems.Remove(inventoryItem);

                    var soldItem = new SoldItem()
                    {
                        SerialNumber = e.Serial,
                        ItemPrice = e.SellingPrice,
                        Discount = e.Discount,
                        Quantity = e.Quantity,
                        ProductId = e.ProductId,
                        SaleId = sale.Id
                    };

                    context.SoldItems.Add(soldItem);
                }
                else
                {
                    var product = await context.Products.FirstOrDefaultAsync(x => x.Id == e.ProductId);

                    if (product.Item.IsEnumerable)
                    {
                        var inventoryItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.ProductId == e.ProductId);
                        inventoryItem.Quantity -= e.Quantity;

                        if (inventoryItem.Quantity == 0)
                            context.InventoryItems.Remove(inventoryItem);
                    }

                    var soldItemToAdd = new SoldItem()
                    {
                        ItemPrice = e.SellingPrice,
                        Discount = e.Discount,
                        Quantity = e.Quantity,
                        ProductId = e.ProductId,
                        SaleId = sale.Id
                    };

                    context.SoldItems.Add(soldItemToAdd);
                }

                await context.SaveChangesAsync();
            }

            await LoadDataAsync();
        }

        private void SaleDetails_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.P)
            //    OpenPrint();
        }

        PrintAction printAction;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Rectangle area;
        ////PrintAction printAction;
        //Pen areaPen = new Pen(Brushes.Red);
        //Pen gridPen = new Pen(Brushes.Gray);

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (var context = POSEntities.Create())
            {
                var sale = context.Sales.FirstOrDefault(x => x.Id == _saleId);

                ReceiptDetails details = new ReceiptDetails
                {
                    ControlNumber = sale.Id.ToString(),
                    CustomerName = soldTo.Text,
                    TransactBy = UserManager.instance.CurrentLogin.Name ?? "User",
                    Tendered = sale.AmountRecieved,
                    Discount = sale.Discount
                };

                foreach (var soldItem in sale.SoldItems.OrderBy(x => x.Product.Item.Name).ThenBy(x => x.SerialNumber))
                {
                    details.AddItem(
                        soldItem.Product.Item.Name,
                        soldItem.SerialNumber,
                        soldItem.Quantity,
                        soldItem.ItemPrice,
                        soldItem.Discount
                        );
                }

                e.FormatReceipt(printAction, details);
            }
        }

        private void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            printAction = e.PrintAction;
            doc.PrinterSettings.PrintFileName = $"Sale - #{_saleId} - {DateTime.Now:ddMMyyyy}";
            doc.PrinterSettings.PrinterName = ReceiptPrintingConfigurations.ReceiptPrintingConfig.Printer;
        }

        void TryCancelLoading()
        {
            try
            {
                cancellationTokenSource?.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

        }

        CancellationTokenSource cancellationTokenSource = null;

        async Task<bool> LoadDataAsync()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            bool isNotEmpty = false;

            try
            {
                using (var context = POSEntities.Create())
                {
                    var soldItems = context.SoldItems
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(so => so.SaleId == _saleId)
                        .ApplySearch(keyword)
                        .OrderBy(s => s.Product.Item.Name);

                    token.ThrowIfCancellationRequested();

                    var result = await soldItems.ToListAsync(token);
                    isNotEmpty = result.Count > 0;

                    if (isNotEmpty)
                    {
                        itemsTable.Rows.Clear();

                        if (checkBox1.Checked)
                        {
                            var nameGroupings = soldItems.GroupBy(s => s.Product.Item.Name);
                            foreach (var group in nameGroupings)
                            {
                                token.ThrowIfCancellationRequested();

                                bool isFirstNameEntry = true;
                                var nameItems = result.Where(r => r.Product.Item.Name == group.Key);
                                var supplierGroupings = nameItems.GroupBy(i => i.Product.Supplier?.Name);

                                foreach (var supplierGroup in supplierGroupings)
                                {
                                    token.ThrowIfCancellationRequested();

                                    bool isFirstSupplierEntry = true;
                                    var supplierItems = nameItems.Where(i => i.Product.Supplier?.Name == supplierGroup.Key);

                                    foreach (var i in supplierItems)
                                    {
                                        token.ThrowIfCancellationRequested();

                                        itemsTable.Rows.Add(
                                            CreateRow(
                                                i,
                                                isFirstNameEntry,
                                                isFirstSupplierEntry,
                                                i.Product.Item.IsSerialRequired ? supplierItems.Count() : supplierItems.Where(x => x.ProductId == i.ProductId).Sum(s => s.Quantity)
                                            )
                                        );

                                        isFirstSupplierEntry = false;
                                        isFirstNameEntry = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            var rows = result.Select(soldItem => CreateRow(soldItem, true, true, soldItem.Quantity)).ToArray();

                            token.ThrowIfCancellationRequested();

                            itemsTable.Rows.AddRange(rows);
                        }

                        decimal subTotal = itemsTable.Rows.Cast<DataGridViewRow>().Select(row => (decimal)(row.Cells[totalCol.Index].Value)).Sum();
                        itemsTable.Rows.Add("", "", "", "", "", "", "", "", subTotal);
                    }
                }
            }
            catch
            {

            }
            finally
            {
                cancellationTokenSource?.Dispose();
            }
            return isNotEmpty;
        }

        DataGridViewRow CreateRow(SoldItem soldItem, bool isFirstNameEntry = true, bool isFirstSupplierEntry = true, int? Qty = 0) => itemsTable.CreateRow(
           soldItem.Id,
           soldItem.DateAdded,
           isFirstNameEntry ? soldItem.Product.Item.Name : null,
           isFirstSupplierEntry ? soldItem.Product.Supplier?.Name : null,
           isFirstSupplierEntry ? Qty : null,
           soldItem.SerialNumber,
           soldItem.ItemPrice,
           soldItem.Discount == 0 ? null : (decimal?)soldItem.Discount,
           soldItem.Quantity * (soldItem.ItemPrice - soldItem.Discount)
           );

        string keyword = string.Empty;

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            keyword = e.Text.Trim();
            TryCancelLoading();
            e.SearchFound = await LoadDataAsync();

            _messageLabel.Text = e.SearchFound ? "" : "**No Results Found.";
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            TryCancelLoading();
            await LoadDataAsync();
        }

        private void soldTo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var customerChangingForm = new ChangeCustomerForm(_saleId);
                if (customerChangingForm.ShowDialog() == DialogResult.OK)
                {
                    soldTo.Text = ((Customer)customerChangingForm.Tag)?.ToString();
                }
            }
        }

        private void itemsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            var table = sender as DataGridView;
            var value = table[e.ColumnIndex, e.RowIndex].Value?.ToString();

            if (value is null)
                return;

            try { Clipboard.SetText(value); }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TryCancelLoading();
            await LoadDataAsync();
        }

        private void SaleDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryCancelLoading();
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            label8.Text = itemsTable.SelectedRows.Count.ToString("0 Selected");
        }

        private async void itemsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            await ReturnSelectedItems();
        }

        async Task ReturnSelectedItems()
        {
            if (!CurrentLogin.CanVoidSale)
            {
                MessageBox.Show("You do not have permission to edit this sale", "Return aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Return these selected items?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            try
            {
                using (var context = POSEntities.Create())
                {
                    var selectedIds = itemsTable.GetSelectedIds<int>(out IEnumerable<DataGridViewRow> selectedRows);

                    var selectedItems = await context.SoldItems
                        .Where(soldItem => selectedIds.Any(i => i == soldItem.Id))
                        .ToArrayAsync();

                    if (selectedItems.Length == 0)
                    {
                        MessageBox.Show("No Item Selected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    await context.ReturnSoldItems(selectedItems);

                    context.SoldItems.RemoveRange(selectedItems);
                    var sale = await context.Sales.FirstOrDefaultAsync(s => s.Id == _saleId);

                    if (sale.SoldItems.Count == 0)
                    {
                        if (MessageBox.Show("Would you like to remove this sale?", "Sold items for this sale is empty", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            context.Sales.Remove(sale);
                            await context.SaveChangesAsync();

                            ///close this form because the sale is no longer available
                            Close();
                            ///return so that the load will not be called
                            return;
                        }
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Return Items Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            TryCancelLoading();
            await LoadDataAsync();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dateAddedCol.Visible = checkBox2.Checked;
        }
    }

    public static class SoldItem_Extension
    {
        public static IQueryable<SoldItem> ApplySearch(this IQueryable<SoldItem> soldItems, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return soldItems;

            return soldItems.Where(so => so.SerialNumber == keyword || so.Product.Item.Barcode == keyword || so.Product.Item.Name.Contains(keyword));
        }

        public static async Task ReturnSoldItems(this POSEntities context, params SoldItem[] soldItems)
        {
            foreach (var soldItem in soldItems)
            {
                if (!soldItem.Product.Item.IsEnumerable)
                    continue;

                if (!string.IsNullOrWhiteSpace(soldItem.SerialNumber))
                {
                    ///just a safety check for when duplicate is found in the inventory item
                    if (context.InventoryItems.Any(i => i.SerialNumber == soldItem.SerialNumber))
                        continue;

                    var inv = new InventoryItem
                    {
                        Product = soldItem.Product,
                        Quantity = 1,
                        SerialNumber = soldItem.SerialNumber
                    };

                    context.InventoryItems.Add(inv);
                }
                else
                {
                    var inventoryItem = await context.InventoryItems
                        .Where(i => i.Product.Item.Type == ItemType.Quantifiable.ToString())
                        .FirstOrDefaultAsync(x => x.Product.Id == soldItem.ProductId);

                    if (inventoryItem != null)
                        inventoryItem.Quantity += soldItem.Quantity;
                    else
                    {
                        var temp = new InventoryItem
                        {
                            Product = soldItem.Product,
                            Quantity = soldItem.Quantity
                        };

                        context.InventoryItems.Add(temp);
                    }
                }
            }
        }
    }
}
