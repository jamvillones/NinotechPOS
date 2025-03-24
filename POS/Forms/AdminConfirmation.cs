using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class AdminConfirmation : Form
    {
        public AdminConfirmation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var adminLogin = await context.Logins.FirstOrDefaultAsync(x => x.Username == "admin");

                    if (adminLogin != null && adminLogin.Password.Equals(textBox1.Text))
                    {
                        DialogResult = DialogResult.OK;
                        return;
                    }
                }
            }
            catch (Exception)
            {


            }

            MessageBox.Show("Wrong Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static class AdminProtection
    {
        public static DialogResult RequireAdminConfirmationBeforeViewing<T>(this T form) where T : Form
        {
            using (var adminConfirmation = new AdminConfirmation())
            {
                if (adminConfirmation.ShowDialog() == DialogResult.OK)
                {
                    return form.ShowDialog();
                }

                return DialogResult.None;
            }
        }
    }
}
