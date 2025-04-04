using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class LoginForm : Form
    {
        public bool LoginSuccessful
        {
            get; private set;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            button.Enabled = false;
            panel3.Visible = false;

            button.Text = "LOADING...";

            var task = UserManager.instance.Login_Async(username.Text, password.Text, checkBox1.Checked);
            await Task.WhenAll(task, Task.Delay(500));

            LoginSuccessful = task.Result;

            if (LoginSuccessful)
            {
                this.Close();
                return;
            }

            button.Text = "LOG IN";
            button.Enabled = true;
            panel3.Visible = true;
            System.Media.SystemSounds.Hand.Play();
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = $"POS - Login {ConnectionConfiguration_Source.CurrentConfiguration}";

            label1.Text = $"version: {this.GetVersion()}";

            await GetLoginUsernameForAutocomplete();
        }

        async Task GetLoginUsernameForAutocomplete()
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var loadingTask = context.Logins.AsNoTracking().Select(x => x.Username).ToArrayAsync();
                    await Task.WhenAll(loadingTask, Task.Delay(1000));

                    username.AutoCompleteCustomSource.AddRange(loadingTask.Result);
                }
            }
            catch (EntityException)
            {
                if (MessageBox.Show("Make sure the server is operational and is connected. Also ensure that the connection configuration parameters are set properly.",
                                    "Connection Not Established!",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error) == DialogResult.Retry)
                    await GetLoginUsernameForAutocomplete();
            }
        }

        private void hide_MouseDown(object sender, MouseEventArgs e)
        {
            password.PasswordChar = '\0';
        }

        private void hide_MouseUp(object sender, MouseEventArgs e)
        {
            password.PasswordChar = '●';
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Shift && e.Control && e.KeyCode == Keys.C)
            {
                using (var config = new ServerConnections())
                    config.ShowDialog();

                this.Text = $"POS - Login {ConnectionConfiguration_Source.CurrentConfiguration}";
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            hide.Visible = !string.IsNullOrWhiteSpace(password.Text);
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var createLogin = new CreateLogin())
            {
                if (createLogin.RequireAdminConfirmationBeforeViewing() == DialogResult.OK)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var config = new ServerConnections())
            {
                if (config.ShowDialog() == DialogResult.OK)
                    this.Text = $"POS - Login {ConnectionConfiguration_Source.CurrentConfiguration}";
            }
        }
    }
}
