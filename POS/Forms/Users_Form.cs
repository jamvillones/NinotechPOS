using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Users_Form : Form
    {
        public Users_Form()
        {
            InitializeComponent();
        }

        POSEntities context { get; set; }

        private async void Users_Form_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();

        }

        private async Task LoadDataAsync()
        {
            try
            {
                context = POSEntities.Create();

                var users = await context.Logins.Where(L => L.Username != "admin").AsQueryable().ToListAsync();

                foreach (var user in users.Select(CreateRow))
                    dataGridView1.Rows.Add(user);

            }
            catch (EntityException ex)
            {
                if (MessageBox.Show("Reload Entries?", "Connection not established", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question) == DialogResult.Retry)
                {
                    await LoadDataAsync();
                    return;
                }

                this.Close();
            }
        }

        Login SelectedLogin => dataGridView1.SelectedRows[0].Cells[col_obj.Index].Value as Login;

        DataGridViewRow CreateRow(Login login)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dataGridView1, login.Id, login.Username, login.Name, login.Email, login);
            return row;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await context.SaveChangesAsync();
                MessageBox.Show("Changes Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            finally
            {
                context.Dispose();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var login = SelectedLogin;
            if (login is null) return;

            label2.Text = login.ToString();

            checkBox1.Checked = login.CanEditItem;
            checkBox2.Checked = login.CanEditProduct;
            checkBox3.Checked = login.CanEditSupplier;
            checkBox4.Checked = login.CanStockIn;
            checkBox5.Checked = login.CanEditInventory;
            checkBox6.Checked = login.CanVoidSale;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
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

        }
    }
}
