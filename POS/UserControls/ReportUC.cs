using POS.Forms;
using POS.Interfaces;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UserControls
{
    public enum SaleStatusFilter { All, Pending, Paid, Count }

    public partial class ReportUC : UserControl, ITab
    {
        public ReportUC()
        {
            InitializeComponent();
        }

        private void ReportUC_Load(object sender, EventArgs e)
        {
            comboFilterType.SelectedIndex = 0;

            comboFilterType.SelectedIndexChanged += comboFilterType_SelectedIndexChanged;
            dtFilter.ValueChanged += dtFilter_ValueChanged;
        }

        public void RefreshData()
        {

        }

        CancellationTokenSource regularSource = null;
        CancellationTokenSource chargedSource = null;

        string keyword = string.Empty;
        SaleStatusFilter statusFilter = SaleStatusFilter.Pending;

        public void CancelLoading()
        {
            TryCancelTokenSource(regularSource);
            TryCancelTokenSource(chargedSource);
        }

        bool TryCancelTokenSource(CancellationTokenSource source)
        {
            try
            {
                source?.Cancel();
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        public Control FirstControl()
        {
            return null;
        }

        public Button EnterButton()
        {
            return null;
        }

        public async Task InitializeAsync()
        {
            _chargedLoadingTask = LoadChargedAsync();
            var regT = setRegularTableByDate();

            //var setOther = Task.Run(() => {
            //    using (var p = new POSEntities()) {
            //        IEnumerable<Sale> charged = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString());
            //        decimal total = charged.Select(x => x.Remaining).DefaultIfEmpty(0).Sum();

            //        //toBeSettledTxt.InvokeIfRequired(() => { toBeSettledTxt.Text = string.Format("P {0:n}", total); });
            //    }
            //});

            await Task.WhenAll(_chargedLoadingTask, regT);
        }

        private void DefButton_Click(object sender, EventArgs e)
        {

        }

        private void saleTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var table = (DataGridView)sender;
            int index = (int)(table.SelectedCells[0].Value);

            using (var context = new POSEntities())
                if (!context.Sales.Any(x => x.Id == index))
                {
                    MessageBox.Show("Sale removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    table.Rows.RemoveAt(e.RowIndex);
                    return;
                }

            using (var saleDetails = new SaleDetails(index))
            {
                //saleDetails.SetId(index);
                saleDetails.OnSave += SaleDetails_OnSave;
                saleDetails.ShowDialog();
            }
        }

        private async void SaleDetails_OnSave(object sender, EventArgs e)
        {
            await LoadChargedAsync();
        }

        private async Task setRegularTableByDate()
        {

            regularSource = new CancellationTokenSource();

            using (var context = new POSEntities())
            {
                string type = SaleType.Regular.ToString();

                IQueryable<Sale> filteredSales = context.Sales.Where(x => x.SaleType == type);

                int index = 0;

                comboFilterType.InvokeIfRequired(() => { index = comboFilterType.SelectedIndex; });

                switch (index)
                {
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

                try
                {
                    saleTable.InvokeIfRequired(() => { saleTable.Rows.Clear(); });
                    var rows = await createRegularRow(filteredSales);

                    saleTable.InvokeIfRequired(() => { saleTable.Rows.AddRange(rows); });
                    totalSale.InvokeIfRequired(() => { totalSale.Text = "Total: " + string.Format("₱ {0:n}", filteredSales.ToArray().Sum(x => x.Total)); });

                    //Console.WriteLine("finished: Regular");
                }
                catch
                {
                    regularSource.Dispose();
                    regularSource = null;
                }
            }
        }
        private async Task<DataGridViewRow[]> createRegularRow(IEnumerable<Sale> sales)
        {
            var rows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                try
                {
                    foreach (var i in sales)
                    {
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

        private async Task LoadChargedAsync()
        {
            chargedSource = new CancellationTokenSource();
            var token = chargedSource.Token;

            try
            {
                using (var context = new POSEntities())
                {

                    var chargedSales = await GetChargedSalesAsync(context, token);

                    if (!chargedSales.Any())
                        return;

                    await AddRowsAsync(chargedSales, token);
                }
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {
                chargedSource.Dispose();
                chargedSource = null;
            }
        }

        DataGridViewRow CreateChargedRow(Sale sale)
        {

            var row = new DataGridViewRow();

            row.DefaultCellStyle.ForeColor = sale.FullyPaid ? Color.DarkGreen : sale.AmountRecieved == 0 ? Color.DarkRed : Color.Black;

            row.CreateCells(chargedTable,
                sale.Id,
                sale.Customer.Name,
                sale.Date.Value.ToString("MMM d, yyyy hh:mm tt"),
                string.Format("₱ {0:n}", sale.Total),
                string.Format("₱ {0:n}", sale.AmountRecieved),
                string.Format("₱ {0:n}", sale.Remaining),
                sale.Login?.Name ?? "--",
                sale.FullyPaid
            );

            return row;

        }

        private async Task AddRowsAsync(IEnumerable<Sale> sale, CancellationToken token)
        {

            chargedTable.Rows.Clear();

            await Task.Run(() =>
            {
                try
                {
                    foreach (var i in sale)
                    {
                        var row = CreateChargedRow(i);

                        token.ThrowIfCancellationRequested();

                        chargedTable.InvokeIfRequired(() => chargedTable.Rows.Add(row));
                    }
                }
                catch (OperationCanceledException)
                {

                }
            });
        }

        public async void Refresh_Callback(object sender, EventArgs e)
        {
            await LoadChargedAsync();
        }

        async Task<IEnumerable<Sale>> GetChargedSalesAsync(POSEntities context, CancellationToken token)
        {
            var chargedSales = await context.Sales
                .AsNoTracking()
                .AsQueryable()
                .Where(c => c.SaleType == SaleType.Charged.ToString())
                .FilterCharged(statusFilter)
                .FilterByName(keyword)
                .OrderByDescending(c => c.Date)
                .ToListAsync(token);

            return chargedSales;
        }

        private void comboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            switch (index)
            {
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

        private void dtFilter_ValueChanged(object sender, EventArgs e)
        {
            var s = setRegularTableByDate();
        }

        private void saleTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var s = setRegularTableByDate();
            }
        }

        private void chargedTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var s = LoadChargedAsync();
            }
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            e.SearchFound = true;
            keyword = e.Text;
            await StartNewChargedLoading();
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await StartNewChargedLoading();
        }

        private async void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {

                if (Enum.TryParse(rb.Text.Trim(), out SaleStatusFilter filter))
                {

                    statusFilter = filter;
                    await StartNewChargedLoading();
                }
            }
        }

        async Task StartNewChargedLoading()
        {
            //initiate cancellation
            TryCancelTokenSource(chargedSource);

            //wait until the laoding task is finished to avoid risidual rows 
            await _chargedLoadingTask;

            //start new laoding task
            _chargedLoadingTask = LoadChargedAsync();
        }

        Task _chargedLoadingTask = null;

        private void saleTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public static class SalesExtension
    {
        public static IQueryable<Sale> FilterCharged(this IQueryable<Sale> sales, SaleStatusFilter filter)
        {

            switch (filter)
            {
                case SaleStatusFilter.Paid:
                    return sales.Where(x => x.SoldItems.Sum(si => si.Quantity * (si.ItemPrice - si.Discount)) - x.AmountRecieved <= 0);
                case SaleStatusFilter.Pending:
                    return sales.Where(x => x.SoldItems.Sum(si => si.Quantity * (si.ItemPrice - si.Discount)) - x.AmountRecieved > 0);
            }

            return sales;
        }

        public static IQueryable<Sale> FilterByName(this IQueryable<Sale> sales, string keyword = "")
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return sales;
            return sales.Where(s => s.Customer.Name.Contains(keyword));
        }
    }
}
