using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Suppliers_List : Form
    {

        public Suppliers_List()
        {
            InitializeComponent();
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        #region edits
        Supplier targetSupplier;
        private void supplierTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var id = (int)((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
            try
            {
                using (var p = POSEntities.Create())
                {
                    targetSupplier = p.Suppliers.FirstOrDefault(x => x.Id == id);
                }
            }
            catch (UnautorizedLoginException)
            {
                this.ShowLoginUnauthorizedMessage();
                return;
            }
        }
        private async void supplierTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (var p = POSEntities.Create())
                {
                    var dgt = (DataGridView)sender;
                    var newValue = dgt.CurrentCell.Value?.ToString().Trim().NullIfEmpty();

                    ///make sure to terminate the save when changes values are not changed
                    if ((e.ColumnIndex == col_suppName.Index && newValue == targetSupplier.Name) ||
                        (e.ColumnIndex == col_contact.Index && newValue == targetSupplier.ContactDetails))
                        return;

                    var id = (int)(dgt.Rows[e.RowIndex].Cells[0].Value);

                    var supplier = await p.Suppliers.FirstOrDefaultAsync(x => x.Id == id);

                    if (e.ColumnIndex == col_suppName.Index) supplier.Name = newValue;
                    else if (e.ColumnIndex == col_contact.Index) supplier.ContactDetails = newValue;

                    await p.SaveChangesAsync();
                }
            }
            catch (UnautorizedLoginException)
            {
                this.ShowLoginUnauthorizedMessage();
                return;
            }
            catch (EntityException ex)
            {
                MessageBox.Show(ex.Message, "Edit Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Edit Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private async void supplierTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
                return;

            var dgt = sender as DataGridView;
            var id = (int)(dgt.Rows[e.RowIndex].Cells[0].Value);

            if (MessageBox.Show("Are you sure you want to delete supplier: " + dgt.Rows[e.RowIndex].Cells[1].Value.ToString() + "\n\nTo edit details, simply edit the cells in the table."
                               , "",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            try
            {
                using (var context = POSEntities.Create())
                {
                    var s = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
                    context.Suppliers.Remove(s);
                    await context.SaveChangesAsync();
                }
            }
            catch (UnautorizedLoginException)
            {
                this.ShowLoginUnauthorizedMessage();

                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Supplier cannot be deleted\nThis supplier is already referenced in one of the items", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //resetAutoComplete();
            dgt.Rows.RemoveAt(e.RowIndex);
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            _keyword = e.Text.Trim();
            TryCancel();
            e.SearchFound = await LoadDataAsync();

            if (!e.SearchFound)
                MessageBox.Show("No Entries Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        string _keyword = string.Empty;
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            _keyword = string.Empty;
            TryCancel();
            await LoadDataAsync();
        }

        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        void TryCancel()
        {
            try
            {
                cancellationTokenSource?.Cancel();
            }
            catch (ObjectDisposedException)
            {

            }
        }

        private async Task<bool> LoadDataAsync()
        {
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {
                using (var context = POSEntities.Create())
                {
                    var suppliers = await context.Suppliers.AsNoTracking().AsQueryable()
                        .Where(s => s.Name != "none")
                        .ApplySearch(_keyword)
                        .ToListAsync(token);

                    token.ThrowIfCancellationRequested();

                    if (suppliers.Count > 0)
                    {
                        supplierTable.Rows.Clear();

                        foreach (var supplier in suppliers)
                        {
                            supplierTable.Rows.Add(CreateRow(supplier));
                            token.ThrowIfCancellationRequested();
                            await Task.Delay(1, token);
                        }

                        return true;
                    }

                }
            }
            catch (UnautorizedLoginException)
            {
                this.ShowLoginUnauthorizedMessage();
            }
            catch (OperationCanceledException) { }
            catch (EntityException) { }

            return false;
        }

        DataGridViewRow CreateRow(Supplier s) => supplierTable.CreateRow(s.Id, s.Name, s.ContactDetails, "Remove");

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (var supplierForm = new Create_Supplier_Form())
            {
                if (supplierForm.ShowDialog() == DialogResult.OK)
                {
                    var newSupplier = supplierForm.Tag as Supplier;
                    supplierTable.Rows.Add(CreateRow(newSupplier));
                }
            }
        }

        private void Suppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryCancel();
        }
    }

    public static class SupplierQueryExtensions
    {
        public static IQueryable<Supplier> ApplySearch(this IQueryable<Supplier> suppliers, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return suppliers;

            return suppliers.Where(s => s.Name.Contains(keyword) || s.ContactDetails == keyword);
        }
    }


}
