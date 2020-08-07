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
        //bool barcodeTaken = false;
        public override void Init()
        {
            base.Init();
            for (int i = 0; i < (int)ItemType.Count; i++)
            {
                itemType.Items.Add((ItemType)i).ToString();
            }
            itemType.SelectedIndex = 0;
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

            var item = new Item();
            item.Barcode = barcode.Text;
            item.Name = name.Text;

            item.SellingPrice = sellingPrice.Value;
            //item.Cost = cost.Value;

            item.Department = itemDepartment.Text;
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
                    if(item.Type == ItemType.Service.ToString() || item.Type == ItemType.Software.ToString())
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
    }
}
