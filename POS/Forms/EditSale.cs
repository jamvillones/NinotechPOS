using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Misc;


namespace POS.Forms
{
    public partial class EditSale : Form
    {
        Login currentLogin
        {
            get
            {
                return Misc.UserManager.instance.currentLogin;
            }
        }

        public event EventHandler OnSave;

        Sale sale;

        public EditSale(int id)
        {
            InitializeComponent();
            Initialize(id);
        }
        /// <summary>
        /// initializes the values
        /// </summary>
        /// <param name="id"></param>
        private void Initialize(int id)
        {
            using (var p = new POSEntities())
            {
                sale = p.Sales.FirstOrDefault(x => x.Id == id);
                var soldItems = sale.SoldItems;
                SaleId.Text = sale.Id.ToString();
                foreach (var x in soldItems)
                {
                    itemsTable.Rows.Add(x.Id, x.Product.Item.Name,
                                        x.SerialNumber,
                                        x.Quantity,
                                        string.Format("₱ {0:n}", x.ItemPrice),
                                        x.Discount,
                                        string.Format("₱ {0:n}", (x.Quantity * x.ItemPrice) * ((100 - x.Discount) / 100)),
                                        x.Product.Supplier.Name,
                                        "Return Item");
                }
                total.Text = string.Format("₱ {0:n}", sale.GetSaleTotalPrice());
                amountRecieved.Text = string.Format("₱ {0:n}", sale.AmountRecieved);

                soldTo.Text = sale.Customer.Name;

                var items = p.Customers.Select(x => x.Name).ToArray();
                soldTo.Items.AddRange(items);
                soldTo.AutoCompleteCustomSource.AddRange(items);

                dateOfPurchase.Value = sale.Date.Value;

            }
            remaining.Text = string.Format("₱ {0:n}", (sale.GetSaleTotalPrice() - sale.AmountRecieved));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var adv = new AdvancedSearchForm())
            {
                adv.ItemSelected += Adv_ItemSelected;
                adv.ShowDialog();
            }
        }
        int calculateQuantity(int quantity, int total, out int remains)
        {

            if (total == 0)
            {
                remains = -1;
                return quantity;
            }
            int r = total - quantity;
            if (r < 0)
            {
                remains = 0;
                return total;
            }
            remains = r;
            return quantity;
        }

        private void Adv_ItemSelected(object sender, ItemInfoHolder e)
        {
            Console.WriteLine("add item here");

            using (var p = new POSEntities())
            {
                var targetSale = p.Sales.FirstOrDefault(x => x.Id == sale.Id);

                var newSoldItem = new SoldItem();

                InventoryItem Inv = null;

                if (!string.IsNullOrEmpty(e.Serial))
                    Inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == e.Serial);
                else
                    Inv = p.InventoryItems.FirstOrDefault(x => x.Product.Item.Name == e.Name && x.Product.Supplier.Name == e.Supplier);

                Console.WriteLine(Inv.Product.Item.Name);
                newSoldItem.SaleId = sale.Id;
                newSoldItem.Product = p.Products.FirstOrDefault(x => x.Item.Name == e.Name && x.Supplier.Name == e.Supplier);
                newSoldItem.SerialNumber = e.Serial;
                int rem = -1;

                newSoldItem.Quantity = calculateQuantity(e.Quantity, Inv.Quantity, out rem);
                newSoldItem.ItemPrice = e.SellingPrice;
                newSoldItem.Discount = e.discount;
                Console.WriteLine(rem);
                if (rem == 0)
                {
                    p.InventoryItems.Remove(Inv);
                }
                else if (rem > 0)
                {
                    Inv.Quantity = rem;
                }

                p.SoldItems.Add(newSoldItem);
                p.SaveChanges();

                OnSave?.Invoke(this, null);

                itemsTable.Rows.Add(newSoldItem.Id,
                                    newSoldItem.Product.Item.Name,
                                    newSoldItem.SerialNumber,
                                    newSoldItem.Quantity,
                                    string.Format("₱ {0:n}", newSoldItem.ItemPrice),
                                    newSoldItem.Discount,
                                    string.Format("₱ {0:n}", (newSoldItem.Quantity * newSoldItem.ItemPrice) * ((100 - newSoldItem.Discount) / 100)),
                                    newSoldItem.Product.Supplier.Name,
                                    "Return Item");

            }
        }

        private void itemsTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            total.Text = string.Format("₱ {0:n}", sale.GetSaleTotalPrice());
            remaining.Text = string.Format("₱ {0:n}", (sale.GetSaleTotalPrice() - sale.AmountRecieved));
        }

        private void itemsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 8)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to remove this item in this sale?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }
            var table = sender as DataGridView;
            using (var p = new POSEntities())
            {
                var id = (int)(table.Rows[e.RowIndex].Cells[0].Value);
                var soldItem = p.SoldItems.FirstOrDefault(x => x.Id == id);

                if (!string.IsNullOrEmpty(soldItem.SerialNumber))
                {
                    var inv = new InventoryItem();
                    inv.Product = soldItem.Product;
                    inv.Quantity = 1;
                    inv.SerialNumber = soldItem.SerialNumber;
                    p.InventoryItems.Add(inv);
                }
                else
                {
                    var inv = p.InventoryItems.FirstOrDefault(x => x.SerialNumber == null && x.Product.Id == soldItem.ProductId);
                    if (inv != null)
                    {
                        if (inv.Quantity != 0)
                            inv.Quantity += soldItem.Quantity;
                    }
                    else
                    {
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

        Customer validateNewCustomer(string newCustomer)
        {
            using (var p = new POSEntities())
            {
                return p.Customers.FirstOrDefault(x => x.Name == newCustomer);
            }

        }
        private void soldTo_SelectedIndexChanged(object sender, EventArgs e)
        {

            var newCustomer = validateNewCustomer(soldTo.Text);
            using (var p = new POSEntities())
            {
                var oldCustomer = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId);

                if (newCustomer != null)
                {
                    if (oldCustomer.Name == newCustomer.Name)
                    {
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to change Customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        soldTo.Text = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId).Name;
                        return;
                    }
                }
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
                s.CustomerId = newCustomer.Id;
                p.SaveChanges();
            }
        }


        private void soldTo_Leave(object sender, EventArgs e)
        {
            if (validateNewCustomer(soldTo.Text) == null)
            {
                using (var p = new POSEntities())
                {
                    var oldCustomer = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId);

                    soldTo.Text = p.Customers.FirstOrDefault(x => x.Id == sale.CustomerId).Name;
                    MessageBox.Show("Customer not found.","", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);

                s.Date = dateOfPurchase.Value;
                p.SaveChanges();
                //MessageBox.Show("Date changed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}


