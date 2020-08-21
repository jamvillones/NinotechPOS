using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using POS.Misc;

namespace POS.Forms
{
    public partial class AddItemForm : ItemFormBase
    {
        public AddItemForm()
        {
            InitializeComponent();
        }
        public AddItemForm(string initialBarcode)
        {
            InitializeComponent();
            barcode.Text = initialBarcode;
        }
        //bool barcodeTaken = false;
        public override void Init()
        {
            base.Init();
            for (int i = 0; i < (int)ItemType.Count; i++)
            {
                itemType.Items.Add((ItemType)i).ToString();
            }
            itemType.SelectedIndex = 0;
            using (var p = new POSEntities())
            {
                foreach (var i in p.Suppliers)
                    supplierOption.Items.Add(i.Name);
            }
        }
        private void barcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(barcode.Text))
            {
                return;
            }
            using (var p = new POSEntities())
            {
                var i = p.Items.FirstOrDefault(x => x.Barcode == barcode.Text);
                if (i != null)
                {
                    this.ActiveControl = barcode;
                    barcode.SelectAll();
                    MessageBox.Show("Barcode already taken.");
                    // barcodeTaken = true;
                    return;
                }
                //barcodeTaken = false;
            }
        }

        public override bool canSave()
        {
            if (string.IsNullOrEmpty(barcode.Text) || string.IsNullOrEmpty(name.Text))
            {
                MessageBox.Show("Barcode and Item name can never be empty!");
                return false;
            }

            return true;
        }
        public override void save()
        {
            if (!canSave())
            {
                return;
            }

            switch (MessageBox.Show(this, "Are you sure you want to create this item?", "Please double check.", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //Stay on this form
                case DialogResult.No:
                    return;

                default:
                    break;
            }

            var item = new Item();
            item.Barcode = barcode.Text;
            item.Name = name.Text;

            item.SellingPrice = sellingPrice.Value;
            //item.Cost = cost.Value;

            item.Department = string.IsNullOrEmpty(itemDepartment.Text) ? null : itemDepartment.Text;
            // item.Type = itemType.Text;
            item.Type = itemType.Text;
            item.Details = details.Text;
            if (ImageBox.Image != null)
            {
                item.SampleImage = ImageDatabaseConverter.imageToByteArray(ImageBox.Image);
            }

            try
            {
                using (var p = new POSEntities())
                {
                    p.Items.Add(item);
                    if (item.Type == ItemType.Service.ToString() || item.Type == ItemType.Software.ToString())
                    {
                        MessageBox.Show("Items of type Service or Software will automatically create an item variation and be added to Inventory.");

                        var prod = new Product();
                        prod.Item = item;
                        prod.Cost = 0;
                        prod.Supplier = p.Suppliers.FirstOrDefault(x => x.Name == "None");
                        p.Products.Add(prod);
                        var inventory = new InventoryItem();
                        inventory.Product = prod;
                        inventory.Quantity = 0;
                        inventory.SerialNumber = null;
                        p.InventoryItems.Add(inventory);
                    }
                    else
                    {
                        foreach (DataGridViewRow i in variationTable.Rows)
                        {
                            var prod = new Product();
                            prod.ItemId = item.Barcode;
                            string s = i.Cells[0].Value.ToString();
                            prod.Supplier = p.Suppliers.FirstOrDefault(x => x.Name == s);
                            prod.Cost = Convert.ToDecimal(i.Cells[1].Value);

                            p.Products.Add(prod);
                        }
                    }

                    p.SaveChanges();
                    MessageBox.Show("Item Added");
                }

                InvokeEvent();
                clearFields();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }
        protected override void clearFields()
        {
            base.clearFields();
            variationTable.Rows.Clear();
        }
        private void itemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VariationGroup.Enabled = itemType.Text == ItemType.Hardware.ToString();
            if (itemType.Text != ItemType.Hardware.ToString())
                variationTable.Rows.Clear();
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            if (supplierOption.Text == string.Empty)
                return;
            using (var p = new POSEntities())
            {
                if (p.Suppliers.FirstOrDefault(x => x.Name == supplierOption.Text) == null)
                {
                    MessageBox.Show("Supplier not found.");
                    using (var supplier = new SupplierForm())
                    {
                        supplier.OnSave += Supplier_OnSave;
                        supplier.ShowDialog();
                    }
                    this.ActiveControl = supplierOption;
                }
            }
        }

        private void Supplier_OnSave(object sender, EventArgs e)
        {
            supplierOption.Items.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.Suppliers)
                    supplierOption.Items.Add(i.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (supplierOption.Text == string.Empty) return;
            variationTable.Rows.Add(supplierOption.Text, cost.Value);
            supplierOption.Items.RemoveAt(supplierOption.SelectedIndex);
        }
    }
}
