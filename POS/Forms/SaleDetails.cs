using POS.Misc;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;


namespace POS.Forms {
    public partial class SaleDetails : Form {
        public SaleDetails() {
            InitializeComponent();
        }

        Login currentLogin => Misc.UserManager.instance.currentLogin;
        Sale sale;

        public event EventHandler OnSave;
        public void SetId(int id) {
            using (var p = new POSEntities()) {
                sale = p.Sales.FirstOrDefault(x => x.Id == id);
                soldBy.Text = sale.Login?.Name ?? sale.Login?.Username;
                soldTo.Text = sale.Customer.Name + " - " + sale.Customer.ContactDetails + " - " + sale.Customer.Address;

                this.Text = this.Text + " - " + sale.Id.ToString() + " (" + sale.Date.Value.ToString("MMM d, yyyy hh:mm tt") + " - " + sale.SaleType + ")";

                //SaleId.Text = sale.Id.ToString();
                //address.Text = sale.Customer.Address;
                //contact.Text = sale.Customer.ContactDetails;
                //saleType.Text = sale.SaleType;
                //Datetext.Text = sale.Date.Value.ToString("MMMM dd, yyyy hh:mm tt");

                var soldItems = sale.SoldItems;
                foreach (var x in soldItems.OrderBy(x => x.Product.Item.Name)) {
                    itemsTable.Rows.Add(x.Product.Item.Name,
                                        x.SerialNumber ?? "--",
                                        x.Product.Supplier?.Name,
                                        x.Quantity,
                                        string.Format("₱ {0:n}", x.ItemPrice),
                                        string.Format("₱ {0:n}", x.Discount),
                                        string.Format("₱ {0:n}", (x.Quantity * (x.ItemPrice - x.Discount))),
                                        x.Quantity, x.ItemPrice, x.Discount);
                }

                total.Text = string.Format("₱ {0:n}", sale.Total);
                amountRecieved.Text = string.Format("₱ {0:n}", sale.AmountRecieved);
                recHistBtn.Visible = p.ChargedPayRecords.FirstOrDefault(x => x.Sale.Id == sale.Id) != null ? true : false;

                if (sale.SaleType == SaleType.Charged.ToString() || sale.AmountRecieved >= sale.Total) {
                    remainGroup.Visible = false;
                    //addPaymentGroup.Visible = false;
                    return;
                }
            }


            remaining.Text = string.Format("₱ {0:n}", (sale.Total - sale.AmountRecieved));
        }
        void addPayment() {
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

        private void addPaymentButton_Click(object sender, EventArgs e) {
            addPayment();
        }

        private void button1_Click(object sender, EventArgs e) {
            using (var ts = new PaymentsForm()) {
                ts.SetId(sale.Id);
                ts.ShowDialog();
            }
        }

        private void voidBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("All sold items that is associated with this sale will be stocked and this sale will be removed", "Are you sure you want to void this sale?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;

            using (var p = new POSEntities()) {
                //get the reference of the sale
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
                //get the solditems of this sale and restock them

                addBackToInventory(p.SoldItems.Where(x => x.SaleId == s.Id).Select(x => x.Id).ToArray());
                //p.SoldItems.RemoveRange(s.SoldItems);

                p.Sales.Remove(s);
                p.SaveChanges();
            }
        }
        void addBackToInventory(params int[] id) {
            using (var p = new POSEntities()) {
                foreach (var i in id) {
                    var soldItem = p.SoldItems.FirstOrDefault(x => x.Id == i);

                    if (!string.IsNullOrEmpty(soldItem.SerialNumber)) {
                        var inv = new InventoryItem();
                        inv.Product = soldItem.Product;
                        inv.Quantity = 1;
                        inv.SerialNumber = soldItem.SerialNumber;
                        p.InventoryItems.Add(inv);
                    }
                    else {
                        var inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == null && x.Product.Id == soldItem.ProductId);
                        if (inv != null) {
                            if (inv.Quantity != 0)
                                inv.Quantity += soldItem.Quantity;
                        }
                        else {
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

        private void SaleDetails_Load(object sender, EventArgs e) {
            voidBtn.Visible = currentLogin.CanVoidSale;
            editItemsBtn.Visible = currentLogin.CanVoidSale;

            var settings = Properties.Settings.Default;
            if (!string.IsNullOrEmpty(settings.ReceiptPrinter))
                doc.PrinterSettings.PrinterName = settings.ReceiptPrinter;
        }

        private void editItemsBtn_Click(object sender, EventArgs e) {

            this.Close();

            using (var editsolditems = new EditSale(sale.Id)) {
                editsolditems.ShowDialog();
            }
        }

        private void SaleDetails_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control) {
                if (e.KeyCode == Keys.P) {
                    OpenPrint();
                }
            }
        }

        void OpenPrint() {
            using (var reprint = new SaleReprint()) {
                if (reprint.SetId(sale.Id))
                    reprint.ShowDialog();
            }
        }

        private void button1_Click_1(object sender, EventArgs e) {
            OpenPrint();
        }
        PrintAction printAction;
        private void button2_Click(object sender, EventArgs e) {
            try {
                doc.Print();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e) {
            ReceiptDetails details = new ReceiptDetails();
            details.ControlNumber = sale.Id.ToString();
            details.CustomerName = soldTo.Text;
            details.TransactBy = UserManager.instance.currentLogin.Name ?? "User";
            details.Tendered = sale.AmountRecieved;

            for (int i = 0; i < itemsTable.RowCount; i++)

                details.Additem(
                    itemsTable[nameCol.Index, i].Value.ToString(),
                    itemsTable[serialCol.Index, i].Value.ToString(),
                    (int)itemsTable[actualQty.Index, i].Value,
                    (decimal)itemsTable[actualPrice.Index, i].Value,
                    (decimal)itemsTable[actualDiscount.Index, i].Value);

            e.FormatReciept(printAction, details);
        }

        private void doc_BeginPrint(object sender, PrintEventArgs e) {
            printAction = e.PrintAction;
        }

        private void paymentNum_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                addPayment();
        }

        private void button1_Click_2(object sender, EventArgs e) {
            using (var det = new EditSaleDetails()) {
                det.SaleId = sale.Id;

                if (det.ShowDialog() == DialogResult.OK) {
                    using (var p = new POSEntities()) {
                        sale = p.Sales.FirstOrDefault(x => x.Id == sale.Id);

                        soldTo.Text = sale.Customer.Name;
                        //Datetext.Text = sale.Date.Value.ToString("MMMM dd, yyyy hh:mm tt");
                    }
                }
            }
        }
    }
}
