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
    public partial class SubstituteProduct : Form
    {
        int Id;
        public event EventHandler<Product> OnChoose;
        public SubstituteProduct(int productId)
        {
            InitializeComponent();
            Id = productId;
        }

        private void SubstituteProduct_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                Product variation = p.Products.FirstOrDefault(x => x.Id == Id);
                controlNum.Text = variation.Id.ToString();
                barcode.Text = variation.ItemId;
                name.Text = variation.Item.Name;
                supplier.Text = variation.Supplier.Name;
                cost.Text = variation.Cost.ToString();
                var t = p.Products.Where(x => x.ItemId == variation.ItemId && x.Id != variation.Id);
                foreach (var i in t)
                {
                    varTable.Rows.Add(i.Id,
                                      i.Item.Id,
                                      i.Item.Name,
                                      i.Supplier.Name,
                                      i.Cost);
                }
                //var solditemwiththisproduct = p.SoldItems.Where(x => x.Product.Id == variation.Id);
                //var inv = p.InventoryItems.Where(x => x.Product.Id == variation.Id);
            }
        }
        bool havechosen;
        private void chooseBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to choose this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var p = new POSEntities())
                {
                    var controlnum = varTable.SelectedCells[0].Value;
                    var prod = p.Products.FirstOrDefault(x => x.Id == (int)controlnum);
                    OnChoose?.Invoke(this, prod);
                    havechosen = true;
                }
                this.Close();
            }
        }

        private void SubstituteProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!havechosen)
                OnChoose?.Invoke(this, null);
        }
    }
}
