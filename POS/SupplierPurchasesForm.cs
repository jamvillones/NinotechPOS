using POS.Forms;
using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS
{
    public partial class SupplierPurchasesForm : Form
    {
        private readonly int supplierId;
        private DateFilterMode dateFilter = DateFilterMode.Annually;

        public SupplierPurchasesForm(int supplierId)
        {
            InitializeComponent();
            this.supplierId = supplierId;
        }

        private class SupplierPurchasesDTO
        {
            public string Product { get; set; }
            public decimal? Value { get; set; }
        }

        private void LoadDataAsync()
        {
            using (var context = POSEntities.Create())
            {
                var entries = context.Products
                    .AsNoTracking()
                    .Where(x => x.SupplierId == supplierId)
                    .Where(x => x.Item != null)
                    .AsEnumerable()
                    .Select(x => new SupplierPurchasesDTO()
                    {
                        Product = x.Item.Name,
                        Value = x.StockinHistories.FilterByDate(DateFilter, dateTimePicker.Value).Sum(st => st.Cost ?? 0m)
                    })
                    .Where(x => x.Value > 0)
                    .ToList();

                if (table.RowCount > 0) table.Rows.Clear();

                foreach (var e in entries)
                    table.Rows.Add(e.Product, e.Value);

                table.Rows.Add("", entries.Sum(x => x.Value));
            }
        }

        private void SupplierPurchasesForm_Load(object sender, EventArgs e)
        {
            dateTimePicker.MaxDate = DateTime.Now;
            LoadDataAsync();
        }

        DateFilterMode DateFilter
        {
            get => dateFilter;
            set
            {
                dateFilter = value;
                LoadDataAsync();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = DateFilterMode.Annually;
            dateTimePicker.CustomFormat = "yyyy";
            dateTimePicker.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = DateFilterMode.Monthly;
            dateTimePicker.CustomFormat = "MMM yyyy";
            dateTimePicker.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DateFilter = DateFilterMode.All;
            dateTimePicker.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var total = (decimal)table.Rows[table.RowCount - 1].Cells[1].Value;
            var dataPoints = table.Rows
                .Cast<DataGridViewRow>()
                .Where(x => x.Cells[0].Value?.ToString() != "")
                .Select(x => new DataPoint()
                {
                    AxisLabel = ((decimal)x.Cells[1].Value).ToPercentageString(total) + " • " + x.Cells[0].Value.ToString(),
                    YValues = new double[] { (double)((decimal)(x.Cells[1].Value)) }
                })
                .ToArray();

            new PurchasedItem_Chart(dataPoints).ShowDialog();
        }
    }

    public static class StockinHistoryExtension
    {
        public static IEnumerable<StockinHistory> FilterByDate(this IEnumerable<StockinHistory> histories, DateFilterMode filterMode, DateTime dateSelected)
        {
            switch (filterMode)
            {
                case DateFilterMode.Daily:
                    return histories.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                              s.Date.Value.Month == dateSelected.Month &&
                                              s.Date.Value.Day == dateSelected.Day);
                case DateFilterMode.Monthly:
                    return histories.Where(s => s.Date.Value.Year == dateSelected.Year &&
                                             s.Date.Value.Month == dateSelected.Month);
                case DateFilterMode.Annually:
                    return histories.Where(s => s.Date.Value.Year == dateSelected.Year);
                default:
                    return histories;
            }
        }
    }
}
