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
    public partial class CreateLogin : Form
    {
        public CreateLogin()
        {
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTxt.Text == string.Empty || PasswordTxt.Text == string.Empty)
            {
                MessageBox.Show("fields must not be empty!");
                return;
            }
            using (var eb = new POSEntities())
            {
                var u = eb.Logins.FirstOrDefault(x => x.Username == UsernameTxt.Text);
                if (u != null)
                {
                    MessageBox.Show("Username already taken.");
                    return;
                }
            }
            if (!SamePassword)
            {
                ActiveControl = PasswordTxt;
                MessageBox.Show("Password does not match");
                PasswordTxt.Clear();
                ConfirmPassTxt.Clear();
                return;
            }
            using (var a = new POSEntities())
            {
                var login = new Login();

                login.Username = UsernameTxt.Text;
                login.Password = PasswordTxt.Text;

                login.CanStockIn = false;

               // login.CanAddSupplier = false;
                login.CanEditSupplier = false;
               // login.CanDeleteSupplier = false;

                //login.CanAddItem = false;
                login.CanEditItem = false;
                //login.CanDeleteItem = false;

               // login.CanAddProduct = false;
                login.CanEditProduct = false;

                a.Logins.Add(login);
                a.SaveChanges();
            }
            MessageBox.Show("Successfully added");
            this.Close();
        }
        /// <summary>
        /// checks if the password match
        /// </summary>
        bool SamePassword
        {
            get
            {
                return PasswordTxt.Text == ConfirmPassTxt.Text;
            }
        }

        private void PasswordTxt_TextChanged(object sender, EventArgs e)
        {
            if (PasswordTxt.Text == string.Empty) return;
            checkImage.Visible = SamePassword ? true : false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ConfirmPassTxt.Text == string.Empty) return;
            checkImage.Visible = SamePassword ? true : false;
        }
    }
}
