using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class StockinLog : Form {
        public StockinLog() {
            InitializeComponent();

            //dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        //bool InRangeMode => dateTimePicker2.Checked && dateTimePicker1.Value.Date != dateTimePicker2.Value.Date;

        private string keyword = string.Empty;
        private DateTime From_Date => dateTimePicker1.Value.Date;
        //private DateTime To_Date {
        //    get {
        //        switch (filterMode) {
        //            case DateFilterMode.Monthly:
        //                return new DateTime(
        //                    dateTimePicker2.Value.Year,
        //                    dateTimePicker2.Value.Month,
        //                    DateTime.DaysInMonth(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month),
        //                    23, 59, 59);
        //            case DateFilterMode.Annually:
        //                return new DateTime(dateTimePicker2.Value.Year,
        //                    12,
        //                    DateTime.DaysInMonth(dateTimePicker2.Value.Year, dateTimePicker2.Value.Month),
        //                    23, 59, 59);
        //            default:
        //                return dateTimePicker2.Value;
        //        }
        //    }
        //}

        public DateFilterMode filterMode = DateFilterMode.Daily;

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

        private async Task LoadDataAsync() {
            using (var p = new POSEntities()) {
                var stockins = await p.StockinHistories
                    .AsNoTracking()
                    .FilterByKeyword(keyword)
                    .FilterByDate(From_Date, filterMode)
                    .OrderByDescending(s => s.Date)
                        .ThenBy(s => s.ItemName)
                    .AsQueryable()
                    .ToListAsync();

                histTable.InvokeIfRequired(() => histTable.Rows.Clear());

                var rows = stockins
                    .Select(CreateRow)
                    .ToArray();

                histTable.InvokeIfRequired(() => histTable.Rows.AddRange(rows));
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

        private async void dateTimePicker2_ValueChanged(object sender, EventArgs e) {
            await LoadDataAsync();
        }

        void DecreaseInventory(POSEntities p, int quantity, InventoryItem i) {
            i.Quantity -= quantity;
            if (i.Quantity <= 0)
                p.InventoryItems.Remove(i);
        }

        void DecreaseStockinHist(POSEntities p, int quanity, StockinHistory st) {
            st.Quantity -= quanity;
            if (st.Quantity <= 0)
                p.StockinHistories.Remove(st);
        }
        void updateTable(int rowIndex, int toMinus) {
            var row = histTable.Rows[rowIndex];
            var q = (int)row.Cells[5].Value;
            q -= toMinus;

            if (q <= 0) {
                histTable.Rows.RemoveAt(rowIndex);
                return;
            }

            row.Cells[5].Value = q;
        }

        private async void all_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.All;
                dateTimePicker1.Visible = false;
                await LoadDataAsync();
            }
        }

        private async void annually_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Annually;
                dateTimePicker1.CustomFormat = "yyyy";
                dateTimePicker1.Visible = true;
                await LoadDataAsync();
            }
        }

        private async void monthly_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Monthly;
                dateTimePicker1.CustomFormat = "MMM yyyy";
                dateTimePicker1.Visible = true;
                await LoadDataAsync();
            }
        }

        private async void daily_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                filterMode = DateFilterMode.Daily;
                dateTimePicker1.CustomFormat = "MMM d, yyyy";
                dateTimePicker1.Visible = true;
                await LoadDataAsync();
            }
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

        public static IQueryable<StockinHistory> FilterByKeyword(
            this IQueryable<StockinHistory> stockins,
            string keyword = "") {

            if (string.IsNullOrWhiteSpace(keyword))
                return stockins;

            return stockins.Where(s => s.ItemName.Contains(keyword));
        }
    }
}
