﻿using POS.Misc;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ChangePass : Form
    {
        int _id = 0;
        public ChangePass()
        {
            InitializeComponent();
            this.Text = "Create New Login";
            currUser.ReadOnly = false;
            panel5.Visible = panel9.Visible = false;
        }

        public ChangePass(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                await Edit();
                return;
            }

            await Create();
        }
        async Task Edit()
        {
            using (var context = POSEntities.Create())
            {
                var u = await context.Logins.FirstOrDefaultAsync(x => x.Id == _id);

                if (passwordTxtBx.Text != u.Password)
                {
                    MessageBox.Show("Incorrect Password. If you cannot remember your current password, please contact administrator for assistance!", "Change Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (u != null)
                {
                    if (!string.IsNullOrEmpty(newPasswordTxt.Text))
                    {
                        if (newPasswordTxt.Text == comfirmPasswordTxt.Text)
                            u.Password = newPasswordTxt.Text;
                        else
                            MessageBox.Show("New Password and Confirm Password did not match.", "Change Password Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    u.Name = string.IsNullOrWhiteSpace(nameTxtBx.Text) ? null : nameTxtBx.Text.Trim();
                    u.Email = textBox1.Text.NullIfEmpty();
                }

                await context.SaveChangesAsync();
                Tag = u;
            }

            MessageBox.Show("Successfully changed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        async Task Create()
        {
            if (string.IsNullOrEmpty(passwordTxtBx.Text) || string.IsNullOrWhiteSpace(currUser.Text))
                return;

            using (var context = POSEntities.Create())
            {
                var newUser = new Login()
                {
                    Username = currUser.Text.Trim(),
                    Name = string.IsNullOrWhiteSpace(nameTxtBx.Text) ? null : nameTxtBx.Text.Trim(),
                    Password = passwordTxtBx.Text
                };

                context.Logins.Add(newUser);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Successfully Added.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private async void ChangePass_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {

                using (var context = POSEntities.Create())
                {
                    var user = await context.Logins.FirstOrDefaultAsync(x => x.Id == _id);

                    currUser.Text = user.Username;
                    nameTxtBx.Text = user.Name;
                    textBox1.Text = user.Email;
                }
            }
        }
    }
}
