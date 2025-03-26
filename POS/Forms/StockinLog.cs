using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class StockinLog : Form
    {
        public StockinLog()
        {
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

        private async void StockinLog_Load(object sender, EventArgs e) => await LoadDataAsync();

        bool TryCancelCurrentOperation()
        {
            try
            {
                CancelSource?.Cancel();
                return true;
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        private async Task<bool> LoadDataAsync()
        {

            TryCancelCurrentOperation();

            CancelSource = new CancellationTokenSource();
            var token = CancelSource.Token;

            bool ResultsFound = false;
            try
            {
                using (var p = new POSEntities())
                {
                    var stockIns = p.StockinHistories
                        .AsNoTracking()
                        .AsQueryable()
                        .FilterByKeyword(keyword);

                    stockIns = (InRangeMode ? stockIns.FilterByDateRange(From_Date, To_Date) :
                                              stockIns.FilterByDate(Date, filterMode))
                        .OrderByDescending(x => x.Date)
                            .ThenBy(s => s.ItemName);

                    var finalResult = await stockIns.ToListAsync();


                    ResultsFound = finalResult.Count > 0;

                    if (ResultsFound)
                    {
                        historyTable.Rows.Clear();
                        token.ThrowIfCancellationRequested();
                        historyTable.Rows.AddRange(finalResult.Select(CreateRow).ToArray());
                        _totalCost.Text = ((decimal)(finalResult.Select(x => x.Cost * x.Quantity).Sum())).ToString("C2");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            finally
            {
                CancelSource.Dispose();
            }

            return ResultsFound;
        }

        private DataGridViewRow CreateRow(StockinHistory stockInHistory)
        {
            var row = new DataGridViewRow();

            row.CreateCells(historyTable,
                       stockInHistory.Id,
                       stockInHistory.Date.Value,
                       stockInHistory.LoginUsername,
                       stockInHistory.Product?.ToString() ?? stockInHistory.ItemName,
                       stockInHistory.SerialNumber,
                       stockInHistory.Quantity,
                       stockInHistory.Cost
                       );

            return row;
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
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
            keyword = string.Empty;
            await LoadDataAsync();
        }

        private async void datePicker_ValueChanged(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void all_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {

                filterMode = DateFilterMode.All;
                regular_Dt.Visible = false;

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

                    await LoadDataAsync();
                }
                else
                    dateRangeHolder.Visible = false;
            }
        }

        bool preventFrom = false;
        private async void range_to_Dt_ValueChanged(object sender, EventArgs e)
        {
            ///this makes sure that the from event doesnt trigger a load
            preventFrom = true;
            range_from_Dt.MaxDate = range_to_Dt.Value.Date;
            preventFrom = false;

            await LoadDataAsync();
        }

        private async void range_from_Dt_ValueChanged(object sender, EventArgs e)
        {
            if (preventFrom)
                return;

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
                using (var context = new POSEntities())
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
                using (var context = new POSEntities())
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
                    invItem.Quantity -= stockIn.Quantity;
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

            return stockIns.Where(s => s.ItemName.Contains(keyword) || s.Product.Item.Name.Contains(keyword) || s.SerialNumber.Contains(keyword));
        }
    }
}
