using POS.Misc;
using System;
using System.Data.Entity;
using System.Windows.Forms;

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

        private async void BasicInformation_Form_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            _type.SelectedIndex = 0;

            try
            {
                using (var context = new POSEntities())
                {
                    var departments = await context.Items
                        .AsNoTracking()
                        .GetDepartments()
                        .ToArrayAsync();

                    _departmentOption.Items.Add("");
                    _departmentOption.Items.AddRange(departments);
                    _departmentOption.AutoCompleteCustomSource.AddRange(departments);
                }
            }
            catch (Exception)
            {

            }

            this.Enabled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            item.Barcode = _barcode.Text.Trim();
            item.Name = _name.Text.Trim();

            item.CriticalQuantity = (int?)_criticalQty.Value;

            item.Type = _type.SelectedItem.ToString();
            item.Department = _departmentOption.Text.NullIfEmpty();
            item.Details = _description.Text.NullIfEmpty();
            item.Tags = _tags.Text.Trim(',', ' ').NullIfEmpty();

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
    }
}
