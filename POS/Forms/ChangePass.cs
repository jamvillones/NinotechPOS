using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ChangePass : Form
    {
        Login currentUser;
        public ChangePass()
        {
            InitializeComponent();

            //newPassword.Validated += Helper.TextBoxTrimSpaces;
            //confirmPassword.Validated += Helper.TextBoxTrimSpaces;
            //currPassword.Validated += Helper.TextBoxTrimSpaces;
        }
        public void SetUser(string u)
        {
            using (var eb = new POSEntities())
            {
                var user = eb.Logins.FirstOrDefault(x => x.Username == u);
                currentUser = user;
                currUser.Text = user.Username;
                nameTxt.Text = user.Name;
            }
        }
        bool canSave()
        {
            return currPassword.Text != string.Empty;
        }
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (!canSave())
                return;

            using (var eb = new POSEntities())
            {
                var u = eb.Logins.FirstOrDefault(x => x.Username == currentUser.Username);
                if (u != null)
                {
                    u.Password = currPassword.Text;
                    if (!string.IsNullOrWhiteSpace(nameTxt.Text))
                        u.Name = nameTxt.Text.Trim();
                }
                eb.SaveChanges();
                MessageBox.Show("Password successfully changed.");
                this.Close();
            }
        }
    }
}
