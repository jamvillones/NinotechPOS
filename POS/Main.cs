using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Forms;
using POS.Interfaces;
using POS.Misc;

namespace POS
{
    public partial class Main : Form
    {
        List<ITab> uControls = new List<ITab>();

        public Main()
        {
            InitializeComponent();

            uControls.Add(inventoryTab);
            uControls.Add(reportTab);

            setChangingColorsBtn(inventoryBtn, repBtn);

            foreach (var i in uControls)
                i.Initialize();

            userButton.Text = UserManager.instance.currentLogin.Username;
            foreach (var i in uControls)
                refreshToolStripBtn.Click += i.Refresh_Callback;
        }

        void setChangingColorsBtn(params Button[] buttons)
        {
            foreach (var i in buttons)
                i.Click += buttonColorChangeCallback;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void buttonColorChangeCallback(object sender, EventArgs e)
        {
            if (prevButton == null)
            {
                prevButton = inventoryBtn;
                prevButton.BackColor = selectedButtonColor;
            }

            prevButton.BackColor = normalButtonColor;
            var b = (Button)sender;
            b.BackColor = selectedButtonColor;
            prevButton = b;
        }
        Button prevButton;
        Color selectedButtonColor = Color.Gray;
        Color normalButtonColor = Color.FromArgb(64, 64, 64);

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            inventoryTab.BringToFront();
        }

        private void repBtn_Click(object sender, EventArgs e)
        {
            reportTab.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (!UserManager.instance.currentLogin.CanAddUser ?? false)
                {
                    MessageBox.Show("Cannot perform this action!");
                    return;
                }
                ///add new login
                using (var newlogin = new CreateLogin())
                    newlogin.ShowDialog();
            }
            else if (e.KeyCode == Keys.F2)
            {
                ///change password
                using (var changepass = new ChangePass())
                {
                    changepass.SetUser(UserManager.instance.currentLogin.Username);
                    changepass.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                RefreshData();
            }
        }
        void RefreshData()
        {
            refreshToolStripBtn.PerformClick();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            //userContextMenuStrip.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!UserManager.instance.currentLogin.CanAddUser ?? false)
            {
                MessageBox.Show("Cannot perform this action!");
                return;
            }
            ///add new login
            using (var newlogin = new CreateLogin())
                newlogin.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var changepass = new ChangePass())
            {
                changepass.SetUser(UserManager.instance.currentLogin.Username);
                changepass.ShowDialog();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (var supplier = new SupplierForm())
                supplier.ShowDialog();
        }

        private void addNewLoginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var login = new CreateLogin())
                login.ShowDialog();
        }

        private void changePasswordToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            using (var changePass = new ChangePass())
            {
                changePass.SetUser(UserManager.instance.currentLogin.Username);
                changePass.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var customer = new CreateCustomerProfile())
                customer.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (StockinLog log = new StockinLog())
                log.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using(var sellForm = new SellForm())
            {
                sellForm.ShowDialog();
            }
        }

        private void refreshToolStripBtn_Click(object sender, EventArgs e)
        {

        }

        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    //foreach(var i in uControls)
        //    //    i.re
        //}
    }
}
