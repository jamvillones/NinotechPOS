using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class StockinLog : Form {
        public StockinLog() {
            InitializeComponent();

            regular_Dt.MaxDate = DateTime.Now;
            range_from_Dt.MaxDate = DateTime.Now;
            range_to_Dt.MaxDate = DateTime.Now;
        }

        bool InRangeMode => radioButton5.Checked;

        private string keyword = string.Empty;
        private DateTime Date => regular_Dt.Value.Date;

        private DateTime From_Date => range_from_Dt.Value.Date;

        private DateTime To_Date => new DateTime(
                            range_to_Dt.Value.Year,
                            range_to_Dt.Value.Month,
                            range_to_Dt.Value.Day,
                            23, 59, 59);


        public DateFilterMode filterMode = DateFilterMode.Daily;

        private CancellationTokenSource CancelSource = null;

        private async void StockinLog_Load(object sender, EventArgs e) {
            var init = Task.Run(() => {
                using (var p = new POSEntities()) {
                    var namegroup = p.StockinHistories.GroupBy(x => x.ItemName);
                    searchControl1.InvokeIfRequired(() => searchControl1.SetAutoComplete(namegroup.Select(x => x.Key).ToArray()));
                }
            });

            var tableInit = LoadDataAsync();

            await Task.WhenAll(init, tableInit);
        }

        bool TryCancelCurrentOperation() {
            try {
                CancelSource?.Cancel();
                return true;
            }
            catch (ObjectDisposedException) {

                return false;
            }

        }

        private async Task LoadDataAsync() {

            TryCancelCurrentOperation();

            CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;

            try {

                using (var p = new POSEntities()) {
                    var stockins = p.StockinHistories
                        .AsNoTracking()
                        .FilterByKeyword(keyword)
                        .AsQueryable();

                    stockins = (InRangeMode ? stockins.FilterByDateRange(From_Date, To_Date) :
                                              stockins.FilterByDate(Date, filterMode))
                        .OrderByDescending(x => x.Date)
                            .ThenBy(s => s.ItemName);

                    var finalResult = await stockins.ToListAsync();

                    histTable.InvokeIfRequired(() => histTable.Rows.Clear());

                    var rows = finalResult
                        .Select(CreateRow)
                        .ToArray();

                    token.ThrowIfCancellationRequested();

                    histTable.InvokeIfRequired(() => histTable.Rows.AddRange(rows));
                    _totalCost.Text = string.Format("₱ {0:n}", finalResult.Select(x => x.Cost * x.Quantity).Sum());
                }
            }
            catch (OperationCanceledException) {

            }
            finally {
                CancelSource.Dispose();
            }
        }

        private DataGridViewRow CreateRow(StockinHistory stockinHistory) {
            var row = new DataGridViewRow();

            row.CreateCells(histTable,
                       stockinHistory.Id,
                       stockinHistory.Date.Value.ToString("MMM d, yyyy hh:mm tt"),
                       stockinHistory.LoginUsername,
                       stockinHistory.ItemName,
                       stockinHistory.SerialNumber,
                       stockinHistory.Quantity?.ToString("N0"),
                       string.Format("₱ {0:n}", stockinHistory.Cost),
                       stockinHistory.Supplier,
                       "Undo"
                       );

            return row;
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e) {
            keyword = e.Text;

            await LoadDataAsync();

            e.SearchFound = true;

            if (histTable.RowCount == 0) {
                MessageBox.Show("No entries found.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        private async void datePicker_ValueChanged(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        private async void all_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {

                filterMode = DateFilterMode.All;
                regular_Dt.Visible = false;

                await LoadDataAsync();
            }
        }

        private async void annually_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Annually;
                regular_Dt.CustomFormat = "yyyy";
                regular_Dt.Visible = true;

                await LoadDataAsync();
            }
        }

        private async void monthly_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Monthly;
                regular_Dt.CustomFormat = "MMM yyyy";
                regular_Dt.Visible = true;

                await LoadDataAsync();
            }
        }

        private async void daily_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Daily;
                regular_Dt.CustomFormat = "MMM d, yyyy";
                regular_Dt.Visible = true;

                await LoadDataAsync();
            }
        }

        private async void dateRange_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb) {
                if (rb.Checked) {
                    regular_Dt.Visible = false;
                    dateRangeHolder.Visible = true;

                    await LoadDataAsync();
                }
                else
                    dateRangeHolder.Visible = false;

            }
        }

        bool preventFrom = false;
        private async void range_to_Dt_ValueChanged(object sender, EventArgs e) {
            ///this makes sure that the from event doesnt trigger a load
            preventFrom = true;
            range_from_Dt.MaxDate = range_to_Dt.Value.Date;
            preventFrom = false;

            await LoadDataAsync();
        }

        private async void range_from_Dt_ValueChanged(object sender, EventArgs e) {
            if (preventFrom)
                return;

            await LoadDataAsync();
        }

        private async void histTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.RowIndex == -1 || e.ColumnIndex != col_removeBtn.Index) return;

            var login = UserManager.instance.currentLogin;

            if (!login.CanEditInventory) {
                MessageBox.Show("You do not have permission to undo stockin.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure you want to undo this stockin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            var id = histTable.GetSelectedId();

            using (var context = new POSEntities()) {
                var stockin = await context.StockinHistories.FirstOrDefaultAsync(x => x.Id == id);

                ///with serial
                if (!string.IsNullOrWhiteSpace(stockin.SerialNumber)) {
                    var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.SerialNumber == stockin.SerialNumber);
                    if (invItem != null) {
                        context.InventoryItems.Remove(invItem);
                    }
                    else {
                        MessageBox.Show("This stockin cannot be undone!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                }
                else {
                    var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.ProductId == stockin.ProductId);
                    if (invItem != null || invItem.Quantity >= stockin.Quantity) {
                        invItem.Quantity -= (int)stockin.Quantity;
                        if (invItem.Quantity <= 0)
                            context.InventoryItems.Remove(invItem);
                    }
                    else {
                        MessageBox.Show(
                            "The amount of stock-in you are trying to revoke exceeds the current stock quantity. Please make sure to undo the correct stockin entry.",
                            "Stockin Correction Terminated.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning); return;
                    }
                }

                context.StockinHistories.Remove(stockin);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Stockin successfully undone.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            histTable.Rows.RemoveAt(histTable.DataGridViewCurrentRowIndex());
        }
    }
    public static class StockinExtension {
        public static IQueryable<StockinHistory> FilterByDate(
            this IQueryable<StockinHistory> stockins,
            DateTime dateSelected,
            DateFilterMode filterMode) {

            switch (filterMode) {
                case DateFilterMode.Daily:
                    return stockins.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                              s.Date.Value.Month == dateSelected.Month &&
                                              s.Date.Value.Day == dateSelected.Day);
                case DateFilterMode.Monthly:
                    return stockins.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                             s.Date.Value.Month == dateSelected.Month);
                case DateFilterMode.Annually:
                    return stockins.Where(s => s.Date.Value.Year == dateSelected.Year);
                default:
                    return stockins;

            }
        }

        public static IQueryable<StockinHistory> FilterByDateRange(
           this IQueryable<StockinHistory> stockins,
           DateTime from,
           DateTime to) => stockins.Where(s => s.Date >= from && s.Date <= to);


        public static IQueryable<StockinHistory> FilterByKeyword(
            this IQueryable<StockinHistory> stockins,
            string keyword = "") {

            if (string.IsNullOrWhiteSpace(keyword))
                return stockins;

            return stockins.Where(s => s.ItemName.Contains(keyword));
        }
    }
}
