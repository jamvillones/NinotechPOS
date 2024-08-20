using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class AdvancedSearchForm : Form {
        public event EventHandler<ItemInfoHolder> ItemSelected;
        ItemInfoHolder infoHolder;
        public AdvancedSearchForm() {
            InitializeComponent();
            InitializeTable();
            setAutoComplete();

        }
        void setAutoComplete() {
            using (var p = new POSEntities()) {
                searchControl1.SetAutoComplete(p.InventoryItems.Select(x => x.Product.Item.Name).ToArray());
            }
        }
        //private void searchBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void search_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        searchBtn.PerformClick();
        //}

        private void itemTables_SelectionChanged(object sender, EventArgs e) {
            if (itemTables.SelectedCells.Count == 0)
                return;
            var id = (int)(itemTables.SelectedCells[0].Value);
            //var barc = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[1].Value?.ToString();
            var serialNumber = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[3].Value?.ToString();
            //var supplier = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[4].Value.ToString();


            using (var p = new POSEntities()) {
                var i = p.InventoryItems.FirstOrDefault(x => x.Id == id);

                infoHolder.Barcode = i.Product.Item.Barcode;
                infoHolder.Name = i.Product.Item.Name;
                infoHolder.Supplier = i.Product.Supplier?.Name;
                infoHolder.SellingPrice = i.Product.Item.SellingPrice;
                infoHolder.Quantity = 1;

                quantity.Enabled = string.IsNullOrEmpty(serialNumber) ? true : false;

                quantity.Value = 1;
                discount.Value = 0;

                //itemName.Text = infoHolder.Name;
                sellingPrice.Value = infoHolder.SellingPrice;
                calculateTotal();
                //totalPrice.Text = infoHolder.TotalPrice.ToString();

                infoHolder.Serial = i.SerialNumber;
                //serial.Text = infoHolder.Serial;

                if (!string.IsNullOrEmpty(serialNumber)) {
                    quantity.Value = 1;
                }
            }
        }

        void addToCart() {
            ItemSelected?.Invoke(this, infoHolder);
        }

        private void selectBtn_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(infoHolder.Name)) {
                MessageBox.Show("No item Selected", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (MessageBox.Show(
                "The item " + infoHolder.Name + " is about to be added.",
                "Are you sure you want to continue?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    addToCart();
                    break;
                default:
                    break;
            }
        }
        void calculateTotal() {
            //totalPrice.Text = string.Format("₱ {0:n}", infoHolder.TotalPrice);
        }
        private void quantity_ValueChanged(object sender, EventArgs e) {
            infoHolder.Quantity = (int)quantity.Value;
            calculateTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            infoHolder.SellingPrice = sellingPrice.Value;
            calculateTotal();
        }

        private void discount_ValueChanged(object sender, EventArgs e) {
            infoHolder.Discount = discount.Value;
            calculateTotal();
        }

        private void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e) {

            using (var p = new POSEntities()) {
                var searchedItems = p.InventoryItems.Where(x => x.Product.Item.Id == e.Text);

                if (searchedItems.Count() == 0) {
                    searchedItems = p.InventoryItems.Where(x => x.SerialNumber == e.Text);
                    if (searchedItems.Count() == 0) {
                        searchedItems = p.InventoryItems.Where(x => x.Product.Item.Name.Contains(e.Text));
                    }
                }
                e.SearchFound = true;
                itemTables.Rows.Clear();
                foreach (var i in searchedItems)
                    itemTables.Rows.Add(i.Id, i.Quantity == 0 ? "Inifinite" : i.Quantity.ToString(), i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Product.Supplier.Name);

            }
        }

        void InitializeTable() {
            using (var p = new POSEntities()) {
                itemTables.Rows.Clear();
                foreach (var i in p.InventoryItems)
                    itemTables.Rows.Add(
                        i.Id, i.Quantity == 0 ? "Inifinite" : i.Quantity.ToString(),
                        i.Product.Item.Barcode,
                        i.SerialNumber,
                        i.Product.Item.Name,
                        i.Product.Supplier?.Name);

            }
        }
        private void searchControl1_OnTextEmpty(object sender, EventArgs e) {
            InitializeTable();
        }

        private void label2_Click(object sender, EventArgs e) {

        }
    }
}
