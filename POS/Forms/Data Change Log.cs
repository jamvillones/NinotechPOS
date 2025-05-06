using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Data_Change_Log : Form
    {
        public Data_Change_Log()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;

            col_Time.DataPropertyName = nameof(ChangeLog.Time);
            col_By.DataPropertyName = nameof(ChangeLog.MadeBy);
            col_Details.DataPropertyName = nameof(ChangeLog.Details);

            dataGridView1.DataSource = Changes;
        }

        private BindingList<ChangeLog> Changes { get; } = new BindingList<ChangeLog>();

        private async void Data_Change_Log_Load(object sender, EventArgs e)
        {
            using (var context = POSEntities.Create())
            {
                var logs = await context.ChangeLogs.AsNoTracking().OrderByDescending(l => l.Time).ToListAsync();

                foreach (var log in logs)
                    Changes.Add(log);
            }
        }
    }
}
