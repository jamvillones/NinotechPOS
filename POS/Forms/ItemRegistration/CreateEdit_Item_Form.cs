using POS.Misc;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{

    public partial class CreateEdit_Item_Form : Form
    {
        public CreateEdit_Item_Form(string id = "")
        {
            InitializeComponent();

            costTable.AutoGenerateColumns = false;

            col_Id.DataPropertyName = nameof(Cost_ViewModel.Id);
            col_Supplier.DataPropertyName = nameof(Cost_ViewModel.Supplier);
            col_Value.DataPropertyName = nameof(Cost_ViewModel.Cost);

            costTable.DataSource = Costs;
            col_Id.Visible = false;

            costTable.DecimalOnlyEditting(col_Value.Index);
            _type.SelectedIndex = 0;

            _id = id;
        }

        string _id = string.Empty;



        readonly BindingList<Cost_ViewModel> Costs = new BindingList<Cost_ViewModel>();

        private Item Item
        {
            get => new Item()
            {
                Id = _id == string.Empty ? Guid.NewGuid().ToString("N") : _id,
                Barcode = _barcode.Text.NullIfEmpty(),
                Name = _name.Text.NullIfEmpty(),
                SellingPrice = _price.Value,
                CriticalQuantity = (int?)_criticalQty.Value,
                Type = _type.SelectedItem.ToString(),
                IsSerialRequired = checkBox1.Checked,
                Department = string.IsNullOrWhiteSpace(departmentOption.Text) ? null : departmentOption.Text.Trim(),
                Details = _description.Text.NullIfEmpty(),
                Tags = string.IsNullOrWhiteSpace(_tags.Text) ? null : _tags.Text.Trim(',', ' '),
                Products = Costs.Select(c => c.ToProduct).ToList(),
                SampleImage = pictureBox.Image.ToByteArray()
            };
            set
            {
                this.Text = "Edit Item - " + value.Name;
                _id = value.Id;
                _barcode.Text = value.Barcode;
                _name.Text = value.Name;
                _price.Value = value.SellingPrice;
                _criticalQty.Value = value.CriticalQuantity ?? 0;
                _description.Text = value.Details;
                _tags.Text = value.Tags;
                _type.SelectedItem = value.Type;
                pictureBox.Image = value.SampleImage.ToImage();

                checkBox1.Checked = value.IsSerialRequired;
                checkBox1.Enabled = false;

                departmentOption.Text = value.Department;

                if (value.Type != ItemType.Quantifiable.ToString())
                    ToggleCostGroup();

                _type.Enabled = _id == string.Empty;

                foreach (var p in value.Products)
                    Costs.Add(new Cost_ViewModel(p));
            }
        }

        /// <summary>
        /// determines wether we need to update the image field to avoid unnecessary saving
        /// </summary>
        bool IsImageChanged = false;

        private async void SaveBtn_Click(object sender, EventArgs e)
        {

            if (Costs.Count <= 0 && Item.IsFinite)
            {
                if (MessageBox.Show(
                    "Items without Cost cannot be restocked. Are you sure you intend to leave it empty?",
                    "Cost Is Empty",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning) == DialogResult.Cancel)
                    return;
            }

            try
            {
                using (var context = new POSEntities())
                {
                    var temp = Item;

                    if (_id == string.Empty)
                    {
                        if (!temp.IsFinite)
                        {
                            var newProduct = new Product() { Supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Name == "none") };
                            temp.Products.Add(newProduct);
                            context.InventoryItems.Add(new InventoryItem() { Product = newProduct });
                        }

                        var toSave = context.Items.Add(temp);


                        Tag = toSave;
                    }

                    else
                    {
                        var toSave = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);
                        toSave.Name = temp.Name;
                        toSave.Barcode = temp.Barcode;
                        toSave.SellingPrice = temp.SellingPrice;
                        toSave.CriticalQuantity = temp.CriticalQuantity;
                        toSave.Department = temp.Department;
                        toSave.Details = temp.Details;
                        toSave.Type = temp.Type;
                        toSave.IsSerialRequired = temp.IsSerialRequired;
                        toSave.Tags = temp.Tags;

                        if (IsImageChanged)
                            toSave.SampleImage = temp.SampleImage;

                        if (toSave.IsFinite)
                        {
                            //delete removed items
                            var toRemove = await context.Products.Where(x => x.ItemId == _id).ToListAsync();
                            foreach (var entry in toRemove)
                                if (!temp.Products.Any(t => t.Id == entry.Id))
                                    context.Products.Remove(entry);

                            ///add those with 0 id and edit otherwise
                            foreach (var cost in temp.Products)
                            {
                                if (cost.Id == 0)
                                    toSave.Products.Add(cost);
                                else
                                {
                                    var product = await context.Products.FirstOrDefaultAsync(x => x.Id == cost.Id);
                                    product.Cost = cost.Cost;
                                }
                            }
                        }

                        Tag = toSave;
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Barcode or Name is already taken.",
                    "Save failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    ); return;
            }
            catch (DbEntityValidationException)
            {
                MessageBox.Show("Item Name cannot be empty!", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Save successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        void ToggleCostGroup(bool value = false)
        {
            label8.Visible = value;
            panel16.Visible = value;
        }

        private async void Create_Item_Form_Load(object sender, EventArgs e)
        {
            this.Enabled = false;

            try
            {
                using (var context = new POSEntities())
                {

                    var suppliers = await context.Suppliers
                        .OrderBy(s => s.Name)
                        .ToArrayAsync();

                    _supplierOption.Items.AddRange(suppliers);

                    var departments = await context.Items
                        .GetDepartments()
                        .ToArrayAsync();

                    departmentOption.Items.AddRange(departments);
                    departmentOption.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    departmentOption.AutoCompleteCustomSource.AddRange(departments);

                    if (!_id.IsEmpty())
                        Item = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);
                }

            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Connection not established", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    Create_Item_Form_Load(null, EventArgs.Empty);
                    return;
                }
                else
                    this.Close();
            }
            this.Enabled = true;
        }

        private async void AddCost_Click(object sender, EventArgs e)
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

            var selectedCost = Costs.FirstOrDefault(c => c.Supplier.Name.Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase));

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

        private void costTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var table = sender as DataGridView;
            var row = table.Rows[e.RowIndex];
            int id = (int)table[col_Id.Index, e.RowIndex].Value;
            row.DefaultCellStyle.ForeColor = id == 0 ? Color.Black : Color.Blue;

            row.Selected = true;
            costTable.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        private void _supplierOption_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(_supplierOption.Text))
            {
                button4.PerformClick();
            }
        }

        private void _type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isEnumerable = _type.Text == ItemType.Quantifiable.ToString();
            if (!isEnumerable)
                checkBox1.Checked = false;

            checkBox1.Enabled = isEnumerable;
            ToggleCostGroup(isEnumerable);
            _criticalQty.Enabled = isEnumerable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this image?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            if (pictureBox.Image != null)
            {
                IsImageChanged = true;
                pictureBox.Image = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg;*.png)|*.jpg; *.jpeg; *.png";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                    IsImageChanged = true;
                }
                catch (IOException)
                {
                }
            }
        }

        private async void cancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to cancel changes?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning) == DialogResult.Cancel) return;

            if (_id == string.Empty)
            {
                //adding
                _name.Text = string.Empty;
                _barcode.Text = string.Empty;
                _type.SelectedIndex = 0;
                checkBox1.Checked = false;
                _price.Value = 0;
                _criticalQty.Value = 0;
                _tags.Text = string.Empty;
                _description.Text = string.Empty;

                Costs.Clear();
                pictureBox.Image = null;

                return;
            }
            ///editing
            using (var context = new POSEntities())
            {
                var currentItem = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);

                if (currentItem != null)
                {

                    _id = currentItem.Id;
                    _barcode.Text = currentItem.Barcode;
                    _name.Text = currentItem.Name;
                    _price.Value = currentItem.SellingPrice;
                    _criticalQty.Value = currentItem.CriticalQuantity ?? 0;
                    _description.Text = currentItem.Details;
                    _tags.Text = currentItem.Tags;
                    _type.SelectedItem = currentItem.Type;
                    pictureBox.Image = currentItem.SampleImage.ToImage();

                    checkBox1.Checked = currentItem.IsSerialRequired;

                    Costs.Clear();
                    foreach (var p in currentItem.Products)
                        Costs.Add(new Cost_ViewModel(p));
                }
            }
        }

        private void CreateEdit_Item_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                saveBtn.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12); // Shorten GUID

            _barcode.Text = guid.Base36Encode();
        }
    }

    public static class ItemDepartmentExtensions
    {
        public static IQueryable<string> GetDepartments(this IQueryable<Item> items)
        {
            return items.Where(i => i.Department != null).GroupBy(s => s.Department).Select(s => s.Key.ToString());
        }
    }
}
