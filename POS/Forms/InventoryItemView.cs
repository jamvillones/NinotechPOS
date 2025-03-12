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
        string _id;
        string _serial = string.Empty;

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

                var invItems = await context.InventoryItems.AsNoTracking().AsQueryable().Where(x => x.Product.Item.Id == _id).ToListAsync();
                var item = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);
                this.Text = this.Text + " - " + item.Name + " ( " + invItems.Select(i => i.Quantity).DefaultIfEmpty(0).Sum().ToString("N0") + " units )";
                await Task.Run(() =>
                {
                    foreach (var inv in invItems)
                        invTable.InvokeIfRequired(() => invTable.Rows.Add(CreateRow(inv)));
                });
            }

            if (!string.IsNullOrWhiteSpace(_serial))
            {
                var index = invTable.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(row => row.Cells[Column1.Index].Value?.ToString().Equals(_serial.Trim(), StringComparison.OrdinalIgnoreCase) ?? false).Index;

                invTable.Rows[index].Selected = true;
            }
        }

        private void invTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private async void invTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this entry?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            var id = (int)e.Row.Cells[0].Value;
            try
            {

                using (var context = new POSEntities())
                {
                    var inventoryItemToDelete = await context.InventoryItems.FirstOrDefaultAsync(x => x.Id == id);

                    context.InventoryItems.Remove(inventoryItemToDelete);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void invTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        //int SelectedInventoryItemId => invTable.RowCount == 0 ? 0 : (int)(invTable[0, invTable.SelectedCells[0].ColumnIndex].Value);
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
    }
}
