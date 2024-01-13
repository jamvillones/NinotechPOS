using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class EditSale : Form {
        //Login currentLogin => Misc.UserManager.instance.currentLogin;

        BindingList<SoldItemViewModel> SoldItems = new BindingList<SoldItemViewModel>();

        public event EventHandler OnSave;
        Sale Sale { get; set; }

        public EditSale(int id) {
            InitializeComponent();
            InitBindings();
            Initialize(id);
        }

        private class SoldItemViewModel {
            public SoldItemViewModel(SoldItem s) {
                Id = s.Id;
                ItemName = s.Product.Item.Name;
                Serial = s.SerialNumber;
                Quantity = s.Quantity;
                Price = s.ItemPrice;
                Discount = s.Discount;
                SupplierName = s.Product.Supplier.Name;
            }
            public int Id { get; private set; }

            public string ItemName { get; private set; }
            public string Serial { get; private set; }
            public int Quantity { get; private set; }
            public decimal Price { get; set; }
            public decimal Discount { get; set; }
            public decimal Total => Quantity * (Price - Discount);
            public string SupplierName { get; private set; }
        }

        void InitBindings() {
            itemsTable.AutoGenerateColumns = false;

            col_Name.DataPropertyName = nameof(SoldItemViewModel.ItemName);
            col_Serial.DataPropertyName = nameof(SoldItemViewModel.Serial);
            col_Qty.DataPropertyName = nameof(SoldItemViewModel.Quantity);
            col_Price.DataPropertyName = nameof(SoldItemViewModel.Price);
            col_Discount.DataPropertyName = nameof(SoldItemViewModel.Discount);
            col_Total.DataPropertyName = nameof(SoldItemViewModel.Total);
            col_Supplier.DataPropertyName = nameof(SoldItemViewModel.SupplierName);
        }
        /// <summary>
        /// initializes the values
        /// </summary>
        /// <param name="id"></param>
        private void Initialize(int id) {
            using (var p = new POSEntities()) {
                Sale = p.Sales.FirstOrDefault(x => x.Id == id);

                this.Text = this.Text + " - " + id;

                SoldItems = new BindingList<SoldItemViewModel>(
                    Sale.SoldItems
                    .OrderBy(x => x.Product.Item.Name)
                    .Select(s => new SoldItemViewModel(s))
                    .ToArray());

                itemsTable.DataSource = SoldItems;

            }
        }

        private void button1_Click(object sender, EventArgs e) {
            using (var adv = new AdvancedSearchForm()) {
                adv.ItemSelected += Adv_ItemSelected;
                adv.ShowDialog();
            }
        }
        int calculateQuantity(int quantity, int total, out int remains) {

            if (total == 0) {
                remains = -1;
                return quantity;
            }
            int r = total - quantity;
            if (r < 0) {
                remains = 0;
                return total;
            }
            remains = r;
            return quantity;
        }

        private void Adv_ItemSelected(object sender, ItemInfoHolder e) {

            using (var p = new POSEntities()) {
                var targetSale = p.Sales.FirstOrDefault(x => x.Id == Sale.Id);

                var newSoldItem = new SoldItem();

                InventoryItem Inv = null;

                if (!string.IsNullOrEmpty(e.Serial))
                    Inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == e.Serial);
                else
                    Inv = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Name == e.Name && x.Product.Supplier.Name == e.Supplier);

                newSoldItem.SaleId = Sale.Id;
                newSoldItem.Product = p.Products.FirstOrDefault(x => x.Item.Name == e.Name && x.Supplier.Name == e.Supplier);
                newSoldItem.SerialNumber = e.Serial;
                int rem = -1;

                newSoldItem.Quantity = calculateQuantity(e.Quantity, Inv.Quantity, out rem);
                newSoldItem.ItemPrice = e.SellingPrice;
                newSoldItem.Discount = e.Discount;

                if (rem == 0) {
                    p.InventoryItems.Remove(Inv);
                }
                else if (rem > 0) {
                    Inv.Quantity = rem;
                }

                var result = p.SoldItems.Add(newSoldItem);
                p.SaveChanges();

                OnSave?.Invoke(this, null);

                SoldItems.Add(new SoldItemViewModel(result));
            }
        }

        private void itemsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != 8) {
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this item in this sale?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
                return;
            }
            var table = sender as DataGridView;
            using (var p = new POSEntities()) {
                //var id = (int)(table.Rows[e.RowIndex].Cells[0].Value);
                var id = ((SoldItemViewModel)table.Rows[e.RowIndex].DataBoundItem).Id;
                var soldItem = p.SoldItems.FirstOrDefault(x => x.Id == id);

                if (!string.IsNullOrEmpty(soldItem.SerialNumber)) {
                    var inv = new InventoryItem();
                    inv.Product = soldItem.Product;
                    inv.Quantity = 1;
                    inv.SerialNumber = soldItem.SerialNumber;
                    p.InventoryItems.Add(inv);
                }
                else {
                    var inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == null && x.Product.Id == soldItem.ProductId);
                    if (inv != null) {
                        if (inv.Quantity != 0)
                            inv.Quantity += soldItem.Quantity;
                    }
                    else {
                        var temp = new InventoryItem();
                        temp.Product = soldItem.Product;
                        temp.Quantity = soldItem.Quantity;
                        p.InventoryItems.Add(temp);
                    }
                }

                p.SoldItems.Remove(soldItem);
                p.SaveChanges();
            }
            table.Rows.RemoveAt(e.RowIndex);
            MessageBox.Show("Entry Removed");
        }

        Customer validateNewCustomer(string newCustomer) {
            using (var p = new POSEntities()) {
                return p.Customers.FirstOrDefault(x => x.Name == newCustomer);
            }

        }
        private void soldTo_SelectedIndexChanged(object sender, EventArgs e) {

            //var newCustomer = validateNewCustomer(soldTo.Text);
            //using (var p = new POSEntities()) {
            //    var oldCustomer = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId);

            //    if (newCustomer != null) {
            //        if (oldCustomer.Name == newCustomer.Name) {
            //            return;
            //        }
            //        if (MessageBox.Show("Are you sure you want to change Customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
            //            soldTo.Text = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId).Name;
            //            return;
            //        }
            //    }
            //    var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
            //    s.CustomerId = newCustomer.Id;
            //    p.SaveChanges();
            //}
        }


        private void soldTo_Leave(object sender, EventArgs e) {
            //if (validateNewCustomer(soldTo.Text) == null) {
            //    using (var p = new POSEntities()) {
            //        var oldCustomer = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId);

            //        soldTo.Text = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId).Name;
            //        MessageBox.Show("Customer not found.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            //using (var p = new POSEntities()) {
            //    var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);

            //    s.Date = dateOfPurchase.Value;
            //    p.SaveChanges();
            //    //MessageBox.Show("Date changed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void itemsTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            if (e.RowIndex == -1) return;

            var table = sender as DataGridView;

            if (e.ColumnIndex == col_Price.Index) {
                var selectedItem = (SoldItemViewModel)table.SelectedRows[0].DataBoundItem;
                initialPrice = selectedItem.Price;

            }
            else if (e.ColumnIndex == col_Discount.Index) {
                var selectedItem = (SoldItemViewModel)table.SelectedRows[0].DataBoundItem;
                initialDiscount = selectedItem.Discount;
            }
        }

        decimal initialPrice = -1;
        decimal initialDiscount = -1;

        private void itemsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            var table = sender as DataGridView;

            if (decimal.TryParse(table[e.ColumnIndex, e.RowIndex].Value.ToString(), out decimal newValue)) {
                var selectedItem = (SoldItemViewModel)table.SelectedRows[0].DataBoundItem;

                if (e.ColumnIndex == col_Price.Index) {
                    TrySetNewPrice(newValue, selectedItem);
                }
                else if (e.ColumnIndex == col_Discount.Index) {
                    TrySetNewDiscount(newValue, selectedItem);
                }
            }
        }

        void TrySetNewPrice(decimal newPrice, SoldItemViewModel soldItem) {
            if (newPrice == initialPrice)
                return;

            soldItem.Price = newPrice;
            initialPrice = -1;
        }
        void TrySetNewDiscount(decimal newDiscount, SoldItemViewModel soldItem) {
            if (newDiscount < 0 || newDiscount == initialDiscount) {
                return;
            }
            soldItem.Discount = newDiscount;
            initialDiscount = -1;
        }

        private void itemsTable_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            e.Cancel = true;
            if (e.ColumnIndex == col_Price.Index) {
                MessageBox.Show("New Price Should be a Decimal!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.ColumnIndex == col_Discount.Index) {
                MessageBox.Show("New Discount Should be a Decimal!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void itemsTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            if (e.ColumnIndex == col_Price.Index) {
                if (decimal.TryParse(e.FormattedValue.ToString(), out decimal newValue)) {
                    e.Cancel = newValue < 0;

                    if (e.Cancel)
                        MessageBox.Show("Price cannot be Negative!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == col_Discount.Index) {
                if (decimal.TryParse(e.FormattedValue.ToString(), out decimal newValue)) {
                    e.Cancel = newValue < 0 || newValue > ((SoldItemViewModel)itemsTable.SelectedRows[0].DataBoundItem).Price;

                    if (e.Cancel)
                        MessageBox.Show("Discount must be less than or equal to price and cannot be Negative.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}


