using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class ItemSoldItemsForm : Form {
        public ItemSoldItemsForm(string id) {
            InitializeComponent();
            _id = id;
        }

        readonly string _id;

        private async void ItemSoldItemsForm_Load(object sender, EventArgs e) {
            try {
                using (var context = POSEntities.Create()) {
                    var sales = await context.Sales.AsNoTracking().AsQueryable()
                        .Where(x => x.SoldItems.Any(so => so.SaleId == x.Id && so.Product.ItemId == _id))
                        .OrderByDescending(o => o.Date)
                        .ToListAsync();

                    var rows = sales.Select(CreateRow).ToArray();

                    soldTable.Rows.AddRange(rows);

                    this.Text += " - " + soldTable.Rows.Cast<DataGridViewRow>().Select(row => (int)row.Cells[col_Qty.Index].Value).Sum().ToString("N0") + " units";
                }
            }
            catch (Exception) {

            }
        }

        DataGridViewRow CreateRow(Sale sale) => soldTable.CreateRow(
            sale.Id,
            sale.Date,
            sale.Login,
            sale.Customer,
            sale.SoldItems.Where(s => s.Product.ItemId == _id).Sum(item => item.Quantity));

        private void soldTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == -1) return;

            using (var details = new SaleDetails((int)soldTable.SelectedCells[col_Id.Index].Value)) {
                details.ShowDialog();
            }
        }
    }
}
