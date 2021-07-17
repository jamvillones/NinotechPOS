using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class EditSaleDetails : Form
    {
        public EditSaleDetails()
        {
            InitializeComponent();
        }

        private int id;
        public int SaleId
        {
            get { return id; }
            set
            {
                id = value;
                using (var r = new POSEntities())
                {
                    var sale = r.Sales.FirstOrDefault(x => x.Id == id);
                    saleId.Text = sale.Id.ToString();
                    customerOption.Text = sale.Customer.Name;
                    transactionDate.Value = sale.Date.Value;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to make this changes?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (var p = new POSEntities())
            {
                var s = p.Sales.FirstOrDefault(x => x.Id == SaleId);
                s.Customer = p.Customers.FirstOrDefault(x => x.Name == customerOption.Text.Trim());
                s.Date = transactionDate.Value;

                p.SaveChanges();
            }

            DialogResult = DialogResult.OK;
        }

        private void EditSaleDetails_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                transactionDate.Value = p.Sales.FirstOrDefault(x => x.Id == SaleId).Date.Value;

                var customers = p.Customers.Select(x => x.Name).ToArray();
                customerOption.Items.AddRange(customers);
                customerOption.AutoCompleteCustomSource.AddRange(customers);
            }
        }
    }
}
