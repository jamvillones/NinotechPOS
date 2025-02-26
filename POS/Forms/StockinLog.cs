﻿using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
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

        private async void StockinLog_Load(object sender, EventArgs e) =>
            await LoadDataAsync();


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
                    var stockins = p.StockinHistories
                        .AsNoTracking()
                        .FilterByKeyword(keyword)
                        .AsQueryable();

                    stockins = (InRangeMode ? stockins.FilterByDateRange(From_Date, To_Date) :
                                              stockins.FilterByDate(Date, filterMode))
                        .OrderByDescending(x => x.Date)
                            .ThenBy(s => s.ItemName);

                    var finalResult = await stockins.ToListAsync();

                    histTable.Rows.Clear();

                    ResultsFound = finalResult.Count > 0;

                    if (ResultsFound)
                    {
                        token.ThrowIfCancellationRequested();

                        await Task.Run(() =>
                        {
                            foreach (var row in finalResult)
                            {
                                if (token.IsCancellationRequested) break;
                                histTable.InvokeIfRequired(() => histTable.Rows.Add(CreateRow(row)));
                            }
                        });

                        _totalCost.Text = string.Format("₱ {0:n}", finalResult.Select(x => x.Cost * x.Quantity).Sum());
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

        private DataGridViewRow CreateRow(StockinHistory stockinHistory)
        {
            var row = new DataGridViewRow();

            row.CreateCells(histTable,
                       stockinHistory.Id,
                       stockinHistory.Date.Value,
                       stockinHistory.LoginUsername,
                       stockinHistory.ItemName,
                       stockinHistory.SerialNumber,
                       stockinHistory.Quantity,
                       stockinHistory.Cost,
                       stockinHistory.Supplier,
                       "Undo"
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

        void ShowStockinFailedMessage()
        {
            MessageBox.Show("The amount of stock-in you are trying to revoke exceeds the current stock quantity. Please make sure to undo the correct stockin entry.",
                            "Stockin Correction Terminated.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private async void histTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (e.ColumnIndex == col_removeBtn.Index)
            {
                await UndoStockinForEntry(histTable.GetSelectedId());
                return;
            }

            if (e.ColumnIndex == col_Cost.Index)
            {
                if (!UserManager.instance.IsAdmin)
                    return;

                decimal oldCost = (decimal)histTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                decimal newCost = 0;

                using (var costForm = new EditCostForm(oldCost))
                {
                    if (costForm.ShowDialog() == DialogResult.OK)
                        newCost = costForm.Cost;
                    else
                        return;
                }

                await ChangeCostForStockinEntry(histTable.GetSelectedId(), newCost);

                histTable[e.ColumnIndex, e.RowIndex].Value = newCost;

                return;
            }
        }

        async Task UndoStockinForEntry(int _id)
        {
            var login = UserManager.instance.CurrentLogin;

            if (!login.CanEditInventory)
            {
                MessageBox.Show("You do not have permission to undo stockin.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Are you sure you want to undo this stockin?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            var id = _id;

            using (var context = new POSEntities())
            {
                var stockin = await context.StockinHistories.FirstOrDefaultAsync(x => x.Id == id);

                ///with serial
                if (!string.IsNullOrWhiteSpace(stockin.SerialNumber))
                {
                    var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.SerialNumber == stockin.SerialNumber);
                    if (invItem != null)
                    {
                        context.InventoryItems.Remove(invItem);
                    }
                    else
                    {
                        ShowStockinFailedMessage();
                        return;
                    }
                }
                else
                {
                    var invItem = await context.InventoryItems.FirstOrDefaultAsync(x => x.ProductId == stockin.ProductId);

                    if (invItem != null || invItem.Quantity >= stockin.Quantity)
                    {
                        invItem.Quantity -= (int)stockin.Quantity;
                        if (invItem.Quantity <= 0)
                            context.InventoryItems.Remove(invItem);
                    }
                    else
                    {
                        ShowStockinFailedMessage();
                        return;
                    }
                }

                context.StockinHistories.Remove(stockin);
                await context.SaveChangesAsync();
            }

            MessageBox.Show("Stockin successfully undone.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            histTable.Rows.RemoveAt(histTable.DataGridViewCurrentRowIndex());
        }

        async Task ChangeCostForStockinEntry(int _id, decimal updatedCost)
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
    }

    public static class StockinExtension
    {
        public static IQueryable<StockinHistory> FilterByDate(
            this IQueryable<StockinHistory> stockins,
            DateTime dateSelected,
            DateFilterMode filterMode)
        {

            switch (filterMode)
            {
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
            string keyword = "")
        {

            if (string.IsNullOrWhiteSpace(keyword))
                return stockins;

            return stockins.Where(s => s.ItemName.Contains(keyword) || s.SerialNumber.Contains(keyword));
        }
    }
}
