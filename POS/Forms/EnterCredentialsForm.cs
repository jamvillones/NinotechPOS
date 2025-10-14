using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class EnterCredentialsForm : Form
    {
        public EnterCredentialsForm()
        {
            InitializeComponent();
        }

        public EnterCredentialsForm(string details)
        {
            InitializeComponent();
            this.Text = this.Text + " - " + details;
        }

        string UserName => usernameTxt.Text.Trim();
        string Password => passwordTxt.Text.Trim();

        private async void Login_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var login = await context.Logins.FirstOrDefaultAsync(x => x.Username == UserName && x.Password == Password);

                    if (login is null)
                    {
                        MessageBox.Show("No Login Found", "Login Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    Tag = login;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (EntityException exc)
            {
                Debug.WriteLine("ENTER CREDENTIALS -> " + exc.Message);
            }
        }
    }
}
