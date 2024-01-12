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

namespace POS.Forms
{
    public partial class Suppliers : Form
    {
        ///List<Supplier> suppliers = new List<Supplier>();
        //public event EventHandler OnSave;
        public Suppliers()
        {
            InitializeComponent();
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        //void resetAutoComplete()
        //{
        //    using (var p = new POSEntities())
        //    {
        //        searchControl1.SetAutoComplete(p.Suppliers.Select(x => x.Name).ToArray());
        //    }
        //}

        #region edits
        Supplier targetSupplier;
        private void supplierTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var id = (int)(((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value);
            using (var p = new POSEntities())
            {
                targetSupplier = p.Suppliers.FirstOrDefault(x => x.Id == id);
            }
        }
        private void supplierTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgt = (DataGridView)sender;
            var current = dgt.CurrentCell.Value.ToString();
            ///name
            if ((e.ColumnIndex == 1 && current == targetSupplier.Name) ||
                (e.ColumnIndex == 2 && current == targetSupplier.ContactDetails))
            {
                return;
            }
            using (var p = new POSEntities())
            {
                var id = (int)(dgt.Rows[e.RowIndex].Cells[0].Value);
                var supp = p.Suppliers.FirstOrDefault(x => x.Id == id);
                if (e.ColumnIndex == 1)
                {
                    supp.Name = dgt.Rows[e.RowIndex].Cells[1].Value.ToString();

                }
                else if (e.ColumnIndex == 2)
                {
                    supp.ContactDetails = dgt.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
                //OnSave?.Invoke(this, null);
                p.SaveChanges();
                MessageBox.Show("Edit saved");
            }
        }
        #endregion

        //private void textBox_TextChanged(object sender, EventArgs e)
        //{
        //    addSuppBtn.Enabled = supplierName.Text == string.Empty || contactDetails.Text == string.Empty ? false : true;
        //}

        //private void supplierName_Leave(object sender, EventArgs e)
        //{
        //    if (supplierName.Text == string.Empty)
        //        return;

        //    using (var p = new POSEntities())
        //    {
        //        if (p.Suppliers.Any(x => x.Name == supplierName.Text))
        //        {
        //            MessageBox.Show("Supplier already present.");
        //            this.ActiveControl = supplierName;
        //            supplierName.SelectAll();
        //        }
        //    }
        //}

        //string supplier => string.IsNullOrWhiteSpace(supplierName.Text) ? null : supplierName.Text.Trim();
        //string contact => string.IsNullOrWhiteSpace(contactDetails.Text) ? null : contactDetails.Text.Trim();

        //bool canSave => supplier != null && contact != null;


        //private void addSuppBtn_Click(object sender, EventArgs e)
        //{
        //    if (!canSave)
        //        return;

        //    if (MessageBox.Show("Are you sure you want to add a new Supplier?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //        return;

        //    using (var p = new POSEntities())
        //    {
        //        var newSupplier = new Supplier();
        //        newSupplier.Name = supplier;
        //        newSupplier.ContactDetails = contact;
        //        p.Suppliers.Add(newSupplier);

        //        supplierTable.Rows.Add(newSupplier.Id, newSupplier.Name, newSupplier.ContactDetails, "Delete");

        //        p.SaveChanges();
        //    }

        //    resetAutoComplete();
        //    OnSave?.Invoke(this, null);
        //    supplierName.ResetText();
        //    contactDetails.ResetText();
        //}

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
                using (var context = new POSEntities())
                {
                    var s = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);
                    context.Suppliers.Remove(s);
                    await context.SaveChangesAsync();
                }
            }
            catch
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
            e.SearchFound = await LoadDataAsync();
        }

        string _keyword = string.Empty;
        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            _keyword = string.Empty;
            await LoadDataAsync();
        }

        private async Task<bool> LoadDataAsync()
        {
            using (var context = new POSEntities())
            {
                var suppliers = await context.Suppliers.AsNoTracking().AsQueryable().ApplySearch(_keyword).ToListAsync();

                if (suppliers.Count > 0)
                {
                    supplierTable.Rows.Clear();

                    foreach (var supplier in suppliers)
                        supplierTable.Rows.Add(CreateRow(supplier));

                    return true;
                }

            }
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
