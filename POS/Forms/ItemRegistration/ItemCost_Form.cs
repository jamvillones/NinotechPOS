using POS.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{
    public partial class ItemCost_Form : Form
    {
        private readonly Item item;

        public ItemCost_Form(Item item)
        {
            InitializeComponent();

            this.item = item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            if (Costs.Count == 0)
            {
                //ask if they intend to put cost later
                if (MessageBox.Show("Do you intend to leave cost empty and set it later?", "Cost Is Not Set", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            item.SellingPrice = _price.Value;
            item.Products = Costs.Select(c => c.ToProduct).ToList();

            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
        }

        private async void ItemCost_Form_Load(object sender, EventArgs e)
        {
            costTable.AutoGenerateColumns = false;

            col_Id.DataPropertyName = nameof(Cost_ViewModel.Id);
            col_Supplier.DataPropertyName = nameof(Cost_ViewModel.Supplier);
            col_Value.DataPropertyName = nameof(Cost_ViewModel.Cost);

            costTable.DataSource = Costs;
            col_Id.Visible = false;

            costTable.DecimalOnlyEditting(col_Value.Index);

            try
            {
                using (var context = new POSEntities())
                {
                    var suppliers = await context.Suppliers
                                .OrderBy(s => s.Name)
                                .ToArrayAsync();

                    _supplierOption.Items.AddRange(suppliers);
                }
            }
            catch { }
        }


        readonly BindingList<Cost_ViewModel> Costs = new BindingList<Cost_ViewModel>();

        private async void button4_Click(object sender, EventArgs e)
        {
            if (_supplierOption.Text.IsEmpty()) return;

            if (_supplierOption.SelectedItem == null)
            {

                if (MessageBox.Show(
                    "Supplier might not be registered yet. Do want to add this and continue?",
                    "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                    ) == DialogResult.Cancel) return;

                using (var context = new POSEntities())
                {

                    var newSupplier = context.Suppliers.Add(new Supplier() { Name = _supplierOption.Text.Trim() });
                    await context.SaveChangesAsync();

                    _supplierOption.Items.Add(newSupplier);
                    _supplierOption.SelectedItem = newSupplier;
                }
            }

            var selectedCost = Costs.FirstOrDefault(c => c.Supplier.ToString().Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase));

            if (selectedCost != null)
            {
                // get the index of the duplicate cost
                var index = costTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells[col_Supplier.Index].Value.ToString().Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase)).Index;

                // select and focus to the row
                costTable.Rows[index].Selected = true;
                costTable.FirstDisplayedScrollingRowIndex = index;

                MessageBox.Show("Supplier is already added.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                // for user convenience
                _supplierOption.SelectAll();
                return;
            }

            Costs.Add(new Cost_ViewModel()
            {
                Supplier = _supplierOption.SelectedItem as Supplier,
                Cost = 0
            });

            _supplierOption.SelectedItem = null;
        }

        private void _supplierOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button4.PerformClick();
        }
    }
}
