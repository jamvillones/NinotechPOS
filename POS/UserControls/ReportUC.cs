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
            var regT = SetRegularTableByDate();
            await Task.WhenAll(_chargedLoadingTask, regT);
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
                //saleDetails.OnSave += SaleDetails_OnSave;
                if (saleDetails.ShowDialog() == DialogResult.OK)
                {
                    table.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private async void SaleDetails_OnSave(object sender, EventArgs e)
        {
            await LoadChargedAsync();
        }

        private async Task SetRegularTableByDate()
        {

            regularSource = new CancellationTokenSource();

            using (var context = new POSEntities())
            {
                string type = SaleType.Regular.ToString();

                IQueryable<Sale> filteredSales = context.Sales.AsNoTracking().AsQueryable().OrderByDescending(s => s.Date).Where(x => x.SaleType == type);

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
                    saleTable.Rows.Clear();
                    var rows = await CreateRegularRow(filteredSales);
                    saleTable.Rows.AddRange(rows);
                    totalSale.Text = "Total: " + filteredSales.ToArray().Sum(x => x.AmountDue).ToCurrency();
                }
                catch
                {
                    regularSource.Dispose();
                    regularSource = null;
                }
            }
        }

        private async Task<DataGridViewRow[]> CreateRegularRow(IEnumerable<Sale> sales)
        {
            var rows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                try
                {
                    foreach (var sale in sales)
                    {

                        if (regularSource.Token.IsCancellationRequested)
                            break;

                        DataGridViewRow row = saleTable.CreateRow(
                            sale.Id,
                            sale.Date.Value,
                            sale.Login.ToString(),
                            sale.Customer.ToString(),
                            sale.AmountDue
                            );
                        rows.Add(row);
                    }
                    //regularSource.Token.ThrowIfCancellationRequested();
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
                sale.Customer?.ToString(),
                sale.Date.Value,
                sale.AmountDue,
                sale.AmountRecieved,
                sale.Remaining,
                //string.Format("₱ {0:n}", sale.AmountDue),
                //string.Format("₱ {0:n}", sale.AmountRecieved),
                //string.Format("₱ {0:n}", sale.Remaining),
                sale.Login.ToString() ?? "--",
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

            var s = SetRegularTableByDate();
        }

        private void dtFilter_ValueChanged(object sender, EventArgs e)
        {
            var s = SetRegularTableByDate();
        }

        private void saleTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                var s = SetRegularTableByDate();
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
