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

        private void StockinLog_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var namegroup = p.StockinHistories.GroupBy(x => x.ItemName);

                searchControl1.SetAutoComplete(namegroup.Select(x => x.Key).ToArray());
                foreach (var i in p.StockinHistories.OrderByDescending(x => x.Date))
                    histTable.Rows.Add(i.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                       i.LoginUsername,
                                       i.ItemName,
                                       i.SerialNumber,
                                       i.Quantity,
                                       i.Cost,
                                       i.Supplier);
            }
        }

        private void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.StockinHistories.Where(x => x.ItemName.Contains(e.Text));
                if (s.Count() == 0)
                {
                    MessageBox.Show("No items found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                histTable.Rows.Clear();
                e.SearchFound = true;
                foreach (var i in s.OrderByDescending(x => x.Date))
                    histTable.Rows.Add(i.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                       i.LoginUsername,
                                       i.ItemName,
                                       i.SerialNumber,
                                       i.Quantity,
                                       i.Cost,
                                       i.Supplier);
            }
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            histTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.StockinHistories.OrderByDescending(x => x.Date))
                    histTable.Rows.Add(i.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                       i.LoginUsername,
                                       i.ItemName,
                                       i.SerialNumber,
                                       i.Quantity,
                                       i.Cost,
                                       i.Supplier);
            }
        }
    }
}
