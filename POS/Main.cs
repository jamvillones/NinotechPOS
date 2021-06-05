using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
    public partial class Main : Form, IMainWindow
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                this.WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public Main()
        {
            InitializeComponent();
        }
        bool isLoading { get; set; } = true;
        bool isClosing { get; set; } = false;

        /// <summary>
        /// this handles the properties of buttons depending on login
        /// </summary>
        private void LoadButtonProperties()
        {
            var cl = currLogin;

            userButton.InvokeIfRequired(() => { userButton.Text = cl.Username; });

            addNewLoginToolStripMenuItem1.Enabled = cl.Username == "admin";
            loginPrivilegesToolStripMenuItem1.Enabled = cl.Username == "admin";
            addNewSupplierToolstripbuttn.Enabled = cl.CanEditSupplier;
            stockinToolStrpBtn.Enabled = cl.CanStockIn;

            stockInBtn.InvokeIfRequired(() => { stockInBtn.Visible = cl.CanStockIn; });
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            setChangingColorsBtn(inventoryBtn, repBtn);

            var init = Task.Run((Action)LoadButtonProperties);
            var t = inventoryTab.InitializeAsync();
            var r = reportTab.InitializeAsync();

            await Task.WhenAll(t, r, init);

            Console.WriteLine("Form initialized.");
            isLoading = false;
            if (isClosing)
                this.Close();
        }

        void setChangingColorsBtn(params Button[] buttons)
        {
            foreach (var i in buttons)
                i.InvokeIfRequired(() => { i.Click += buttonColorChangeCallback; });
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
                TryCreateLogin();
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

            if (e.Control && e.KeyCode == Keys.P)
            {
                toolStripButton5.PerformClick();
            }
        }

        void RefreshData()
        {

        }

        private void userButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            IsSigneout = true;

            this.Close();
        }

        public bool IsSigneout { get; private set; } = false;

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TryCreateLogin();
        }

        void TryCreateLogin()
        {
            if (UserManager.instance.currentLogin.Username != "admin")
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
            using (var sellForm = new ConsoleSell())
            {
                sellForm.ShowDialog();
            }
        }

        private void refreshToolStripBtn_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            using (var print = new PrintInventory())
            {
                print.ShowDialog();
            }
        }

        private void stockin_Callback(object sender, EventArgs e)
        {
            using (var stockin = new StockinForm())
            {
                stockin.OnSave += Stockin_OnSave; ;
                stockin.ShowDialog();
            }
        }

        private void Stockin_OnSave(object sender, EventArgs e)
        {
            inventoryTab.RefreshData();
        }

        private void sell_Callback(object sender, EventArgs e)
        {
            using (var sellForm = new MakeSale())
            {
                sellForm.ShowDialog();
            }
        }

        Login currLogin
        {
            get
            {
                return UserManager.instance.currentLogin;
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            using (var s = new StockinLog())
            {
                s.ShowDialog();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLoading)
            {
                this.Hide();
                isClosing = true;
                e.Cancel = true;
            }
        }

        private void loginPrivilegesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var previliges = new UserPrivilegesForm())
                previliges.ShowDialog();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            using (var printerSettings = new RecieptPrintingConfigurations())
                printerSettings.ShowDialog();
        }
    }
}
