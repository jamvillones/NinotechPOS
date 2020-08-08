using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class StockinLog : Form
    {
        public StockinLog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            histTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                var hist = p.StockinHistories.Where(x => x.Date.Value.Day == dateTimeFilter.Value.Day);
                foreach (var i in hist)
                {
                    histTable.Rows.Add(i.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"), i.LoginUsername, i.ItemName, i.SerialNumber, i.Quantity, i.Cost, i.Supplier);
                }
            }
        }
    }
}
