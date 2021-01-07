using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void UserPrivilegesForm_Load(object sender, EventArgs e)
        {
            using (var ent = new POSEntities())
            {
                searchText.AutoCompleteCustomSource.AddRange(ent.Logins.Where(x => x.Username != "admin").Select(y => y.Username).ToArray());

                fillTable(ent.Logins.Where(x => x.Username != "admin"));
            }
        }
        void fillTable(IQueryable<Login> logins)
        {
            userTable.Rows.Clear();
            foreach (var i in logins)
            {
                userTable.Rows.Add(i.Id,
                                   i.Username,
                                   i.CanEditItem,
                                   i.CanEditProduct,
                                   i.CanEditInventory,
                                   i.CanEditSupplier,
                                   i.CanStockIn,
                                   i.CanVoidSale,
                                   "Remove");
            }
        }
        private void userTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var table = sender as DataGridView;
            var id = (int)table.SelectedCells[0].Value;
            if ((table.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell))
            {
                if(MessageBox.Show("Are you sure you want to remove this User","", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)== DialogResult.Cancel)
                {
                    return;
                }

                using (var t = new POSEntities())
                {
                    var u = t.Logins.FirstOrDefault(x => x.Id == id);
                    t.Logins.Remove(u);
                    t.SaveChanges();

                    table.Rows.RemoveAt(e.RowIndex);
                }
                return;
            }

            if (!(table.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell))
            {
                return;
            }

            var check = !(bool)table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            using (var ent = new POSEntities())
            {
                var user = ent.Logins.FirstOrDefault(x => x.Id == id);

                switch (e.ColumnIndex)
                {
                    case 2:
                        //user.ItemPrevileges = check;
                        user.CanEditItem = check;
                        break;

                    case 3:
                        //user.TransactionPrevileges = check;
                        user.CanEditProduct = check;
                        break;

                    case 4:
                        //user.LoginPrevileges = check;
                        user.CanEditInventory = check;
                        break;
                    case 5:
                        user.CanEditSupplier = check;
                        break;
                    case 6:
                        user.CanStockIn = check;
                        break;
                    case 7:
                        user.CanVoidSale = check;
                        break;
                }
                ent.SaveChanges();
            }
        }

        private void searchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (searchText.Text == string.Empty)
                    return;
                ///process search here
                using (var p = new POSEntities())
                {
                    var logins = p.Logins.Where(x => x.Username.Contains(searchText.Text) && x.Username != "admin");
                    fillTable(logins);
                }
            }
        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {
            if(searchText.Text == string.Empty)
            {
                using (var p = new POSEntities())
                {
                    var logins = p.Logins.Where(x => x.Username != "admin");
                    fillTable(logins);
                }
            }
        }
    }
}
