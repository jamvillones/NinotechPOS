using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Forms
{
    public partial class SaleDetails : Form
    {
        //public SaleDetails() {
        //    InitializeComponent();
        //}

        public SaleDetails(int id)
        {
            InitializeComponent();
            _saleId = id;

            voidBtn.Visible = CurrentLogin.CanVoidSale;
            editItemsBtn.Visible = CurrentLogin.CanVoidSale;

            var settings = Properties.Settings.Default;

            if (!string.IsNullOrEmpty(settings.ReceiptPrinter))
                doc.PrinterSettings.PrinterName = settings.ReceiptPrinter;
        }

        Login CurrentLogin => UserManager.instance.CurrentLogin;

        private readonly int _saleId;

        DataGridViewRow CreateRow(SoldItem soldItem) => itemsTable.CreateRow(
            soldItem.Product.Item.Name,
            soldItem.SerialNumber,
            soldItem.Product.Supplier?.Name,
            soldItem.Quantity,
            soldItem.ItemPrice,
            soldItem.Discount == 0 ? null : (decimal?)soldItem.Discount,
            soldItem.Quantity * (soldItem.ItemPrice - soldItem.Discount)
            );

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

                using (var context = new POSEntities())
                {
                    //get the reference of the sale
                    var saleToVoid = context.Sales.FirstOrDefault(x => x.Id == _saleId);
                    await AddBackToInventory(context, context.SoldItems.Where(x => x.SaleId == saleToVoid.Id).Select(x => x.Id).ToArray());

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
            //this.Close();
        }

        async Task AddBackToInventory(POSEntities context, params int[] id)
        {
            foreach (var i in id)
            {
                var soldItem = await context.SoldItems.FirstOrDefaultAsync(x => x.Id == i);

                if (!soldItem.Product.Item.IsEnumerable)
                    continue;

                if (!string.IsNullOrWhiteSpace(soldItem.SerialNumber))
                {
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
                    var inv = await context.InventoryItems
                        .Where(ii => ii.Product.Item.Type == ItemType.Quantifiable.ToString())
                        .FirstOrDefaultAsync(x => x.Product.Id == soldItem.ProductId);

                    if (inv != null)                    
                        inv.Quantity += soldItem.Quantity;                    
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

        private async Task AddRowsAsync(IEnumerable<SoldItem> items)
        {
            await Task.Run(() =>
            {
                foreach (var soldItem in items)
                {
                    //if (itemsTable.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[serialCol.Index] == null).Any(i => i.Cells[nameCol.Index].ToString().Equals(soldItem.Product.Item.Name, StringComparison.OrdinalIgnoreCase))) {

                    //}
                    //else
                    itemsTable.InvokeIfRequired(() => itemsTable.Rows.Add(CreateRow(soldItem)));
                }

            });
        }

        private async void SaleDetails_Load(object sender, EventArgs e)
        {
            itemsTable.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            using (var p = new POSEntities())
            {
                var sale = await p.Sales.FirstOrDefaultAsync(x => x.Id == _saleId);

                this.Text = this.Text + " - " + sale.Id.ToString() + " ( " + sale.Date.Value.ToString("MMM d, yyyy hh:mm tt") + " - " + sale.SaleType + " )";
                bool isCharged = sale.SaleType.Equals(SaleType.Charged.ToString(), StringComparison.OrdinalIgnoreCase);

                soldBy.Text = sale.Login.ToString();
                soldTo.Text = sale.Customer?.ToString();

                paymentsBtn.Visible = isCharged;

                var soldItems = await GetSoldItemsAsync(p);
                itemsTable.Rows.AddRange(soldItems.Select(CreateRow).ToArray());

                decimal subTotal = itemsTable.Rows.Cast<DataGridViewRow>().Select(row => (decimal)(row.Cells[totalCol.Index].Value)).Sum();
                itemsTable.Rows.Add("", "", "", "", "", "", subTotal);

                discount.Text = sale.Discount.ToCurrency();
                amountDue.Text = sale.AmountDue.ToCurrency();
                amountRecieved.Text = sale.AmountRecieved.ToCurrency();
                //total.Text = sale.Total.ToCurrency();
                remaining.Text = (sale.AmountDue - sale.AmountRecieved).ToCurrency();
            }
        }

        private async void editItemsBtn_Click(object sender, EventArgs e)
        {

            using (var editSoldItems = new EditSale(_saleId))
            {
                editSoldItems.ShowDialog();
                if (editSoldItems.ChangesMade)
                {
                    await LoadDataAsync();

                    //amountDue.Text = itemsTable.Rows.Cast<DataGridViewRow>()
                    //    //.Select(row => (int)(row.Cells[qtyCol.Index].Value) * ((decimal)(row.Cells[priceCol.Index].Value) - (decimal)(row.Cells[discountCol.Index].Value)))
                    //    .Select(row => (decimal)(row.Cells[totalCol.Index].Value))
                    //    .Sum()
                    //   .ToString("C2");
                }
            }
        }

        private void SaleDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
                OpenPrint();
        }

        void OpenPrint()
        {
            using (var reprint = new SaleReprint())
            {
                if (reprint.SetId(_saleId))
                    reprint.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenPrint();
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

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (var context = new POSEntities())
            {
                var sale = context.Sales.FirstOrDefault(x => x.Id == _saleId);

                ReceiptDetails details = new ReceiptDetails();
                details.ControlNumber = sale.Id.ToString();
                details.CustomerName = soldTo.Text;
                details.TransactBy = UserManager.instance.CurrentLogin.Name ?? "User";
                details.Tendered = sale.AmountRecieved;
                details.Discount = sale.Discount;

                foreach (var soldItem in sale.SoldItems)
                {
                    details.AddItem(
                        soldItem.Product.Item.Name,
                        soldItem.SerialNumber,
                        soldItem.Quantity,
                        soldItem.ItemPrice,
                        soldItem.Discount
                        );
                }

                e.FormatReciept(printAction, details);
            }
        }

        private void doc_BeginPrint(object sender, PrintEventArgs e)
        {
            printAction = e.PrintAction;
        }

        public async Task<List<SoldItem>> GetSoldItemsAsync(POSEntities context)
        {
            return await context.SoldItems
                .AsNoTracking()
                .AsQueryable()
                .Where(so => so.SaleId == _saleId)
                .OrderBy(o => o.Product.Item.Name)
                .ToListAsync();
        }

        async Task<bool> LoadDataAsync()
        {
            bool isNotEmpty = false;
            using (var context = new POSEntities())
            {

                var soldItems = context.SoldItems.AsNoTracking().AsQueryable()
                    .Where(so => so.SaleId == _saleId);

                soldItems = string.IsNullOrWhiteSpace(keyword) ?
                    soldItems :
                    soldItems.Where(so => so.SerialNumber == keyword || so.Product.Item.Name.Contains(keyword));

                var result = await soldItems.ToListAsync();
                isNotEmpty = result.Count > 0;

                if (isNotEmpty)
                {

                    itemsTable.Rows.Clear();
                    itemsTable.Rows.AddRange(result.Select(CreateRow).ToArray());

                    decimal subTotal = itemsTable.Rows.Cast<DataGridViewRow>().Select(row => (decimal)(row.Cells[totalCol.Index].Value)).Sum();
                    itemsTable.Rows.Add("", "", "", "", "", "", subTotal);

                }
            }
            return isNotEmpty;
        }
        string keyword = string.Empty;

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            keyword = e.Text.Trim();
            e.SearchFound = await LoadDataAsync();

            _messageLabel.Text = e.SearchFound ? "" : "**No Results Found.";
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
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
    }
}
