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
    public partial class EditItemForm : ItemFormBase
    {
        public EditItemForm()
        {
            InitializeComponent();
        }
        public override bool canSave()
        {
            return base.canSave();
        }
        public override void Init()
        {
            base.Init();
            itemType.Enabled = false;

            Item item;
            using(var p = new POSEntities())
            {
                item = p.Items.FirstOrDefault(x => x.Barcode == barcode.Text);
                ImageBox.Image = POS.Misc.ImageDatabaseConverter.byteArrayToImage(item.SampleImage);
            }
            name.Text = item.Name;
            sellingPrice.Value = item.SellingPrice;
            itemDepartment.Text = item.Department;
            details.Text = item.Details;
        }
        public void GetBarcode(string item)
        {
            barcode.Text = item;
        }
        public override void save()
        {
            try
            {
                using (var p = new POS.POSEntities())
                {
                    var item = p.Items.FirstOrDefault(x => x.Barcode == barcode.Text);
                    item.Name = name.Text;
                    //item.Cost = cost.Value;
                    item.SellingPrice = sellingPrice.Value;
                    //item.Type = itemType.Text;
                    item.Department = itemDepartment.Text;
                    item.Details = details.Text;
                    if (ImageBox.Image != null)
                    {
                        item.SampleImage = Misc.ImageDatabaseConverter.imageToByteArray(ImageBox.Image);
                    }

                    p.SaveChanges();
                    InvokeEvent();                    
                    MessageBox.Show("Successfully saved.");
                    this.Close();
                }
            }
            catch
            {

            }
        }
    }
}
