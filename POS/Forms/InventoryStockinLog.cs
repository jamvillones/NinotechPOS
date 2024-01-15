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
using System.Xml.Linq;

namespace POS.Forms
{
    public partial class InventoryStockinLog : Form
    {
        string _id;
        string _name;
        public InventoryStockinLog(string id, string name)
        {
            InitializeComponent();
            _id = id;
            _name = name;
        }


        private async void InventoryStockinLog_Load(object sender, EventArgs e)
        {
            histTable.Rows.Clear();

            using (var context = new POSEntities())
            {
                var hist = await context.StockinHistories
                    .Where(x => x.Product.Item.Id == _id)
                    .OrderByDescending(x => x.Date)
                .ToListAsync();

                this.Text = this.Text + " - " + _name + " - " + hist.Sum(h => h.Quantity) + " units";


                await Task.Run(() =>
                {
                    foreach (var i in hist)
                        histTable.InvokeIfRequired(() =>
                            histTable.Rows.Add(
                             i.Id,
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
