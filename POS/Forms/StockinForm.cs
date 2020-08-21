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
    public partial class StockinForm : Form
    {
        List<Product> productsToImport = new List<Product>();
        public event EventHandler OnSave;
        public StockinForm()
        {
            InitializeComponent();
        }

        void SetTable()
        {
            itemsTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.Products.Where(x=>x.Item.Type == ItemType.Hardware.ToString()))
                    itemsTable.Rows.Add(i.Item?.Barcode, i.Item?.Name, i.Cost, i.Supplier?.Name);
            }
            itemsTable.Sort(itemsTable.Columns[0], ListSortDirection.Ascending);
        }
        private void StockinForm_Load(object sender, EventArgs e)
        {
            SetTable();
            toolTip.SetToolTip(barcode, "Press f1 to set focus on barcode");
            toolTip.SetToolTip(serialNumber, "Press f2 to set focus on serial number");
            toolTip.SetToolTip(quantity, "Press f3 to set focus on quantity");
        }

        private void itemsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (itemsTable.DataGridViewCurrentRowIndex() == -1)
                return;
            using (var p = new POSEntities())
            {
                /// get the current row
                var currentRow = itemsTable.Rows[itemsTable.DataGridViewCurrentRowIndex()];
                ///get the supplier name based on current row
                string supplierName = currentRow.Cells[3].Value.ToString();
                ///get the barcode based on current row
                string barc = currentRow.Cells[0].Value.ToString();

                selectedProduct = p.Products.FirstOrDefault(x => x.Supplier.Name == supplierName && x.ItemId == barc);
                itemName.Text = selectedProduct.Item.Name;
                cost.Text = selectedProduct.Cost.ToString();
                supplier.Text = selectedProduct.Supplier.Name;
                barcode.Text = selectedProduct.ItemId;
            }
            serialNumber.Text = string.Empty;
            this.ActiveControl = serialNumber;
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            //cost.Text = (quantity.Value * item.SellingPrice).ToString();
        }
        bool alreadyInTable(string id, string supplier, out int index)
        {
            string b, s;
            for (int i = 0; i < inventoryTable.RowCount; i++)
            {

                b = inventoryTable.Rows[i].Cells[0].Value.ToString();
                s = inventoryTable.Rows[i].Cells[6].Value.ToString();
                if (b == id && s == supplier && inventoryTable.Rows[i].Cells[1].Value.ToString() == string.Empty)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }
        Item getItemById(string id)
        {
            using (var p = new POSEntities())
            {
                return p.Items.FirstOrDefault(x => x.Barcode == id);
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            addItem();
        }

        private void stockinBtn_Click(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                Product product;
                for (int i = 0; i < inventoryTable.RowCount; i++)
                {
                    var it = new InventoryItem();
                    var itemId = inventoryTable.Rows[i].Cells[0].Value.ToString();
                    var suppName = inventoryTable.Rows[i].Cells[6].Value.ToString();
                    var serialNum = inventoryTable.Rows[i].Cells[1].Value.ToString();
                    var q = Convert.ToInt32((inventoryTable.Rows[i].Cells[3].Value.ToString()));
                    product = p.Products.FirstOrDefault(x => x.ItemId == itemId && x.Supplier.Name == suppName);

                   
                    if (string.IsNullOrEmpty(serialNum))
                    {
                        it = p.InventoryItems.FirstOrDefault(x => x.Product.ItemId == itemId && x.Product.Supplier.Name == suppName);
                        if (it == null)
                        {
                            it = new InventoryItem();
                            it.Product = product;
                            it.Quantity = q;
                            p.InventoryItems.Add(it);
                        }
                        else
                        {
                            it.Quantity += q;
                        }
                    }
                    else
                    {
                        it = new InventoryItem();
                        it.Product = product;
                        it.Quantity = q;
                        it.SerialNumber = serialNum;
                        p.InventoryItems.Add(it);
                    }
                    var stockinHist = new StockinHistory();
                    stockinHist.ItemName = it.Product.Item.Name;
                    stockinHist.Cost = it.Product.Cost;
                    stockinHist.Supplier = it.Product.Supplier.Name;
                    stockinHist.Date = DateTime.Now;
                    stockinHist.Quantity = q;
                    stockinHist.SerialNumber = it.SerialNumber;
                    stockinHist.LoginUsername = p.Logins.FirstOrDefault(x => x.Username == UserManager.instance.currentLogin.Username).Username;

                    p.StockinHistories.Add(stockinHist);
                }
                p.SaveChanges();
                OnSave?.Invoke(this, null);
                MessageBox.Show("Saved.");
                this.Close();
            }
        }

        bool serialAlreadyTaken()
        {
            using (var p = new POSEntities())
            {
                if (p.InventoryItems.FirstOrDefault(x => x.SerialNumber == serialNumber.Text) != null)
                {
                    MessageBox.Show("Serial number already in inventory.");
                    return true;
                }
            }
            for (int i = 0; i < inventoryTable.RowCount; i++)
            {
                if (serialNumber.Text == inventoryTable.Rows[i].Cells[1].Value.ToString())
                {
                    MessageBox.Show("Serial number already on the list.");
                    return true;
                }
            }
            return false;
        }

        Product selectedProduct;
        void addItem()
        {
            ///check if the item to be added has serial
            if (!string.IsNullOrEmpty(serialNumber.Text))
            {
                if (serialAlreadyTaken())
                {
                    return;
                }
            }
            else
            {
                ///if not then check if the item to be added is already in the table, if yes just edit quantitty
                int index;
                if (alreadyInTable(barcode.Text, supplier.Text, out index))
                {
                    var currentQuant = Convert.ToInt32(inventoryTable.Rows[index].Cells[3].Value);
                    inventoryTable.Rows[index].Cells[3].Value = currentQuant + quantity.Value;
                    inventoryTable.Rows[index].Cells[5].Value = (currentQuant + quantity.Value) * Convert.ToDecimal(cost.Text);
                    return;
                }
            }
            ///else, add the item
            Decimal totalCost = quantity.Value * Convert.ToDecimal(cost.Text);
            inventoryTable.Rows.Add(barcode.Text, serialNumber.Text, itemName.Text, quantity.Value, cost.Text, totalCost.ToString(), supplier.Text);

            serialNumber.Text = string.Empty;
        }

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            addItem();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (inventoryTable.RowCount == 0)
                return;
            int index = inventoryTable.CurrentCell.RowIndex;
            inventoryTable.Rows.RemoveAt(index);
        }

        private void serialNumber_TextChanged(object sender, EventArgs e)
        {
            if (serialNumber.Text.Count() != 0)
            {
                quantity.Value = 1;
                quantity.Enabled = false;
                return;
            }
            quantity.Enabled = true;
        }

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (barcode.Text == string.Empty)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                itemsTable.Rows.Clear();
                using (var p = new POSEntities())
                {
                    var products = p.Products.Where(x => x.ItemId == barcode.Text);
                    foreach (var i in products)
                    {
                        itemsTable.Rows.Add(i.ItemId, i.Item.Name, i.Cost, i.Supplier.Name);
                    }
                }
            }
        }

        private void barcode_TextChanged(object sender, EventArgs e)
        {
            if (barcode.TextLength <= 0)
                SetTable();
        }

        private void StockinForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                this.ActiveControl = barcode;

            if (e.KeyCode == Keys.F2)
                this.ActiveControl = serialNumber;

            if (e.KeyCode == Keys.F3)
                this.ActiveControl = quantity;
        }

        private void createItemBtn_Click(object sender, EventArgs e)
        {
            using(var additem =new AddItemForm())
            {
                additem.OnSave += Additem_OnSave;
                additem.ShowDialog();
            }
        }

        private void Additem_OnSave(object sender, EventArgs e)
        {
            SetTable();
        }
    }
}
