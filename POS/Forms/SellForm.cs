using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                    _customerOption.SelectedItem = customers.FirstOrDefault(x => x.Name.Equals("walkin", StringComparison.OrdinalIgnoreCase));

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
            await Task.Delay(100);

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
                            //loadingTxt.Text = "ITEM IS EMPTY";
                            await Task.Delay(100);
                            notifyIcon1.ShowBalloonTip(1, "Item is Empty!", selectedItem.Name, ToolTipIcon.Warning);
                            loadingTxt.Text = string.Empty;
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
                        //loadingTxt.Text = "ITEM NOT FOUND!";
                        await Task.Delay(100);
                        notifyIcon1.ShowBalloonTip(1, "Item not found", "Please make sure that the item is already added to the records.", ToolTipIcon.Error);
                        loadingTxt.Text = string.Empty;
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
                    await Task.Delay(100);
                    notifyIcon1.ShowBalloonTip(1, "Item is at maximum quantity", "All Items for this entry is already in cart.", ToolTipIcon.Warning);
                    loadingTxt.Text = string.Empty;
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
                        notifyIcon1.ShowBalloonTip(1, "Item is at maximum quantity", "All Items for this entry is already in cart.", ToolTipIcon.Warning);
                        loadingTxt.Text = string.Empty;
                        return;
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
            checkoutBtn.Enabled = cartTable.Rows.Count > 0;
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
                var details = _customerOption.Text.Split('/').ToArray();
                var cust_Name = details[0];
                var cust_contact = details.Length == 2 || details.Length == 3 ? details[1] : null;
                var cust_address = details.Length == 3 ? details[2] : null;

                var addCustomer = new Customer()
                {
                    Name = cust_Name.Trim(),
                    ContactDetails = cust_contact.NullIfEmpty(),
                    Address = cust_address.NullIfEmpty()
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

            if (cartTable.Rows.Count == 0)
            {
                discBtn.Enabled = editQtyBtn.Enabled = priceBtn.Enabled = false;
            }

            checkoutBtn.Enabled = cartTable.Rows.Count > 0;

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

        bool ValidateCheckout()
        {
            if (CartItems.Count == 0)
                return false;

            if (_customerOption.SelectedItem == null)
            {
                if (
                    _customerOption.Text.IsEmpty() &&
                    MessageBox.Show(
                    "Customer will be set to walkin. Are you sure you want to continue?", "Customer is not set",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.Cancel) return false;
                else
                {
                    if (
                    MessageBox.Show("Customer will be added automatically with the details provided when you proceed.\n\nYou can change it out later in the Customers List.",
                    "Customer is not yet registered.",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.Cancel) return false;
                }
            }

            return true;
        }

        bool IsAllValuesEqual(decimal[] priceList, out decimal value)
        {
            value = 0;
            if (priceList.Length == 0) return false;

            var initialValue = priceList.First();

            if (priceList.All(item => item == initialValue))
            {
                value = initialValue;
                return true;
            }
            return false;
        }

        void Reset()
        {
            CartItems.Clear();

            tendered.Value = discount.Value = 0;
        }

        private async void checkout_Click(object sender, EventArgs e)
        {
            if (!ValidateCheckout()) return;

            using (var context = new POSEntities())
            {
                var newSale = new Sale()
                {
                    Customer = (Customer)_customerOption.SelectedItem,
                    Login = await context.Logins.FirstOrDefaultAsync(x => x.Id == UserManager.instance.currentLogin.Id),
                    Date = DateTime.Now,
                    AmountRecieved = tendered.Value > grandtTotal ? grandtTotal : tendered.Value,
                    Discount = discount.Value,
                    SaleType = tendered.Value < grandtTotal ? SaleType.Charged.ToString() : SaleType.Regular.ToString()
                };

                ToPrint = context.Sales.Add(newSale);

                foreach (var entry in CartItems)
                {
                    var item = await context.Items.FirstOrDefaultAsync(x => x.Id == entry.Id);
                    SoldItem newSoldItem = null;
                    if (item.IsFinite)
                    {
                        if (item.IsSerialRequired)
                        {
                            var inv = await context.InventoryItems.FirstOrDefaultAsync(x => x.SerialNumber == entry.Serial);

                            newSoldItem = new SoldItem()
                            {
                                Product = inv.Product,
                                SerialNumber = entry.Serial,
                                Quantity = entry.Quantity,
                                ItemPrice = entry.Price,
                                Discount = entry.Discount,
                            };
                            context.SoldItems.Add(newSoldItem);
                            context.InventoryItems.Remove(inv);
                        }
                        else
                        {
                            var invItems = await context.InventoryItems
                                .Where(x => x.Product.ItemId == entry.Id)
                                .OrderBy(o => o.Quantity)
                                .ToListAsync();

                            int entryTotal = entry.Quantity;

                            foreach (var i in invItems)
                            {
                                if (entryTotal - i.Quantity < 0)
                                {
                                    context.SoldItems.Add(
                                        new SoldItem()
                                        {
                                            ProductId = i.ProductId,
                                            Quantity = entryTotal,
                                            ItemPrice = entry.Price,
                                            Discount = entry.Discount,

                                        });

                                    i.Quantity -= entryTotal;
                                    break;
                                }
                                else
                                {
                                    entryTotal -= i.Quantity;
                                    newSoldItem = new SoldItem()
                                    {
                                        ProductId = i.ProductId,
                                        Quantity = i.Quantity,
                                        ItemPrice = entry.Price,
                                        Discount = entry.Discount,

                                    };
                                    context.SoldItems.Add(newSoldItem);
                                    context.InventoryItems.Remove(i);

                                    if (entryTotal == 0)
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        context.SoldItems.Add(
                            new SoldItem()
                            {
                                ProductId = item.Products.First().Id,
                                Quantity = entry.Quantity,
                                ItemPrice = entry.Price,
                                Discount = entry.Discount,
                            });
                    }
                }
                await context.SaveChangesAsync();
                notifyIcon1.ShowBalloonTip(1, newSale.SaleType.ToString().ToUpper() + " SALE", newSale.Customer?.ToString() + " - " + newSale.AmountDue.ToCurrency(), ToolTipIcon.Info);
            }

            //MessageBox.Show(
            //       "Saved!", "",
            //       MessageBoxButtons.OKCancel,
            //       MessageBoxIcon.Information);

            if (checkBox1.Checked)
            {
                try
                {
                    printDoc.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Printing failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Reset();
        }

        Sale ToPrint = null;
        IEnumerable<Cart_Item_ViewModel> SelectedItemInCart => cartTable.SelectedRows.Cast<DataGridViewRow>().Select(row => (Cart_Item_ViewModel)row.DataBoundItem);

        string SelectedSerial => ((Cart_Item_ViewModel)cartTable.SelectedRows[0].DataBoundItem).Serial;
        private void cartTable_SelectionChanged(object sender, EventArgs e)
        {
            if (cartTable.SelectedRows.Count == 0)
            {
                return;
            }

            var selected = SelectedItemInCart;
            editQtyBtn.Enabled = cartTable.SelectedRows.Count == 1 && SelectedSerial.IsEmpty();
            priceBtn.Enabled = IsAllValuesEqual(selected.Select(s => s.Price).ToArray(), out priceToChange);
            discBtn.Enabled = IsAllValuesEqual(selected.Select(s => s.Discount).ToArray(), out discountToChange);
        }
        decimal priceToChange;
        decimal discountToChange;
        private void priceBtn_Click(object sender, EventArgs e)
        {
            using (var editDecimalForm = new EditDecimalValue(priceToChange))
            {
                editDecimalForm.Text = "Edit Price - " + priceToChange.ToCurrency();
                if (editDecimalForm.ShowDialog() == DialogResult.OK)
                {
                    var selected = SelectedItemInCart;
                    foreach (var s in selected)
                        s.Price = (decimal)editDecimalForm.Tag;
                    FormatValues();
                }
            }
        }

        private void discBtn_Click(object sender, EventArgs e)
        {
            using (var editDecimalForm = new EditDecimalValue(discountToChange))
            {
                editDecimalForm.Text = "Edit Discount - " + discountToChange.ToCurrency();
                if (editDecimalForm.ShowDialog() == DialogResult.OK)
                {
                    var selected = SelectedItemInCart;
                    foreach (var s in selected)
                    {
                        var newDiscount = (decimal)editDecimalForm.Tag;
                        s.Discount = newDiscount > s.Price ? s.Price : newDiscount;
                    }
                    FormatValues();
                }
            }
        }

        PrintAction printAction;

        private void printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printAction = e.PrintAction;
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ReceiptDetails details = new ReceiptDetails();

            details.ControlNumber = ToPrint.Id.ToString();
            details.CustomerName = ToPrint.Customer.ToString();
            details.TransactBy = ToPrint.Login.ToString();
            details.Tendered = ToPrint.AmountRecieved;

            foreach (var item in CartItems)
                details.Additem(
                    item.Name,
                    item.Serial,
                    item.Quantity,
                    item.Price,
                    item.Discount
                    );

            e.FormatReciept(printAction, details);
            ToPrint = null;
        }

        private async void editQtyBtn_Click(object sender, EventArgs e)
        {
            var selected = SelectedItemInCart.First();
            int initialQty = selected.Quantity;
            int maxQty = 0;

            using (var context = new POSEntities())
            {
                var item = await context.Items.AsNoTracking().FirstOrDefaultAsync(x => x.Id == selected.Id);
                maxQty = !item.IsFinite ? 999999999 : item.QuantityInInventory;
            }

            using (var editDecimalForm = new EditDecimalValue(initialQty, maxQty, true))
            {
                editDecimalForm.Text = "Edit Qty - " + initialQty;
                if (editDecimalForm.ShowDialog() == DialogResult.OK)
                {
                    selected.Quantity = (int)((decimal)editDecimalForm.Tag);
                    FormatValues();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var itemView = new ItemListForm())
            {
                if (itemView.ShowDialog() == DialogResult.OK)
                {
                    SetSearchKeyword(itemView.Tag.ToString());
                }
            }
        }
    }
}
