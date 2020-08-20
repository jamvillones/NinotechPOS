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
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {

                foreach (var x in p.Items.Where(x => x.Type == Misc.ItemType.Hardware.ToString()))
                    itemsTable.Rows.Add(x.Barcode, x.Name);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(supplier.Text))
            {
                MessageBox.Show("Supplier can never be empty");
                return;
            }
            using (var p = new POSEntities())
            {
                var newProduct = new Product();
                newProduct.ItemId = barcode.Text;
                var s = p.Suppliers.FirstOrDefault(x => x.Name == supplier.Text);
                newProduct.Supplier = s;
                newProduct.Cost = cost.Value;

                p.Products.Add(newProduct);
                p.SaveChanges();
                MessageBox.Show("Product added");
                this.Close();
            }
        }

        object TableCurrentValueAt(int index)
        {
            return itemsTable.Rows[itemsTable.SelectedCells[0].RowIndex].Cells[index].Value;

        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            var id = TableCurrentValueAt(0).ToString();

            using (var p = new POSEntities())
            {
                selectedItem = p.Items.FirstOrDefault(x => x.Barcode == id);
                barcode.Text = selectedItem.Barcode;
                itemName.Text = selectedItem.Name;

                supplier.Items.Clear();

                foreach (var x in p.Suppliers.Where(x => x.Products.FirstOrDefault(y => y.ItemId == id) == null))
                    supplier.Items.Add(x.Name);
            }
        }

        Item selectedItem;

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            for (int i = 0; i < itemsTable.RowCount; i++)
            {
                if (barcode.Text == itemsTable.Rows[i].Cells[0].Value.ToString())
                {
                    itemsTable.Rows[i].Selected = true;
                    break;
                }
            }
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

                foreach (var x in p.Suppliers.Where(x => x.Products.FirstOrDefault(y => y.ItemId == selectedItem.Barcode) == null))
                    supplier.Items.Add(x.Name);
            }
        }
    }
}
