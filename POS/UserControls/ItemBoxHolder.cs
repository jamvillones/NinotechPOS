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
        private decimal _price;
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                priceTxt.Text = string.Format("₱{0:n}", _price);
            }
        }

        private int _quantity;
        public int Quantity {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                // quantityTxt.Text = _quantity.ToString() + (Quantity == 0 ? "Infinite" : (_quantity == 1 ? " pc." : " pcs."));
                quantityTxt.Text = _quantity == 0 ? "Inifinite" : (_quantity > 1?_quantity+" pcs.":_quantity+" pc.");
            }
        }

        public string Barcode { get; private set; }
        public string Serial { get; private set; }
        public string ItemName { get; private set; }
        public Image img { get { return picture.Image; } }
        public int Id { get; private set; }
        public ItemBoxHolder()
        {
            InitializeComponent();
        }
        public void SetValues(decimal price, int totalQuantity, Image img, string barcode, string serial, string name, int id)
        {
            this.Price = price;
            this.Quantity = totalQuantity;
            this.Barcode = barcode;
            this.Serial = serial;
            this.ItemName = name;
            this.Id = id;

            if (img != null)
                picture.Image = img;

            //priceTxt.Text = string.Format("₱{0:n}", Price);
            //quantityTxt.Text = Quantity.ToString() +(Quantity==0?"Infinite": (Quantity == 1 ? " pc." : " pcs."));
            barcodeTxt.Text = Barcode;
            serialTxt.Text = serial ?? "N/A";
            nameTxt.Text = ItemName.ToUpper();
        }

        private void picture_Click(object sender, EventArgs e)
        {
            ItemChosen?.Invoke(this, null);
        }
    }
}
