using POS.Misc;
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
    public partial class ItemVariationsForm : Form
    {
        public event EventHandler Onsave;

        Item target;

        public ItemVariationsForm()
        {
            InitializeComponent();
        }

        public ItemVariationsForm(string barcode)
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
            refBtn.Enabled = UserManager.instance.currentLogin.CanEditProduct;

            using (var p = new POSEntities())
            {
                supplier.Items.AddRange(p.Suppliers.Where(x => x.Products.FirstOrDefault(y => y.Item.Barcode == target.Barcode) == null).Select(x => x.Name).ToArray());
                foreach (var i in p.Products.Where(x => x.Item.Barcode == target.Barcode))
                {
                    varTable.Rows.Add(i.Id, i.Supplier?.Name, i.Cost, "Delete");
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
                //changesMade = true;

                varTable.Rows.Add(newVariation.Id, newVariation.Supplier.Name, cost.Value, "Delete");
            }
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

        Login currLogin
        {
            get
            {
                return UserManager.instance.currentLogin;
            }
        }

        //private void itemsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        //{
        //    if (!currLogin.CanDeleteProduct)
        //    {
        //        e.Cancel = true;
        //        return;
        //    }
        //    var s = e.Row.Cells[0].Value.ToString();

        //    using (var p = new POSEntities())
        //    {
        //        Product variation = p.Products.FirstOrDefault(x => x.Item.Barcode == target.Barcode && x.Supplier.Name == s);
        //        var solditemwiththisproduct = p.SoldItems.FirstOrDefault(x => x.Product.Id == variation.Id);
        //        var inv = p.InventoryItems.FirstOrDefault(x => x.Product.Id == variation.Id);
        //        bool condition = solditemwiththisproduct != null || inv != null;
        //        if (MessageBox.Show("Are you sure you want to remove item variation of this item with supplier " + s + (condition ? "? This will also remove record of sold items with this product or Item in inventory with this kind of Product." : ""), condition ? "Not safe to delete" : "Safe to delete", MessageBoxButtons.OKCancel, condition ? MessageBoxIcon.Stop : MessageBoxIcon.Asterisk) == DialogResult.Cancel)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }

        //        p.Products.Remove(variation);
        //        p.SaveChanges();

        //        supplier.Items.Add(s);
        //        changesMade = true;
        //    }
        //}

        private void varTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex != 3)
                return;

            var t = sender as DataGridView;
            if (!currLogin.CanEditProduct)
            {
                MessageBox.Show("You do not have administrative privileges to perform this action.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var s = t.SelectedCells[1].Value.ToString();
            var c = t.SelectedCells[2].Value;

            using (var p = new POSEntities())
            {
                Product variation = p.Products.FirstOrDefault(x => x.Item.Barcode == target.Barcode && x.Supplier.Name == s && x.Cost == (decimal)c);

                var solditemwiththisproduct = p.SoldItems.Where(x => x.Product.Id == variation.Id);
                var inv = p.InventoryItems.Where(x => x.Product.Id == variation.Id);
                bool condition = solditemwiththisproduct.Count() != 0 || inv.Count() != 0;
                DialogResult dialog = MessageBox.Show("Are you sure you want to remove item variation of this item with supplier " + s + (condition ? "?\n\nThis will also remove record of sold items with this product or Item in inventory with this kind of Product.\n\n(Click show references to see dependencies)" : ""),
                                                 condition ? "Not safe to delete" : "Safe to delete",
                                                 MessageBoxButtons.YesNo,
                                                 condition ? MessageBoxIcon.Stop : MessageBoxIcon.Asterisk);
                if (dialog == DialogResult.Yes)
                {
                    //bool godelete = true;
                    /////prompt user to provide substitute to product

                    //using (var subs = new SubstituteProduct(variation.Id))
                    //{
                    //    //subs.OnChoose += Subs_OnChoose;
                    //    subs.OnChoose += (a, b) =>
                    //    {
                    //        if (b == null)
                    //        {
                    //            godelete = false;
                    //            return;
                    //        }
                    //        foreach (var i in solditemwiththisproduct)
                    //        {
                    //            i.ProductId = b.Id;
                    //        }
                    //        foreach (var i in inv)
                    //        {
                    //            i.ProductId = b.Id;
                    //        }
                    //    };
                    //    subs.ShowDialog();
                    //}
                    //if (!godelete)
                    //    return;
                }
                else if (dialog == DialogResult.No)
                {
                    return;
                }

                p.Products.Remove(variation);
                p.SaveChanges();

                supplier.Items.Add(s);
                //changesMade = true;
            }
            t.Rows.RemoveAt(e.RowIndex);
        }

        //private void Subs_OnChoose(object sender, Product e)
        //{
        //    using (var p = new POSEntities())
        //    {
        //        foreach (var i in solditemwiththisproduct)
        //        {
        //            i.ProductId = b.Id;
        //        }
        //        foreach (var i in inv)
        //        {
        //            i.ProductId = b.Id;
        //        }
        //    }
        //}

        decimal currentCost;
        private void varTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!currLogin.CanEditProduct)
            {
                e.Cancel = true;
                return;
            }
            var t = sender as DataGridView;
            currentCost = (decimal)(t.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void varTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal n;
            var t = sender as DataGridView;
            // var supplier = t.Rows[e.RowIndex].Cells[0].Value.ToString();
            var id = (int)(t.Rows[e.RowIndex].Cells[0].Value);
            bool isNumeric = decimal.TryParse(t.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out n);
            if (isNumeric)
            {
                using (var p = new POSEntities())
                {
                    var prod = p.Products.FirstOrDefault(x => x.Id == id);
                    prod.Cost = n;
                    p.SaveChanges();
                    MessageBox.Show("Edit successful.");
                }
            }
            else
            {
                t.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCost;
            }
        }

        private void refBtn_Click(object sender, EventArgs e)
        {
            if (varTable.RowCount == 0)
                return;

            using (var variationRef = new VariationReferences((int)(varTable.SelectedCells[0].Value)))
            {
                variationRef.ShowDialog();
            }
        }
    }
}
