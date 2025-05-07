using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS.Forms
{
    public partial class ItemProgressionForm : Form
    {
        public ItemProgressionForm(string id)
        {
            InitializeComponent();

            ItemId = id;

            dataGridView1.AutoGenerateColumns = false;
            col_Time.DataPropertyName = nameof(ItemHistoryViewModel.Time);
            col_Details.DataPropertyName = nameof(ItemHistoryViewModel.Details);
            Column1.DataPropertyName = nameof(ItemHistoryViewModel.Added);
            Column2.DataPropertyName = nameof(ItemHistoryViewModel.Subtracted);
            col_StandingAmount.DataPropertyName = nameof(ItemHistoryViewModel.StandingValue);

            dataGridView1.DataSource = History;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var dgv = sender as DataGridView;

            for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; i++)
            {
                var row = dgv.Rows[i];

                if (row.Cells[Column1.Index].Value?.ToString() != null)
                {
                    row.Cells[Column1.Index].Style.ForeColor = System.Drawing.Color.Green;
                    row.Cells[Column1.Index].Style.SelectionForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    row.Cells[Column2.Index].Style.ForeColor = System.Drawing.Color.Red;
                    row.Cells[Column2.Index].Style.SelectionForeColor = System.Drawing.Color.Red;
                }
            }
        }

        public string ItemId { get; }

        private class ItemHistoryViewModel
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Details { get; set; } = string.Empty;
            public DateTime Time { get; set; }
            public int? Added => Quantity > 0 ? Quantity : default(int?);
            public int? Subtracted => Quantity < 0 ? Quantity : default(int?);
            public int StandingValue { get; private set; }

            public int AddToCurrentQuantity(int previous)
            {
                StandingValue = previous + Quantity;
                return StandingValue;
            }
        }

        BindingList<ItemHistoryViewModel> History { get; } = new BindingList<ItemHistoryViewModel>();

        private async void ItemHistory_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var item = await context.Items.FirstOrDefaultAsync(i => i.Id == ItemId);

                    this.Text = $"{this.Text} - {item.Name}";

                    bool isSerialRequired = item.IsSerialRequired;

                    var stockIns = await context.StockinHistories.Where(s => s.Product.Item.Id == ItemId).AsNoTracking().ToListAsync();

                    var itemAddition = stockIns
                        .GroupBy(s => s.Date.Value.AddMilliseconds(-s.Date.Value.Millisecond))
                        .Select(g => new ItemHistoryViewModel()
                        {
                            Quantity = g.Sum(x => (int)x.Quantity),
                            Time = g.Key,
                            Details = isSerialRequired ? $"[SERIAL]:\n{string.Join(Environment.NewLine, g.Select(x => "▸ " + x.SerialNumber))}" : ""
                        })
                        .ToList();

                    var sold = await context.SoldItems.Where(s => s.Product.Item.Id == ItemId).AsNoTracking().ToListAsync();

                    var itemSubtraction = sold
                        .GroupBy(s => s.DateAdded.AddMilliseconds(-s.DateAdded.Millisecond))
                        .Select(s => new ItemHistoryViewModel()
                        {
                            Quantity = s.Sum(x => x.Quantity) * -1,
                            Time = s.Key,
                            Details = $"[CUSTOMER]: {s.First().Sale.Customer.Name} \n{(isSerialRequired ? $"[SERIAL]:\n{string.Join(Environment.NewLine, s.Select(x => "▸ " + x.SerialNumber))}" : "")}"
                        })
                        .ToList();

                    int standing = 0;
                    var joined = itemAddition.Concat(itemSubtraction).OrderBy(x => x.Time).ToList();

                    foreach (var j in joined)
                        standing = j.AddToCurrentQuantity(standing);

                    foreach (var h in joined.OrderByDescending(i => i.Time))
                        History.Add(h);

                    chart1.Series[0].Name = item.Name;

                    ///so that the charts start with coordinate (0,0)
                    chart1.Series[0].Points.AddXY(0, 0);

                    int xValue = 1;
                    foreach (var h in joined.OrderBy(i => i.Time))
                    {
                        var dataPoint = new DataPoint(xValue++, h.StandingValue);
                        //dataPoint.LabelToolTip = $"{h.Time} - {h.StandingValue}";
                        dataPoint.ToolTip = $"{h.StandingValue} unit/s ({h.Quantity:+0;-0;+0} Δ) ▸ {h.Time}";
                        dataPoint.Label = "";


                        chart1.Series[0].Points.Add(dataPoint);
                    }
                    //chart1.Series[0].Points.AddXY(h.Time, h.StandingValue);
                }
            }
            catch { }
        }
    }
}
