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

        private async void StockinLog_Load(object sender, EventArgs e)
        {
            var init = Task.Run(() =>
            {
                using (var p = new POSEntities())
                {
                    var namegroup = p.StockinHistories.GroupBy(x => x.ItemName);
                    searchControl1.InvokeIfRequired(() => searchControl1.SetAutoComplete(namegroup.Select(x => x.Key).ToArray()));
                }
            });

            var tableInit = initTableAsync();

            await Task.WhenAll(init, tableInit);
        }

        private async Task initTableAsync()
        {
            using (var p = new POSEntities())
            {
                histTable.InvokeIfRequired(() => histTable.Rows.Clear());

                IEnumerable<StockinHistory> s = p.StockinHistories;

                if (dateTimePicker1.Checked)
                    s = s.Where(x => x.Date.Value.Date == dateTimePicker1.Value.Date);

                var rows = await createRowAsync(s);
                histTable.InvokeIfRequired(() => histTable.Rows.AddRange(rows));
            }
        }

        //private async Task<DataGridViewRow[]> createRow(IEnumerable<StockinHistory> s)
        //{
        //    DataGridViewRow[] row = null;
        //    await Task.Run(() =>
        //    {
        //        ro
        //        //row = s.Select(x => histTable.createRow(
        //        //    x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
        //        //    x.LoginUsername,
        //        //    x.ItemName,
        //        //    x.SerialNumber,
        //        //    x.Quantity,
        //        //    x.Cost,
        //        //    x.Supplier
        //        //    )).ToArray();
        //    });
        //    return row;
        //}

        private async Task<DataGridViewRow[]> createRowAsync(IEnumerable<StockinHistory> s)
        {
            var rows = new List<DataGridViewRow>();

            await Task.Run(() =>
            {
                foreach (var x in s.OrderByDescending(x => x.Date))
                {
                    var row = new DataGridViewRow();

                    row.CreateCells(histTable,
                        x.Id,
                        x.Date.Value.ToString("MMM d, yyyy hh:mm tt"),
                        x.LoginUsername,
                        x.ItemName,
                        x.SerialNumber,
                        x.Quantity,
                        string.Format("₱ {0:n}", x.Cost),
                        x.Supplier,
                        "Undo"
                        );

                    rows.Add(row);
                }
            });

            return rows.ToArray();
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.StockinHistories.AsEnumerable().Where(x => x.ItemName.Contains(e.Text));

                if (dateTimePicker1.Checked)
                    s = s.Where(x => x.Date.Value.Date == dateTimePicker1.Value.Date);

                if (s.Count() == 0)
                {
                    MessageBox.Show("No items found.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                e.SearchFound = true;

                histTable.Rows.Clear();
                var row = await createRowAsync(s);
                histTable.Rows.AddRange(row);
            }
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            await initTableAsync();
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.StockinHistories.AsEnumerable();

                if (dateTimePicker1.Checked)
                    s = s.Where(x => x.Date.Value.Date == dateTimePicker1.Value.Date);

                histTable.Rows.Clear();

                try
                {
                    var row = await createRowAsync(s);
                    histTable.Rows.AddRange(row);
                }
                catch
                {

                }
            }
        }

        private void histTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
                return;

            if (MessageBox.Show("Are you sure you want to undo this action?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            var id = (int)histTable[0, e.RowIndex].Value;

            int quantity = (int)histTable[5, e.RowIndex].Value;
            string serial = histTable[4, e.RowIndex].Value?.ToString();

            using (var p = new POSEntities())
            {
                var stockinHist = p.StockinHistories.FirstOrDefault(x => x.Id == id);
                var reference = stockinHist.InventoryItem;

                if (reference == null)
                {
                    MessageBox.Show("Item is either deleted or soldout", "Cannot undo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int remaining = reference.Quantity - quantity;
                int qtyToMinus = remaining < 0 ? reference.Quantity : quantity;

                DecreaseInventory(p, qtyToMinus, reference);
                DecreaseStockinHist(p, qtyToMinus, stockinHist);
                updateTable(e.RowIndex, qtyToMinus);

                p.SaveChanges();

            }
        }

        void DecreaseInventory(POSEntities p, int quantity, InventoryItem i)
        {
            i.Quantity -= quantity;
            if (i.Quantity <= 0)
                p.InventoryItems.Remove(i);
        }

        void DecreaseStockinHist(POSEntities p, int quanity, StockinHistory st)
        {
            st.Quantity -= quanity;
            if (st.Quantity <= 0)
                p.StockinHistories.Remove(st);
        }
        void updateTable(int rowIndex, int toMinus)
        {
            var row = histTable.Rows[rowIndex];
            var q = (int)row.Cells[5].Value;
            q -= toMinus;

            if (q <= 0)
            {
                histTable.Rows.RemoveAt(rowIndex);
                return;
            }

            row.Cells[5].Value = q;
        }
    }
}
