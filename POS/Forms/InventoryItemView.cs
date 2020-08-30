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
    public partial class InventoryItemView : Form
    {
        Login currlogin;
        public event EventHandler OnSave;
        public InventoryItemView()
        {
            InitializeComponent();
            currlogin = UserManager.instance.currentLogin;
            Column1.ReadOnly = !(currlogin.CanEditInventory);
        }
        public void SetItemId(string barcode)
        {
            using (var p = new POSEntities())
            {
                var item = p.Items.FirstOrDefault(x => x.Barcode == barcode);
                if (item == null)
                {
                    MessageBox.Show("Not found.");
                    return;
                }
                barcodeField.Text = item.Barcode;
                itemName.Text = item.Name;
                sellingPrice.Text = string.Format("₱ {0:n}", item.SellingPrice);

                var invItem = p.InventoryItems.Where(x => x.Product.Item.Barcode == item.Barcode);
                quantity.Text = invItem.Sum(x => x.Quantity).ToString();
                int counter = 0;
                foreach (var i in invItem)
                {
                    counter++;
                    invTable.Rows.Add(counter, i.SerialNumber, i.Quantity, i.Product.Supplier.Name);
                }
            }
        }

        //private void invTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //e.Control.TextChanged -= Control_TextChanged;
        //}

        //////private void Control_TextChanged(object sender, EventArgs e)
        //////{
        //////   // throw new NotImplementedException();
        //////}

        InventoryItem target;
        private void invTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!UserManager.instance.currentLogin.CanEditProduct)
            {
                e.Cancel = true;
                return;
            }
            if (e.ColumnIndex != 1)
            {
                return;
            }
            var dgt = sender as DataGridView;
            var serial = dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            var quantity = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells[2].Value.ToString());
            if (string.IsNullOrEmpty(serial) && quantity > 1)
            {
                MessageBox.Show("Thes serial cannot be edited");
                e.Cancel = true;
                return;
            }

            using (var p = new POSEntities())
            {
                target = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == serial);

            }
        }

        private void invTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgt = sender as DataGridView;
            if (dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() == target.SerialNumber)
            {
                return;
            }
            using (var p = new POSEntities())
            {
                if (MessageBox.Show("Are you sure you want to save new Serial?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target.SerialNumber;
                }
                else
                {
                    var t = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == target.SerialNumber);
                    t.SerialNumber = dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    p.SaveChanges();
                    OnSave?.Invoke(this, null);
                    MessageBox.Show("Serial successfully updated");
                }
            }

        }
        bool RemoveInventoryItem()
        {
            if (invTable.RowCount == 0 || !currlogin.CanEditInventory) return false;
            if (MessageBox.Show("Are you sure you want to remove this from inventory? This action cannot be undone.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                var cells = invTable.Rows[invTable.SelectedCells[0].RowIndex].Cells;
                string b = barcodeField.Text;
                string s = cells[3].Value.ToString();
                using (var p = new POSEntities())
                {

                    var i = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Barcode == b && x.Product.Supplier.Name == s);
                    p.InventoryItems.Remove(i);

                    p.SaveChanges();

                }
                OnSave.Invoke(this, null);
                MessageBox.Show("Successfully removed from inventory");
                return true;
            }
            return false;
        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (RemoveInventoryItem())
                invTable.Rows.RemoveAt(invTable.SelectedCells[0].RowIndex);
        }

        private void invTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (RemoveInventoryItem() == false )
                e.Cancel = true;
        }
    }
}
