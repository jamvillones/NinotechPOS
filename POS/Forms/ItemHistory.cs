using POS.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ItemHistory : Form
    {
        public ItemHistory(string id)
        {
            InitializeComponent();

            Id = id;
            dataGridView1.AutoGenerateColumns = false;
            col_Time.DataPropertyName = nameof(ItemHistoryViewModel.Time);
            col_Details.DataPropertyName = nameof(ItemHistoryViewModel.Details);
            col_Value.DataPropertyName = nameof(ItemHistoryViewModel.Quantity);
            col_StandingAmount.DataPropertyName = nameof(ItemHistoryViewModel.StandingValue);
        }

        public string Id { get; }

        private class ItemHistoryViewModel
        {
            public int Id { get; set; }
            public int Quantity { get; set; }
            public string Details { get; set; } = string.Empty;
            public DateTime Time { get; set; }

            public int StandingValue { get; private set; }

            public bool IsIncrease => Quantity > 0;
            public int AddToCurrentQuantity(int previous)
            {
                StandingValue = previous + Quantity;
                return StandingValue;
            }
        }

        BindingList<ItemHistoryViewModel> History { get; set; } = new BindingList<ItemHistoryViewModel>();
        private async void ItemHistory_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    var item = await context.Items.FirstOrDefaultAsync(i => i.Id == Id);

                    this.Text = $"{this.Text} -  {item.Name}";

                    var stockIns = await context.StockinHistories.Where(s => s.Product.Item.Id == Id).AsNoTracking().ToListAsync();

                    var itemAddition = stockIns.Select(s => new ItemHistoryViewModel()
                    {
                        Id = s.Id,
                        Quantity = (int)s.Quantity,
                        Time = s.Date.Value,
                        Details = s.SerialNumber.IsEmpty() ? "" : $"Serial : [{s.SerialNumber}]"
                    }).ToList();

                    var sold = await context.SoldItems.Where(s => s.Product.Item.Id == Id).AsNoTracking().ToListAsync();

                    var itemSubtraction = sold.Select(s => new ItemHistoryViewModel()
                    {
                        Id = s.Id,
                        Quantity = s.Quantity * -1,
                        Time = s.DateAdded,
                        Details = $"Customer: [{s.Sale.Customer.Name}] {(s.SerialNumber.IsEmpty() ? "" : "Serial : [" + s.SerialNumber+"]")}"
                    }).ToList();

                    dataGridView1.DataSource = History;

                    int standing = 0;
                    var joined = itemAddition.Concat(itemSubtraction).OrderBy(i => i.Time).ToList();
                    foreach (var j in joined)
                    {
                        standing = j.AddToCurrentQuantity(standing);
                    }
                    foreach (var h in joined.OrderByDescending(i => i.Time).ThenByDescending(i => i.Id))
                        History.Add(h);
                }
            }
            catch
            {

            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            var addedHistory = row.DataBoundItem as ItemHistoryViewModel;

            var backColor = addedHistory.IsIncrease ? Color.Green : Color.Red;
            row.DefaultCellStyle.ForeColor = backColor;
            row.DefaultCellStyle.SelectionForeColor = backColor;
        }
    }
}
