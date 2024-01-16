using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class UserPrivilegesForm : Form {
        public UserPrivilegesForm() {
            InitializeComponent();
        }

        private async void UserPrivilegesForm_Load(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        string keyword = string.Empty;
        async Task<bool> LoadDataAsync() {
            bool resultsNotEmpty = false;
            try {
                using (var context = new POSEntities()) {
                    var logins = context.Logins
                        .AsNoTracking()
                        .AsQueryable()
                        .Where(x => x.Username != "admin");

                    logins = string.IsNullOrWhiteSpace(keyword) ?
                        logins :
                        logins.Where(l => l.Username == keyword || l.Name.Contains(keyword));

                    var result = await logins.OrderBy(o => o.Username).ToListAsync();
                    resultsNotEmpty = result.Count > 0;

                    if (resultsNotEmpty) {
                        userTable.Rows.Clear();

                        await Task.Run(() => {
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
            login.CanEditInventory,
            login.CanEditSupplier,
            login.CanStockIn,
            login.CanVoidSale
            );

        private async void userTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            var table = sender as DataGridView;
            var id = (int)table.SelectedCells[0].Value;

            if (e.ColumnIndex == Column3.Index) {
                if (MessageBox.Show(
                    "Are you sure you want to remove this User",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;

                try {

                    using (var context = new POSEntities()) {
                        var u = await context.Logins.FirstOrDefaultAsync(x => x.Id == id);
                        context.Logins.Remove(u);
                        context.SaveChanges();

                        table.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch {
                    MessageBox.Show("This user has already made transaction and cannot be deleted.", "Delete Aborted", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                return;
            }

            ///ensures that the editting is being done on checkbox only
            if (!(table.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)) return;

            var check = !(bool)table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            using (var context = new POSEntities()) {
                var user = await context.Logins.FirstOrDefaultAsync(x => x.Id == id);
                switch (e.ColumnIndex) {
                    case 3:
                        user.CanEditItem = check;
                        break;
                    case 4:
                        user.CanEditProduct = check;
                        break;
                    case 5:
                        user.CanEditInventory = check;
                        break;
                    case 6:
                        user.CanEditSupplier = check;
                        break;
                    case 7:
                        user.CanStockIn = check;
                        break;
                    case 8:
                        user.CanVoidSale = check;
                        break;
                }
                await context.SaveChangesAsync();
            }
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e) {
            //e.SearchFound = true;
            keyword = e.Text;
            e.SearchFound = await LoadDataAsync();
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        //private void searchText_KeyDown(object sender, KeyEventArgs e) {
        //    if (e.KeyCode == Keys.Enter) {
        //        if (searchText.Text == string.Empty)
        //            return;
        //        ///process search here
        //        using (var p = new POSEntities()) {
        //            var logins = p.Logins.Where(x => x.Username.Contains(searchText.Text) && x.Username != "admin");
        //            fillTable(logins);
        //        }
        //    }
        //}

        //private void searchText_TextChanged(object sender, EventArgs e) {
        //    if (searchText.Text == string.Empty) {
        //        using (var p = new POSEntities()) {
        //            var logins = p.Logins.Where(x => x.Username != "admin");
        //            fillTable(logins);
        //        }
        //    }
        //}
    }
}
