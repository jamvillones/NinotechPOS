using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Misc;

namespace POS.Forms
{
    public partial class ViewItem : Form
    {
        Item item;

        Color hardwareColor = Color.Blue;
        Color softwareColor = Color.Red;
        Color serviceColor = Color.DarkGreen;

        public void SetItemId(string Id)
        {
            using (var p = new POSEntities())
            {
                item = p.Items.FirstOrDefault(x => x.Barcode == Id);
                barcode.Text = item.Barcode;
                itemName.Text = item.Name;
                sellingPrice.Text = string.Format("₱ {0:n}", item.SellingPrice);
                itemType.Text = item.Type;
                setTypeColor(item.Type.Trim());
                department.Text = item.Department;
                details.Text = item.Details;

                ImageBox.Image = Misc.ImageDatabaseConverter.byteArrayToImage(item.SampleImage);
                var stock = p.InventoryItems.Where(x => x.Product.Item.Barcode == item.Barcode);
                foreach (var i in stock)
                {
                    stockTable.Rows.Add(i.SerialNumber, i.Quantity, i.Product.Supplier?.Name);
                }
                groupBox9.Text = groupBox9.Text +" - " + stock.Select(x => x.Quantity).DefaultIfEmpty(0).Sum().ToString();

                var variations = p.Products.Where(x => x.ItemId == item.Barcode);
                variationsTable.Rows.Clear();
                foreach (var x in variations)
                    variationsTable.Rows.Add(x.Supplier?.Name, x.Cost);

                variationsTable.Columns[1].ReadOnly = UserManager.instance?.currentLogin.CanEditProduct ?? false ? false : true;
            }
        }

        public ViewItem()
        {
            InitializeComponent();
        }
        void setTypeColor(string t)
        {
            switch (t) {
                case "Hardware":
                    itemType.ForeColor = hardwareColor;
                    break;
                case "Service":
                    itemType.ForeColor = serviceColor;
                    break;
                case "Software":
                    itemType.ForeColor = softwareColor;
                    break;
            }

        }
        //private void variationsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void variationsTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgt = (DataGridView)sender;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (dgt.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
