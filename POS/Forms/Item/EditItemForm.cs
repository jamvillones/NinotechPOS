using POS.Misc;
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

            Item item;
            using (var p = new POSEntities())
            {
                item = p.Items.FirstOrDefault(x => x.Barcode == barcode.Text);
                ImageBox.Image = POS.Misc.ImageDatabaseConverter.byteArrayToImage(item.SampleImage);
            }

            name.Text = item.Name;
            sellingPrice.Value = item.SellingPrice;
            itemDepartment.Text = dept;
            details.Text = deets;

            for (int i = 0; i < (int)ItemType.Count; i++)
                itemType.Items.Add((ItemType)i).ToString();

            itemType.Text = item.Type;
            numericUpDown1.Value = item.CriticalQuantity ?? 0;
            itemType.Enabled = false;
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
                    item.SellingPrice = sellingPrice.Value;
                    item.Department = dept;
                    item.Details = deets;

                    if (numericUpDown1.Value > 0 && numericUpDown1.Enabled)
                        item.CriticalQuantity = (int)numericUpDown1.Value;
                    else
                        item.CriticalQuantity = null;

                    if (ImageBox.Image != null)
                    {
                        item.SampleImage = Misc.ImageDatabaseConverter.imageToByteArray(ImageBox.Image);
                    }
                    else
                        item.SampleImage = null;

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

        private void EditItemForm_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
