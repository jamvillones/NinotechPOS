using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace POS.Forms.ItemRegistration {
    public partial class Create_Item_Form : Form {
        public Create_Item_Form() {
            InitializeComponent();

            costTable.AutoGenerateColumns = false;

            col_Id.DataPropertyName = nameof(Cost_ViewModel.Id);
            col_Supplier.DataPropertyName = nameof(Cost_ViewModel.Supplier);
            col_Value.DataPropertyName = nameof(Cost_ViewModel.Cost);

            costTable.DataSource = Costs;
            col_Id.Visible = false;

            costTable.DecimalOnlyEditting(col_Value.Index);
        }

        string _id = string.Empty;

        private class Cost_ViewModel {
            public Cost_ViewModel() {

            }

            public Cost_ViewModel(Product p) {
                Id = p.Id;
                Supplier = p.Supplier;
                Cost = p.Cost;
            }

            public int Id { get; set; } = 0;
            public Supplier Supplier { get; set; }
            public decimal Cost { get; set; } = 0;

            public Product ToProduct => new Product() { Id = Id, SupplierId = Supplier.Id, Cost = Cost };
        }

        readonly BindingList<Cost_ViewModel> Costs = new BindingList<Cost_ViewModel>();

        public Item Item {
            get => new Item() {
                Id = _id == string.Empty ? Guid.NewGuid().ToString("N") : _id,
                Barcode = string.IsNullOrWhiteSpace(_barcode.Text) ? null : _barcode.Text.Trim(),
                Name = _name.Text.Trim(),
                SellingPrice = _price.Value,
                CriticalQuantity = (int?)_criticalQty.Value,
                Details = string.IsNullOrWhiteSpace(_description.Text) ? null : _description.Text.Trim(),
                Type = _type.SelectedItem.ToString(),
                IsSerialRequired = checkBox1.Checked,
                Tags = string.IsNullOrWhiteSpace(_tags.Text) ? null : _tags.Text.Trim(',', ' '),
                Products = Costs.Select(c => c.ToProduct).ToArray()

            };
            set {
                this.Text = "Edit Item - " + value.Name;
                _id = value.Id;
                _barcode.Text = value.Barcode;
                _name.Text = value.Name;
                _price.Value = value.SellingPrice;
                _criticalQty.Value = value.CriticalQuantity ?? 0;
                _description.Text = value.Details;
                _tags.Text = value.Tags;
                _type.SelectedItem = value.Type;

                checkBox1.Checked = value.IsSerialRequired;
                checkBox1.Enabled = false;

                if (value.Type != ItemType.Quantifiable.ToString())
                    DisableCostGroup();

                _type.Enabled = _id == string.Empty;

                foreach (var p in value.Products)
                    Costs.Add(new Cost_ViewModel(p));
            }
        }

        private async void addSuppBtn_Click(object sender, EventArgs e) {

            Item toSave = null;

            try {
                using (var context = new POSEntities()) {

                    var temp = Item;

                    if (_id == string.Empty)
                        toSave = context.Items.Add(temp);

                    else {
                        toSave = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);
                        toSave.Name = temp.Name;
                        toSave.Barcode = temp.Barcode;
                        toSave.SellingPrice = temp.SellingPrice;
                        toSave.CriticalQuantity = temp.CriticalQuantity;
                        toSave.Details = temp.Details;
                        toSave.Type = temp.Type;
                        toSave.IsSerialRequired = temp.IsSerialRequired;
                        toSave.Tags = temp.Tags;
                    }

                    foreach (var cost in temp.Products) {
                        if (cost.Id == 0)
                            toSave.Products.Add(cost);
                        else {
                            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == cost.Id);
                            product.Cost = cost.Cost;
                        }
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex) {
                MessageBox.Show(ex.Message+" Cannot have duplicate barcode or name", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Save successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Tag = toSave;
        }

        void DisableCostGroup() {
            label8.Visible = false;
            panel16.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private async void Create_Item_Form_Load(object sender, EventArgs e) {

            try {
                using (var context = new POSEntities()) {

                    var suppliers = await context.Suppliers
                        .OrderBy(s => s.Name)
                        .ToListAsync();

                    var supplierNames = suppliers.Select(p => p.Name).ToArray();

                    _supplierOption.Items.AddRange(suppliers.ToArray());
                    _supplierOption.AutoCompleteCustomSource.AddRange(supplierNames);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Connection not established", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCost_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(_supplierOption.Text)) return;
            var selectedCost = Costs.FirstOrDefault(c => c.Supplier.Name.Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase));

            if (selectedCost != null) {
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

            Costs.Add(new Cost_ViewModel() {
                Supplier = _supplierOption.SelectedItem as Supplier,
                Cost = 0
            });

            _supplierOption.SelectedItem = null;
        }

        private void costTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            var table = sender as DataGridView;
            var row = table.Rows[e.RowIndex];
            int id = (int)table[col_Id.Index, e.RowIndex].Value;
            row.DefaultCellStyle.ForeColor = id == 0 ? Color.Black : Color.Blue;

            row.Selected = true;
            costTable.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void _supplierOption_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(_supplierOption.Text)) {
                button4.PerformClick();
            }
        }




        //private void costTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
        //    var table = sender as DataGridView;
        //    if (e.Control is TextBox t) {
        //        t.Validating += costEditting_TextBox_Validating;

        //        t.Text = costTable[
        //            table.SelectedCells[0].ColumnIndex,
        //            table.SelectedCells[0].RowIndex]
        //            .Value.ToString();
        //    }
        //}

        //private void costEditting_TextBox_Validating(object sender, CancelEventArgs e) {

        //    var textbox = sender as TextBox;
        //    textbox.KeyPress += (s, args) => {
        //        if (s is TextBox t) {

        //            if (!char.IsControl(args.KeyChar) && !char.IsDigit(args.KeyChar) && (args.KeyChar != '.')) {
        //                args.Handled = true;
        //            }

        //            // only allow one decimal point
        //            if ((args.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
        //                args.Handled = true;
        //            }
        //        }
        //    };
        //}
    }
}
