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
    public partial class AdvancedSearchForm : Form
    {
        public event EventHandler<ItemInfoHolder> ItemSelected;
        ItemInfoHolder infoHolder;
        public AdvancedSearchForm()
        {
            InitializeComponent();
            //LoadData_Async();
            //setAutoComplete();

        }
        async Task setAutoComplete_Async()
        {
            try
            {

                using (var context = POSEntities.Create())
                {
                    var autocomplete = await context.Items.AsNoTracking().Select(i => i.Name).ToArrayAsync();
                    searchControl1.SetAutoComplete(autocomplete);
                }
            }
            catch
            {

            }
        }

        private void itemTables_SelectionChanged(object sender, EventArgs e)
        {

            if (itemTables.SelectedCells.Count == 0)
                return;
            var id = (int)(itemTables.SelectedCells[0].Value);
            //var barc = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[1].Value?.ToString();
            var serialNumber = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[3].Value?.ToString();
            //var supplier = itemTables.Rows[itemTables.SelectedCells[0].RowIndex].Cells[4].Value.ToString();


            using (var p = POSEntities.Create())
            {
                var i = p.InventoryItems.FirstOrDefault(x => x.Id == id);
                if (i is null)
                {
                    return;
                }

                infoHolder.Barcode = i.Product.Item.Barcode;
                infoHolder.Name = i.Product.Item.Name;
                infoHolder.Supplier = i.Product.Supplier?.Name;
                infoHolder.SellingPrice = i.Product.Item.SellingPrice;
                infoHolder.Quantity = 1;
                infoHolder.ProductId = i.ProductId;

                quantity.Enabled = string.IsNullOrEmpty(serialNumber) ? true : false;
                quantity.Maximum = i.Quantity == 0 ? 999999999 : i.Quantity;

                quantity.Value = 1;
                discount.Value = 0;

                //itemName.Text = infoHolder.Name;
                sellingPrice.Value = infoHolder.SellingPrice;
                CalculateTotal();
                //totalPrice.Text = infoHolder.TotalPrice.ToString();

                infoHolder.Serial = i.SerialNumber;
                //serial.Text = infoHolder.Serial;

                if (!string.IsNullOrEmpty(serialNumber))
                {
                    quantity.Value = 1;
                }
            }
        }

        void AddToCart()
        {
            Tag = textBox1.Text.Trim();
            ItemSelected?.Invoke(this, infoHolder);
            Close();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Must provide reason", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(infoHolder.Name))
            {
                MessageBox.Show("No item Selected", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (MessageBox.Show(
                "The item " + infoHolder.Name + " is about to be added.",
                "Are you sure you want to continue?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    AddToCart();
                    break;
                default:
                    break;
            }
        }

        void CalculateTotal()
        {
            //totalPrice.Text = string.Format("₱ {0:n}", infoHolder.TotalPrice);
        }
        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.Quantity = (int)quantity.Value;
            CalculateTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.SellingPrice = sellingPrice.Value;
            CalculateTotal();
        }

        private void discount_ValueChanged(object sender, EventArgs e)
        {
            infoHolder.Discount = discount.Value;
            CalculateTotal();
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            keyWord = e.Text;

            await LoadData_Async();
        }

        string keyWord = "";

        async Task LoadData_Async()
        {
            //try
            //{
            using (var context = POSEntities.Create())
            {

                var inventoryItems = await context.InventoryItems.AsNoTracking().AsQueryable()
                    .ApplySearch(keyWord)
                    .OrderBy(x => x.Product.Item.Name)
                    .ToListAsync();

                if (inventoryItems.Count > 0)
                {
                    itemTables.Rows.Clear();

                    var itemGroupings = inventoryItems.GroupBy(x => x.Product.Item.Name);

                    foreach (var group in itemGroupings)
                    {
                        bool isFirstEntry = true;
                        var toAdd = inventoryItems.Where(x => x.Product.Item.Name.Equals(group.Key));
                        foreach (var t in toAdd)
                        {
                            itemTables.Rows.Add(CreateRow(t, isFirstEntry));
                            isFirstEntry = false;
                        }
                    }
                }

            }
            //}
            //catch
            //{

            //}
        }

        DataGridViewRow CreateRow(InventoryItem inventoryItem, bool firstEntry = true) => itemTables.CreateRow(
            inventoryItem.Id,
            firstEntry ? inventoryItem.Product.Item.Barcode : null,
            firstEntry ? inventoryItem.Product.ToString() : null,
            inventoryItem.SerialNumber,
            inventoryItem.Quantity <= 0 ? null : (int?)inventoryItem.Quantity
            );

        private async void AdvancedSearchForm_Load(object sender, EventArgs e)
        {
            await setAutoComplete_Async();
        }
    }

    public static class InventoryItemContextExtension
    {
        public static IQueryable<InventoryItem> ApplySearch(this IQueryable<InventoryItem> items, string keyword = "")
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return items;

            return items.Where(i => i.SerialNumber.Contains(keyword) || i.Product.Item.Name.Contains(keyword));
        }
    }
}
