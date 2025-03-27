using POS.Forms;
using POS.Interfaces;
using POS.Misc;
using POS.UserControls;
using System;
using System.Data.Entity;
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

            this.Text = $"POS - {ConnectionConfiguration_Source.CurrentConfiguration}";

            bool isAdmin = currentLogin.Username.Equals("admin", StringComparison.OrdinalIgnoreCase);

            button6.Visible = isAdmin;
            button5.Enabled = currentLogin.CanEditSupplier;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
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
                        builder.AppendLine(c.Name + " - " + c.QuantityInInventory + " units");
                    }

                    NotificationHandler.Instance.ShowTooltip("Items in Critical Qty (" + itemsInCriticalQuantity.Count + "): ", builder.ToString(), ToolTipIcon.Warning);
                }
            }
            catch (Exception) { }
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

            editUser.ShowDialog();
            //if (MessageBox.Show("Are you sure you want to log off?",
            //    "",
            //    MessageBoxButtons.OKCancel,
            //    MessageBoxIcon.Question) == DialogResult.Cancel) return;

            //IsLoggedOut = true;
            //this.Close();
        }

        public bool IsLoggedOut { get; private set; } = false;

        #region toolstrips
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var changeDetails = new ChangePass(UserManager.instance.CurrentLogin.Id))
            {
                if (changeDetails.ShowDialog() == DialogResult.OK)
                {
                    var result = (Login)changeDetails.Tag;
                    userButton.Text = result.ToString();
                }
            }
        }
        private void addNewLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenDialog<CreateLogin>();
            using (var changeDetails = new ChangePass())
            {
                if (changeDetails.ShowDialog() == DialogResult.OK)
                {
                    //var result = (Login)changeDetails.Tag;
                    //userButton.Text = result.ToString();
                }
            }
        }
        private void loginPrivilegesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog<UserPrivilegesForm>();
        }

        private void openSupplier_Click(object sender, EventArgs e)
        {
            OpenDialog<Suppliers_List>();
        }
        private void createCustomer_Click(object sender, EventArgs e)
        {
            OpenDialog<Customers_List>();
        }
        private void stockinLog_Click(object sender, EventArgs e)
        {
            OpenDialog<StockInLog>();
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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    inventoryTab.BringToFront();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    reportTab.BringToFront();
        //}

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
            OpenDialog<RecieptPrintingConfigurations>();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log off?",
               "",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.Cancel) return;

            IsLoggedOut = true;
            this.Close();
        }
    }
}
