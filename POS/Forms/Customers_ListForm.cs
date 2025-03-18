using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS.Forms
{
    public partial class Customers_ListForm : Form
    {

        public event EventHandler<Customer> OnSelected;
        public Customers_ListForm(bool isSelecting)
        {
            InitializeComponent();
            _isSelecting = isSelecting;
        }

        public Customers_ListForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// used for customer picking mode. automatically selecting customer upon register if true.
        /// </summary>
        bool _isSelecting = false;

        private async void CreateCustomerProfile_Load(object sender, EventArgs e)
        {
            await LoadData_Async();
            await SetAutoComplete_Async();
        }

        async Task<string[]> GetAutoComplete_Async()
        {
            try
            {
                using (var context = new POSEntities())
                {
                    return await context.Customers
                        .AsNoTracking()
                        .AsQueryable()
                        .Select(x => x.Name)
                        .ToArrayAsync();
                }
            }
            catch
            {
                return Array.Empty<string>();
            }
        }

        async Task SetAutoComplete_Async()
        {
            var names = await GetAutoComplete_Async();

            searchControl.SetAutoComplete(names);
        }
        string _keyWord = string.Empty;
        private async void searchControl_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            _keyWord = e.Text;

            TryCancelLoading();

            e.SearchFound = await LoadData_Async();
            if (!e.SearchFound)
                MessageBox.Show("No Entries Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //return wether an actual task is cancelled
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

        async Task<bool> LoadData_Async()
        {

            tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            try
            {
                //loadingLabel.Text = "loading...";
                using (var context = new POSEntities())
                {
                    var customers = await context.Customers
                        .AsNoTracking()
                        .AsQueryable()
                        .ApplySearch(_keyWord)
                        //.OrderBy(x => x.Name)
                        .Select(c => new CustomerDTO()
                        {
                            Id = c.Id,
                            Name = c.Name,
                            ContactDetails = c.ContactDetails,
                            Address = c.Address
                        })
                        .ToListAsync(token);

                    token.ThrowIfCancellationRequested();

                    if (customers.Count > 0)
                    {
                        customerTable.Rows.Clear();
                        foreach (var c in customers)
                        {
                            token.ThrowIfCancellationRequested();
                            customerTable.Rows.Add(CreateRow(c));
                            await Task.Delay(100);
                        }

                        return true;
                    }
                }
            }
            catch (OperationCanceledException) { }
            catch { }
            finally
            {
                tokenSource?.Dispose();

            }

            return false;
        }

        private class CustomerDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string ContactDetails { get; set; }
        }

        DataGridViewRow CreateRow(CustomerDTO c) => customerTable.CreateRow(
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

            if (TryCancelLoading())
                await Task.Delay(100);

            await LoadData_Async();
        }

        void DeleteCustomer(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
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

        string lastValue = string.Empty;
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
            if (_isSelecting && MessageBox.Show("Would you like to select the newly added Customer?",
                                                "",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var newlyAddedCustomer = (Customer)e;
                OnSelected?.Invoke(this, newlyAddedCustomer);

                if (sender is Form createForm)
                    createForm.Close();

                return;
            }
            if (e is Customer newCustomer)
            {
                var customer = new CustomerDTO()
                {
                    Id = newCustomer.Id,
                    Name = newCustomer.Name,
                    Address = newCustomer.Address
                };
                customerTable.Rows.Add(CreateRow(customer));
            }
        }

        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryCancelLoading();
        }

        private async void customerTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex != -1) return;

            Customer Selected = null;

            var id = (int)customerTable.SelectedCells[col_id.Index].Value;

            try
            {
                using (var context = new POSEntities())
                {
                    Selected = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                }
                if (Selected is null)
                {
                    MessageBox.Show("Customer might be removed", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {

            }

            OnSelected?.Invoke(this, Selected);
        }
    }

    public static class CustomerQueryExtensions
    {
        public static IQueryable<Customer> ApplySearch(this IQueryable<Customer> customers, string keyword)
        {

            if (keyword.IsEmpty())
                return customers;



            return customers.Where(c => c.Name.Contains(keyword) || c.ContactDetails == keyword || c.Address.Contains(keyword));
        }
    }

}
