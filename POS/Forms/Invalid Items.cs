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
    public partial class Invalid_Items : Form
    {
        public Invalid_Items()
        {
            InitializeComponent();
        }

        private void Invalid_Items_Load(object sender, EventArgs e)
        {
            Column1.Visible = UserManager.instance.IsAdmin;
            _ = LoadDataAsync();
        }

        enum InvalidItemClass { Inventory, SoldItem }

        InvalidItemClass ItemFlag = InvalidItemClass.Inventory;

        string keyword = "";

        private async Task<bool> LoadDataAsync()
        {
            try
            {
                using (var context = POSEntities.Create())
                {
                    List<InvalidDTO> items = null;

                    if (ItemFlag == InvalidItemClass.Inventory)
                    {
                        items = await context.InventoryItems.Where(x => x.IsDefective).FilterItems(keyword).Select(x =>
                        new InvalidDTO()
                        {
                            Id = x.Id,
                            Name = x.Product.Item.Name,
                            Supplier = x.Product.Supplier.Name,
                            Serial = x.SerialNumber
                        }).ToListAsync();
                    }
                    else
                    {
                        items = await context.SoldItems.Where(x => x.IsDefective).FilterItems(keyword).Select(x =>
                        new InvalidDTO()
                        {
                            Id = x.Id,
                            Name = x.Product.Item.Name,
                            Supplier = x.Product.Supplier.Name,
                            Serial = x.SerialNumber
                        }).ToListAsync();
                    }

                    if (inventoryTable.RowCount > 0)
                        inventoryTable.Rows.Clear();

                    if (items.Count > 0)
                        foreach (var item in items)
                            inventoryTable.Rows.Add(item.Id, item.Name, item.Supplier, item.Serial);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        private void invTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == markAsDefectiveCol.Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var image = Properties.Resources.undo_15px;
                var w = image.Width;
                var h = image.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private class InvalidDTO
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Supplier { get; set; }

            public string Serial { get; set; }
        }


        private async void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ItemFlag = InvalidItemClass.Inventory;

                await LoadDataAsync();
            }
        }

        private async void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ItemFlag = InvalidItemClass.SoldItem;

                await LoadDataAsync();
            }
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            keyword = e.Text;

            await LoadDataAsync();

            e.SearchFound = inventoryTable.RowCount > 0;
        }

        private async void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            keyword = "";

            await LoadDataAsync();
        }

        private async void inventoryTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;


            if (e.ColumnIndex == markAsDefectiveCol.Index)
            {
                if (MessageBox.Show("Mark item as Valid?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

                int id = (int)inventoryTable.SelectedCells[0].Value;
                try
                {
                    using (var context = POSEntities.Create())
                    {
                        if (ItemFlag == InvalidItemClass.Inventory)
                        {
                            var itemToUndo = await context.InventoryItems.FirstOrDefaultAsync(x => x.Id == id);
                            context.AdditionalDetails = "SN:" + itemToUndo.SerialNumber;
                            itemToUndo.IsDefective = false;
                        }
                        else
                        {
                            var itemToUndo = await context.SoldItems.FirstOrDefaultAsync(x => x.Id == id);
                            context.AdditionalDetails = "SN:" + itemToUndo.SerialNumber;
                            itemToUndo.IsDefective = false;
                        }

                        await context.SaveChangesAsync();

                        inventoryTable.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
