using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{

    public partial class CreateEdit_Item_Form : Form
    {
        public CreateEdit_Item_Form()
        {
            InitializeComponent();

            SetCostBindings();

            bool canEditItem = UserManager.instance.CurrentLogin.CanEditItem;

            buttonsHolder.Visible = canEditItem;
            costTable.ReadOnly = !canEditItem;

            addCostButton.Visible =
            autoGenBarcodeButton.Visible =
            chooseImageButton.Visible =
            removeImageButton.Visible = canEditItem;
        }

        private void SetCostBindings()
        {
            costTable.AutoGenerateColumns = false;
            col_Supplier.DataPropertyName = nameof(Product.Supplier);
            col_Value.DataPropertyName = nameof(Product.Cost);
            costTable.DataSource = Costs;
            costTable.DecimalOnlyEditting(col_Value.Index);
        }

        BindingList<Product> Costs { get; } = new BindingList<Product>();

        private Item _item;
        public Item Item
        {
            get => _item;

            private set
            {
                _item = value;

                this.Text = $"Item ID: {value.Id.ToUpper()}";

                _barcode.Text = value.Barcode;
                _name.Text = value.Name;
                _price.Text = value.SellingPrice.ToString("F2");
                _criticalQty.Value = value.CriticalQuantity ?? 0;
                _description.Text = value.Details;
                _tags.Text = value.Tags;

                pictureBox.Image = value.SampleImage.ToImage();

                departmentOption.Text = value.Department;

                foreach (var p in value.Products)
                    Costs.Add(p);

                if (!value.IsEnumerable)
                    ToggleCostGroup();

                label10.Text = $"Type: {value.Type}";
                label9.Visible = value.IsSerialRequired;
            }
        }

        /// <summary>
        /// determines wether we need to update the image field to avoid unnecessary saving
        /// </summary>
        bool IsImageChanged = false;

        private async void SaveBtn_Click(object sender, EventArgs e)
        {

            //if (Costs.Count <= 0 && Item.IsEnumerable)
            //{
            //    if (MessageBox.Show(
            //        "Items without Cost cannot be restocked. Are you sure you intend to leave it empty?",
            //        "Cost Is Empty",
            //        MessageBoxButtons.OKCancel,
            //        MessageBoxIcon.Warning) == DialogResult.Cancel)
            //        return;
            //}

            //try
            //{
            //    using (var context = POSEntities.Create())
            //    {
            //        var temp = Item;

            //        if (_id == string.Empty)
            //        {
            //            if (!temp.IsEnumerable)
            //            {
            //                var newProduct = new Product() { Supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Name == "none") };
            //                temp.Products.Add(newProduct);
            //                context.InventoryItems.Add(new InventoryItem() { Product = newProduct });
            //            }

            //            var toSave = context.Items.Add(temp);


            //            Tag = toSave;
            //        }

            //        else
            //        {
            //            var toSave = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);
            //            toSave.Name = temp.Name;
            //            toSave.Barcode = temp.Barcode;
            //            toSave.SellingPrice = temp.SellingPrice;
            //            toSave.CriticalQuantity = temp.CriticalQuantity;
            //            toSave.Department = temp.Department;
            //            toSave.Details = temp.Details;
            //            toSave.Type = temp.Type;
            //            toSave.IsSerialRequired = temp.IsSerialRequired;
            //            toSave.Tags = temp.Tags;

            //            if (IsImageChanged)
            //                toSave.SampleImage = temp.SampleImage;

            //            if (toSave.IsEnumerable)
            //            {
            //                //delete removed items
            //                var toRemove = await context.Products.Where(x => x.ItemId == _id).ToListAsync();
            //                foreach (var entry in toRemove)
            //                    if (!temp.Products.Any(t => t.Id == entry.Id))
            //                        context.Products.Remove(entry);

            //                ///add those with 0 id and edit otherwise
            //                foreach (var cost in temp.Products)
            //                {
            //                    if (cost.Id == 0)
            //                        toSave.Products.Add(cost);
            //                    else
            //                    {
            //                        var product = await context.Products.FirstOrDefaultAsync(x => x.Id == cost.Id);
            //                        product.Cost = cost.Cost;
            //                    }
            //                }
            //            }

            //            Tag = toSave;
            //        }
            //        await context.SaveChangesAsync();
            //    }
            //}
            //catch (DbUpdateException)
            //{
            //    MessageBox.Show(
            //        "Barcode or Name is already taken.",
            //        "Save failed",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //        ); return;
            //}
            //catch (DbEntityValidationException)
            //{
            //    MessageBox.Show("Item Name cannot be empty!", "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //MessageBox.Show("Save successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //DialogResult = DialogResult.OK;
        }

        void ToggleCostGroup(bool value = false)
        {
            panel16.Visible = value;
            costTable.Visible = value;
            addCostButton.Visible = value;
        }

        public BindingList<Supplier> Suppliers { get; private set; }

        POSEntities context = null;

        public async Task<bool> InitializeData(string id)
        {
            try
            {
                context = POSEntities.Create();

                SetSupplierOptions(await context.Suppliers.OrderBy(s => s.Name).ToListAsync());
                SetDepartmentOptions(await context.Items.GetDepartments().ToArrayAsync());

                Item = await context.Items.Include(i => i.Products).FirstOrDefaultAsync(x => x.Id == id);

                return true;
            }
            catch (UnautorizedLoginException)
            {
                this.ShowLoginUnauthorizedMessage();
                return false;
            }
            catch (EntityException ex)
            {
                if (MessageBox.Show(ex.Message, "Connection not established", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return await InitializeData(id);
                }
                else
                    return false;
            }
        }

        private void SetSupplierOptions(List<Supplier> suppliers)
        {
            Suppliers = new BindingList<Supplier>(suppliers);
            var comboBoxColumn = (DataGridViewComboBoxColumn)costTable.Columns[nameof(col_Supplier)];

            comboBoxColumn.DisplayMember = nameof(Supplier.Name);
            comboBoxColumn.ValueMember = nameof(Supplier.Self);

            comboBoxColumn.DataSource = Suppliers;
        }

        private void SetDepartmentOptions(string[] departments)
        {
            departmentOption.Items.AddRange(departments);
            departmentOption.AutoCompleteSource = AutoCompleteSource.CustomSource;
            departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            departmentOption.AutoCompleteCustomSource.AddRange(departments);
        }

        //private async void AddCost_Click(object sender, EventArgs e)
        //{
        //    if (_supplierOption.Text.IsEmpty()) return;

        //    if (_supplierOption.SelectedItem == null)
        //    {

        //        if (MessageBox.Show(
        //            "Supplier might not be registered yet. Do want to add this and continue?",
        //            "",
        //            MessageBoxButtons.OKCancel,
        //            MessageBoxIcon.Question
        //            ) == DialogResult.Cancel) return;

        //        using (var context = POSEntities.Create())
        //        {

        //            var newSupplier = context.Suppliers.Add(new Supplier() { Name = _supplierOption.Text.Trim() });
        //            await context.SaveChangesAsync();

        //            _supplierOption.Items.Add(newSupplier);
        //            _supplierOption.SelectedItem = newSupplier;
        //        }
        //    }

        //    var selectedCost = Costs.FirstOrDefault(c => c.Supplier.Name.Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase));

        //    if (selectedCost != null)
        //    {
        //        // get the index of the duplicate cost
        //        var index = costTable.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells[col_Supplier.Index].Value.ToString().Equals(_supplierOption.Text, StringComparison.OrdinalIgnoreCase)).Index;

        //        // select and focus to the row
        //        costTable.Rows[index].Selected = true;
        //        costTable.FirstDisplayedScrollingRowIndex = index;

        //        MessageBox.Show("Supplier is already added.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        //        // for user convenience
        //        _supplierOption.SelectAll();
        //        return;
        //    }

        //    Costs.Add(new Cost_ViewModel()
        //    {
        //        Supplier = _supplierOption.SelectedItem as Supplier,
        //        Cost = 0
        //    });

        //    _supplierOption.SelectedItem = null;
        //}

        private void costTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            var row = costTable.Rows[e.RowIndex];
            int id = ((Product)row.DataBoundItem).Id;

            if (id == 0)
            {
                row.DefaultCellStyle.BackColor = Color.IndianRed;
                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            }

            //var backColor = id == 0 ? Color.Red : Color.Blue;

            //row.DefaultCellStyle.ForeColor = backColor;
            //row.DefaultCellStyle.SelectionForeColor = backColor;

            //row.Selected = true;
            //costTable.FirstDisplayedScrollingRowIndex = e.RowIndex;
        }

        //private void _supplierOption_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(_supplierOption.Text))
        //    {
        //        button4.PerformClick();
        //    }
        //}

        //private void _type_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bool isEnumerable = _type.Text == ItemType.Quantifiable.ToString();
        //    if (!isEnumerable)
        //        checkBox1.Checked = false;

        //    checkBox1.Enabled = isEnumerable;
        //    ToggleCostGroup(isEnumerable);
        //    _criticalQty.Enabled = isEnumerable;
        //}

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

            //if (_id == string.Empty)
            //{
            //    //adding
            //    _name.Text = string.Empty;
            //    _barcode.Text = string.Empty;
            //    //_type.SelectedIndex = 0;
            //    //checkBox1.Checked = false;
            //    _price.Value = 0;
            //    _criticalQty.Value = 0;
            //    _tags.Text = string.Empty;
            //    _description.Text = string.Empty;

            //    Costs.Clear();
            //    pictureBox.Image = null;

            //    return;
            //}
            /////editing
            //using (var context = POSEntities.Create())
            //{
            //    var currentItem = await context.Items.FirstOrDefaultAsync(x => x.Id == _id);

            //    if (currentItem != null)
            //    {
            //        _id = currentItem.Id;
            //        _barcode.Text = currentItem.Barcode;
            //        _name.Text = currentItem.Name;
            //        _price.Value = currentItem.SellingPrice;
            //        _criticalQty.Value = currentItem.CriticalQuantity ?? 0;
            //        _description.Text = currentItem.Details;
            //        _tags.Text = currentItem.Tags;
            //        pictureBox.Image = currentItem.SampleImage.ToImage();

            //        Costs.Clear();
            //        foreach (var p in currentItem.Products)
            //            Costs.Add(new Cost_ViewModel(p));
            //    }
            //}
        }

        private void CreateEdit_Item_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                saveButton.PerformClick();

            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12); // Shorten GUID

            _barcode.Text = guid.Base36Encode();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image is null)
                return;

            using (var imagePreview = new PictureView(pictureBox.Image))
            {
                if (imagePreview.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var openCamera = new CaptureImage())
            {
                openCamera.ShowDialog();
            }
        }

        private void costTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var table = sender as DataGridView;

            //if (e.RowIndex == -1 || e.ColumnIndex != col_Supplier.Index)
            //    return;

            //var cost = table.SelectedCells[0].OwningRow.DataBoundItem as Product;

            //using (var changeSupplier = new ChangeCostSupplier(cost.Id))
            //{
            //    if (changeSupplier.RequireAdminConfirmationBeforeViewing() == DialogResult.OK)
            //    {
            //        cost.Supplier = changeSupplier.Tag as Supplier;
            //    }
            //}
        }

        private void CreateEdit_Item_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            context?.Dispose();
        }

        private void _price_Validating(object sender, CancelEventArgs e)
        {
            var textbox = sender as TextBox;

            e.Cancel = textbox.ComputeExpression();
        }



        private void costTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == Column1.Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var image = Properties.Resources.copy_15px;
                var w = image.Width;
                var h = image.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void costTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == Column1.Index)
            {
                try
                {
                    Clipboard.SetText(((Product)costTable[Column1.Index, e.RowIndex].OwningRow.DataBoundItem).Cost.ToString());
                }
                catch
                {

                }
            }
        }

        private void _price_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter)

            {
                var textbox = sender as TextBox;

                if (textbox.ComputeExpression())
                {

                }

                e.Handled = true;
            }
        }
    }

    public static class ItemDepartmentExtensions
    {
        public static IQueryable<string> GetDepartments(this IQueryable<Item> items)
            => items.Where(i => i.Department != null)
                    .GroupBy(s => s.Department)
                    .Select(s => s.Key.ToString());
    }
}
