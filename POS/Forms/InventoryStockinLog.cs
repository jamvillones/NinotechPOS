using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class InventoryStockinLog : Form
    {
        string id;
        public InventoryStockinLog(string barcode)
        {
            InitializeComponent();
            id = barcode;
        }


        private async void InventoryStockinLog_Load(object sender, EventArgs e)
        {
            histTable.Rows.Clear();

            using (var context = new POSEntities())
            {
                var hist = await context.StockinHistories
                    .Where(x => x.Product.Item.Barcode == id)
                    .OrderByDescending(x => x.Date)
                    .ToListAsync();

                await Task.Run(() =>
                {
                    foreach (var i in hist)
                        histTable.InvokeIfRequired(() =>
                            histTable.Rows.Add(
                             i.LoginUsername,
                             i.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                             i.ItemName,
                             i.SerialNumber,
                             i.Supplier,
                             i.Quantity,
                             i.Cost));
                });

            }
        }
    }
}
