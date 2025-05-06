using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Data_Change_Log : Form
    {
        public Data_Change_Log()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            col_Date.DataPropertyName = nameof(ChangeLog.Time);
            col_Time.DataPropertyName = nameof(ChangeLog.Time);
            col_By.DataPropertyName = nameof(ChangeLog.MadeBy);
            col_Details.DataPropertyName = nameof(ChangeLog.Details);

            dataGridView1.DataSource = Changes;
        }

        DateTime Start => new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, 1);
        DateTime End => new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month,
                            DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month)).AddDays(1).AddTicks(-1);

        private BindingList<ChangeLog> Changes { get; } = new BindingList<ChangeLog>();

        private async void Data_Change_Log_Load(object sender, EventArgs e)
        {
            await LoadData_Async();
        }

        private async Task LoadData_Async()
        {
            using (var context = POSEntities.Create())
            {
                Changes.Clear();

                var logs = await context.ChangeLogs.AsNoTracking()
                    .FilterByDate(dateTimePicker1.Checked, Start, End)
                    .OrderByDescending(l => l.Time)
                    .ToListAsync();

                foreach (var log in logs)
                    Changes.Add(log);
            }
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            await LoadData_Async();
        }

        private void Data_Change_Log_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private async void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                await LoadData_Async();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //var dgv = sender as DataGridView;
            //if (e.ColumnIndex == col_Details.Index)
            //{
            //    e.Value = e.Value.ToString().Trim('\n');
            //    e.FormattingApplied = true;
            //}
        }
    }

    public static class ChangeLogExtension
    {
        public static IQueryable<ChangeLog> FilterByDate(this IQueryable<ChangeLog> logs, bool shouldBeApplied, DateTime start, DateTime end)
        {
            if (!shouldBeApplied) return logs;

            return logs.Where(l => l.Time >= start && l.Time <= end);
        }
    }
}
