using POS.Misc;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class CreateLogin : Form
    {
        public CreateLogin()
        {
            InitializeComponent();
        }

        private async void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTxt.Text == string.Empty || PasswordTxt.Text == string.Empty)
            {
                MessageBox.Show("fields must not be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsPasswordMatched)
            {
                ActiveControl = PasswordTxt;
                MessageBox.Show("Password do not match", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTxt.Clear();
                ConfirmPassTxt.Clear();
                return;
            }

            using (var context = POSEntities.Create())
            {
                var u = await context.Logins.FirstOrDefaultAsync(x => x.Username == UsernameTxt.Text);

                if (u != null)
                {
                    MessageBox.Show("Username already taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var login = new Login
                {
                    Username = UsernameTxt.Text,
                    Password = PasswordTxt.Text,
                    Email = textBox1.Text.NullIfEmpty(),
                    Name = nameTxt.Text.NullIfEmpty(),

                    CanStockIn = false,
                    CanEditSupplier = false,
                    CanEditItem = false,
                    CanEditProduct = false
                };

                context.Logins.Add(login);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Successfully added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// checks if the password match
        /// </summary>
        bool IsPasswordMatched => PasswordTxt.Text == ConfirmPassTxt.Text;

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTxt.Text == string.Empty) return;
            checkImage.Visible = IsPasswordMatched;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ConfirmPassTxt.Text == string.Empty) return;
            checkImage.Visible = IsPasswordMatched;
        }
    }
}
