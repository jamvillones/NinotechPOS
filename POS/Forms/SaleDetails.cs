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

        Login CurrentLogin => UserManager.instance.currentLogin;

        private int _saleId;

        //Sale sale;

        public event EventHandler OnSave;

        DataGridViewRow CreateRow(SoldItem soldItem) => itemsTable.CreateRow(
            soldItem.Product.Item.Name,
            soldItem.SerialNumber,
            soldItem.Product.Supplier.Name,
            soldItem.Quantity,
            soldItem.ItemPrice,
            soldItem.Discount,
            soldItem.Quantity * (soldItem.ItemPrice - soldItem.Discount)
            );

        void addPayment()
        {
            //if (paymentNum.Value == 0)
            //    return;

            //if (MessageBox.Show("Are you sure you want to add payment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //    return;

            //using (var p = new POSEntities()) {
            //    var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
            //    s.AmountRecieved += paymentNum.Value;

            //    amountRecieved.Text = string.Format("₱ {0:n}", s.AmountRecieved);
            //    remaining.Text = string.Format("₱ {0:n}", s.Remaining);

            //    var transaction = new ChargedPayRecord();
            //    transaction.Sale = s;
            //    transaction.Username = currentLogin.Username;
            //    transaction.TransactionTime = DateTime.Now;
            //    transaction.AmountPayed = paymentNum.Value;

            //    p.ChargedPayRecords.Add(transaction);
            //    p.SaveChanges();
            //    OnSave?.Invoke(this, null);

            //    MessageBox.Show(s.AmountRecieved < s.Total ? "Payment added." : "Amount fully Paid.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void addPaymentButton_Click(object sender, EventArgs e)
        {
            addPayment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ts = new PaymentsForm())
            {
                ts.SetId(_saleId);
                ts.ShowDialog();
            }
        }

        private void voidBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All sold items that is associated with this sale will be re-stocked and this sale will be removed", "Are you sure you want to void this sale?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            using (var p = new POSEntities())
            {
                //get the reference of the sale
                var s = p.Sales.FirstOrDefault(x => x.Id == _saleId);
                //get the solditems of this sale and restock them

                addBackToInventory(p.SoldItems.Where(x => x.SaleId == s.Id).Select(x => x.Id).ToArray());
                //p.SoldItems.RemoveRange(s.SoldItems);

                p.Sales.Remove(s);
                p.SaveChanges();
            }
        }

        void addBackToInventory(params int[] id)
        {
            using (var p = new POSEntities())
            {
                foreach (var i in id)
                {
                    var soldItem = p.SoldItems.FirstOrDefault(x => x.Id == i);

                    if (!string.IsNullOrEmpty(soldItem.SerialNumber))
                    {
                        var inv = new InventoryItem();
                        inv.Product = soldItem.Product;
                        inv.Quantity = 1;
                        inv.SerialNumber = soldItem.SerialNumber;
                        p.InventoryItems.Add(inv);
                    }
                    else
                    {
                        var inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == null && x.Product.Id == soldItem.ProductId);
                        if (inv != null)
                        {
                            if (inv.Quantity != 0)
                                inv.Quantity += soldItem.Quantity;
                        }
                        else
                        {
                            var temp = new InventoryItem();
                            temp.Product = soldItem.Product;
                            temp.Quantity = soldItem.Quantity;
                            p.InventoryItems.Add(temp);
                        }
                    }
                }
                p.SaveChanges();
                MessageBox.Show("Void Successful");
                this.Close();
            }

        }

        private async void SaleDetails_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var sale = await p.Sales.FirstOrDefaultAsync(x => x.Id == _saleId);

                soldBy.Text = sale.Login?.Name ?? sale.Login?.Username;
                soldTo.Text = sale.Customer.Name + " - " + sale.Customer.ContactDetails + " - " + sale.Customer.Address;

                this.Text = this.Text + " - " + sale.Id.ToString() + " (" + sale.Date.Value.ToString("MMM d, yyyy hh:mm tt") + " - " + sale.SaleType + ")";

                var soldItems = await GetSoldItemsAsync(p);

                await Task.Run(() =>
                {
                    foreach (var soldItem in soldItems)
                    {
                        itemsTable.InvokeIfRequired(() => itemsTable.Rows.Add(CreateRow(soldItem)));
                    }
                });

                total.Text = sale.Total.ToString("C2");
                amountRecieved.Text = sale.AmountRecieved.ToString("C2");

                if (sale.SaleType == SaleType.Charged.ToString() || sale.AmountRecieved >= sale.Total)
                {
                    remainGroup.Visible = false;
                    return;
                }
                remaining.Text = string.Format("₱ {0:n}", (sale.Total - sale.AmountRecieved));
            }
        }

        private void editItemsBtn_Click(object sender, EventArgs e)
        {

            //this.Close();

            using (var editsolditems = new EditSale(_saleId))
            {
                editsolditems.ShowDialog();
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
                details.TransactBy = UserManager.instance.currentLogin.Name ?? "User";
                details.Tendered = sale.AmountRecieved;

                foreach (var soldItem in sale.SoldItems)
                {
                    details.Additem(
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
                    await Task.Run(() =>
                    {
                        foreach (var s in result)
                            itemsTable.InvokeIfRequired(() => itemsTable.Rows.Add(CreateRow(s)));
                    });
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
    }
}
