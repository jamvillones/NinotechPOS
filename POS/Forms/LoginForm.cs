using POS.Misc;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
namespace POS.Forms
{
    public partial class LoginForm : Form
    {
        //UserManager u;
        public bool LoginSuccessful
        {
            get; private set;
        }
        public LoginForm()
        {
            InitializeComponent();
            //u = manager;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginSuccessful = UserManager.instance.Login(username.Text, password.Text);
            if (LoginSuccessful)
            {
                this.Close();
                return;
            }
            ///MessageBox.Show("Login failed!","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ///
            System.Media.SystemSounds.Hand.Play();
            label2.Text = "Log In Failed!";
        }

        string GetVersion()
        {
            try
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception ex)
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            this.Text = "POS-Login: " + (settings.IsLocalConnection ? "localHost" : settings.DataSource);

            label1.Text = "version: " + GetVersion();
            TryConnect();
        }

        void TryConnect()
        {
            try
            {
                using (var p = new POSEntities())
                {
                    username.AutoCompleteCustomSource.AddRange(p.Logins.Select(x => x.Username).ToArray());
                }
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message + "\n\nMake sure the server is operational and is connected before clicking retry.", "Connection Failed!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    TryConnect();
                }
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {

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
                //var connectionString = ConfigurationManager.ConnectionStrings["POSEntities"].ConnectionString.ToString();

                //var STRINGS = connectionString.Split(';');

                //MessageBox.Show(STRINGS[2], "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var config = new ConnectionConfigurations();
                config.ShowDialog();

            }

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            hide.Visible = !string.IsNullOrWhiteSpace(password.Text);
            label2.Text = string.Empty;
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
        }
    }
}
