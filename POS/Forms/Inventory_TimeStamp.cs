using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class Inventory_TimeStamp : Form {
        public Inventory_TimeStamp() {
            InitializeComponent();
        }

        private class InventoryTimeStamp {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int Qty { get; set; }
            public int InventoryQty { get; set; }
            public decimal Cost { get; set; } = 0;
            public decimal TotalCost => Qty * Cost;
        }

        DateTime DateSelected => dateTimePicker1.Value.Date.AddHours(23).AddMinutes(59);


        private async void Inventory_TimeStamp_Load(object sender, EventArgs e) {
            await LoadAsync();
        }
        private async Task LoadAsync() {
            using (var context = new POSEntities()) {
                var items = await context.Products
                    .AsNoTracking()
                    .AsQueryable()
                    .Where(i => i.Item.Type == ItemType.Quantifiable.ToString())
                    .Select(i => new InventoryTimeStamp() {
                        ProductId = i.Id,
                        Name = i.Item.Name + " - " + i.Supplier.Name,
                        Qty = i.StockinHistories.Where(s => s.Date <= DateSelected).Select(s => s.Quantity).DefaultIfEmpty(0).Sum() -
                              i.SoldItems.Where(s => s.Sale.Date <= DateSelected).Select(s => s.Quantity).DefaultIfEmpty(0).Sum(),
                        InventoryQty = i.InventoryItems.Select(s => s.Quantity).DefaultIfEmpty(0).Sum(),
                        Cost = i.Cost
                    })
                    .ToListAsync();

                TotalLabel.Text = items.Sum(i => i.TotalCost).ToCurrency();
                dataGridView1.Rows.Clear();
                foreach (var item in items)
                    dataGridView1.Rows.Add(
                        item.ProductId,
                        item.Name,
                        item.Qty,
                        item.InventoryQty,
                        item.Cost,
                        item.TotalCost
                        );
            }
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            await LoadAsync();
        }
    }
}
