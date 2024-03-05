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
            int year = dateTimePicker1.Value.Year;

            chart1.Series[0].Points.Clear();

            try {
                using (var context = new POSEntities()) {

                    chart1.Series[0].LegendText = year.ToString();
                    int monthUpto = year == DateTime.Today.Year ? DateTime.Today.Month : 12;

                    for (var i = 1; i <= monthUpto; i++) {
                        DateTime CurrentDate = new DateTime()
                            .AddYears(year - 1)
                                .AddMonths(i - 1)
                                    .AddDays(DateTime.DaysInMonth(year, i) - 1)
                            .AddHours(23)
                                .AddMinutes(59)
                                    .AddSeconds(59)
                                        .AddMilliseconds(999);

                        var currentInventoryValue = await context.Products
                            .AsNoTracking()
                            .AsQueryable()
                            .Where(x => x.Item.Type == ItemType.Quantifiable.ToString())
                            .Select(x => x.StockinHistories.Where(s => s.Date <= CurrentDate).Select(s => s.Quantity * x.Cost).DefaultIfEmpty(0).Sum() -
                                         x.SoldItems.Where(s => s.Sale.Date <= CurrentDate).Select(s => s.Quantity * x.Cost).DefaultIfEmpty(0).Sum())
                            .SumAsync(token);

                        token.ThrowIfCancellationRequested();

                        var point = new DataPoint() {
                            Label = currentInventoryValue.ToCurrency(),
                            XValue = i,
                            AxisLabel = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)
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

        void TryCancel() {
            try { source?.Cancel(); }
            catch (ObjectDisposedException) {

            }
        }

        private async void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            TryCancel();

            await Initialize_Async();
        }
    }
}
