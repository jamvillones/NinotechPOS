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
    public partial class AddProductForm : Form
    {
        bool changesMade = false;
        public event EventHandler Onsave;
        Item target;

        public AddProductForm()
        {
            InitializeComponent();
        }

        public AddProductForm(string barcode)
        {
            InitializeComponent();
            using (var p = new POSEntities())
            {
                target = p.Items.FirstOrDefault(x => x.Barcode == barcode);
            }
            this.Disposed += AddProductForm_Disposed;
        }

        private void AddProductForm_Disposed(object sender, EventArgs e)
        {
            Onsave?.Invoke(this, null);
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            barcode.Text = target.Barcode;
            itemName.Text = target.Name;
            //cost.Value = target.DefaultCost;

            using (var p = new POSEntities())
            {
                supplier.Items.AddRange(p.Suppliers.Where(x => x.Products.FirstOrDefault(y => y.Item.Barcode == target.Barcode) == null).Select(x => x.Name).ToArray());
                foreach (var i in p.Products.Where(x => x.Item.Barcode == target.Barcode))
                {
                    varTable.Rows.Add(i.Supplier.Name, i.Cost);
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(supplier.Text))
            {
                MessageBox.Show("Supplier can never be empty");
                return;
            }

            switch (MessageBox.Show("Are you sure you want to continue?", "", MessageBoxButtons.OKCancel))
            {
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    return;
            }
            using (var p = new POSEntities())
            {
                var newVariation = new Product();
                newVariation.Item = p.Items.FirstOrDefault(x => x.Barcode == target.Barcode);
                newVariation.Supplier = p.Suppliers.FirstOrDefault(x => x.Name == supplier.Text);
                newVariation.Cost = cost.Value;

                p.Products.Add(newVariation);
                p.SaveChanges();
                changesMade = true;

            }
            varTable.Rows.Add(supplier.Text, cost.Value);
            supplier.Items.RemoveAt(supplier.SelectedIndex);
        }

        object TableCurrentValueAt(int index)
        {
            return varTable.Rows[varTable.SelectedCells[0].RowIndex].Cells[index].Value;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var supplier = new SupplierForm();
            supplier.OnSave += Supplier_OnSave;
            supplier.ShowDialog();
        }

        private void Supplier_OnSave(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                supplier.Items.Clear();

                foreach (var x in p.Suppliers.Where(x => x.Products.FirstOrDefault(y => y.Item.Barcode == target.Barcode) == null))
                    supplier.Items.Add(x.Name);
            }
        }

        private void itemsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var s = e.Row.Cells[0].Value.ToString();

            using (var p = new POSEntities())
            {
                Product variation = p.Products.FirstOrDefault(x => x.Item.Barcode == target.Barcode && x.Supplier.Name == s);
                var solditemwiththisproduct = p.SoldItems.FirstOrDefault(x => x.Product.Id == variation.Id);
                var inv = p.InventoryItems.FirstOrDefault(x => x.Product.Id == variation.Id);
                bool condition = solditemwiththisproduct != null || inv != null;
                if (MessageBox.Show("Are you sure you want to remove item variation of this item with supplier " + s + (condition ? "? This will also remove record of sold items with this product or Item in inventory with this kind of Product." : ""),condition? "Not safe to delete":"Safe to delete", MessageBoxButtons.OKCancel, condition ? MessageBoxIcon.Stop : MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                p.Products.Remove(variation);
                p.SaveChanges();

                supplier.Items.Add(s);
                changesMade = true;
            }
        }
    }
}
