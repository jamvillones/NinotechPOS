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

            if(!string.IsNullOrEmpty(textBox2.Text) && !IsRFIDMatched)
            {
                ActiveControl = textBox2;
                MessageBox.Show("RFID do not match", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        bool IsRFIDMatched => textBox2.Text.Equals(textBox3.Text);

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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                textBox3.Select();
                textBox3.Focus();
            }
        }

        private void checkForRFIDMatch_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = textBox2.Text.Equals(textBox3.Text);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                                ConfirmBtn.PerformClick();
            }
        }
    }
}
