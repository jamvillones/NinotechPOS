using POS.Misc;
using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class SwitchUser : Form
    {
        public SwitchUser()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.NullIfEmpty() is null || textBox2.Text.NullIfEmpty() is null)
                return;

            if (await UserManager.instance.Login_Async(textBox1.Text, textBox2.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            MessageBox.Show("No User of these credentials in the record", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void SwitchUser_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var usernames = await context.Logins.Select(x => x.Username).ToArrayAsync();

                    textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    textBox1.AutoCompleteCustomSource.AddRange(usernames);
                }
            }
            catch (EntityException)
            {

            }
        }
    }
}
