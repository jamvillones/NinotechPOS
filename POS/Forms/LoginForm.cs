﻿using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
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

        private void exitBtn_Click(object sender, EventArgs e) => this.Close();

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            LoginSuccessful =await UserManager.instance.Login_Async(username.Text, password.Text, checkBox1.Checked);

            if (LoginSuccessful)
            {
                this.Close();
                return;
            }

            System.Media.SystemSounds.Hand.Play();
            label2.Text = "Log In Failed!";
        }

        string GetVersion()
        {
            try
            {
                return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception)
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private async void LoginForm_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;

            this.Text = $"POS - Login {ConnectionConfiguration_Source.CurrentConfiguration}";

            await TryConnect();
        }

        async Task TryConnect()
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var loadingTask = context.Logins.AsNoTracking().Select(x => x.Username).ToArrayAsync();
                    await Task.WhenAll(loadingTask, Task.Delay(1000));

                    username.AutoCompleteCustomSource.AddRange(loadingTask.Result);
                }
            }
            catch (EntityException)
            {
                if (MessageBox.Show("Make sure the server is operational and is connected. Also ensure that the connection configuration parameters are set properly.\n\nFor further questions, please contact 0997 522 4858 and look for Jamil Villones.", "Connection Not Established!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    await TryConnect();
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
                var config = new ServerConnections();

                if (config.ShowDialog() == DialogResult.OK)
                    this.Text = $"POS - Login {ConnectionConfiguration_Source.CurrentConfiguration}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var createLogin = new CreateLogin())
            {
                if (createLogin.RequireAdminConfirmationBeforeViewing() == DialogResult.OK)
                {

                }
            }
        }
    }
}
