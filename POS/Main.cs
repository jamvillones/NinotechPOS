using Newtonsoft.Json;
using POS.Forms;
using POS.Interfaces;
using POS.Misc;
using POS.UserControls;
using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Main : Form, IMainWindow
    {
        public Main()
        {
            InitializeComponent();

            prevButton = button1;
            prevButton.BackColor = selectedButtonColor;
            NotificationHandler.Instance.ShowCallback = ShowTooltip;
        }

        void ShowTooltip(string title, string details, ToolTipIcon icon)
        {

            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = details;
            notifyIcon1.BalloonTipIcon = icon;
            notifyIcon1.ShowBalloonTip(2);
        }

        /// <summary>
        /// this handles the properties of buttons depending on login
        /// </summary>
        private void LoadProperties()
        {
            var currentLogin = CurrentLogin;
            userButton.Text = "  " + currentLogin.ToString();

            this.Text = $"POS version: {this.GetVersion()} - {ConnectionConfiguration_Source.CurrentConfiguration}";

            bool isAdmin = UserManager.instance.IsAdmin;

            usersButton.Visible = isAdmin;
            supplierButton.Enabled = currentLogin.CanEditSupplier;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            ReceiptPrintingConfigurations.Initialize();

            try
            {
                SetButtonChangeMechanism(button1, button2);
                LoadProperties();

                await inventoryTab.InitializeAsync();
                await reportTab.InitializeAsync();
                await GetCriticalQty();
            }
            catch (Exception) { }

            Console.WriteLine("======================* Load Finished *======================");
        }

        async Task GetCriticalQty()
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var itemsInCriticalQuantity = await context.Items.IsInCriticalQty()
                        .ToListAsync();

                    var builder = new StringBuilder();

                    foreach (var c in itemsInCriticalQuantity)
                    {
                        builder.AppendLine($"{c.Name} - {c.QuantityInInventory} units");
                    }

                    NotificationHandler.Instance.ShowTooltip("Items in Critical Qty (" + itemsInCriticalQuantity.Count + "): ", builder.ToString(), ToolTipIcon.Warning);
                }
            }
            catch (EntityException ex)
            {
                MessageBox.Show(ex.Message, "Critical Quantity Not Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SetButtonChangeMechanism(params Button[] buttons)
        {
            foreach (var i in buttons)
                i.InvokeIfRequired(() => { i.Click += ButtonChangedMechanism_Callback; });
        }

        private void ButtonChangedMechanism_Callback(object sender, EventArgs e)
        {
            prevButton.BackColor = normalButtonColor;

            var button = sender as Button;

            button.BackColor = selectedButtonColor;

            prevButton = button;
        }

        Button prevButton;

        Color selectedButtonColor =
            Color.FromArgb(153, 180, 209);
        Color normalButtonColor =
            Color.White;

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            reportTab.Enabled = false;
            inventoryTab.Enabled = true;
            inventoryTab.BringToFront();
            TabSelected(inventoryTab);
        }

        private void repBtn_Click(object sender, EventArgs e)
        {
            inventoryTab.Enabled = false;
            reportTab.Enabled = true;
            reportTab.BringToFront();
            TabSelected(reportTab);
        }

        void TabSelected(ITab tab)
        {
            tab.FirstControl()?.Focus();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            var editUser = new ChangePass(CurrentLogin.Id);

            if (editUser.ShowDialog() == DialogResult.OK)
            {
                var changed = editUser.Tag as Login;
                userButton.Text = $"  {changed}";
            }
        }

        public bool IsLoggedOut { get; private set; } = false;

        #region toolstrips

        void OpenDialog<T>() where T : Form, new()
        {
            using (T f = new T())
            {
                f.ShowDialog();
            }
        }
        #endregion

        Login CurrentLogin => UserManager.instance.CurrentLogin;

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsLoggedOut)
                if (MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

            CancelLoadings(inventoryTab);
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();

            var settings = Properties.Settings.Default;

            settings.WindowConfiguration = JsonConvert.SerializeObject(WindowConfiguration.Instance);
            settings.Save();
        }

        protected override void WndProc(ref Message m)
        {
            FormWindowState org = this.WindowState;
            base.WndProc(ref m);
            if (this.WindowState != org)
                this.OnFormWindowStateChanged(EventArgs.Empty);
        }

        protected virtual void OnFormWindowStateChanged(EventArgs e)
        {
            // Do your stuff
            if (this.WindowState != FormWindowState.Minimized)
                WindowConfiguration.Instance.WindowState = this.WindowState;
        }

        void CancelLoadings(params ITab[] tabs)
        {
            foreach (var i in tabs)
                i.CancelLoading();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            using (var shiftSum = new ShiftSummaryForm())
            {
                if (shiftSum.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Maximized;

            this.Activate();
            this.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenDialog<Suppliers_List>();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenDialog<Customers_List>();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenDialog<UserPrivilegesForm>();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenDialog<ReceiptPrintingConfigurations>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log off?",
               "",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.Cancel) return;

            IsLoggedOut = true;
            UserManager.instance.LogOut();
            this.Close();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
                button7.PerformClick();
        }
    }
}
