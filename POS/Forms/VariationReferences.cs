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
    public partial class VariationReferences : Form
    {
        public VariationReferences(int ProductId)
        {
            int Id;
            InitializeComponent();
            using (var p = new POSEntities())
            {
                var prod = p.Products.FirstOrDefault(x => x.Id == ProductId);
                if (prod == null)
                {
                    MessageBox.Show("Variation not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Id = prod.Id;
                barcode.Text = prod.Item.Barcode;
                itemName.Text = prod.Item.Name;
                supplier.Text = prod.Supplier?.Name;
                cost.Text = prod.Cost.ToString();

                var refInv = p.InventoryItems.Where(x => x.Product.Id == prod.Id);
                foreach (var i in refInv)
                {
                    inventoryTable.Rows.Add(i.Product.Item.Barcode,
                                            i.Product.Item.Name,
                                            i.SerialNumber,
                                            i.Quantity,
                                            string.Format("₱ {0:n}",
                                            i.Product.Item.SellingPrice));
                }

                var sales = p.Sales.Where(x => p.SoldItems.Any(y => y.SaleId == x.Id && y.ProductId == Id));
                foreach (var i in sales)
                {
                    soldTable.Rows.Add(
                        i.Id,
                        i.Date.Value.ToString("MMMM, dd yyyy hh:mm tt"),
                        i.Customer.Name,
                        i.Login.Username,
                        string.Format("₱ {0:n}", i.Total)
                        );
                }

            }

        }

        private void soldTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void soldTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (var details = new SaleDetails())
            {
                details.SetId((int)soldTable.SelectedCells[0].Value);
                details.ShowDialog();
            }

        }
    }
}
