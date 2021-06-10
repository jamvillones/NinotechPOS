using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class SellItem : Form
    {
        SearchHandler handler = new SearchHandler();

        public SellItem()
        {
            InitializeComponent();
        }

        InventoryDetails[] inventoryItems = null;

        private void SellItem_Load(object sender, EventArgs e)
        {
            handler.ReferencedTextbox = textBox1;
            handler.OnSearch += Handler_OnSearch;
            handler.OnTextCleared += Handler_OnTextCleared;

            using (var p = new POSEntities())
                inventoryItems = p.InventoryItems.Select(x => new InventoryDetails()
                {
                    Id = x.Id,
                    Barcode = x.Product.Item.Barcode,
                    Serial = x.SerialNumber,
                    Name = x.Product.Item.Name,
                    Supplier = x.Product.Supplier.Name,
                    Qty = x.Quantity,
                    Price = x.Product.Item.SellingPrice
                }).ToArray();
        }

        private void Handler_OnTextCleared(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            handler.PerformSearch();
        }

        private void Handler_OnSearch(object sender, SearchHandler e)
        {
            e.SeachFound = true;
            PerformSearch(e.SearchedString);
        }

        void PerformSearch(string e)
        {
            label1.Visible = false;
            var text = e;
            var inventories = inventoryItems.Where(a => !tableRows.Any(b => (int)b.Cells[idCol.Index].Value == a.Id && (int)b.Cells[qtyCol.Index].Value == a.Qty));
            var inv = inventories.FirstOrDefault(x => x.Serial == text);

            if (inv == null)
            {
                inv = inventories.FirstOrDefault(x => x.Barcode == text);

                if (inv == null)
                {
                    // MessageBox.Show("No item found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label1.Visible = true;
                    return;
                }
            }

            int index = getIndex(inv.Id);

            if (index == -1)
            {
                addTable(inv);
            }
            else
            {
                int newQuantity = (int)cart[qtyCol.Index, index].Value + 1;
                decimal price = (decimal)cart[priceCol.Index, index].Value;
                decimal discount = (decimal)cart[discCol.Index, index].Value;

                cart[qtyCol.Index, index].Value = newQuantity;
                cart[totalCol.Index, index].Value = newQuantity * (price - discount);
            }

            updateTotal();
        }

        int getIndex(int id)
        {
            var t = tableRows;
            return t.FirstOrDefault(x => (int)x.Cells[idCol.Index].Value == id)?.Index ?? -1;
        }

        DataGridViewRow[] tableRows => cart.Rows.Cast<DataGridViewRow>().ToArray();

        private void addTable(InventoryDetails inv, int quantity = 1, decimal discount = 0)
        {
            cart.Rows.Add(
                inv.Id,
                false,
                inv.Barcode,
                inv.Serial,
                inv.Name,
                inv.Supplier,
                quantity,
                inv.Price,
                // string.Format("₱ {0:n}", inv.Product.Item.SellingPrice),
                discount,
                // string.Format("₱ {0:n}", 0),
                quantity * (inv.Price - discount)
                //string.Format("₱ {0:n}", inv.Product.Item.SellingPrice)
                );
        }

        class InventoryDetails
        {
            public int Id { get; set; }
            public string Barcode { get; set; }
            public string Serial { get; set; }
            public string Name { get; set; }
            public string Supplier { get; set; }
            public int Qty { get; set; }
            public decimal Price { get; set; }
        }

        void updateTotal()
        {
            totalLabel.Text = string.Format("₱ {0:n}", cart.Rows.Cast<DataGridViewRow>().Select(x => (decimal)x.Cells[totalCol.Index].Value).DefaultIfEmpty(0).Sum());
        }

        private void SellItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            // handler.OnSearch -= Handler_OnSearch;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var checkout = new Checkout(cart))
                checkout.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool value = checkBox1.Checked;

            foreach (var i in tableRows)
            {
                i.Cells[1].Value = value;
            }
        }
    }
}
