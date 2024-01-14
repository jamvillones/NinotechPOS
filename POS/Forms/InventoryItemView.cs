using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class InventoryItemView : Form
    {
        public InventoryItemView(string barcode)
        {
            InitializeComponent();
            _barcode = barcode;
        }
        string _barcode;

        DataGridViewRow CreateRow(InventoryItem item) => invTable.CreateRow(
            item.Id,
            item.SerialNumber,
            item.Quantity,
            item.Product.Supplier.Name
            );

        private async void InventoryItemView_Load(object sender, EventArgs e)
        {
            using (var context = new POSEntities())
            {
                var item = await context.Items.FirstOrDefaultAsync(x => x.Barcode == _barcode);

                var invItems = await context.InventoryItems.AsNoTracking().AsQueryable().Where(x => x.Product.Item.Barcode == _barcode).ToListAsync();
                this.Text = this.Text + " - " + item.Name + " (" + invItems.Select(i => i.Quantity).DefaultIfEmpty(0).Sum().ToString("N0") + ")";
                await Task.Run(() =>
                {
                    foreach (var inv in invItems)
                        invTable.InvokeIfRequired(() => invTable.Rows.Add(CreateRow(inv)));
                });
            }
        }

        private void invTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
