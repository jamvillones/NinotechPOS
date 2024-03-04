using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class InventoryTimeStamp_Form : Form {
        public InventoryTimeStamp_Form() {
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
                    .ApplySearch(keyword)
                    .Select(i => new InventoryTimeStamp() {
                        ProductId = i.Id,
                        Name = i.Item.Name + " - " + i.Supplier.Name,
                        Qty = i.StockinHistories.Where(s => s.Date <= DateSelected).Select(s => s.Quantity).DefaultIfEmpty(0).Sum() -
                              i.SoldItems.Where(s => s.Sale.Date <= DateSelected).Select(s => s.Quantity).DefaultIfEmpty(0).Sum(),
                        InventoryQty = i.InventoryItems.Select(s => s.Quantity).DefaultIfEmpty(0).Sum(),
                        Cost = i.Cost
                    })
                    .ToListAsync();

                if (items.Count > 0) {

                    TotalLabel.Text = "Total: " + items.Sum(i => i.TotalCost).ToCurrency();

                    dataGridView.Rows.Clear();
                    foreach (var item in items) {
                        var createdRow = CreateRow(item);

                        if (item.Qty < item.InventoryQty)
                            createdRow.DefaultCellStyle.ForeColor = Color.Maroon;
                        else if (item.Qty > item.InventoryQty)
                            createdRow.DefaultCellStyle.ForeColor = Color.Blue;

                        dataGridView.Rows.Add(createdRow);
                    }

                    return;
                }

                MessageBox.Show("No Entries Found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DataGridViewRow CreateRow(InventoryTimeStamp p) => dataGridView.CreateRow(p.ProductId, p.Name, p.InventoryQty, p.Qty, p.Cost, p.TotalCost);

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            await LoadAsync();
        }
        private class Correction_Inventory_Item {
            public int ProductId { get; set; }
            public int ComputedQty { get; set; }
            public int InventoryQty { get; set; }
        }
        private async Task Balance_Async() {
            using (var context = new POSEntities()) {

                var user = await context.Logins.FirstOrDefaultAsync(x => x.Username == "admin");

                var correctionDate = new DateTime(2019, 1, 1);

                var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Name == "none");

                var correctionSaleInstance = new Sale() {
                    Date = correctionDate,
                    Customer = context.Customers.FirstOrDefault(x => x.Name == "Inventory Correction") ?? new Customer() { Name = "Inventory Correction" },
                    Login = user,
                };

                var selecteds = dataGridView.SelectedRows.Cast<DataGridViewRow>().Select(i => new Correction_Inventory_Item() {
                    ProductId = (int)i.Cells[0].Value,
                    InventoryQty = (int)i.Cells[2].Value,
                    ComputedQty = (int)i.Cells[3].Value,
                }).ToArray();

                foreach (var instance in selecteds) {

                    if (instance.ComputedQty != instance.InventoryQty) {
                        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == instance.ProductId);
                        if (instance.ComputedQty < instance.InventoryQty) {
                            ///add corrective stockin
                            var newStockin = new StockinHistory() {
                                ProductId = instance.ProductId,
                                Cost = product.Cost,
                                Quantity = instance.InventoryQty - instance.ComputedQty,
                                Date = correctionDate,
                                ItemName = product.Item.Name,
                                LoginUsername = user.Username,
                                Supplier = supplier.Name,
                            };

                            context.StockinHistories.Add(newStockin);

                        }
                        else {
                            ///add corrective sell
                            var newSoldItem = new SoldItem() {
                                ProductId = instance.ProductId,
                                ItemPrice = product.Item.SellingPrice,
                                Quantity = instance.ComputedQty - instance.InventoryQty,
                            };
                            correctionSaleInstance.SoldItems.Add(newSoldItem);
                        }
                    }
                }

                context.Sales.Add(correctionSaleInstance);

                await context.SaveChangesAsync();

                MessageBox.Show("Correction Successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void button1_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to balance?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            await Balance_Async();
        }

        string keyword = string.Empty;
        private async void searchControl1_OnSearch(object sender, SearchEventArgs e) {
            keyword = e.Text;
            await LoadAsync();
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadAsync();
        }
    }
}
