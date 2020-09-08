using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.UserControls
{
    public partial class ItemBoxHolder : UserControl
    {
        public event EventHandler ItemChosen;
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public string Barcode { get; private set; }
        public string Serial { get; private set; }
        public string ItemName { get; private set; }
        public ItemBoxHolder()
        {
            InitializeComponent();
        }
        public void SetValues(decimal price, int totalQuantity, Image img, string barcode, string serial, string name)
        {
            this.Price = price;
            this.Quantity = totalQuantity;
            this.Barcode = barcode;
            this.Serial = serial;
            this.ItemName = name;

            if (img != null)
                picture.Image = img;

            quantityTxt.Text = string.Format("₱{0:n}", Price);
            priceTxt.Text = Quantity.ToString() + (Quantity == 1 ? " pc." : " pcs.");
            barcodeTxt.Text = Barcode;
            serialTxt.Text = Serial ?? "N/A";
            nameTxt.Text = ItemName.ToUpper();
        }

        private void picture_Click(object sender, EventArgs e)
        {
            ItemChosen?.Invoke(this, null);
        }
    }
}
