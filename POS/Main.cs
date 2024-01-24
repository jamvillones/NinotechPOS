using POS.Forms;
using POS.Interfaces;
using POS.Misc;
using POS.UserControls;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS {
    public partial class Main : Form, IMainWindow {

        public Main() {
            InitializeComponent();

            prevButton = inventoryBtn;
            prevButton.BackColor = selectedButtonColor;
            NotificationHandler.Instance.ShowCallback = ShowTooltip;
        }

        void ShowTooltip(string title, string details, ToolTipIcon icon) {

            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = details;
            notifyIcon1.BalloonTipIcon = icon;

            notifyIcon1.ShowBalloonTip(2);
        }

        /// <summary>
        /// this handles the properties of buttons depending on login
        /// </summary>
        private void LoadProperties() {
            var currentLogin = CurrentLogin;

            userButton.Text = currentLogin.ToString();

            bool isAdmin = currentLogin.Username.Equals("admin", StringComparison.OrdinalIgnoreCase);
            loginPrivilegesToolStripMenuItem.Enabled = isAdmin;
            addNewLoginToolStripMenuItem.Enabled = isAdmin;
        }

        private async void Main_Load(object sender, EventArgs e) {
            SetButtonChangeMechansim(inventoryBtn, repBtn);
            LoadProperties();

            var t = inventoryTab.InitializeAsync();
            var r = reportTab.InitializeAsync();
            var c = GetCriticalQty();

            await Task.WhenAll(t, r, c);

            Console.WriteLine("======================* Load Finished *======================");
        }

        async Task GetCriticalQty() {
            try {
                using (var context = new POSEntities()) {
                    var crits = await context.Items.IsInCriticalQty()
                        .ToListAsync();

                    var builder = new StringBuilder();

                    foreach (var c in crits) {
                        builder.AppendLine(c.Name + " - " + c.QuantityInInventory + " units");
                    }

                    NotificationHandler.Instance.ShowTooltip("Items in Critical Qty (" + crits.Count + "): ", builder.ToString(), ToolTipIcon.Warning);
                }
            }
            catch (Exception) {

            }
        }

        void SetButtonChangeMechansim(params Button[] buttons) {
            foreach (var i in buttons)
                i.InvokeIfRequired(() => { i.Click += ButtonChangedMechanism_Calbback; });
        }

        private void ButtonChangedMechanism_Calbback(object sender, EventArgs e) {
            prevButton.BackColor = normalButtonColor;

            var button = sender as Button;

            button.BackColor = selectedButtonColor;
            prevButton = button;
            marker.Top = button.Top;
        }

        Button prevButton;

        Color selectedButtonColor =
            Color.FromArgb(240, 240, 240);
        Color normalButtonColor =
            Color.Transparent;

        private void inventoryBtn_Click(object sender, EventArgs e) {
            inventoryTab.BringToFront();
            TabSelected(inventoryTab);
        }

        private void repBtn_Click(object sender, EventArgs e) {
            reportTab.BringToFront();
            TabSelected(reportTab);
        }

        void TabSelected(ITab tab) {
            tab.FirstControl()?.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {

        }

        private void userButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to log off?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel) return;

            IsLoggedOut = true;
            this.Close();
        }

        public bool IsLoggedOut { get; private set; } = false;

        #region toolstrips
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var changeDetails = new ChangePass(UserManager.instance.currentLogin.Id)) {
                if (changeDetails.ShowDialog() == DialogResult.OK) {
                    var result = (Login)changeDetails.Tag;
                    userButton.Text = result.ToString();
                }
            }
        }
        private void addNewLoginToolStripMenuItem_Click(object sender, EventArgs e) {
            //OpenDialog<CreateLogin>();
            using (var changeDetails = new ChangePass()) {
                if (changeDetails.ShowDialog() == DialogResult.OK) {
                    //var result = (Login)changeDetails.Tag;
                    //userButton.Text = result.ToString();
                }
            }
        }
        private void loginPrivilegesToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenDialog<UserPrivilegesForm>();
        }

        private void openSupplier_Click(object sender, EventArgs e) {
            OpenDialog<Suppliers>();
        }
        private void createCustomer_Click(object sender, EventArgs e) {
            OpenDialog<Customers>();
        }
        private void stockinLog_Click(object sender, EventArgs e) {
            OpenDialog<StockinLog>();
        }
        private void printInventory_Click(object sender, EventArgs e) {
            OpenDialog<PrintInventory>();
        }
        private void receiptConfig_Click(object sender, EventArgs e) {
            OpenDialog<RecieptPrintingConfigurations>();
        }

        void OpenDialog<T>() where T : Form, new() {
            using (T f = new T()) {
                f.ShowDialog();
            }
        }
        void OpenDialog<T>(Action<T> action) where T : Form, new() {
            using (T f = new T()) {
                action(f);
                f.ShowDialog();
            }
        }
        #endregion

        Login CurrentLogin => UserManager.instance.currentLogin;

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            if (!IsLoggedOut)
                if (MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) {
                    e.Cancel = true;
                    return;
                }

            CancelLoadings(inventoryTab);
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
        }
        void CancelLoadings(params ITab[] tabs) {
            foreach (var i in tabs)
                i.CancelLoading();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            using (var shiftSum = new ShiftSummaryForm()) {
                if (shiftSum.ShowDialog() == DialogResult.OK) {

                }
            }
        }

        int showedWidth = 120;
        int collapsedWidth = 10;

        private void sideButtonsPanel_DoubleClick(object sender, EventArgs e) {
            var s = sender as Panel;

            s.Width = s.Width == showedWidth ? collapsedWidth : showedWidth;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (this.WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Maximized;

            this.Activate();
            this.BringToFront();
        }
    }
}
