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
        List<Supplier> suppliers = new List<Supplier>();
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
                    suppliers = p.Suppliers.ToList();
                    foreach (var x in p.Suppliers)
                    {
                        supplierTable.Rows.Add(x.Name, x.ContactDetails);
                    }
                }
            }
            catch
            {

            }
        }

        private void supplierTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void supplierTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgt = (DataGridView)sender;

            using (var p = new POSEntities())
            {
                //if (e.RowIndex == suppliers.Count)
                //{
                //    if(dgt.Rows)
                //    var suppName = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();
                //    if (p.Suppliers.FirstOrDefault(x => x.Name == suppName) != null) {
                //        MessageBox.Show("Supplier already present.");
                //        dgt.Rows.RemoveAt(e.RowIndex);
                //        return;
                //    }
                //    var newSupp = new Supplier();
                //    newSupp.Name = suppName;
                //    suppliers.Add(newSupp);
                //    p.Suppliers.Add(newSupp);
                //    p.SaveChanges();
                //    return;
                //}
                var id = suppliers[e.RowIndex].Id;
                var supp = p.Suppliers.FirstOrDefault(x => x.Id == id);
                if (e.ColumnIndex == 0)
                {
                    supp.Name = dgt.Rows[e.RowIndex].Cells[0].Value.ToString();

                }
                else
                {
                    supp.ContactDetails = dgt.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
                OnSave?.Invoke(this, null);
                p.SaveChanges();
            }
        }

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
                if (p.Suppliers.FirstOrDefault(x => x.Name == supplierName.Text) != null)
                {
                    MessageBox.Show("Supplier already present.");
                    this.ActiveControl = supplierName;
                    supplierName.SelectAll();
                }
            }
        }

        private void addSuppBtn_Click(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var newSupplier = new Supplier();
                newSupplier.Name = supplierName.Text.Trim(' ');
                newSupplier.ContactDetails = contactDetails.Text.Trim(' ');
                p.Suppliers.Add(newSupplier);

                supplierTable.Rows.Add(newSupplier.Name, newSupplier.ContactDetails);

                suppliers.Add(newSupplier);
                p.SaveChanges();
            }
            OnSave?.Invoke(this, null);
            supplierName.ResetText();
            contactDetails.ResetText();
        }
    }
}
