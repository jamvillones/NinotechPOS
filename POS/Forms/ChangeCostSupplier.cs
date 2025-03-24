using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ChangeCostSupplier : Form
    {
        private readonly int _costId;

        public ChangeCostSupplier(int costId)
        {
            InitializeComponent();
            this._costId = costId;
        }

        public Supplier SelectedSupplier { get => (Supplier)comboBox1.SelectedItem; private set { comboBox1.SelectedItem = value; } }

        private async void ChangeCostSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    var suppliers = await context.Suppliers.ToListAsync();
                    comboBox1.DataSource = suppliers;

                    var cost = await context.Products.FirstOrDefaultAsync(x => x.Id == _costId);
                    SelectedSupplier = suppliers.FirstOrDefault(x => x.Id == cost.SupplierId);
                }
            }
            catch (Exception)
            {

            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var context = new POSEntities())
            {
                var cost = await context.Products.FirstOrDefaultAsync(x => x.Id == _costId);
                cost.Supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Id == SelectedSupplier.Id);
                await context.SaveChangesAsync();
            }

            Tag = SelectedSupplier;
            DialogResult = DialogResult.OK;
        }
    }
}
