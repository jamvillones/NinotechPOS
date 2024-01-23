using POS.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class EditSale : Form {

        BindingList<SoldItemViewModel> SoldItems = new BindingList<SoldItemViewModel>();
        public event EventHandler OnSave;
        int _saleId = 0;
        public EditSale(int id) {
            _saleId = id;
            InitializeComponent();
            InitBindings();

            itemsTable.DecimalOnlyEditting(HandleEdittingTextbox);
            itemsTable.CellBeginEdit += ItemsTable_CellBeginEdit;
            itemsTable.CellEndEdit += ItemsTable_CellEndEdit;

            col_Price.ReadOnly = col_Discount.ReadOnly = !UserManager.instance.IsAdmin;
        }

        private void ItemsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            ///handle the actual saving
        }

        private void ItemsTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            columnIndexOfEditting = e.ColumnIndex;
            rowIndexOfEditting = e.RowIndex;
        }

        int columnIndexOfEditting;
        int rowIndexOfEditting;
        void HandleEdittingTextbox(TextBox t) {
            if (columnIndexOfEditting == col_Discount.Index) {
                t.Text = SoldItems[rowIndexOfEditting].Discount.ToString();
            }
            else if (columnIndexOfEditting == col_Price.Index) {
                t.Text = SoldItems[rowIndexOfEditting].Price.ToString();
            }
        }


        private class SoldItemViewModel : INotifyPropertyChanged {
            private decimal price;
            private decimal discount;

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
            public decimal Price {
                get => price; set {
                    if (value == price) return;

                    price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                }
            }
            public decimal Discount {
                get => discount;
                set {
                    if (discount == value) return;

                    discount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Discount)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                }
            }
            public decimal Total => Quantity * (Price - Discount);
            public string SupplierName { get; private set; }

            public event PropertyChangedEventHandler PropertyChanged;
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

            itemsTable.DataSource = SoldItems;
        }
        /// <summary>
        /// initializes the values
        /// </summary>
        /// <param name="id"></param>
        private async Task Initialize(int id) {
            using (var p = new POSEntities()) {
                var sale = await p.Sales.FirstOrDefaultAsync(x => x.Id == id);

                this.Text = this.Text + " - " + id;

                var items = sale.SoldItems
                    .OrderBy(x => x.Product.Item.Name)
                    .Select(s => new SoldItemViewModel(s))
                    .ToArray();

                foreach (var i in items)
                    SoldItems.Add(i);
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
                var targetSale = p.Sales.FirstOrDefault(x => x.Id == _saleId);

                var newSoldItem = new SoldItem();

                InventoryItem Inv = null;

                if (!string.IsNullOrEmpty(e.Serial))
                    Inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == e.Serial);
                else
                    Inv = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Name == e.Name && x.Product.Supplier.Name == e.Supplier);

                newSoldItem.SaleId = _saleId;
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

        private async void ItemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != col_Remove.Index) return;

            if (MessageBox.Show(
                "Are you sure you want to remove this item in this sale?",
                "", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            var table = sender as DataGridView;
            using (var context = new POSEntities()) {
                var id = ((SoldItemViewModel)table.Rows[e.RowIndex].DataBoundItem).Id;
                var soldItem = context.SoldItems.FirstOrDefault(x => x.Id == id);

                if (!string.IsNullOrEmpty(soldItem.SerialNumber)) {
                    var inv = new InventoryItem();
                    inv.Product = soldItem.Product;
                    inv.Quantity = 1;
                    inv.SerialNumber = soldItem.SerialNumber;
                    context.InventoryItems.Add(inv);
                }
                else {
                    var inv = context.InventoryItems.FirstOrDefault(x => x.SerialNumber == null && x.Product.Id == soldItem.ProductId);
                    if (inv != null) {
                        if (inv.Quantity != 0)
                            inv.Quantity += soldItem.Quantity;
                    }
                    else {
                        var temp = new InventoryItem();
                        temp.Product = soldItem.Product;
                        temp.Quantity = soldItem.Quantity;
                        context.InventoryItems.Add(temp);
                    }
                }
                context.SoldItems.Remove(soldItem);
                context.SaveChanges();
            }

            await Task.Delay(200);

            SoldItems.RemoveAt(e.RowIndex);
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

        private async void EditSale_Load(object sender, EventArgs e) {
            await Initialize(_saleId);
        }
        public bool ChangesMade { get; private set; } = false;
        private async void itemsTable_CellValidated(object sender, DataGridViewCellEventArgs e) {
            var table = sender as DataGridView;

            try {
                using (var context = new POSEntities()) {
                    var soldItem = ((SoldItemViewModel)table.Rows[e.RowIndex].DataBoundItem);
                    var targetSoldItem = await context.SoldItems.FirstOrDefaultAsync(x => x.Id == soldItem.Id);
                    if (e.ColumnIndex == col_Discount.Index)
                        targetSoldItem.Discount = soldItem.Discount;

                    else if (e.ColumnIndex == col_Price.Index)
                        targetSoldItem.ItemPrice = soldItem.Price;
                    await context.SaveChangesAsync();
                }

                ChangesMade = true;
            }
            catch (Exception) {

            }
        }
    }
}


