using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Forms
{
    public partial class SaleDetails : Form
    {
        Login currentLogin
        {
            get
            {
                return Misc.UserManager.instance.currentLogin;
            }
        }
        public event EventHandler OnSave;
        Sale sale;
        public SaleDetails()
        {
            InitializeComponent();
        }
        public void SetId(int id)
        {
            using (var p = new POSEntities())
            {
                sale = p.Sales.FirstOrDefault(x => x.Id == id);
                soldBy.Text = sale.Login?.Username;
                soldTo.Text = sale.Customer.Name;
                address.Text = sale.Customer.Address;
                contact.Text = sale.Customer.ContactDetails;
                saleType.Text = sale.SaleType;

                Datetext.Text = sale.Date.Value.ToString("MMMM dd, yyyy hh:mm tt");
                var soldItems = sale.SoldItems;
                foreach (var x in soldItems)
                {
                    itemsTable.Rows.Add(x.ItemName,
                                        x.SerialNumber,
                                        x.Quantity,
                                        string.Format("₱ {0:n}", x.ItemPrice),
                                        x.Discount,
                                        string.Format("₱ {0:n}", (x.Quantity * x.ItemPrice) * ((100 - x.Discount) / 100)),
                                        x.ItemSupplier);
                }
                total.Text = string.Format("₱ {0:n}", sale.TotalPrice);
                amountRecieved.Text = string.Format("₱ {0:n}", sale.AmountRecieved);
                recHistBtn.Visible = p.ChargedPayRecords.FirstOrDefault(x => x.Sale.Id == sale.Id) != null ? true : false;
            }


            if (saleType.Text == "Chareged" || string.IsNullOrEmpty(saleType.Text) || sale.AmountRecieved >= sale.TotalPrice)
            {
                remainGroup.Visible = false;
                addPaymentGroup.Visible = false;
                return;
            }
            remaining.Text = string.Format("₱ {0:n}", (sale.TotalPrice - sale.AmountRecieved));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            addPaymentButton.Enabled = addPayment.Value <= 0 ? false : true;
        }

        private void addPaymentButton_Click(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
                s.AmountRecieved += addPayment.Value;
                //if(s.AmountRecieved >= s.TotalPrice)
                //{
                //    s.SaleType = Misc.SaleType.Regular.ToString();
                //}
                if (s.AmountRecieved >= s.TotalPrice)
                {

                    s.AmountRecieved = s.TotalPrice;
                }

                amountRecieved.Text = string.Format("₱ {0:n}", s.AmountRecieved);
                remaining.Text = string.Format("₱ {0:n}", (s.TotalPrice - s.AmountRecieved));

                var transaction = new ChargedPayRecord();
                transaction.Sale = s;
                transaction.Username = currentLogin.Username;
                transaction.TransactionTime = DateTime.Now;
                transaction.AmountPayed = addPayment.Value;
                p.ChargedPayRecords.Add(transaction);
                p.SaveChanges();
                OnSave?.Invoke(this, null);
                MessageBox.Show(s.AmountRecieved < s.TotalPrice ? "Payment added." : "Amount fully Paid.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ts = new TransactionHistoryForm();
            ts.SetId(sale.Id);
            ts.ShowDialog();
        }

        private void voidBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to void this sale?", "All sold items that is associated with this sale will be stocked and this sale will be removed", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;

            }
            using (var p = new POSEntities())
            {
                //get the reference of the sale
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
                //get the solditems of this sale and restock them

                addBackToInventory(p.SoldItems.Select(x => x.Id).ToArray());
                //p.SoldItems.RemoveRange(s.SoldItems);

                p.Sales.Remove(s);
                p.SaveChanges();
            }
        }
        void addBackToInventory(params int[] id)
        {
            using (var p = new POSEntities())
            {
                foreach(var i in id)
                {
                    var soldItem = p.SoldItems.FirstOrDefault(x => x.Id == i);
                    var Product = p.Products.FirstOrDefault(x => x.Item.Name == soldItem.ItemName && x.Supplier.Name == soldItem.ItemSupplier);
                }
            }

        }
    }
}
