using POS.Misc;
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
    public partial class PrintInventory : Form
    {
        public PrintInventory()
        {
            InitializeComponent();
        }

        private void PrintInventory_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var inventoryGroup = p.InventoryItems.Where(y => y.Product.Item.Type == ItemType.Hardware.ToString()).GroupBy(x => x.Product.Item.Barcode);
                foreach (var i in inventoryGroup)
                {
                    var item = p.Items.FirstOrDefault(x => x.Barcode == i.Key);
                    var quantity = p.InventoryItems.Where(x => x.Product.Item.Barcode == item.Barcode).Sum(x => x.Quantity);
                    table.Rows.Add(item.Barcode, item.Name, quantity);
                }
            }
        }

        private void table_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var dt = sender as DataGridView;
            e.Control.KeyPress -= new KeyPressEventHandler(Tb_KeyPress);
            if (dt.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Tb_KeyPress);
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPrinterHelper.DGVPrinter printer = new DGVPrinterHelper.DGVPrinter();
            printer.PageNumbers = true;
            printer.PrintMargins = new System.Drawing.Printing.Margins(5, 5, 5, 5);
            printer.TableAlignment = DGVPrinterHelper.DGVPrinter.Alignment.Center;
            printer.PorportionalColumns = true;
            printer.SubTitle = string.Format(" Date: {0} By: {1}", DateTime.Now, UserManager.instance.currentLogin.Username);
            printer.PrintDataGridView(table);
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.table.Width, this.table.Height);
            table.DrawToBitmap(bm, new Rectangle(0, 0, this.table.Width, this.table.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
