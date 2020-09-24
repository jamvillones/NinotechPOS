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
        /// <summary>
        /// maximum number of items in actual view in flowlayout
        /// </summary>
        const int maxItemInView = 20;

        /// <summary>
        /// the current page number in flowlayout
        /// </summary>
        int currentIndex = 1;

        /// <summary>
        /// total pages
        /// </summary>
        int Indexes = 0;

        /// <summary>
        /// the actual list of items
        /// </summary>
        List<ItemBoxHolder> totalItems = new List<ItemBoxHolder>();
        /// <summary>
        /// the current items in the display diveded into segments since view is limited
        /// </summary>
        List<ItemBoxHolder> filteredItems = new List<ItemBoxHolder>();

        public ConsoleSell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// taken by adding total prices in the cart table
        /// </summary>
        public decimal TotalPrice { get { return cartTable.Rows.Cast<DataGridViewRow>().Sum(x => (decimal)(x.Cells[totalPriceCol.Name].Value)); } }

        private void ConsoleSel_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                ///add itemboxes depending in inventory items
                var it = p.InventoryItems.OrderBy(y => y.Product.Item.Name);
                searchControl1.SetAutoComplete(it.Select(x => x.Product.Item.Name).ToArray());
                foreach (var i in it)
                {
                    var j = new UserControls.ItemBoxHolder();
                    j.ItemChosen += BoxClicked_Callback;
                    j.SetValues(i.Product.Item.SellingPrice, i.Quantity, Misc.ImageDatabaseConverter.byteArrayToImage(i.Product.Item.SampleImage), i.Product.Item.Barcode, i.SerialNumber, i.Product.Item.Name, i.Id);
                    totalItems.Add(j);
                }
                ///set filtered items to total items since at the beginning where filter is not made, filtered is equals total
                filteredItems = totalItems;
                ///set the totalentries heads up
                totalEntriesValue.Text = filteredItems.Count.ToString();
                ///determining indexes of pages of the boxes
                int quotient = filteredItems.Count / maxItemInView;
                Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
                index.Text = (currentIndex + "/" + Indexes).ToString();
                int length = filteredItems.Count < maxItemInView ? filteredItems.Count : maxItemInView;

                ///add the itemboxes to flow depending on computeed length
                itemsHolder.Controls.Clear();
                for (int i = 0; i < length; i++)
                    itemsHolder.Controls.Add(filteredItems[i]);
            }
        }

        private void ConsoleSell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.F)
                    ActiveControl = searchControl1.firstControl;
                if (e.KeyCode == Keys.Left)
                    prev.PerformClick();
                if (e.KeyCode == Keys.Right)
                    next.PerformClick();

                e.SuppressKeyPress = true;
            }
            if (e.Shift && e.KeyCode == Keys.Enter)
            {
                proceedBtn.PerformClick();
            }
        }

        private void proceedBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proceed to checkout.");
        }

        /// <summary>
        /// handles what happened after one of the boxes is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxClicked_Callback(object sender, EventArgs e)
        {
            ItemBoxHolder s = sender as ItemBoxHolder;
            var sameRow = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)(x.Cells[0].Value) == s.Id);
            var isSameRowPresent = sameRow != null;

            decimal currentPrice = isSameRowPresent ? (decimal)(sameRow.Cells[priceCol.Name].Value) : 0;
            decimal currentDiscount = isSameRowPresent ? (decimal)(sameRow.Cells[discountCol.Name].Value) : 0;

            using (var saleSetup = new ItemSaleSetupForm())
            {

                saleSetup.SetValues(s.Id,
                            s.Barcode,
                            s.Serial,
                            s.ItemName,
                            s.img,
                            isSameRowPresent ? currentPrice : s.Price,
                            s.Quantity,
                            isSameRowPresent ? currentDiscount : 0,
                            1,
                            isSameRowPresent);

                saleSetup.OnConfirm += On_Confirm;
                saleSetup.ShowDialog();
            }
        }

        /// <summary>
        /// callback for when user finished the setup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void On_Confirm(object sender, InventoryItemDetailArgs e)
        {

            TakeItemsFromCart(e.Id, e.Quantity);

            using (var p = new POSEntities())
            {
                ///find the item in inventory
                var i = p.InventoryItems.FirstOrDefault(x => x.Id == e.Id);
                ///if not found, then dont handle addition of item to cart
                if (i == null)
                {
                    return;
                }
                ///search for identitcal id in cart
                var sameRow = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)(x.Cells[0].Value) == i.Id);
                /// if none then add new row
                if (sameRow == null)
                {

                    cartTable.Rows.Add(i.Id,
                                       i.SerialNumber,
                                       i.Product.Item.Name,
                                       e.Quantity,
                                       e.Price,
                                       e.Discount,
                                       (e.Price - e.Discount) * e.Quantity,
                                       i.Product.Supplier.Name,
                                       "Modify");
                }
                ///else add quantity to the current quantity in cart
                else
                {
                    int newQuantity = (int)(sameRow.Cells[quantityCol.Name].Value) + e.Quantity;
                    decimal currentPrice = (decimal)(sameRow.Cells[priceCol.Name].Value);
                    decimal currentDiscount = (decimal)(sameRow.Cells[discountCol.Name].Value);

                    sameRow.Cells[quantityCol.Name].Value = newQuantity;
                    sameRow.Cells[totalPriceCol.Name].Value = newQuantity * (currentPrice - currentDiscount);
                }
            }
            ///update the grandtotal
            totalPrice.Text = string.Format("₱{0:n}", TotalPrice);
        }

        #region navigation buttons
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
        #endregion

        #region search callbacks
        private void OnSearch_Callback(object sender, SearchEventArgs e)
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
            totalEntriesValue.Text = filteredItems.Count.ToString();
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

        private void OnEmptySearch_Callback(object sender, EventArgs e)
        {
            filteredItems = totalItems;

            int quotient = filteredItems.Count / maxItemInView;
            Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
            index.Text = (currentIndex + "/" + Indexes).ToString();
            int length = filteredItems.Count < maxItemInView ? filteredItems.Count : maxItemInView;

            totalEntriesValue.Text = filteredItems.Count.ToString();

            itemsHolder.Controls.Clear();
            for (int i = 0; i < length; i++)
                itemsHolder.Controls.Add(filteredItems[i]);
        }
        #endregion

        /// <summary>
        /// Handles Inventory upon item selections
        /// </summary>
        /// <param name="id">the ivnentory item id</param>
        /// <param name="quantityReduction">value to be subtracted</param>
        public void TakeItemsFromCart(int id, int quantityReduction)
        {
            var boxHolder = filteredItems.FirstOrDefault(x => x.Id == id);

            if (boxHolder.Quantity != 0)
            {
                boxHolder.Quantity -= quantityReduction;
                if (boxHolder.Quantity == 0)
                {

                    totalItems.Remove(boxHolder);
                    filteredItems.Remove(boxHolder);
                    itemsHolder.Controls.Remove(boxHolder);

                    totalEntriesValue.Text = filteredItems.Count.ToString();

                    if ((currentIndex * maxItemInView) <= filteredItems.Count)
                        itemsHolder.Controls.Add(filteredItems[(currentIndex * maxItemInView) - 1]);

                    int quotient = filteredItems.Count / maxItemInView;
                    Indexes = (filteredItems.Count % maxItemInView) == 0 ? quotient : quotient + 1;
                    index.Text = (currentIndex + "/" + Indexes).ToString();
                }
            }
        }

        private void cartTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
                return;
            var t = sender as DataGridView;

            var id = (int)(t.Rows[e.RowIndex].Cells[0].Value);
            var quantity = (int)(t.Rows[e.RowIndex].Cells[quantityCol.Name].Value);
            var price = (decimal)(t.Rows[e.RowIndex].Cells[priceCol.Name].Value);
            var discount = (decimal)(t.Rows[e.RowIndex].Cells[discountCol.Name].Value);

            using (var p = new POSEntities())
            {
                var inventoryItem = p.InventoryItems.FirstOrDefault(x => x.Id == id);
                using (var setup = new ItemSaleSetupForm())
                {
                    setup.SetValues(inventoryItem.Id
                                    , inventoryItem.Product.Item.Barcode,
                                    inventoryItem.SerialNumber,
                                    inventoryItem.Product.Item.Name,
                                    ImageDatabaseConverter.byteArrayToImage(inventoryItem.Product.Item.SampleImage),
                                    price,
                                    inventoryItem.Quantity,
                                    discount,
                                    quantity);

                    setup.OnConfirm += editConfirmed_Callback;
                    setup.ShowDialog();
                }
            }
        }

        private void editConfirmed_Callback(object sender, InventoryItemDetailArgs e)
        {
            //throw new NotImplementedException();
            var rowToBeModified = cartTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => (int)(x.Cells[0].Value) == e.Id);

            rowToBeModified.Cells[priceCol.Name].Value = e.Price;
            rowToBeModified.Cells[quantityCol.Name].Value = e.Quantity;
            rowToBeModified.Cells[discountCol.Name].Value = e.Discount;
            rowToBeModified.Cells[totalPriceCol.Name].Value = (e.Price - e.Discount) * e.Quantity;
        }
    }
}
