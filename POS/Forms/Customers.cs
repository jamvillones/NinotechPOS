using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Forms
{
    public partial class Customers : Form
    {
        //public event EventHandler OnSave;
        public Customers()
        {
            InitializeComponent();
        }

        public Customers(string Name)
        {
            InitializeComponent();

            //name.Text = Name.Trim();
        }

        //bool canSave()
        //{
        //    if (string.IsNullOrEmpty(name.Text.Trim()))
        //    {
        //        MessageBox.Show("Name cannot be empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return false;
        //    }
        //    using (var p = new POSEntities())
        //    {
        //        var c = p.Customers.FirstOrDefault(x => x.Name == name.Text);
        //        if (c != null)
        //        {
        //            MessageBox.Show("Name already taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        //private void saveBtn_Click(object sender, EventArgs e)
        //{
        //    if (!canSave())
        //        return;

        //    using (var p = new POSEntities())
        //    {
        //        var add = address.Text.Trim();
        //        var cont = contact.Text.Trim();

        //        Customer c = new Customer();

        //        c.Name = name.Text.Trim();

        //        c.Address = add == string.Empty ? null : add;
        //        c.ContactDetails = cont == string.Empty ? null : cont;

        //        p.Customers.Add(c);
        //        p.SaveChanges();

        //        OnSave?.Invoke(this, null);
        //    }

        //    this.Tag = name.Text.Trim();
        //    DialogResult = DialogResult.OK;

        //    this.Close();
        //}

        private async void CreateCustomerProfile_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
        string _keyWord = string.Empty;
        private async void searchControl_OnSearch(object sender, Misc.SearchEventArgs e)
        {

            _keyWord = e.Text.Trim();
            TryCancelLoading();
            e.SearchFound = await LoadDataAsync();
            if (!e.SearchFound)
                MessageBox.Show("Entries Not Found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        bool TryCancelLoading()
        {
            try
            {
                tokenSource?.Cancel();
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        CancellationTokenSource tokenSource = null;

        async Task<bool> LoadDataAsync()
        {

            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            try
            {
                using (var context = new POSEntities())
                {
                    var customers = await context.Customers
                        .AsNoTracking()
                        .AsQueryable()
                        .OrderBy(x => x.Name)
                        .ApplySearch(_keyWord)
                        .ToListAsync(token);

                    token.ThrowIfCancellationRequested();

                    if (customers.Count > 0)
                    {
                        customerTable.Rows.Clear();

                        await Task.Run(() =>
                        {

                            foreach (var customer in customers)
                            {
                                if (token.IsCancellationRequested) break;
                                customerTable.InvokeIfRequired(() => customerTable.Rows.Add(CreateRow(customer)));
                            }

                        });

                        return true;
                    }

                }
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                tokenSource?.Dispose();
            }

            return false;
        }



        DataGridViewRow CreateRow(Customer c) => customerTable.CreateRow(
            c.Id,
            "Transactions",
            c.Name,
            c.ContactDetails,
            c.Address,
            "Remove"
            );


        private async void searchControl_OnTextEmpty(object sender, EventArgs e)
        {
            _keyWord = string.Empty;
            await LoadDataAsync();
        }

        void DeleteCustomer(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var table = customerTable;
            var id = (int)(table.Rows[rowIndex].Cells[0].Value);

            using (var p = new POSEntities())
            {
                var customerToBeDeleted = p.Customers.FirstOrDefault(x => x.Id == id);
                if (customerToBeDeleted.Sales.Count > 0)
                {
                    MessageBox.Show("This customer already made transactions and cannot be deleted!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (customerToBeDeleted != null)
                {
                    p.Customers.Remove(customerToBeDeleted);
                    p.SaveChanges();
                }
            }

            table.Rows.RemoveAt(rowIndex);
        }

        private void customerTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == col_del.Index)
            {
                DeleteCustomer(e.RowIndex);
            }
            if (e.ColumnIndex == col_transact.Index)
            {
                using (var ct = new CustomerTransactionsForm())
                {
                    if (ct.SetId((int)(customerTable.Rows[e.RowIndex].Cells[0].Value)))
                        ct.ShowDialog();
                    else
                        MessageBox.Show("No Transactions Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        string lastValue = "";
        private void customerTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var table = sender as DataGridView;
            lastValue = table[e.ColumnIndex, e.RowIndex].Value?.ToString();
        }

        private void customerTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var table = sender as DataGridView;

            var id = (int)table[0, e.RowIndex].Value;

            var newValue = table[e.ColumnIndex, e.RowIndex].Value?.ToString().Trim();
            table[e.ColumnIndex, e.RowIndex].Value = newValue;

            if (newValue == lastValue)
                return;

            if (MessageBox.Show("Are you sure you want to edit this item?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                table[e.ColumnIndex, e.RowIndex].Value = lastValue;
                lastValue = "";
                return;
            }

            using (var context = new POSEntities())
            {
                var target = context.Customers.FirstOrDefault(x => x.Id == id);

                if (e.ColumnIndex == col_name.Index)
                    target.Name = newValue;

                else if (e.ColumnIndex == col_address.Index)
                    target.Address = string.IsNullOrWhiteSpace(newValue) ? null : newValue;

                else if (e.ColumnIndex == col_contact.Index)
                    target.ContactDetails = string.IsNullOrWhiteSpace(newValue) ? null : newValue;

                context.SaveChanges();
            }
        }

        private void customerTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var name = e.FormattedValue.ToString().Trim();

            bool limitExceeded = name.Length > 50;

            if (limitExceeded)
            {
                e.Cancel = true;
                MessageBox.Show("Length cannot exceed 50 characters!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
                //customerTable[e.ColumnIndex, e.RowIndex].ErrorText = "character length cannot be more then 50";
            }
            if (e.ColumnIndex == col_name.Index)
                e.Cancel = string.IsNullOrWhiteSpace(name);

        }

        private void customerTable_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void recHistBtn_Click(object sender, EventArgs e)
        {
            using (var customerForm = new Create_Customer_Form())
            {
                customerForm.OnSuccessfulCreation += CustomerForm_OnSuccessfulCreation;
                customerForm.ShowDialog();
            }
        }

        private void CustomerForm_OnSuccessfulCreation(object sender, object e)
        {
            if (e is Customer newCustomer)
            {
                customerTable.Rows.Add(CreateRow(newCustomer));
            }
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryCancelLoading();
        }
    }

    public static class CustomerQueryExtensions
    {
        public static IQueryable<Customer> ApplySearch(this IQueryable<Customer> customers, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return customers;

            return customers.Where(c => c.Name.Contains(keyword) || c.ContactDetails == keyword || c.Address.Contains(keyword));
        }
    }

}
