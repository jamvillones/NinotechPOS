using POS.Forms.ItemRegistration;
using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
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

        async Task LoadData_Async()
        {
            if (invTable.RowCount > 0)
                invTable.Rows.Clear();

            using (var context = POSEntities.Create())
            {
                var inventoryItems = await context.InventoryItems.AsNoTracking().AsQueryable()
                    .Where(x => x.Product.Item.Id == _id && !x.IsDefective)
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
                        .FirstOrDefault(row => row.Cells[Column1.Index].Value?.ToString().Equals(_serial.Trim(), StringComparison.OrdinalIgnoreCase) ?? false).Index;

                    invTable.Rows[index].Selected = true;
                }

                this.Text = $"{this.Text} - {inventoryItems.First().Product.Item.Name} [{inventoryItems.Select(i => i.Quantity).DefaultIfEmpty(0).Sum():N0} Unit/s]";
            }
        }

        private async void ViewItemDetails_Click(object sender, EventArgs e)
        {
            using (var editForm = new CreateEdit_Item_Form())
            {
                await editForm.InitializeData(_id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var x = editForm.Tag as Item;
                }
            }
        }

        private void inventoryTable_SelectionChanged(object sender, EventArgs e)
        {
            label1.Text = $"Selected Items: {invTable.SelectedRows.Count:N0}";
        }

        private void invTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == markAsDefectiveCol.Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var image = Properties.Resources.undo_15px;
                var w = image.Width;
                var h = image.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private async void invTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (e.ColumnIndex == markAsDefectiveCol.Index)
            {

                var operationSuccess = await MarkAsDefective((int)invTable.SelectedCells[0].Value);

                if (operationSuccess)
                    await LoadData_Async();
            }
        }

        private async Task<bool> MarkAsDefective(int value)
        {
            if (MessageBox.Show("Mark Item as Defective?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;

            var reasonForm = new ReasonForReturnForm();

            if (reasonForm.ShowDialog() != DialogResult.OK)
                return false;

            var reason = reasonForm.Tag as string;

            try
            {
                using (var context = POSEntities.Create())
                {
                    ///ensures the login privilege is up to date
                    var currentLogin = await context.Logins.FirstOrDefaultAsync(x => x.Id == UserManager.instance.CurrentLogin.Id);

                    if (!currentLogin.CanMarkAsDefective)
                    {
                        MessageBox.Show("Current User has no ADMINISTRATIVE authority to perform this action!", "Operation Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }

                    var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.Id == value);
                    context.AdditionalDetails = "SN:" + invItem.SerialNumber + "=>" + reason;
                    invItem.IsDefective = true;

                    await context.SaveChangesAsync();
                    context.AdditionalDetails = null;

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
