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

        private void BindFields()
        {
            ItemBindingSource = new BindingSource();
            ItemBindingSource.DataSource = Item;

            _name.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.Name), false, DataSourceUpdateMode.OnValidation));
            _barcode.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.Barcode), false, DataSourceUpdateMode.OnValidation));
            _departmentOption.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.Department), false, DataSourceUpdateMode.OnValidation));
            _tags.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.Tags), false, DataSourceUpdateMode.OnValidation));
            _details.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.Details), false, DataSourceUpdateMode.OnValidation));
            _price.DataBindings.Add(new Binding("Text", ItemBindingSource, nameof(POS.Item.SellingPrice), false, DataSourceUpdateMode.OnValidation));
            _criticalQty.DataBindings.Add(new Binding(nameof(NumericUpDown.Value), ItemBindingSource, nameof(POS.Item.CriticalQuantity), false, DataSourceUpdateMode.OnValidation));
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
                foreach (var p in value.Products)
                    Costs.Add(p);

                if (!value.IsEnumerable)
                    ToggleCostGroup();

                label10.Text = $"Type: {value.Type}";
                label9.Visible = value.IsSerialRequired;
            }
        }



        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            if (Item.Error != string.Empty)
                return;

            if (MessageBox.Show("Apply Changes To The Item?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return;
            }

            Tag = Item;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        void ToggleCostGroup(bool value = false)
        {
            panel16.Visible =
            costTable.Visible =
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

                Item = await context.Items
                                    .Include(i => i.Products)
                                    .FirstOrDefaultAsync(x => x.Id == id);

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
            _departmentOption.Items.AddRange(departments);
            _departmentOption.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _departmentOption.AutoCompleteCustomSource.AddRange(departments);
        }

        private void costTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            var row = costTable.Rows[e.RowIndex];
            var newProduct = (Product)row.DataBoundItem;
            Item.Products.Add(newProduct);


            int id = newProduct.Id;

            if (id == 0)
            {
                row.DefaultCellStyle.BackColor = Color.IndianRed;
                row.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this image?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            if (pictureBox.Image != null)
            {
                Item.SampleImage = null;
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
                    var image = new Bitmap(openFileDialog.FileName);

                    Item.SampleImage = image.ToByteArray();
                    pictureBox.Image = image;
                }
                catch (IOException)
                {
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to cancel changes?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No) return;

            context.UndoAllChanges();

            this.ValidateChildren();

            Costs.Clear();
            foreach (var product in Item.Products)
                Costs.Add(product);
        }

        private void CreateEdit_Item_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                saveButton.PerformClick();

            else if (e.Control && e.KeyCode == Keys.Z)
                cancelButton.PerformClick();

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

        }

        private void CreateEdit_Item_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (context.ChangeTracker.HasChanges())
            {
                if (MessageBox.Show("You want to exit with saving changes?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

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

        private void CreateEdit_Item_Form_Load(object sender, EventArgs e)
        {
            BindFields();

        }

        private void _name_Validated(object sender, EventArgs e)
        {
            var tag = (sender as TextBox).Tag?.ToString();
            errorProvider.SetError(_name, Item[tag]);
        }

        private void addCostButton_Click(object sender, EventArgs e)
        {
            Costs.AddNew();
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
