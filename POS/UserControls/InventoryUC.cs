using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Forms;
using POS.Misc;

namespace POS.UserControls
{
    public partial class InventoryUC : UserControl, Interfaces.ITab
    {
        public InventoryUC()
        {
            InitializeComponent();
        }

        #region Tab functions
        public virtual void RefreshData()
        {
            initInventoryTable();
            initItemsTable();
        }
        public virtual Button EnterButton()
        {
            return null;
        }

        public virtual Control FirstControl()
        {
            return null;
        }

        public virtual void Initialize()
        {
            using (var p = new POSEntities())
            {
                initInventoryTable();
                initItemsTable();

                var currlog = UserManager.instance.currentLogin;
                stockinBtn.Enabled = currlog.CanStockIn ?? false;
                addVariationsBtn.Enabled = currlog.CanAddProduct ?? false;
                addItemBtn.Enabled = currlog.CanAddItem ?? false;
                editItemBtn.Enabled = currlog.CanEditItem ?? false;
                //var itemGroup = p.InventoryItems.GroupBy(x => x.Product.Item.Barcode);
                //foreach (var i in itemGroup)
                //{
                //    var item = p.Items.FirstOrDefault(x => x.Barcode == i.Key);
                //    int totalQuantity = p.InventoryItems.Where(x => x.Product.Item.Barcode == i.Key).Sum(x => x.Quantity);

                //    inventoryTable.Rows.Add(item.Barcode, item.Name, string.Format("₱ {0:n}", item.SellingPrice), totalQuantity, string.Format("₱ {0:n}", totalQuantity * item.SellingPrice));
                //}

            }

        }
        #endregion

        #region Control Actions
        protected virtual void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dgt = (DataGridView)sender;

            var inView = new InventoryItemView();
            inView.SetItemId(dgt.Rows[e.RowIndex].Cells[0].Value.ToString());
            inView.ShowDialog();
        }

        protected virtual void firstBtn_Click(object sender, EventArgs e)
        {
            var sell = new MakeSale();
            sell.OnSave += OnInventoryChangedCallback;
            sell.ShowDialog();
        }

        protected virtual void secondBtn_Click(object sender, EventArgs e)
        {
            var stockin = new StockinForm();
            stockin.OnSave += OnInventoryChangedCallback;
            stockin.ShowDialog();

        }

        private void OnInventoryChangedCallback(object sender, EventArgs e)
        {
            initInventoryTable();
            //inventoryTable.Rows.Clear();

            //using (var p = new POSEntities())
            //{
            //    var itemGroup = p.InventoryItems.GroupBy(x => x.Product.Item.Barcode);
            //    foreach (var i in itemGroup)
            //    {
            //        var item = p.Items.FirstOrDefault(x => x.Barcode == i.Key);
            //        int totalQuantity = p.InventoryItems.Where(x => x.Product.Item.Barcode == i.Key).Sum(x => x.Quantity);

            //        inventoryTable.Rows.Add(item.Barcode, item.Name, string.Format("₱ {0:n}", item.SellingPrice), totalQuantity, string.Format("₱ {0:n}", totalQuantity * item.SellingPrice));
            //    }
            //}
        }
        #endregion

        private void itemsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dgt = (DataGridView)sender;

            var View = new ViewItem();
            View.SetItemId(dgt.Rows[e.RowIndex].Cells[0].Value.ToString());
            View.ShowDialog();
        }
        object getValueByCurrentRowAndSpecificColumn(DataGridView target, int column)
        {
            return target.Rows[target.SelectedCells[0].RowIndex].Cells[column].Value;
        }
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            var addItem = new AddItemForm();
            addItem.OnSave += Onsave_Callback;
            addItem.ShowDialog();

        }

        void initInventoryTable()
        {
            inventoryTable.Rows.Clear();

            using (var p = new POSEntities())
            {
                var itemGroup = p.InventoryItems.GroupBy(x => x.Product.Item.Barcode);
                foreach (var i in itemGroup)
                {
                    var item = p.Items.FirstOrDefault(x => x.Barcode == i.Key);
                    int totalQuantity = p.InventoryItems.Where(x => x.Product.Item.Barcode == i.Key).Sum(x => x.Quantity);

                    inventoryTable.Rows.Add(item.Barcode, item.Name, string.Format("₱ {0:n}", item.SellingPrice), (totalQuantity==0?"Infinite":totalQuantity.ToString()),(totalQuantity ==0?"----": string.Format("₱ {0:n}", totalQuantity * item.SellingPrice)));
                }
            }
        }
        private void Onsave_Callback(object sender, EventArgs e)
        {
            initItemsTable();

            initInventoryTable();
        }

        void initItemsTable()
        {
            itemsTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.Items)
                {
                    itemsTable.Rows.Add(i.Barcode, i.Name, string.Format("₱ {0:n}", i.SellingPrice), i.Department,i.Type, i.Details);
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if(itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.");
                return;
            }
            var editItem = new EditItemForm();
            editItem.OnSave += Onsave_Callback;
            editItem.GetBarcode(getValueByCurrentRowAndSpecificColumn(itemsTable, 0).ToString());
            editItem.ShowDialog();
        }

        private void addVariationsBtn_Click(object sender, EventArgs e)
        {
            if (itemsTable.RowCount <= 0)
            {
                MessageBox.Show("You do not have an item.");
                return;
            }
            var variation = new AddProductForm();
            variation.ShowDialog();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            initInventoryTable();
            initItemsTable();
        }
    }
}
