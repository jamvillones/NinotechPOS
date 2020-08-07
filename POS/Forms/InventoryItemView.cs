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
    }
}
