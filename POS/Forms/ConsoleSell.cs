using POS.Misc;
using POS.UserControls;
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
    public partial class ConsoleSell : Form
    {
        public ConsoleSell()
        {
            InitializeComponent();
        }
        public decimal TotalPrice
        {
            get
            {
                return cartTable.Rows.Cast<DataGridViewRow>().Sum(x => (decimal)(x.Cells[totalPriceCol.Name].Value));
            }
        }

        const int maxItemInView = 25;
        int currentIndex = 1;
        int Indexes = 0;
        int currentItemCount
        {
            get
            {
                return itemsHolder.Controls.Count;
            }
        }

        List<ItemBoxHolder> totalItems = new List<ItemBoxHolder>();
        List<ItemBoxHolder> filteredItems = new List<ItemBoxHolder>();

        private void ConsoleSell_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var it = p.InventoryItems.OrderBy(y => y.Product.Item.Name);
                searchControl1.SetAutoComplete(it.Select(x => x.Product.Item.Name).ToArray());
                foreach (var i in it)
                {
                    var j = new UserControls.ItemBoxHolder();
                    j.ItemChosen += J_Click;
                    j.SetValues(i.Product.Item.SellingPrice, i.Quantity, Misc.ImageDatabaseConverter.byteArrayToImage(i.Product.Item.SampleImage), i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Id);
                    totalItems.Add(j);
                }

                filteredItems = totalItems;

                int quotient = filteredItems.Count / maxItemInView;
                Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
                index.Text = (currentIndex + "/" + Indexes).ToString();
                int length = filteredItems.Count < maxItemInView ? filteredItems.Count : maxItemInView;


                itemsHolder.Controls.Clear();
                for (int i = 0; i < length; i++)
                    itemsHolder.Controls.Add(filteredItems[i]);
            }
        }

        private void J_Click(object sender, EventArgs e)
        {
            ItemBoxHolder s = sender as ItemBoxHolder;
            var sameRow = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)(x.Cells[0].Value) == s.Id);
            var isSameRowPresent = sameRow != null;

            decimal currentPrice = isSameRowPresent ? (decimal)(sameRow.Cells[priceCol.Name].Value) : 0;
            decimal currentDiscount = isSameRowPresent ? (decimal)(sameRow.Cells[discountCol.Name].Value) : 0;

            using (var z = new ItemSaleSetupForm())
            {

                z.SetValues(s.Barcode,
                            s.Serial,
                            s.ItemName,
                            s.img,
                            isSameRowPresent ? currentPrice : s.Price,
                            s.Quantity,
                            s.Id,
                            isSameRowPresent ? currentDiscount : 0,
                            isSameRowPresent);
                z.OnConfirm += Z_OnConfirm;
                z.ShowDialog();
            }
        }

        private void Z_OnConfirm(object sender, InventoryItemDetailArgs e)
        {
            var boxHolder = filteredItems.FirstOrDefault(x => x.Id == e.Id);

            if (boxHolder.Quantity != 0)
            {
                boxHolder.Quantity -= e.Quantity;
                if (boxHolder.Quantity == 0)
                {

                    totalItems.Remove(boxHolder);
                    filteredItems.Remove(boxHolder);
                    itemsHolder.Controls.Remove(boxHolder);

                    if ((currentIndex * maxItemInView) <= filteredItems.Count)
                        itemsHolder.Controls.Add(filteredItems[(currentIndex * maxItemInView) - 1]);

                    int quotient = filteredItems.Count / maxItemInView;
                    Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
                    index.Text = (currentIndex + "/" + Indexes).ToString();
                }
            }

            using (var p = new POSEntities())
            {
                var i = p.InventoryItems.FirstOrDefault(x => x.Id == e.Id);

                var sameRow = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)(x.Cells[0].Value) == i.Id);
                if (sameRow == null)
                {

                    cartTable.Rows.Add(i.Id,
                                       i.Product.Item.Barcode,
                                       i.SerialNumber,
                                       i.Product.Item.Name,
                                       e.Quantity,
                                       e.Price,
                                       e.Discount,
                                       (e.Price - e.Discount) * e.Quantity,
                                       i.Product.Supplier.Name);
                }
                else
                {
                    int newQuantity = (int)(sameRow.Cells[quantityCol.Name].Value) + e.Quantity;
                    decimal currentPrice = (decimal)(sameRow.Cells[priceCol.Name].Value);
                    decimal currentDiscount = (decimal)(sameRow.Cells[discountCol.Name].Value);

                    sameRow.Cells[quantityCol.Name].Value = newQuantity;
                    sameRow.Cells[totalPriceCol.Name].Value = newQuantity * (currentPrice - currentDiscount);

                }
            }

            totalPrice.Text = string.Format("₱{0:n}", TotalPrice);
        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (currentIndex == 1)
                return;
            currentIndex--;

            index.Text = currentIndex + "/" + Indexes;

            itemsHolder.Controls.Clear();
            for (int i = (currentIndex * maxItemInView) - maxItemInView; i < currentIndex * maxItemInView; i++)
                itemsHolder.Controls.Add(filteredItems[i]);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currentIndex == Indexes)
                return;

            currentIndex++;

            index.Text = currentIndex + "/" + Indexes;

            itemsHolder.Controls.Clear();
            int m = currentIndex * maxItemInView;
            for (int i = ((currentIndex - 1) * maxItemInView); i < (m > filteredItems.Count ? filteredItems.Count : m); i++)
                itemsHolder.Controls.Add(filteredItems[i]);
        }

        private void searchControl1_OnSearch(object sender, SearchEventArgs e)
        {
            filteredItems = totalItems.Where(x => x.Barcode == e.Text).ToList();
            if (filteredItems.Count == 0)
            {
                filteredItems = totalItems.Where(x => x.ItemName.ToLower().Contains(e.Text.ToLower())).ToList();
                if (filteredItems.Count == 0)
                {
                    filteredItems = totalItems.Where(x => x.Serial?.ToLower() == e.Text.ToLower()).ToList();
                }
            }

            if (filteredItems.Count == 0)
            {
                MessageBox.Show("No items found.");
                return;
            }

            e.SearchFound = true;
            currentIndex = 1;
            int quotient = filteredItems.Count / maxItemInView;
            Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
            index.Text = (currentIndex + "/" + Indexes).ToString();
            int length = filteredItems.Count < maxItemInView ? filteredItems.Count : maxItemInView;

            itemsHolder.Controls.Clear();
            for (int i = 0; i < length; i++)
                itemsHolder.Controls.Add(filteredItems[i]);
        }

        private void searchControl1_OnTextEmpty(object sender, EventArgs e)
        {
            filteredItems = totalItems;

            int quotient = filteredItems.Count / maxItemInView;
            Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
            index.Text = (currentIndex + "/" + Indexes).ToString();
            int length = filteredItems.Count < maxItemInView ? filteredItems.Count : maxItemInView;

            itemsHolder.Controls.Clear();
            for (int i = 0; i < length; i++)
                itemsHolder.Controls.Add(filteredItems[i]);
        }
    }
}
