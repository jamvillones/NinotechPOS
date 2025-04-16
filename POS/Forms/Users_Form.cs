using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Users_Form : Form
    {
        POSEntities context;

        public Users_Form()
        {
            InitializeComponent();

            checkBox2.CheckedChanged += EnableDisableOtherCheckBoxes;
            dataGridView1.AutoGenerateColumns = false;

            col_Id.DataPropertyName = nameof(Login.Id);
            col_Username.DataPropertyName = nameof(Login.Username);
            col_Name.DataPropertyName = nameof(Login.Name);
            col_Email.DataPropertyName = nameof(Login.Email);

            dataGridView1.DataSource = Logins;
        }

        private void EnableDisableOtherCheckBoxes(object sender, EventArgs e)
        {
            var c = sender as CheckBox;

            checkBox1.Enabled =
            checkBox3.Enabled =
            checkBox4.Enabled =
            checkBox5.Enabled =
            checkBox6.Enabled = c.Checked;
        }

        private async void Users_Form_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        public BindingList<Login> Logins { get; } = new BindingList<Login>();

        private async Task<bool> LoadDataAsync()
        {

            context?.Dispose();

            try
            {
                context = POSEntities.Create();

                var users = context.Logins
                    .Where(L => L.Username != "admin")
                    .ApplySearch(keyword);

                bool hasEntries = await users.CountAsync() > 0;

                if (hasEntries)
                {
                    if (Logins.Count > 0)
                        Logins.Clear();

                    foreach (var login in await users.ToListAsync())
                        Logins.Add(login);
                }

                return hasEntries;

            }
            catch (EntityException)
            {
                if (MessageBox.Show("Reload Entries?", "Connection not established", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Retry)
                {
                    return await LoadDataAsync();
                }

                this.Close();
                return false;
            }
        }

        Login SelectedLogin => dataGridView1.SelectedRows.Count == 0 ? null : (Login)dataGridView1.SelectedRows[0].DataBoundItem;

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await context.SaveChangesAsync();
                MessageBox.Show("Changes Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (EntityException) { }
            finally { }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var login = SelectedLogin;
            if (login is null) return;

            label2.Text = login.ToString().ToUpper();
            SetCheckBoxValues(login);
        }

        private void SetCheckBoxValues(Login login)
        {
            checkBox1.Checked = login.CanEditItem;
            checkBox2.Checked = login.CanEditProduct;
            checkBox3.Checked = login.CanEditSupplier;
            checkBox4.Checked = login.CanStockIn;
            checkBox5.Checked = login.CanEditInventory;
            checkBox6.Checked = login.CanVoidSale;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedLogin is null) return;

            var checkbox = sender as CheckBox;
            int index = Convert.ToInt32(checkbox.Tag);

            switch (index)
            {
                case 1:
                    SelectedLogin.CanEditProduct = checkbox.Checked;
                    break;
                case 2:
                    SelectedLogin.CanEditItem = checkbox.Checked;
                    break;
                case 3:
                    SelectedLogin.CanEditSupplier = checkbox.Checked;
                    break;
                case 4:
                    SelectedLogin.CanStockIn = checkbox.Checked;
                    break;
                case 5:
                    SelectedLogin.CanEditInventory = checkbox.Checked;
                    break;
                case 6:
                    SelectedLogin.CanVoidSale = checkbox.Checked;
                    break;
            }

            button1.Enabled = button2.Enabled = HasChanges;
        }

        bool HasChanges => context.ChangeTracker.Entries().Any(e => e.IsEntityActuallyModified());

        private void Users_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasChanges)
            {
                if (MessageBox.Show("There are pending changes.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            context?.Dispose();
        }

        string keyword = "";
        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            keyword = e.Text;

            bool hasResult = await LoadDataAsync();

            if (!hasResult)
                MessageBox.Show("No Entries Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.UndoAllChanges();

            SetCheckBoxValues(SelectedLogin);

            button1.Enabled = button2.Enabled = HasChanges;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var addedRow = dataGridView1.Rows[e.RowIndex];
            var login = (Login)addedRow.DataBoundItem;

            bool isAuthorized = login.CanEditProduct;

            addedRow.DefaultCellStyle.ForeColor = isAuthorized ? Color.Blue : Color.Gray;
            addedRow.DefaultCellStyle.SelectionForeColor = isAuthorized ? Color.Blue : Color.Gray;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            keyword = string.Empty;

            await LoadDataAsync();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    public static class LoginQueryExtensions
    {
        public static IQueryable<Login> ApplySearch(this IQueryable<Login> logins, string keyword = "")
        {
            if (keyword.IsEmpty())
                return logins;

            return logins.Where(l => l.Username.Contains(keyword) || l.Name.Contains(keyword));
        }

        //public static bool HasChanges<T>(List<T> originalList, List<T> updatedList, Func<T, object> keySelector)
        //{
        //    foreach (var original in originalList)
        //    {
        //        var updated = updatedList.FirstOrDefault(x => keySelector(x).Equals(keySelector(original)));
        //        if (updated == null || !AreObjectsEqual(original, updated))
        //        {
        //            return true; // Object removed or changed
        //        }
        //    }

        //    // Check for newly added items
        //    foreach (var updated in updatedList)
        //    {
        //        if (!originalList.Any(x => keySelector(x).Equals(keySelector(updated))))
        //        {
        //            return true; // New object added
        //        }
        //    }

        //    return false;
        //}

        //public static bool AreObjectsEqual<T>(T obj1, T obj2)
        //{
        //    foreach (var prop in typeof(T).GetProperties())
        //    {
        //        var value1 = prop.GetValue(obj1);
        //        var value2 = prop.GetValue(obj2);

        //        if (!object.Equals(value1, value2))
        //            return false;
        //    }
        //    return true;
        //}

        public static bool IsEntityActuallyModified(this DbEntityEntry entry)
        {
            if (entry.State != EntityState.Modified)
                return false;

            foreach (var propName in entry.OriginalValues.PropertyNames)
            {
                var original = entry.OriginalValues[propName];
                var current = entry.CurrentValues[propName];

                if (!object.Equals(original, current))
                    return true;
            }

            return false;
        }

        public static void UndoAllChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        // Reset property values to original
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        // Remove newly added entities
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        // Revert deletion
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}