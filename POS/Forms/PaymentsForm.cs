using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class PaymentsForm : Form
    {
        //Sale currentSale;
        int _id = 0;
        public PaymentsForm()
        {
            InitializeComponent();
        }

        public void SetId(int id)
        {
            _id = id;

            using (var p = POSEntities.Create())
            {
                var sale = p.Sales.FirstOrDefault(x => x.Id == id);

                Text = Text + " - " + sale.Customer.Name;
                PostProcess(sale);

                table.Rows.Clear();
                var ts = p.ChargedPayRecords.Where(x => x.SaleId == sale.Id);
                foreach (var i in ts)
                    table.Rows.Add(CreateRow(i));
            }
        }

        void PostProcess(Sale sale)
        {
            total.Text = sale.Remaining.ToString("C2");
            flowLayoutPanel1.Visible = sale.Remaining > 0;
        }

        DataGridViewRow CreateRow(ChargedPayRecord record) => table.CreateRow(
            record.Id,
            record.TransactionTime.Value,
            record.Username,
            record.AmountPayed,
            record.Details.ToUpper()
            );

        private async void AddPayment_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = POSEntities.Create())
                {

                    var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == _id);

                    var paymentForm = new Add_Payment_Form(sale.Remaining);

                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        /// process the payment
                        /// 
                        var payRecord = (ChargedPayRecord)paymentForm.Tag;
                        payRecord.Sale = sale;
                        //payRecord.Username = UserManager.instance.CurrentLogin.Username;

                        sale.AmountRecieved += (decimal)payRecord.AmountPayed;
                        total.Text = string.Format("₱ {0:n}", sale.AmountRecieved);

                        //var transaction = new ChargedPayRecord();
                        //transaction.Sale = sale;
                        //transaction.Username = UserManager.instance.CurrentLogin.Username;
                        //transaction.TransactionTime = DateTime.Now;
                        //transaction.AmountPayed = paymentNum.Value;

                        var result = context.ChargedPayRecords.Add(payRecord);
                        await context.SaveChangesAsync();

                        table.Rows.Add(CreateRow(result));

                        MessageBox.Show(sale.AmountRecieved < sale.AmountDue ? "Payment added." : "Amount Fully Paid.",
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        //paymentNum.Value = 0;
                        PostProcess(sale);
                    }
                }
            }
            catch
            {

            }
            //if (paymentNum.Value == 0) return;
            //if (MessageBox.Show("Are you sure you want to add payment?",
            //    "",
            //    MessageBoxButtons.OKCancel,
            //    MessageBoxIcon.Question) == DialogResult.Cancel) return;

            //using (var context = POSEntities.Create())
            //{
            //    var sale = await context.Sales.FirstOrDefaultAsync(x => x.Id == _id);
            //    sale.AmountRecieved += paymentNum.Value;

            //    total.Text = string.Format("₱ {0:n}", sale.AmountRecieved);

            //    var transaction = new ChargedPayRecord();
            //    transaction.Sale = sale;
            //    transaction.Username = UserManager.instance.CurrentLogin.Username;
            //    transaction.TransactionTime = DateTime.Now;
            //    transaction.AmountPayed = paymentNum.Value;

            //    var result = context.ChargedPayRecords.Add(transaction);
            //    await context.SaveChangesAsync();

            //    table.Rows.Add(CreateRow(result));

            //    MessageBox.Show(sale.AmountRecieved < sale.AmountDue ? "Payment added." : "Amount fully Paid.",
            //        "",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);

            //    paymentNum.Value = 0;
            //    PostProcess(sale);
            //}
        }
        int SelectedId => (int)table.SelectedCells[col_Id.Index].Value;
        private async void table_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != col_Remove.Index) return;
            if (MessageBox.Show("Are you sure you want to undo this payment?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel) return;

            var t = sender as DataGridView;

            using (var context = POSEntities.Create())
            {
                var paymentToUndo = await context.ChargedPayRecords.FirstOrDefaultAsync(c => c.Id == SelectedId);
                var sale = paymentToUndo.Sale;

                sale.AmountRecieved -= (decimal)paymentToUndo.AmountPayed;
                context.ChargedPayRecords.Remove(paymentToUndo);
                await context.SaveChangesAsync();

                MessageBox.Show("Payment successfully undone.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                t.Rows.RemoveAt(e.RowIndex);
                PostProcess(sale);
            }
        }
    }
}
