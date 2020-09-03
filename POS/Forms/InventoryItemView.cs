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
            Column1.ReadOnly = !currlogin.CanEditInventory;
            removeBtn.Visible = currlogin.CanEditInventory;
        }
        public void SetItemId(string barcode)
        {
            using (var p = new POSEntities())
            {
                var invItem = p.InventoryItems.Where(x => x.Product.Item.Barcode == barcode);

                var item = p.Items.FirstOrDefault(x => x.Barcode == barcode);
                barcodeField.Text = item.Barcode;
                itemName.Text = item.Name;
                sellingPrice.Text = string.Format("₱ {0:n}", item.SellingPrice);

                //var invItem = p.InventoryItems.Where(x => x.Product.Item.Barcode == item.Barcode);
                quantity.Text = invItem.Sum(x => x.Quantity).ToString();
                //int counter = 0;
                foreach (var i in invItem)
                {
                    //counter++;
                    invTable.Rows.Add(i.Id, i.SerialNumber, i.Quantity == 0 ? "Infinite" : i.Quantity.ToString(), i.Product.Supplier.Name,"Stockin Log");
                }
            }
        }

        InventoryItem target;
        private void invTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!UserManager.instance.currentLogin.CanEditProduct)
            {
                e.Cancel = true;
                return;
            }
            var dgt = sender as DataGridView;
            int quantity = 0;
            int id = (int)(dgt.Rows[e.RowIndex].Cells[0].Value);

            if (int.TryParse(dgt.Rows[e.RowIndex].Cells[2].Value.ToString(), out quantity))
            {
                ///if serial
                var serial = dgt.Rows[e.RowIndex].Cells[1].Value?.ToString();
                /////items without serial
                bool con1 = e.ColumnIndex == 1 && quantity == 1;
                bool con2 = e.ColumnIndex == 2 && serial == null;
                //bool con3 = e.ColumnIndex == 1 && string.IsNullOrEmpty(serial) && quantity == 1;
                //if (serial == null && quantity != 1)
                //{
                if (con1 || con2)
                {
                    using (var p = new POSEntities())
                    {
                        target = p.InventoryItems.FirstOrDefault(x => x.Id == id);
                    }
                }
                else
                {
                    MessageBox.Show(!con1 ? "Changing quantity of item with serial number is not allowed." : "Serial cannot be set if item quantity is more than one.", "Edit prohibited", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Item with infinite quantity cannot be edited");
                e.Cancel = true;
            }

        }

        private void invTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgt = sender as DataGridView;
            if (e.ColumnIndex == 1)
            {
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
                        var t = p.InventoryItems.FirstOrDefault(x => x.Id == target.Id);
                        string s = string.IsNullOrEmpty(dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()) ? null : dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                        t.SerialNumber = s;
                        p.SaveChanges();
                        OnSave?.Invoke(this, null);
                        MessageBox.Show("Serial successfully updated");
                    }
                }
            }
            else if (e.ColumnIndex == 2)
            {

                int newQuantity = 0;
                if (int.TryParse(dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out newQuantity))
                {
                    if (newQuantity == target.Quantity)
                    {
                        return;
                    }
                    else
                    {
                        using (var p = new POSEntities())
                        {
                            if (MessageBox.Show("Are you sure you want to save new Quantity?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target.Quantity;
                            }
                            else
                            {
                                var t = p.InventoryItems.FirstOrDefault(x => x.Id == target.Id);
                                t.Quantity = newQuantity;
                                p.SaveChanges();
                                OnSave?.Invoke(this, null);
                                MessageBox.Show("Quantity successfully updated");
                            }
                        }
                    }
                }
                else
                {
                    dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target.Quantity;
                    MessageBox.Show("Invalid Input.");
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
            if (RemoveInventoryItem() == false)
                e.Cancel = true;
        }

        private void invTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4) return;
            var table = sender as DataGridView;
            using (InventoryStockinLog log = new InventoryStockinLog((int)(table.Rows[e.RowIndex].Cells[0].Value)))
            {
                log.ShowDialog();
            }
        }
    }
}
