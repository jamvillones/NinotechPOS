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
    public partial class SupplierForm : Form
    {
        ///List<Supplier> suppliers = new List<Supplier>();
        public event EventHandler OnSave;
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            supplierTable.Rows.Clear();
            try
            {
                using (var p = new POSEntities())
                {
                    //suppliers = p.Suppliers.ToList();
                    foreach (var x in p.Suppliers)
                    {
                        supplierTable.Rows.Add(x.Id, x.Name, x.ContactDetails, "Delete");
                    }
                    searchControl1.SetAutoComplete(p.Suppliers.Select(x => x.Name).ToArray());
                    //forbiddenId = (int)( supplierTable.Rows[0].Cells[0].Value);

                }
                resetAutoComplete();
            }
            catch
            {

            }
        }

        void resetAutoComplete()
        {
            using (var p = new POSEntities())
            {
                searchControl1.SetAutoComplete(p.Suppliers.Select(x => x.Name).ToArray());
            }
        }

        private void supplierTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

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
                OnSave?.Invoke(this, null);
                p.SaveChanges();
                MessageBox.Show("Edit saved");
            }
            resetAutoComplete();
        }
        #endregion

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            addSuppBtn.Enabled = supplierName.Text == string.Empty || contactDetails.Text == string.Empty ? false : true;
        }

        private void supplierName_Leave(object sender, EventArgs e)
        {
            if (supplierName.Text == string.Empty)
                return;

            using (var p = new POSEntities())
            {
                if (p.Suppliers.Any(x => x.Name == supplierName.Text))
                {
                    MessageBox.Show("Supplier already present.");
                    this.ActiveControl = supplierName;
                    supplierName.SelectAll();
                }
            }
        }

        private void addSuppBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add a new Supplier?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            using (var p = new POSEntities())
            {
                var name = supplierName.Text.Trim(' ');
                var contact = contactDetails.Text.Trim(' ');

                //if(p.Suppliers.Any(x=>x.Name == name ))
                //{
                //    MessageBox.Show("Supplier already present.");
                //    return;
                //}

                var newSupplier = new Supplier();
                newSupplier.Name = name;
                newSupplier.ContactDetails = contact;
                p.Suppliers.Add(newSupplier);

                supplierTable.Rows.Add(newSupplier.Id, newSupplier.Name, newSupplier.ContactDetails, "Delete");

                //suppliers.Add(newSupplier);
                p.SaveChanges();
            }
            resetAutoComplete();
            OnSave?.Invoke(this, null);
            supplierName.ResetText();
            contactDetails.ResetText();
        }
        
        private void supplierTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                using (var p = new POSEntities())
                {
                    var s = p.Suppliers.FirstOrDefault(x => x.Id == id);
                    p.Suppliers.Remove(s);
                    p.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Supplier cannot be deleted\nThis supplier is already referenced in one of the items", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            resetAutoComplete();
            dgt.Rows.RemoveAt(e.RowIndex);
        }

        private void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            using (var p = new POSEntities())
            {
                var supps = p.Suppliers.Where(x => x.Name.Contains(e.Text));
                if (supps.Count() != 0)
                {
                    e.SearchFound = true;
                    supplierTable.Rows.Clear();
                    foreach (var i in supps)
                        supplierTable.Rows.Add(i.Id, i.Name, i.ContactDetails, "Delete");
                    return;
                }
                MessageBox.Show("Entry not found");
            }
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                supplierTable.Rows.Clear();

                foreach (var i in p.Suppliers)
                    supplierTable.Rows.Add(i.Id, i.Name, i.ContactDetails, "Delete");

            }
        }
    }
}
