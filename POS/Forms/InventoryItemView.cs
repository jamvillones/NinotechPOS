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
        public InventoryItemView()
        {
            InitializeComponent();
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
                    invTable.Rows.Add(counter, i.SerialNumber ?? "NONE", i.Quantity, i.Product.Supplier.Name);
                }
            }
        }

        private void invTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        InventoryItem target;
        private void invTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                return;
            }
            var dgt = sender as DataGridView;
            var serial = dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (serial == "NONE")
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

            using (var p = new POSEntities())
            {
                if (MessageBox.Show("", "Are you sure you want to save new Serial?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = target.SerialNumber;
                }
                else
                {
                    var t = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == target.SerialNumber);
                    t.SerialNumber = dgt.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    p.SaveChanges();
                    MessageBox.Show("Serial successfully updated");
                }
            }
           
        }
    }
}
