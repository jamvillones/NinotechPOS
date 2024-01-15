using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class InventoryItemView : Form {
        public InventoryItemView(string id, string serial = "") {
            InitializeComponent();
            _id = id;
            _serial = serial;
        }
        string _id;
        string _serial = string.Empty;

        DataGridViewRow CreateRow(InventoryItem item) => invTable.CreateRow(
            item.Id,
            item.SerialNumber,
            item.Quantity,
            item.Product.Supplier.Name
            );

        private async void InventoryItemView_Load(object sender, EventArgs e) {
            using (var context = new POSEntities()) {
                var item = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);

                var invItems = await context.InventoryItems.AsNoTracking().AsQueryable().Where(x => x.Product.Item.Id == _id).ToListAsync();
                this.Text = this.Text + " - " + item.Name + " ( " + invItems.Select(i => i.Quantity).DefaultIfEmpty(0).Sum().ToString("N0") + "units )";
                await Task.Run(() => {
                    foreach (var inv in invItems)
                        invTable.InvokeIfRequired(() => invTable.Rows.Add(CreateRow(inv)));
                });
            }

            if (!string.IsNullOrWhiteSpace(_serial)) {
                var index = invTable.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(row => row.Cells[Column1.Index].Value?.ToString().Equals(_serial.Trim(), StringComparison.OrdinalIgnoreCase) ?? false).Index;

                invTable.Rows[index].Selected = true;
            }
        }

        private void invTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {

        }
    }
}
