using POS.Misc;
using POS.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class StockInLog : Form
    {
        public StockInLog()
        {
            InitializeComponent();

            regular_Dt.MaxDate = DateTime.Now;
            range_from_Dt.MaxDate = DateTime.Now;
            range_to_Dt.MaxDate = DateTime.Now;

            col_Id.Visible = UserManager.instance.IsAdmin;
            label3.Visible = UserManager.instance.CurrentLogin.CanEditInventory;
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

        private async void StockInLog_Load(object sender, EventArgs e) => await LoadDataAsync();

        bool TryCancelCurrentOperation()
        {
            try
            {
                IsTotalEntriesInitialized = false;

                CancelSource?.Cancel();
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        private class StockInHistoryDTO
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string User { get; set; }
            public string Name { get; set; }
            public string SerialNumber { get; set; }
            public int Qty { get; set; }
            public decimal Cost { get; set; }
        }

        readonly Pagination pagination = new Pagination();

        public bool IsTotalEntriesInitialized
        {
            get => isTotalEntriesInitialized;
            private set
            {
                isTotalEntriesInitialized = value;

                if (!IsTotalEntriesInitialized)
                    historyTable.Rows.Clear();
            }
        }

        public bool IsBusyLoading { get; private set; }

        private int entryCount;
        /// <summary>
        /// Total Count Current Rows Displayed
        /// </summary>
        public int EntryCount
        {
            get { return entryCount; }
            set
            {
                entryCount = value;
                countLabel.Text = $"{entryCount:N0} / {totalCount:N0}";
            }
        }

        private int totalCount;
        /// <summary>
        /// Total entries for the given parameters enabled
        /// </summary>
        public int TotalCount
        {
            get { return totalCount; }
            set
            {
                totalCount = value;
                countLabel.Text = $"{entryCount:N0} / {totalCount:N0}";
            }
        }

        private async Task<bool> LoadDataAsync()
        {
            CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;

            bool ResultsFound = false;
            IsBusyLoading = true;

            try
            {
                using (var context = POSEntities.Create())
                {
                    var stockIns = context.StockinHistories
                        .AsNoTracking()
                        .AsQueryable()
                        .FilterByKeyword(keyword);

                    stockIns = (InRangeMode ? stockIns.FilterByDateRange(From_Date, To_Date) :
                                              stockIns.FilterByDate(Date, filterMode))
                        .OrderByDescending(x => x.Date)
                            .ThenBy(s => s.ItemName);

                    if (!IsTotalEntriesInitialized)
                    {
                        //get the total count of entries
                        int totalItems = await stockIns.CountAsync(token);

                        TotalCount = totalItems;

                        //initialize the pagination
                        pagination.Initialize(totalItems, 500);
                        //ensure one time initialization of pagination
                        IsTotalEntriesInitialized = true;
                    }

                    var loadingTask = stockIns
                                    .Skip(pagination.Start).Take(pagination.PageSize)
                                    .Select(sth => new StockInHistoryDTO()
                                    {
                                        Id = sth.Id,
                                        Date = (DateTime)sth.Date,
                                        User = sth.LoginUsername,
                                        Name = sth.Product.Item.Name,
                                        SerialNumber = sth.SerialNumber,
                                        Qty = (int)sth.Quantity,
                                        Cost = (decimal)sth.Cost
                                    }).ToListAsync();

                    await Task.WhenAll(loadingTask, Task.Delay(500));

                    var finalResult = loadingTask.Result;
                    ResultsFound = finalResult.Count > 0;

                    if (ResultsFound)
                    {
                        token.ThrowIfCancellationRequested();

                        historyTable.Rows.AddRange(finalResult.Select(CreateRow).ToArray());
                        _totalCost.Text = finalResult.Select(x => x.Cost * x.Qty).Sum().ToString("C2");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Not Established!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CancelSource.Dispose();

                IsBusyLoading = false;

                EntryCount = historyTable.RowCount;
            }

            return ResultsFound;
        }



        private DataGridViewRow CreateRow(StockInHistoryDTO stockInHistory)
        {
            var row = new DataGridViewRow();

            row.CreateCells(historyTable,
                      stockInHistory.Id,
                      stockInHistory.Date,
                      stockInHistory.User,
                      stockInHistory.Name,
                      stockInHistory.SerialNumber,
                      stockInHistory.Qty,
                      stockInHistory.Cost
                      );

            return row;
        }

        private async void itemsTable_Scroll(object sender, ScrollEventArgs e)
        {
            if (sender is DataGridView dgv && dgv.IsScrolledToBottom())
            {
                if (!IsBusyLoading && pagination.CanNext)
                {
                    pagination.Next();
                    await LoadDataAsync();
                }
            }
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            TryCancelCurrentOperation();
            keyword = e.Text;
            bool found = await LoadDataAsync();
            //e.SearchFound = await LoadDataAsync();

            if (!found)
            {
                MessageBox.Show("No Entries Found", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            TryCancelCurrentOperation();

            keyword = string.Empty;
            await LoadDataAsync();
        }

        private async void datePicker_ValueChanged(object sender, EventArgs e)
        {
            TryCancelCurrentOperation();
            await LoadDataAsync();
        }

        private async void all_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {

                filterMode = DateFilterMode.All;
                regular_Dt.Visible = false;

                TryCancelCurrentOperation();

                await LoadDataAsync();
            }
        }

        private async void annually_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                filterMode = DateFilterMode.Annually;
                regular_Dt.CustomFormat = "yyyy";
                regular_Dt.Visible = true;

                TryCancelCurrentOperation();

                await LoadDataAsync();
            }
        }

        private async void monthly_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                filterMode = DateFilterMode.Monthly;
                regular_Dt.CustomFormat = "MMM yyyy";
                regular_Dt.Visible = true;

                TryCancelCurrentOperation();

                await LoadDataAsync();
            }
        }

        private async void daily_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                filterMode = DateFilterMode.Daily;
                regular_Dt.CustomFormat = "MMM d, yyyy";
                regular_Dt.Visible = true;
                TryCancelCurrentOperation();



                await LoadDataAsync();
            }
        }

        private async void dateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb)
            {
                if (rb.Checked)
                {
                    regular_Dt.Visible = false;
                    dateRangeHolder.Visible = true;

                    TryCancelCurrentOperation();

                    await LoadDataAsync();
                }
                else
                    dateRangeHolder.Visible = false;
            }
        }

        bool preventFrom = false;

        private bool isTotalEntriesInitialized = false;

        private async void range_to_Dt_ValueChanged(object sender, EventArgs e)
        {
            ///this makes sure that the from event doesnt trigger a load
            preventFrom = true;
            range_from_Dt.MaxDate = range_to_Dt.Value.Date;
            preventFrom = false;

            TryCancelCurrentOperation();

            await LoadDataAsync();
        }

        private async void range_from_Dt_ValueChanged(object sender, EventArgs e)
        {
            if (preventFrom)
                return;

            TryCancelCurrentOperation();

            await LoadDataAsync();
        }



        private async void historyTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == col_Cost.Index)
            {
                if (!UserManager.instance.IsAdmin)
                    return;

                decimal oldCost = (decimal)historyTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                decimal newCost = 0;

                using (var costForm = new EditCostForm(oldCost))
                {
                    if (costForm.ShowDialog() == DialogResult.OK)
                        newCost = costForm.Cost;
                    else
                        return;
                }

                await ChangeCostForStockInEntry(historyTable.GetSelectedId(), newCost);

                historyTable[e.ColumnIndex, e.RowIndex].Value = newCost;

                return;
            }
        }

        async Task ChangeCostForStockInEntry(int _id, decimal updatedCost)
        {

            try
            {
                using (var context = POSEntities.Create())
                {
                    var entity = await context.StockinHistories.FirstOrDefaultAsync(x => x.Id == _id);
                    entity.Cost = updatedCost;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void histTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            await UndoSelectedStockIns();
        }

        private async Task UndoSelectedStockIns()
        {
            if (historyTable.SelectedRows.Count == 0)
                return;

            var login = UserManager.instance.CurrentLogin;
            if (!login.CanEditInventory)
            {
                MessageBox.Show("You do not have permission to undo Stock-Ins.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure you want to undo this selected item/s?", "Undo Stock-Ins", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var selectedIds = historyTable.GetSelectedIds<int>(out IEnumerable<DataGridViewRow> selectedRows);

            try
            {
                using (var context = POSEntities.Create())
                {
                    var toUndoItems = context.StockinHistories.Where(st => selectedIds.Any(id => id == st.Id));
                    if (toUndoItems.Count() > 0)
                    {
                        foreach (var st in toUndoItems)
                            await context.HandleInventoryItemForStockInHistoryUndo(st);

                        context.StockinHistories.RemoveRange(toUndoItems);
                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (UndoStockInFailedException)
            {
                ShowStockInFailedMessage();
                return;
            }
            catch (Exception)
            {
                return;
            }

            foreach (var row in selectedRows)
                historyTable.Rows.Remove(row);
        }

        void ShowStockInFailedMessage()
        {
            MessageBox.Show("The amount of stock-in you are trying to revoke exceeds the current stock quantity or The Item is already sold and no longer in INVENTORY.",
                            "Undo Stock-In Terminated.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }
    }

    public class UndoStockInFailedException : Exception
    { }

    public static class StockInExtension
    {
        public static IQueryable<StockinHistory> FilterByDate(
            this IQueryable<StockinHistory> stockIns,
            DateTime dateSelected,
            DateFilterMode filterMode)
        {

            switch (filterMode)
            {
                case DateFilterMode.Daily:
                    return stockIns.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                              s.Date.Value.Month == dateSelected.Month &&
                                              s.Date.Value.Day == dateSelected.Day);
                case DateFilterMode.Monthly:
                    return stockIns.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                             s.Date.Value.Month == dateSelected.Month);
                case DateFilterMode.Annually:
                    return stockIns.Where(s => s.Date.Value.Year == dateSelected.Year);
                default:
                    return stockIns;
            }
        }

        public static async Task HandleInventoryItemForStockInHistoryUndo(this POSEntities context, StockinHistory stockIn)
        {
            ///with serial
            if (!string.IsNullOrWhiteSpace(stockIn.SerialNumber))
            {
                var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.SerialNumber == stockIn.SerialNumber);

                if (invItem != null)
                    context.InventoryItems.Remove(invItem);

                else throw new UndoStockInFailedException();
            }
            else
            {
                var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.ProductId == stockIn.ProductId);

                if (invItem != null && invItem.Quantity >= stockIn.Quantity)
                {
                    invItem.Quantity -= (int)stockIn.Quantity;
                    if (invItem.Quantity <= 0)
                        context.InventoryItems.Remove(invItem);
                }
                else throw new UndoStockInFailedException();
            }
        }

        public static IQueryable<StockinHistory> FilterByDateRange(
           this IQueryable<StockinHistory> stockIns,
           DateTime from,
           DateTime to) => stockIns.Where(s => s.Date >= from && s.Date <= to);

        public static IQueryable<StockinHistory> FilterByKeyword(
            this IQueryable<StockinHistory> stockIns,
            string keyword = "")
        {

            if (string.IsNullOrWhiteSpace(keyword))
                return stockIns;

            return stockIns.Where(s =>
                s.Product.Item.Barcode == keyword ||
                s.ItemName.Contains(keyword) ||
                s.Product.Item.Name.Contains(keyword) ||
                s.SerialNumber.Contains(keyword))
                ;
        }
    }
}
