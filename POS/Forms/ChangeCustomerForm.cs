using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class ChangeCustomerForm : Form {
        public ChangeCustomerForm(int saleId) {
            InitializeComponent();
            _saleId = saleId;
        }

        int _saleId;

        private string searchText = null;
        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e) {
            searchText = e.Text;

            TryCancel();

            await Load_Async();
        }
        private void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            searchText = string.Empty;
        }

        DataGridViewRow CreateRow(Customer c) {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(customerTable, c.Id, c.Name, c.Address);
            return row;
        }

        private async void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == -1) return;
            int id = (int)customerTable.Rows[e.RowIndex].Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to change the customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            using (var context = new POSEntities()) {
                var sale = await context.Sales.FirstOrDefaultAsync(s => s.Id == _saleId);
                var selectedCustomer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
                sale.CustomerId = selectedCustomer.Id;

                await context.SaveChangesAsync();

                Tag = new Customer() { Name = selectedCustomer.Name, Address = selectedCustomer.Address, ContactDetails = selectedCustomer.ContactDetails };
            }

            this.DialogResult = DialogResult.OK;
        }

        async Task LoadDataToTable_Async(CancellationToken token) {

            using (var context = new POSEntities()) {
                var customers = await context.Customers
                    .AsNoTracking()
                    .ApplySearch(searchText)
                    .ToArrayAsync(token);

                if (!customers.Any())
                    return;

                if (token.IsCancellationRequested)
                    return;

                customerTable.Rows.Clear();
                customerTable.Rows.AddRange(customers.Select(CreateRow).ToArray());

            }
        }
        CancellationTokenSource source = null;
        async Task Load_Async() {
            source = new CancellationTokenSource();
            var token = source.Token;

            await LoadDataToTable_Async(token);

            source.Dispose();
            source = null;
        }

        void TryCancel() {
            source?.Cancel();
        }

        private async void ChangeCustomerForm_Load(object sender, EventArgs e) {
            await Load_Async();
        }
    }
}
