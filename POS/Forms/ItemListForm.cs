using POS.Misc;
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
    public partial class ItemListForm : Form
    {
        public ItemListForm()
        {
            InitializeComponent();
        }

        private async void ItemListForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        async Task<bool> LoadDataAsync()
        {
            var itemsAvailable = false;

            using (var context = new POSEntities())
            {
                var raw = context.Items
                    .AsNoTracking()
                    .Where(x => x.Type != ItemType.Quantifiable.ToString() ||
                                x.Products
                                    .Select(a => a.InventoryItems
                                        .Select(b => b.Quantity)
                                        .DefaultIfEmpty(0)
                                        .Sum())
                                    .Sum() > 0)
                    .OrderBy(i => i.Name)
                    .AsQueryable();

                var items = keyword.IsEmpty() ?
                    await raw.ToListAsync() :
                    await raw.Where(x => x.Barcode == keyword || x.Name.Contains(keyword)).ToListAsync();

                itemsAvailable = items.Count > 0;

                if (itemsAvailable)
                {
                    itemsTable.Rows.Clear();

                    await Task.Run(() =>
                    {
                        foreach (var item in items)
                            itemsTable.InvokeIfRequired(() => itemsTable.Rows.Add(CreateRow(item)));
                    });
                }
            }

            return itemsAvailable;
        }

        string SelectedBarcode => itemsTable.SelectedRows[0].Cells[barcodeCol.Index].Value?.ToString();
        string SelectedName => itemsTable.SelectedRows[0].Cells[nameCol.Index].Value?.ToString();

        DataGridViewRow CreateRow(Item item) => itemsTable.CreateRow(
            item.Id,
            item.Barcode,
            item.Name,
            item.IsFinite ? item.QuantityInInventory : default(int?),
            item.SellingPrice,
            item.Type.ToString()
            );

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (itemsTable.SelectedRows.Count == 0) return;

            Tag = SelectedBarcode ?? SelectedName;
            DialogResult = DialogResult.OK;
        }

        string keyword = string.Empty;
        private async void searchControl_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            keyword = e.Text;
            e.SearchFound = await LoadDataAsync();

            if (!e.SearchFound)
                MessageBox.Show("Results not found", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void searchControl_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = string.Empty;
            await LoadDataAsync();
        }

        private async void itemsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                keyword = string.Empty;
                await LoadDataAsync();
            }
        }
    }
}
