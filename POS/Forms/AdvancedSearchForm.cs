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
    public partial class AdvancedSearchForm : Form
    {
        public event EventHandler<ItemInfoHolder> ItemSelected;
        ItemInfoHolder infoHolder;
        public AdvancedSearchForm()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            itemTables.Rows.Clear();
            using (var p = new POSEntities())
            {
                var searchedItems = p.InventoryItems.Where(x => x.Product.Item.Barcode == search.Text);

                if (searchedItems.Count() == 0)
                {
                    searchedItems = p.InventoryItems.Where(x => x.SerialNumber == search.Text);
                    if (searchedItems.Count() == 0)
                    {
                        searchedItems = p.InventoryItems.Where(x => x.Product.Item.Name.Contains(search.Text));
                    }
                }

                foreach (var i in searchedItems)
                    itemTables.Rows.Add(i.Quantity == 0 ? "Inifinite" : i.Quantity.ToString(), i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Product.Supplier.Name);

            }
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchBtn.PerformClick();
        }

        private void itemTables_SelectionChanged(object sender, EventArgs e)
        {
            if (itemTables.SelectedCells.Count == 0)
                return;

            var serialNumber = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[2].Value?.ToString();
            quantity.Enabled = string.IsNullOrEmpty(serialNumber) ? true : false;

            using (var p = new POSEntities())
            {
                var i = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == serialNumber);

                infoHolder.Barcode = i.Product.Item.Barcode;
                infoHolder.Name = i.Product.Item.Name;
                infoHolder.Supplier = i.Product.Supplier.Name;
                infoHolder.SellingPrice = i.Product.Item.SellingPrice;
                infoHolder.Quantity = 1;

                quantity.Value = 1;
                discount.Value = 0;

                itemName.Text = infoHolder.Name;
                sellingPrice.Value = infoHolder.SellingPrice;
                calculateTotal();
                //totalPrice.Text = infoHolder.TotalPrice.ToString();

                infoHolder.Serial = i.SerialNumber;
                serial.Text = infoHolder.Serial;

                if (!string.IsNullOrEmpty(serialNumber))
                {
                    quantity.Value = 1;
                }
            }
        }

        void addToCart()
        {
            ItemSelected?.Invoke(this, infoHolder);
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure you want to continue?", "The item " + infoHolder.Name + " is about to be added to cart", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    addToCart();
                    break;
                default:
                    break;
            }
        }
        void calculateTotal()
        {
            totalPrice.Text =string.Format("₱ {0:n}", infoHolder.TotalPrice);
        }
        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.Quantity = (int)quantity.Value;
            calculateTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.SellingPrice = sellingPrice.Value;
            calculateTotal();
        }

        private void discount_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.discount = discount.Value;
            calculateTotal();
        }
    }
}
