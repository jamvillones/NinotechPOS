using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Misc;
namespace POS.Forms
{
    public partial class PaymentsForm : Form
    {
        Sale currentSale;
        public PaymentsForm()
        {
            InitializeComponent();
        }

        public void SetId(int id)
        {
            using (var p = new POSEntities())
            {
                currentSale = p.Sales.FirstOrDefault(x => x.Id == id);

                Text = Text + " - " + currentSale.Customer.Name;
                PostProcess(currentSale);

                table.Rows.Clear();
                var ts = p.ChargedPayRecords.Where(x => x.SaleId == currentSale.Id);
                foreach (var i in ts)
                    table.Rows.Add(CreateRow(i));
            }
        }

        void PostProcess(Sale sale)
        {
            total.Text = sale.Remaining.ToString("C2");
            flowLayoutPanel1.Visible = sale.Remaining > 0;
            paymentNum.Maximum = sale.Remaining;
        }

        DataGridViewRow CreateRow(ChargedPayRecord record) => table.CreateRow(
            record.Username,
            record.AmountPayed,
            record.TransactionTime.Value
            );

        private async void recHistBtn_Click(object sender, EventArgs e)
        {
            if (paymentNum.Value == 0) return;

            if (MessageBox.Show("Are you sure you want to add payment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (var context = new POSEntities())
            {
                var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == currentSale.Id);
                sale.AmountRecieved += paymentNum.Value;

                total.Text = string.Format("₱ {0:n}", sale.AmountRecieved);

                var transaction = new ChargedPayRecord();
                transaction.Sale = sale;
                transaction.Username = UserManager.instance.currentLogin.Username;
                transaction.TransactionTime = DateTime.Now;
                transaction.AmountPayed = paymentNum.Value;

                var result = context.ChargedPayRecords.Add(transaction);
                await context.SaveChangesAsync();

                table.Rows.Add(CreateRow(result));

                paymentNum.Value = 0;
                PostProcess(sale);

                MessageBox.Show(sale.AmountRecieved < sale.Total ? "Payment added." : "Amount fully Paid.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void paymentNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                addPaymentBtn.PerformClick();
        }
    }
}
