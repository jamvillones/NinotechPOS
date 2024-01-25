using POS.Misc;
using System;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Create_Supplier_Form : Form
    {
        public Create_Supplier_Form()
        {
            InitializeComponent();
        }
        public Create_Supplier_Form(string name, string contact = "")
        {
            InitializeComponent();

            supplierName.Text = name;
            contactDetails.Text = contact;
        }

        private void Create_Supplier_Form_Load(object sender, EventArgs e)
        {

        }

        string SupplierName => supplierName.Text.Trim();
        string ContactDetails => contactDetails.Text.Trim();

        private async void addSuppBtn_Click(object sender, EventArgs e)
        {
            if (!ValidationSuccessfull)
                return;

            if (supplierName.Text.Trim().Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This Name is Reserved for Non-Finite Items (Services and Software)", "Name Not Allowed!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (var context = new POSEntities())
            {
                if (context.Suppliers.FirstOrDefault(s => s.Name == SupplierName) != null)
                {
                    if (MessageBox.Show("There seems to be a supplier with this name already. Are you sure you want to proceed?",
                        "",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                }

                var newSupplier = new Supplier()
                {
                    Name = SupplierName,
                    ContactDetails = string.IsNullOrWhiteSpace(ContactDetails) ? null : ContactDetails
                };

                Tag = context.Suppliers.Add(newSupplier);
                await context.SaveChangesAsync();

                DialogResult = DialogResult.OK;
            }
        }

        bool ValidationSuccessfull => !supplierName.Text.IsEmpty();
    }
}
