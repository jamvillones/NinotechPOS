using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class InventoryItemView : Form
    {
        public InventoryItemView(string id, string serial = "")
        {
            InitializeComponent();

            _id = id;
            _serial = serial;

            bool isAdmin = UserManager.instance.CurrentLogin.Username.Equals("admin", StringComparison.OrdinalIgnoreCase);
            invTable.AllowUserToDeleteRows = isAdmin;
            col_qty.ReadOnly = !isAdmin;
        }

        readonly string _id;
        readonly string _serial = string.Empty;

        DataGridViewRow CreateRow(InventoryItem item, bool isFirstEntry) => invTable.CreateRow(
            item.Id,
            isFirstEntry ? item.Product.Supplier?.Name : null,
            item.SerialNumber,
            item.Quantity > 1 ? (int?)item.Quantity : null
            );

        private async void InventoryItemView_Load(object sender, EventArgs e) => await LoadData_Async();

        async Task LoadData_Async(string selectedSerialNumber = "")
        {
            using (var context = POSEntities.Create())
            {
                var inventoryItems = await context.InventoryItems.AsNoTracking().AsQueryable()
                    .Where(x => x.Product.Item.Id == _id)
                    .ToListAsync();

                var itemGroupings = inventoryItems.GroupBy(x => x.Product.Supplier?.Name);

                foreach (var group in itemGroupings)
                {
                    bool isFirstEntry = true;
                    var toAdd = inventoryItems.Where(x => x.Product.Supplier.Name.Equals(group.Key));
                    foreach (var t in toAdd)
                    {
                        invTable.Rows.Add(CreateRow(t, isFirstEntry));
                        isFirstEntry = false;
                    }
                }

                if (!string.IsNullOrWhiteSpace(_serial))
                {
                    invTable.ClearSelection();
                    invTable.CurrentCell = null;

                    var index = invTable.Rows.Cast<DataGridViewRow>()
                        .FirstOrDefault(row => row.Cells[Column1.Index].Value?.ToString().Equals(selectedSerialNumber.Trim(), StringComparison.OrdinalIgnoreCase) ?? false).Index;

                    invTable.Rows[index].Selected = true;
                }

                this.Text = $"{this.Text} - {inventoryItems.First().Product.Item.Name} [{inventoryItems.Select(i => i.Quantity).DefaultIfEmpty(0).Sum().ToString("N0")} Unit/s]";
            }
        }

        private void ViewItemDetails_Click(object sender, EventArgs e)
        {
            using (var editForm = new CreateEdit_Item_Form(_id))
            {

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var x = editForm.Tag as Item;
                }
            }
        }

        private void inventoryTable_SelectionChanged(object sender, EventArgs e)
        {
            label1.Text = $"Selected Items: {invTable.SelectedRows.Count.ToString("N0")}";
        }
    }
}
