using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;

namespace POS.UserControls {
    public partial class InventorySnapshot_Graph : UserControl, ILoadable {
        public InventorySnapshot_Graph() {
            InitializeComponent();

            IsSettingYear = true;
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            IsSettingYear = false;

        }

        private async void DateTimePicker1_ValueChanged(object sender, EventArgs e) {
            TryCancel();

            await Initialize_Async();
        }

        bool IsSettingYear = false;

        CancellationTokenSource source = null;
        public async Task Initialize_Async() {
            if (IsSettingYear)
                return;

            source = new CancellationTokenSource();
            var token = source.Token;
            int selectedYear = dateTimePicker1.Value.Year;
            int selectedMonth = dateTimePicker1.Value.Month;


            chart1.Series[0].LegendText = radioButton1.Checked ? selectedYear.ToString() : CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(selectedMonth) + " " + selectedYear.ToString();
            chart1.Series[0].Points.Clear();

            try {
                using (var context = new POSEntities()) {

                    int upTo = radioButton1.Checked ? selectedYear == DateTime.Today.Year ? DateTime.Today.Month : 12
                        : selectedYear == DateTime.Today.Year && selectedMonth == DateTime.Today.Month ? DateTime.Today.Day : DateTime.DaysInMonth(selectedYear, selectedMonth);

                    for (var i = 1; i <= upTo; i++) {
                        DateTime CurrentDate = radioButton1.Checked ? GetUpToMonth(selectedYear, i) : GetUpToDay(selectedYear, selectedMonth, i);

                        var currentInventoryValue = await GetValueAsOfDate(
                            context.Products
                            .AsNoTracking()
                            .AsQueryable()
                            .Where(x => x.Item.Type == ItemType.Quantifiable.ToString()),
                            CurrentDate, token);

                        token.ThrowIfCancellationRequested();

                        var point = new DataPoint() {
                            Label = currentInventoryValue.ToCurrency(),
                            XValue = i,
                            AxisLabel = radioButton1.Checked ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i) : i.ToString()
                        };

                        point.SetValueY(currentInventoryValue.ToCurrency());

                        chart1.Series[0].Points.Add(point);
                    }
                }

            }
            catch (Exception) {

            }
            finally {
                source?.Dispose();
            }
        }

        DateTime GetUpToDay(int year, int month, int day) {
            return new DateTime()
                .AddYears(year - 1)
                .AddMonths(month - 1)
                .AddDays(day - 1)
                .AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);
        }

        DateTime GetUpToMonth(int year, int month) {
            return new DateTime()
                .AddYears(year - 1)
                    .AddMonths(month - 1)
                        .AddDays(DateTime.DaysInMonth(year, month) - 1)
                .AddHours(23)
                    .AddMinutes(59)
                        .AddSeconds(59)
                            .AddMilliseconds(999);
        }

        async Task<decimal> GetValueAsOfDate(IQueryable<Product> products, DateTime upTo, CancellationToken cancelToken) {
            return await products
            .Select(x => x.StockinHistories.Where(s => s.Date <= upTo).Select(s => s.Quantity * x.Cost).DefaultIfEmpty(0).Sum() -
                         x.SoldItems.Where(s => s.Sale.Date <= upTo).Select(s => s.Quantity * x.Cost).DefaultIfEmpty(0).Sum())
            .SumAsync(cancelToken);
        }

        void TryCancel() {
            try { source?.Cancel(); }
            catch (ObjectDisposedException) {

            }
        }

        private async void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            TryCancel();

            await Initialize_Async();
        }

        private async void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                dateTimePicker1.CustomFormat = "yyyy";

                TryCancel();
                await Initialize_Async();
            }

        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                dateTimePicker1.CustomFormat = "MMM yyyy";

                TryCancel();
                await Initialize_Async();
            }
        }
    }
}
