using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class UserPrivilegesForm : Form
    {
        public UserPrivilegesForm()
        {
            InitializeComponent();
        }

        private async void UserPrivilegesForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        string keyword = string.Empty;
        async Task<bool> LoadDataAsync()
        {
            bool resultsNotEmpty = false;
            try
            {
                using (var context = new POSEntities())
                {
                    var logins = context.Logins
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(x => x.Username != "admin");

                    logins = string.IsNullOrWhiteSpace(keyword) ?
                        logins :
                        logins.Where(l => l.Username == keyword || l.Name.Contains(keyword));

                    var result = await logins.OrderBy(o => o.Username).ToListAsync();
                    resultsNotEmpty = result.Count > 0;

                    if (resultsNotEmpty)
                    {
                        userTable.Rows.Clear();

                        await Task.Run(() =>
                        {
                            var rows = result.Select(CreateRow).ToArray();
                            userTable.InvokeIfRequired(() => userTable.Rows.AddRange(rows));
                        });
                    }
                }
            }
            catch { }
            return resultsNotEmpty;
        }

        DataGridViewRow CreateRow(Login login) => userTable.CreateRow(
            login.Id,
            login.Username,
            login.Name,
            login.CanEditItem,
            login.CanEditProduct,
            login.CanEditSupplier,
            login.CanStockIn,
            login.CanEditInventory,
            login.CanVoidSale
            );

        private async void userTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var table = sender as DataGridView;
            var id = (int)table.SelectedCells[col_Id.Index].Value;

            if (e.ColumnIndex == col_RemoveBtn.Index)
            {
                if (MessageBox.Show(
                    "Are you sure you want to remove this login?",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                try
                {
                    using (var context = new POSEntities())
                    {
                        var loginToRemove = await context.Logins.FirstOrDefaultAsync(x => x.Id == id);
                        context.Logins.Remove(loginToRemove);
                        await context.SaveChangesAsync();

                        table.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch
                {
                    MessageBox.Show("This user has already made transaction/s and cannot be deleted.", "Delete Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return;
            }

            ///ensures that the editing is being done on checkbox only
            if (!(table.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)) return;

            var check = !(bool)table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            using (var context = new POSEntities())
            {
                var user = await context.Logins.FirstOrDefaultAsync(x => x.Id == id);

                if (e.ColumnIndex == col_ItemEdit.Index) user.CanEditItem = check;
                else if (e.ColumnIndex == col_CostEdit.Index) user.CanEditProduct = check;
                else if (e.ColumnIndex == col_SuppEdit.Index) user.CanEditSupplier = check;
                else if (e.ColumnIndex == col_StockIn.Index) user.CanStockIn = check;
                else if (e.ColumnIndex == col_UndoStockIn.Index) user.CanEditInventory = check;
                else if (e.ColumnIndex == col_Void.Index) user.CanVoidSale = check;

                await context.SaveChangesAsync();
            }
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            keyword = e.Text;
            e.SearchFound = await LoadDataAsync();
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await LoadDataAsync();
        }
    }
}
