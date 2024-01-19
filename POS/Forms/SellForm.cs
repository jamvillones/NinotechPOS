using POS.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS.Forms
{
    public partial class SellForm : Form
    {
        public SellForm()
        {
            InitializeComponent();

            SetBindings();
            FormatValues();
        }

        public void SetSearchKeyword(string keyword)
        {
            searchControl1.firstControl.Text = keyword;
        }

        private void SetBindings()
        {
            cartTable.AutoGenerateColumns = false;
            col_Barcode.DataPropertyName = nameof(Cart_Item_ViewModel.Id);
            col_Name.DataPropertyName = nameof(Cart_Item_ViewModel.Name);
            col_Serial.DataPropertyName = nameof(Cart_Item_ViewModel.Serial);
            col_Qty.DataPropertyName = nameof(Cart_Item_ViewModel.Quantity);
            col_Price.DataPropertyName = nameof(Cart_Item_ViewModel.Price);
            col_Discount.DataPropertyName = nameof(Cart_Item_ViewModel.Discount);
            col_SubTotal.DataPropertyName = nameof(Cart_Item_ViewModel.SubTotal);
            cartTable.DataSource = CartItems;

            _customerOption.DisplayMember = nameof(Customer.Name);
        }

        private async void SellForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var customers = await context.Customers.AsQueryable().AsNoTracking().OrderBy(o => o.Name).ToListAsync();
                    await Task.Run(() =>
                    {
                        foreach (var c in customers)
                            _customerOption.InvokeIfRequired(() => _customerOption.Items.Add(c));
                    });

                }
            }
            catch (Exception)
            {

            }
        }

        private BindingList<Cart_Item_ViewModel> CartItems = new BindingList<Cart_Item_ViewModel>();

        private class Cart_Item_ViewModel : INotifyPropertyChanged
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Serial { get; set; }

            private int _quantity;
            public int Quantity
            {
                get { return _quantity; }
                set
                {
                    _quantity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Quantity)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubTotal)));
                }
            }
            private decimal _price;
            public decimal Price
            {
                get { return _price; }
                set
                {
                    _price = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubTotal)));
                }
            }
            private decimal _discount;

            public event PropertyChangedEventHandler PropertyChanged;

            public decimal Discount
            {
                get { return _discount; }
                set
                {
                    _discount = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Discount)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubTotal)));
                }
            }
            public decimal SubTotal => Quantity * (Price - Discount);
        }

        private async void searchControl1_OnSearch(object sender, Misc.SearchEventArgs e)
        {
            loadingTxt.Text = "Searching...";

            string serial = string.Empty;
            if (!GetQtyAndKeywordFromString(e.Text, out int qty, out string keyword))
            {
                MessageBox.Show("Keyword must be formatted in [number]*[barcode|serial number]", "Parsing Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new POSEntities())
                {
                    var selectedItem = await context.Items
                        .AsNoTracking()
                        .AsQueryable()
                        .FirstOrDefaultAsync(i => i.Barcode == keyword || i.Name == keyword);

                    if (selectedItem != null && !selectedItem.IsFinite)
                    {
                        TryAddInfinite(selectedItem.Id, selectedItem.Name, qty, selectedItem.SellingPrice);
                        loadingTxt.Text = string.Empty;
                        return;
                    }

                    int maxQty = 0;

                    if (selectedItem != null)
                    {
                        maxQty = selectedItem.QuantityInInventory;

                        if (maxQty <= 0)
                        {
                            loadingTxt.Text = "ITEM IS EMPTY";
                            return;
                        }

                        if (selectedItem.IsSerialRequired)
                        {
                            int repeats = qty <= maxQty ? qty : maxQty;
                            qty = 1;
                            for (int i = 0; i < repeats; i++)
                            {
                                var takenSerialNumbers = CartItems.Select(x => x.Serial).ToArray();

                                serial = (await context.InventoryItems.AsNoTracking().AsQueryable()
                                    .Where(x => takenSerialNumbers.All(c => c != x.SerialNumber))
                                    .Where(x => x.Product.Item.Id == selectedItem.Id)
                                    .FirstAsync())?.SerialNumber;

                                CartItems.Add(new Cart_Item_ViewModel()
                                {
                                    Id = selectedItem.Id,
                                    Name = selectedItem.Name,
                                    Serial = serial,
                                    Quantity = qty,
                                    Price = selectedItem.SellingPrice,
                                    Discount = 0
                                });
                            }

                            loadingTxt.Text = string.Empty;
                            return;
                        }

                    }
                    else
                    {
                        var invItem = await context
                            .InventoryItems
                            .AsNoTracking()
                            .AsQueryable()
                            .FirstOrDefaultAsync(i => i.SerialNumber == keyword);

                        if (invItem != null && CartItems.All(c => c.Serial != invItem.SerialNumber))
                        {
                            qty = 1;
                            serial = invItem.SerialNumber;
                            selectedItem = invItem.Product.Item;
                        }
                    }

                    if (selectedItem is null)
                    {
                        loadingTxt.Text = "ITEM NOT FOUND!";
                        return;
                    }

                    if (string.IsNullOrEmpty(serial))
                        TryAdd(selectedItem.Id, selectedItem.Name, qty, maxQty, selectedItem.SellingPrice);
                    else
                        AddWithSerial(selectedItem.Id, selectedItem.Name, serial, selectedItem.SellingPrice);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                {
                    await Task.Delay(300);
                    loadingTxt.Text = "ALREADY AT MAXIMUM QUANTITY!";
                    return;
                }
            }
        }

        void AddWithSerial(string id, string name, string serial, decimal price, decimal discount = 0)
        {
            CartItems.Add(new Cart_Item_ViewModel()
            {
                Id = id,
                Name = name,
                Serial = serial,
                Quantity = 1,
                Price = price,
                Discount = discount
            });
            loadingTxt.Text = string.Empty;
        }
        void TryAddInfinite(string id, string name, int qty, decimal price, decimal discount = 0)
        {

            if (CartItems.Count > 0 && CartItems.Any(c => c.Id == id))
            {
                var already = CartItems.FirstOrDefault(c => c.Id == id);
                if (already != null)
                {
                    already.Quantity += qty;
                    OnTotalChanges();
                    FormatValues();
                    loadingTxt.Text = string.Empty;
                    return;
                }
            }

            CartItems.Add(new Cart_Item_ViewModel()
            {
                Id = id,
                Name = name,
                Serial = string.Empty,
                Quantity = qty,
                Price = price,
                Discount = discount
            });
            loadingTxt.Text = string.Empty;
        }

        void TryAdd(string id, string name, int qty, int maxQty, decimal price, decimal discount = 0)
        {

            if (CartItems.Count > 0 && CartItems.Any(c => c.Id == id))
            {
                var already = CartItems.FirstOrDefault(c => c.Id == id);
                if (already != null)
                {
                    if (already.Quantity >= maxQty)
                    {
                        loadingTxt.Text = "ALREADY AT MAXIMUM QUANTITY!"; return;
                    }

                    already.Quantity = already.Quantity + qty >= maxQty ? maxQty : already.Quantity + qty;
                    OnTotalChanges();
                    FormatValues();
                    loadingTxt.Text = string.Empty;
                    return;
                }
            }

            CartItems.Add(new Cart_Item_ViewModel()
            {
                Id = id,
                Name = name,
                Serial = string.Empty,
                Quantity = qty >= maxQty ? maxQty : qty,
                Price = price,
                Discount = discount
            });
            loadingTxt.Text = string.Empty;
        }

        void OnTotalChanges()
        {
            discount.Maximum = total;
        }

        bool GetQtyAndKeywordFromString(string raw, out int qty, out string keyword)
        {
            qty = 1;
            keyword = string.Empty;
            var splitted = raw.Split('*');

            if (splitted.Length == 2)
            {
                if (int.TryParse(splitted[0], out qty))
                {
                    keyword = splitted[1];
                }
                else
                {
                    return false;
                }
            }
            else
            {
                keyword = raw;
            }
            return true;
        }

        decimal total => CartItems.Select(c => c.SubTotal).Sum();
        decimal grandtTotal => total - discount.Value;

        private void cartTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            OnTotalChanges();
            FormatValues();
        }

        private void tendered_ValueChanged(object sender, EventArgs e)
        {
            FormatValues();
        }

        private void discount_ValueChanged(object sender, EventArgs e)
        {
            FormatValues();
        }

        void FormatValues()
        {
            this.totalTxt.Text = total.ToCurrency();
            this.grandTotalTxt.Text = grandtTotal.ToCurrency();
            this.changeTxt.Text = (tendered.Value - grandtTotal).ToCurrency();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tendered.Value = grandtTotal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            discount.Value = total;
            tendered.Value = 0;
        }

        private async void _customerOption_Validated(object sender, EventArgs e)
        {
            if (_customerOption.Text.IsEmpty())
                return;
            ///the option is not yet in the valid list
            if (_customerOption.SelectedItem == null &&
                MessageBox.Show("Customer is not yet registered. Would you like to register?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                var details = _customerOption.Text.Trim(' ', '/').Split('/');
                var cust_Name = details[0];
                var cust_contact = details[1];
                var cust_address = details[2];

                var addCustomer = new Customer()
                {
                    Name = cust_Name.Trim(),
                    ContactDetails = cust_contact.Trim(),
                    Address = cust_address.Trim()
                };

                using (var context = new POSEntities())
                {
                    var result = context.Customers.Add(addCustomer);
                    await context.SaveChangesAsync();

                    _customerOption.Items.Add(result);
                    _customerOption.SelectedItem = result;
                }
            }
        }

        private void cartTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            FormatValues();
        }

        private void upDown_Validated(object sender, EventArgs e)
        {
            if (sender is NumericUpDown updown)
            {
                if (updown.Text.IsEmpty())
                {
                    updown.Value = 0;
                }
            }
        }
    }
}
