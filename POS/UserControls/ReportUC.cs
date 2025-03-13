using Microsoft.Win32;
using POS.Forms;
using POS.Interfaces;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Json;
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
        CancellationTokenSource chargedCancellationSource = null;

        string keyword = string.Empty;
        SaleStatusFilter statusFilter = SaleStatusFilter.Pending;

        public void CancelLoading()
        {
            TryCancelTokenSource(regularSource);
            TryCancelTokenSource(chargedCancellationSource);
        }

        public void CancelChargedLoading()
        {
            try
            {
                chargedCancellationSource?.Cancel();
            }
            catch
            {

            }
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
            var chargedLoadingTask = LoadChargedAsync();
            var regularLoadingTask = SetRegularTableByDate();

            await Task.WhenAll(chargedLoadingTask, regularLoadingTask);
        }

        private async void ShowSale_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var table = (DataGridView)sender;
            int index = (int)(table.SelectedCells[0].Value);

            ///check if the entry is still available and not removed from other sources
            if (!await IsSaleStillPresent(index))
            {
                MessageBox.Show("Sale Cannot Be Found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                table.Rows.RemoveAt(e.RowIndex);
                return;
            }

            using (var saleDetails = new SaleDetails(index))
            {
                ///the result is okay when the sale is voided, thus entry on the table must also be removed
                if (saleDetails.ShowDialog() == DialogResult.OK)
                    table.Rows.RemoveAt(e.RowIndex);
            }
        }

        private async Task<bool> IsSaleStillPresent(int id)
        {
            try
            {
                using (var context = new POSEntities())
                    return await context.Sales.AnyAsync(x => x.Id == id);
            }
            catch (Exception)
            {

            }

            return true;
        }

        private async void SaleDetails_OnSave(object sender, EventArgs e)
        {
            await LoadChargedAsync();
        }

        private async Task SetRegularTableByDate()
        {

            regularSource = new CancellationTokenSource();

            try
            {


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
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        readonly Pagination pagination = new Pagination();
        bool isOldEntries = false;
        bool IsBusyLoading = false;

        public bool IsOldEntries
        {
            get => isOldEntries;
            set
            {
                isOldEntries = value;
                if (!isOldEntries)
                    chargedTable.Rows.Clear();

            }
        }

        private async Task LoadChargedAsync()
        {
            IsBusyLoading = true;
            loadingLabel.Visible = true;
            Console.WriteLine("-------Charged Loading Started: " + DateTime.Now);

            chargedCancellationSource = new CancellationTokenSource();
            var token = chargedCancellationSource.Token;

            try
            {
                using (var context = new POSEntities())
                {
                    var unpaginatedList = context.Sales
                                      .AsNoTracking()
                                      .AsQueryable()
                                      .Where(c => c.SaleType == SaleType.Charged.ToString())
                                      .FilterCharged(statusFilter)
                                      .FilterByKeyword(keyword);

                    if (!IsOldEntries)
                    {
                        int totalItemCount = await unpaginatedList.CountAsync(token);
                        pagination.Initialize(totalItemCount);
                        IsOldEntries = true;
                    }

                    var task_Loading = unpaginatedList
                                       .OrderByDescending(c => c.Date)
                                       .Skip(pagination.Start).Take(pagination.PageSize)
                                       .ToListAsync(token);

                    var task_minimumLoadingTime = Task.Delay(500, token);

                    await Task.WhenAll(task_Loading, task_minimumLoadingTime);
                    var chargedSales = task_Loading.Result;

                    token.ThrowIfCancellationRequested();

                    if (chargedSales.Count == 0 && !string.IsNullOrWhiteSpace(keyword))
                        MessageBox.Show("No Results Found!", "Charged Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        chargedTable.Rows.AddRange(chargedSales.Select(CreateChargedRow).ToArray());
                }
            }
            catch (OperationCanceledException) { Console.WriteLine("-------Charged Loading Cancelled-------"); }
            catch { }
            finally
            {
                chargedCancellationSource?.Dispose();
                chargedCancellationSource = null;
            }

            loadingLabel.Visible = false;
            IsBusyLoading = false;

            itemCount.Text = chargedTable.Rows.Count.ToString();
            Console.WriteLine("-------Charged Loading Finished: " + DateTime.Now);
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
                sale.Login.ToString() ?? "--",
                sale.FullyPaid
            );

            return row;

        }

        public async void Refresh_Callback(object sender, EventArgs e)
        {
            await LoadChargedAsync();
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

            _ = SetRegularTableByDate();
        }

        private void dtFilter_ValueChanged(object sender, EventArgs e)
        {
            _ = SetRegularTableByDate();
        }

        private void saleTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                _ = SetRegularTableByDate();
            }
        }

        private void chargedTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                _ = LoadChargedAsync();
            }
        }

        private async void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            searchingIndicator.Text = "Searching...";
            e.SearchFound = true;

            keyword = e.Text;

            IsOldEntries = false;
            CancelChargedLoading();

            await LoadChargedAsync();
            searchingIndicator.Text = string.Empty;
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;

            IsOldEntries = false;
            CancelChargedLoading();

            await LoadChargedAsync();
        }

        private async void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                if (Enum.TryParse(rb.Text.Trim(), out SaleStatusFilter filter))
                {
                    statusFilter = filter;

                    IsOldEntries = false;
                    CancelChargedLoading();

                    await LoadChargedAsync();
                }
            }
        }

        private async void chargedTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (sender is DataGridView dgv && dgv.IsScrolledToBottom())
            {
                if (!IsBusyLoading && pagination.CanNext)
                {
                    pagination.Next();
                    await LoadChargedAsync();
                }
            }
        }
    }

    public static class SalesExtension
    {
        /// <summary>
        /// filters charged by its status (paid,pending, and all)
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
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

        /// <summary>
        /// tries to search for sale id or customer name for the sale
        /// </summary>
        /// <param name="sales"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<Sale> FilterByKeyword(this IQueryable<Sale> sales, string keyword = "")
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return sales;

            if (int.TryParse(keyword, out int id))
                return sales.Where(s => s.Id == id);

            return sales.Where(s => s.Customer.Name.Contains(keyword));
        }
    }
}
