using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{
    public partial class Create_Item_Form : Form
    {
        public Create_Item_Form()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            col_Supplier.DataPropertyName = nameof(Cost_ViewModel.Supplier);
            col_Value.DataPropertyName = nameof(Cost_ViewModel.Cost);
            dataGridView1.DataSource = Costs;
        }
        //public Create_Item_Form(string id)
        //{
        //    InitializeComponent();
        //    this._id = id;
        //}

        string _id = string.Empty;

        private class Cost_ViewModel
        {
            public Cost_ViewModel()
            {

            }

            public Cost_ViewModel(Product p)
            {
                Id = p.Id;
                Supplier = p.Supplier;
                Cost = p.Cost;
            }

            public int Id { get; set; } = 0;
            public Supplier Supplier { get; set; }
            public decimal Cost { get; set; } = 0;

            public Product ToProduct => new Product() { Id = Id, SupplierId = Supplier.Id, Cost = Cost };
        }


        BindingList<Cost_ViewModel> Costs = new BindingList<Cost_ViewModel>();

        public Item Item
        {
            get => new Item()
            {
                Id = _id == string.Empty ? Guid.NewGuid().ToString("N") : _id,
                Barcode = string.IsNullOrWhiteSpace(_barcode.Text) ? null : _barcode.Text.Trim(),
                Name = _name.Text.Trim(),
                Details = string.IsNullOrWhiteSpace(_description.Text) ? null : _description.Text.Trim(',', ' '),
                Type = _type.SelectedItem.ToString(),

                SellingPrice = _price.Value,
                CriticalQuantity = (int?)_criticalQty.Value,

                Products = Costs.Select(c => c.ToProduct).ToArray()

            };
            set
            {
                this.Text = "Edit Item - " + value.Name;
                _id = value.Id;
                _barcode.Text = value.Id;
                _name.Text = value.Name;
                _price.Value = value.SellingPrice;
                _criticalQty.Value = value.CriticalQuantity ?? 0;
                _description.Text = value.Details;
                _type.SelectedItem = value.Type;


                foreach (var p in value.Products)
                    Costs.Add(new Cost_ViewModel(p));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
