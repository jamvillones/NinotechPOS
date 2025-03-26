using POS.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS.Forms.ItemRegistration
{
    public partial class BasicInformation_Form : Form
    {
        private readonly Item item;

        public BasicInformation_Form(Item item)
        {
            InitializeComponent();
            this.item = item;
        }

        List<string> RegisteredNames = new List<string>();
        List<string> RegisteredBarcodes = new List<string>();

        private async void BasicInformation_Form_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new POSEntities())
                {
                    //var departments = await context.Items
                    //    .AsNoTracking()
                    //    .GetDepartments()
                    //    .ToArrayAsync();

                    RegisteredNames = await context.Items.AsNoTracking().Select(i => i.Name).ToListAsync();
                    RegisteredBarcodes = await context.Items.AsNoTracking().Where(i => i.Barcode != null).Select(i => i.Barcode).ToListAsync();

                    //_departmentOption.Items.Add("");
                    //_departmentOption.Items.AddRange(departments);
                    //_departmentOption.AutoCompleteCustomSource.AddRange(departments);
                }
            }
            catch (Exception)
            { }

            _departmentOption.DataSource = Departments_Store.Departments;
            _departmentOption.SelectedIndex = 0;
            _type.SelectedIndex = 0;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            item.Barcode = _barcode.Text.Trim().NullIfEmpty();
            item.Name = _name.Text.Trim();

            item.CriticalQuantity = (int?)_criticalQty.Value;

            item.Type = _type.SelectedItem.ToString();
            item.Department = _departmentOption.Text.NullIfEmpty();
            item.Details = _description.Text.NullIfEmpty();
            item.Tags = _tags.Text.Trim(',', ' ').NullIfEmpty();

            if (item.Type != ItemType.Quantifiable.ToString())
            {
                var serviceProduct = new Product() { Cost = 0 };
                serviceProduct.InventoryItems.Add(new InventoryItem() { Product = serviceProduct, Quantity = 0 });
                item.Products.Add(serviceProduct);
            }



            DialogResult = DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoGenerateBarcode();
        }

        private void AutoGenerateBarcode()
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12); // Shorten GUID
            _barcode.Text = guid.Base36Encode();
        }

        private void _barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
                AutoGenerateBarcode();
        }

        private void _name_TextChanged(object sender, EventArgs e)
        {
            saveBtn.Enabled = !string.IsNullOrWhiteSpace(_name.Text);
        }

        private void _type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnumerable = _type.Text == ItemType.Quantifiable.ToString();
            _criticalQty.Enabled = isEnumerable;
        }

        private void _barcode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;

            if (RegisteredBarcodes.Any(name => name.Equals(textBox.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "This barcode is already registered.",
                    "Barcode Invalid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        private void _name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;

            if (RegisteredNames.Any(name => name.Equals(textBox.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "This item is already registered.",
                    "Item Name Invalid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                e.Cancel = true;
            }
        }
    }
}
