using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Interfaces;
using POS.Forms;
using POS.Misc;
using System.Threading;

namespace POS.UserControls {
    public enum SaleStatusFilter { All, Pending, Paid, Count }
    public partial class ReportUC : UserControl, ITab {
        public ReportUC() {
            InitializeComponent();
        }

        private void ReportUC_Load(object sender, EventArgs e) {
            saleStatus.SelectedIndex = 0;
            comboFilterType.SelectedIndex = 0;

            saleStatus.SelectedIndexChanged += saleStatus_SelectedIndexChanged;
            comboFilterType.SelectedIndexChanged += comboFilterType_SelectedIndexChanged;
            dtFilter.ValueChanged += dtFilter_ValueChanged;
        }

        public void RefreshData() {

        }

        CancellationTokenSource regularSource = new CancellationTokenSource();
        CancellationTokenSource chargedSource = new CancellationTokenSource();

        public void CancelLoading() {
            if (regularSource != null)
                regularSource.Cancel();

            if (chargedSource != null)
                chargedSource.Cancel();
        }

        public Control FirstControl() {
            return null;
        }

        public Button EnterButton() {
            return null;
        }

        public async Task InitializeAsync() {
            var chargedT = setCharegedTable();
            var regT = setRegularTableByDate();

            var setOther = Task.Run(() => {
                using (var p = new POSEntities()) {
                    IEnumerable<Sale> charged = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString());
                    decimal total = charged.Select(x => x.Remaining).DefaultIfEmpty(0).Sum();

                    toBeSettledTxt.InvokeIfRequired(() => { toBeSettledTxt.Text = string.Format("P {0:n}", total); });
                }
            });

            await Task.WhenAll(chargedT, regT, setOther);
        }

        private void DefButton_Click(object sender, EventArgs e) {

        }

        private void saleTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == -1)
                return;
            var table = (DataGridView)sender;
            int index = (int)(table.SelectedCells[0].Value);

            using (var context = new POSEntities())
                if (!context.Sales.Any(x => x.Id == index)) {
                    MessageBox.Show("Sale removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    table.Rows.RemoveAt(e.RowIndex);
                    return;
                }

            using (var saleDetails = new SaleDetails()) {
                saleDetails.SetId(index);
                saleDetails.OnSave += SaleDetails_OnSave;
                saleDetails.ShowDialog();
            }
        }

        private async void SaleDetails_OnSave(object sender, EventArgs e) {
            await setCharegedTable();
        }

        POSEntities posEnt => new POSEntities();

        private async Task setRegularTableByDate() {
            Console.WriteLine("started: Regular");

            if (regularSource == null)
                regularSource = new CancellationTokenSource();

            using (var p = posEnt) {
                string type = SaleType.Regular.ToString();

                IQueryable<Sale> filteredSales = p.Sales.Where(x => x.SaleType == type);

                int index = 0;

                comboFilterType.InvokeIfRequired(() => { index = comboFilterType.SelectedIndex; });

                switch (index) {
                    case 0:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year && x.Date.Value.Month == dtFilter.Value.Month && x.Date.Value.Day == dtFilter.Value.Day);
                        break;
                    case 1:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year && x.Date.Value.Month == dtFilter.Value.Month);
                        break;
                    case 2:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year);
                        break;
                }

                try {
                    saleTable.InvokeIfRequired(() => { saleTable.Rows.Clear(); });
                    var rows = await createRegularRow(filteredSales);

                    saleTable.InvokeIfRequired(() => { saleTable.Rows.AddRange(rows); });
                    totalSale.InvokeIfRequired(() => { totalSale.Text = string.Format("₱ {0:n}", filteredSales.ToArray().Sum(x => x.Total)); });

                    Console.WriteLine("finished: Regular");
                }
                catch {
                    regularSource.Dispose();
                    regularSource = null;
                }
            }
        }
        private async Task<DataGridViewRow[]> createRegularRow(IEnumerable<Sale> sales) {
            var rows = new List<DataGridViewRow>();

            await Task.Run(() => {
                try {
                    foreach (var i in sales) {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(saleTable);
                        row.Cells[0].Value = i.Id;
                        row.Cells[1].Value = i.Date.Value.ToString("MMM d, yyyy hh:mm: tt");
                        row.Cells[2].Value = i.Login?.Name ?? "not set";
                        row.Cells[3].Value = i.Customer.Name;
                        row.Cells[4].Value = string.Format("₱ {0:n}", i.Total);

                        rows.Add(row);

                        regularSource.Token.ThrowIfCancellationRequested();
                    }
                }
                catch { }
            });

            regularSource.Token.ThrowIfCancellationRequested();

            return rows.ToArray();
        }

        private async Task setCharegedTable() {
            Console.WriteLine("started: Charged");

            if (chargedSource == null)
                chargedSource = new CancellationTokenSource();

            using (var p = posEnt) {
                chargedTable.InvokeIfRequired(() => { chargedTable.Rows.Clear(); });

                IEnumerable<Sale> sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString()).OrderByDescending(x => x.Date);

                int status = 0;

                saleStatus.InvokeIfRequired(() => status = saleStatus.SelectedIndex);
                switch (status) {
                    case 0:
                        break;
                    case 1:
                        sales = sales.Where(x => x.Remaining > 0);
                        break;
                    case 2:
                        sales = sales.Where(x => x.Remaining <= 0);
                        break;
                    default:
                        break;
                }

                try {
                    var rows = await createChargedRow(sales);

                    chargedTable.InvokeIfRequired(() => { chargedTable.Rows.AddRange(rows); });

                    Console.WriteLine("finished: Charged");
                }
                catch {
                    chargedSource.Dispose();
                    chargedSource = null;
                }
            }
        }

        private async Task<DataGridViewRow[]> createChargedRow(IEnumerable<Sale> sale) {
            var rows = new List<DataGridViewRow>();
            await Task.Run(() => {
                try {
                    foreach (var i in sale) {
                        var row = new DataGridViewRow();

                        if (!i.FullyPaid && i.AmountRecieved == 0)
                            row.DefaultCellStyle.ForeColor = Color.DarkRed;

                        else if (i.FullyPaid)
                            row.DefaultCellStyle.ForeColor = Color.DarkGreen;

                        row.CreateCells(chargedTable,
                            i.Id,
                            i.Customer.Name,
                            i.Date.Value.ToString("MMM d, yyyy hh:mm tt"),
                            string.Format("₱ {0:n}", i.Total),
                            string.Format("₱ {0:n}", i.AmountRecieved),
                            string.Format("₱ {0:n}", i.Remaining),
                            i.Login?.Name ?? "not set",
                            i.FullyPaid
                        );

                        //foreach (var x in sales.OrderByDescending(y => y.Id))
                        //    chargedTable.Rows.Add(x.Id,
                        //                          x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                        //                          x.Login?.Username,
                        //                          x.Customer.Name,
                        //                          string.Format("₱ {0:n}", x.Total),
                        //                          string.Format("₱ {0:n}", x.AmountRecieved),
                        //                          string.Format("₱ {0:n}", x.Remaining),
                        //                          x.Remaining > 0 ? false : true);

                        rows.Add(row);

                        chargedSource.Token.ThrowIfCancellationRequested();
                    }
                }
                catch { }
            });

            chargedSource.Token.ThrowIfCancellationRequested();

            return rows.ToArray();
        }
        //decimal remaining(decimal recieved, decimal totalPrice)
        //{
        //    if (recieved > totalPrice)
        //        return 0;

        //    return totalPrice - recieved;
        //}

        private async Task searchChargeByName() {
            chargedTable.Rows.Clear();

            using (var p = new POSEntities()) {
                IEnumerable<Sale> sales = p.Sales;

                filterCharged(p, ref sales);

                var r = await createChargedRow(sales);

                chargedTable.Rows.AddRange(r);
            }

        }
        bool searchMade { get; set; } = false;

        private async void chargedSearchBtn_Click(object sender, EventArgs e) {
            //var button = sender as Button;
            if (chargedSaleSearch.Text == string.Empty || string.IsNullOrWhiteSpace(chargedSaleSearch.Text))
                return;

            searchMade = true;

            await searchChargeByName();
        }
        private void chargedSaleSearch_TextChanged(object sender, EventArgs e) {
            if (chargedSaleSearch.Text == string.Empty && searchMade) {
                //using (var p = new POSEntities())
                searchMade = false;
                var s = setCharegedTable();
            }
        }
        private void chargedSaleSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                chargedSearchBtn.PerformClick();
        }
        private void month_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                //using (var p = new POSEntities())
                var s = setRegularTableByDate();
            }
        }

        public void Refresh_Callback(object sender, EventArgs e) {

        }

        void filterCharged(POSEntities p, ref IEnumerable<Sale> sales) {
            sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString()).OrderByDescending(x => x.Date);

            if (chargedSaleSearch.Text != string.Empty) {
                var t = chargedSaleSearch.Text.Trim().ToLower();
                sales = sales.Where(x => x.Customer.Name.ToLower().Contains(t));
            }
            if (saleStatus.Text == "Pending") {
                sales = sales.Where(x => x.Remaining > 0);
            }
            else if (saleStatus.Text == "Paid") {
                sales = sales.Where(x => x.Remaining <= 0);
            }
        }
        private async void saleStatus_SelectedIndexChanged(object sender, EventArgs e) {
            chargedTable.Rows.Clear();

            using (var p = new POSEntities()) {
                IEnumerable<Sale> sales = p.Sales;

                filterCharged(p, ref sales);

                var r = await createChargedRow(sales);

                chargedTable.Rows.AddRange(r);
            }
        }

        private void comboFilterType_SelectedIndexChanged(object sender, EventArgs e) {
            int index = ((ComboBox)sender).SelectedIndex;
            switch (index) {
                case 0:
                    dtFilter.CustomFormat = "MMMM d, yyyy";
                    break;
                case 1:
                    dtFilter.CustomFormat = "MMMM yyyy";
                    break;
                case 2:
                    dtFilter.CustomFormat = "yyyy";
                    break;
            }

            var s = setRegularTableByDate();
        }

        private void dtFilter_ValueChanged(object sender, EventArgs e) {
            var s = setRegularTableByDate();
        }

        private void saleTable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F5) {
                var s = setRegularTableByDate();
            }
        }

        private void chargedTable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F5) {
                var s = setCharegedTable();
            }
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e) {
            e.SearchFound = true;
            await searchChargeByName();
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e) {

        }
    }
}
