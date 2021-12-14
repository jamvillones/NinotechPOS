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

        /// <summary>
        /// this handles the properties of buttons depending on login
        /// </summary>
        private void LoadProperties()
        {
            var cl = currLogin;

            userButton.InvokeIfRequired(() => { userButton.Text = cl.Name??"user"; });
            textBox1.InvokeIfRequired(() => textBox1.Text = Properties.Settings.Default.Note);

            toolStrip.InvokeIfRequired(() =>
            {
                addNewLoginToolStripMenuItem1.Enabled = cl.Username == "admin";
                loginPrivilegesToolStripMenuItem1.Enabled = cl.Username == "admin";
                addNewSupplierToolstripbuttn.Enabled = cl.CanEditSupplier;
                toolStripButton3.Enabled = cl.CanStockIn;
            });

        }

        private async void Main_Load(object sender, EventArgs e)
        {
            setChangingColorsBtn(inventoryBtn, repBtn);

            var init = Task.Run((Action)LoadProperties);

            var t = inventoryTab.InitializeAsync();
            var r = reportTab.InitializeAsync();

            await Task.WhenAll(
                t,
                r,
                init
                );

            Console.WriteLine("===== Form Initialized =====");
            //isLoading = false;
            //if (isClosing)
            //    this.Close();
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

        #region toolstrips
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog<ChangePass>((x) => { x.SetUser(UserManager.instance.currentLogin.Username); });
        }
        private void addNewLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserManager.instance.currentLogin.Username != "admin")
            {
                MessageBox.Show("Cannot perform this action!");
                return;
            }
            OpenDialog<CreateLogin>();
        }
        private void loginPrivilegesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog<UserPrivilegesForm>();
        }

        private void openSupplier_Click(object sender, EventArgs e)
        {
            OpenDialog<SupplierForm>();
        }
        private void createCustomer_Click(object sender, EventArgs e)
        {
            OpenDialog<CreateCustomerProfile>();
        }
        private void stockinLog_Click(object sender, EventArgs e)
        {
            OpenDialog<StockinLog>();
        }
        private void printInventory_Click(object sender, EventArgs e)
        {
            OpenDialog<PrintInventory>();
        }
        private void receiptConfig_Click(object sender, EventArgs e)
        {
            OpenDialog<RecieptPrintingConfigurations>();
        }
        void OpenDialog<T>() where T : Form, new()
        {
            using (T f = new T())
            {
                f.ShowDialog();
            }
        }
        void OpenDialog<T>(Action<T> action) where T : Form, new()
        {
            using (T f = new T())
            {
                action(f);
                f.ShowDialog();
            }
        }
        #endregion

        Login currLogin
        {
            get
            {
                return UserManager.instance.currentLogin;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsSigneout)
                if (MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }


            string n = textBox1.Text.Trim();
            Properties.Settings.Default.Note = n == string.Empty ? null : n;
            Properties.Settings.Default.Save();


            CancelLoadings(inventoryTab);
        }
        void CancelLoadings(params ITab[] tabs)
        {
            foreach (var i in tabs)
                i.CancelLoading();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using(var shiftSum = new ShiftSummaryForm())
            {
                if(shiftSum.ShowDialog()== DialogResult.OK)
                {

                }
            }
        }
    }
}
