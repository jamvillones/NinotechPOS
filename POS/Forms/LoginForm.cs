using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Misc;
namespace POS.Forms
{
    public partial class LoginForm : Form
    {
        UserManager u;
        public bool LoginSuccessful
        {
            get; private set;
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginSuccessful = u.Login(username.Text, password.Text);
            if (LoginSuccessful)
            {
                this.Close();
                return;
            }
            MessageBox.Show("User not found.");           
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (UserManager.instance == null)
            {
                Misc.UserManager.instance = new Misc.UserManager();
                u = UserManager.instance;
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
            password.PasswordChar = '*';
        }
    }
}
