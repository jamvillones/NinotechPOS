using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Costs.ListChanged += Costs_ListChanged;
        }

        private void SetBehaviorBasedOnUserPermission(bool canEditItem)
        {
            //buttonsHolder.Visible = canEditItem;

            costTable.ReadOnly = !canEditItem;

            if (canEditItem)
                foreach (var control in this.GetControls(c => c.Tag != null))
                {
                    switch (control)
                    {
                        case TextBox textBox:
                            textBox.TextChanged += (s, e) =>
                            {
                                UpdateButtonBehaviorIfChangeDetected();
                            };
                            break;
                        case ComboBox combo:
                            combo.TextChanged += (s, e) =>
                            {
                                UpdateButtonBehaviorIfChangeDetected();
                            };
                            break;
                        case NumericUpDown nud:
                            nud.ValueChanged += (s, e) =>
                            {
                                UpdateButtonBehaviorIfChangeDetected();
                            };
                            break;
                        case DataGridView dgv:
                            dgv.CellValidated += (s, e) =>
                            {
                                UpdateButtonBehaviorIfChangeDetected();
                            };
                            break;
                        default:
                            Console.WriteLine($"No handler for control type: {control.GetType().Name}");
                            break;
                    }
                }

            foreach (var control in this.GetControls<TextBox>())
                control.ReadOnly = !canEditItem;

            foreach (var btn in this.GetControls<Button>())
                btn.Visible = canEditItem;

            foreach (var combo in this.GetControls<ComboBox>())
            {
                if (!canEditItem)
                {
                    combo.DropDownStyle = ComboBoxStyle.DropDownList;
                    combo.KeyPress += (s, ee) =>
                    {
                        ee.Handled = true;
                    };
                }
            }

            foreach (var num in this.GetControls<NumericUpDown>())
            {
                num.ReadOnly = !canEditItem;
                num.Increment = !canEditItem ? 0 : num.Increment;
            }
        }

        private void UpdateButtonBehaviorIfChangeDetected()
        {
            cancelButton.Enabled = saveButton.Enabled = context.HasChanges();
        }

        Image SampleImage
        {
            get => _pictureBox.Image;

            set
            {
                Item.SampleImage = value.ToByteArray();
                UpdateButtonBehaviorIfChangeDetected();
            }
        }

        private void BindFields(Item item)
        {
            ItemBindingSource = new BindingSource { DataSource = item };

            string controlTextPropertyString = nameof(Control.Text);

            _name.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.Name), true, DataSourceUpdateMode.OnPropertyChanged));
            _barcode.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.Barcode), true, DataSourceUpdateMode.OnPropertyChanged));
            _departmentOption.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.Department), true, DataSourceUpdateMode.OnPropertyChanged));
            _tags.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.Tags), true, DataSourceUpdateMode.OnPropertyChanged));
            _details.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.Details), true, DataSourceUpdateMode.OnPropertyChanged));
            _price.DataBindings.Add(
                new Binding(controlTextPropertyString, ItemBindingSource, nameof(POS.Item.SellingPrice), true, DataSourceUpdateMode.OnPropertyChanged));
            _criticalQty.DataBindings.Add(
                new Binding(nameof(NumericUpDown.Value), ItemBindingSource, nameof(POS.Item.CriticalQuantity), true, DataSourceUpdateMode.OnPropertyChanged));
            _pictureBox.DataBindings.Add(
                new Binding(nameof(PictureBox.Image), ItemBindingSource, nameof(POS.Item.SampleImage), true, DataSourceUpdateMode.OnPropertyChanged));
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

                isPopulatingCost = true;

                foreach (var p in value.Products)
                    Costs.Add(p);

                isPopulatingCost = false;

                if (!value.IsEnumerable)
                    ToggleCostGroup();


                label10.Text = $"Type: {value.Type}";
                label9.Visible = value.IsSerialRequired;
            }
        }

        bool isPopulatingCost = false;
        private void Costs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (isPopulatingCost)
            {
                return;
            }
            saveButton.Enabled = cancelButton.Enabled = true;
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
                SetDepartmentOptions(Departments_Store.Departments);

                Item = await context.Items
                       .Include(i => i.Products)
                       .FirstOrDefaultAsync(x => x.Id == id);

                BindFields(Item);

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

        private void SetDepartmentOptions(BindingList<string> departments)
        {
            _departmentOption.AutoCompleteSource = AutoCompleteSource.ListItems;
            _departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //_departmentOption.AutoCompleteCustomSource.AddRange(departments);
            _departmentOption.DataSource = departments;
            //_departmentOption.Items.AddRange(departments);
        }

        private void costTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            var row = costTable.Rows[e.RowIndex];
            var newProduct = (Product)row.DataBoundItem;
            Item.Products.Add(newProduct);

            int id = newProduct.Id;
            if (id == 0)
            {
                row.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Maroon;
                row.DefaultCellStyle.ForeColor = System.Drawing.Color.Maroon;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this image?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            if (_pictureBox.Image != null)
            {
                SampleImage = null;
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
                    SampleImage = image;
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

            isPopulatingCost = true;
            Costs.Clear();
            foreach (var product in Item.Products)
                Costs.Add(product);
            isPopulatingCost = false;


            UpdateButtonBehaviorIfChangeDetected();
        }

        private void CreateEdit_Item_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                saveButton.PerformClick();

            else if (e.KeyCode == Keys.F5)
                cancelButton.PerformClick();

            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string guid = Guid.NewGuid().ToString("N").Substring(0, 12); // Shorten GUID

            Item.Barcode = guid.Base36Encode();

            _barcode.SelectAll();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_pictureBox.Image is null)
                return;

            using (var imagePreview = new PictureView(SampleImage))
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

        private void CreateEdit_Item_Form_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (saveButton.Visible && context.HasChanges())
            {
                if (MessageBox.Show("You want to exit without saving changes?",
                    "Pending Changes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
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

        const decimal markUpValue = 1.3m;
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
                return;
            }

            else if (e.KeyCode == Keys.F4 && Costs.Count > 0)
            {
                textBox.Text = $"{(MaxCost * markUpValue):N2}";
                sellingPriceLabel.Text = "Selling Price:";
                return;
            }
        }

        private void CreateEdit_Item_Form_Load(object sender, EventArgs e)
        {
            SetBehaviorBasedOnUserPermission(UserManager.instance.CurrentLogin.CanEditItem);

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

        private void _barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
                autoGenBarcodeButton.PerformClick();
        }

        private void _criticalQty_Validated(object sender, EventArgs e)
        {
            Console.WriteLine("  validated");
        }

        private void _criticalQty_Leave(object sender, EventArgs e)
        {
            if (sender is NumericUpDown nud && nud.Text == "")
            {
                nud.Value = 0;
            }
        }

        decimal MaxCost => Item is null ? 0 : Item.Products.Select(p => p.Cost).Max();

        private void _price_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_price.Text) || _price.Text == "0.00")
            {
                sellingPriceLabel.Text = $"Selling Price: [F4] {MaxCost} * {markUpValue} = {(MaxCost * markUpValue):N2}";
            }
        }

        private void costTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete || costTable.ReadOnly)
            {
                return;
            }

            e.Handled = true;
            DeleteSelectedCost();
        }

        private void DeleteSelectedCost()
        {
            var selectedCost = (Product)costTable.CurrentRow.DataBoundItem;

            if (!context.StockinHistories.AsNoTracking().Any(st => st.ProductId == selectedCost.Id))
            {
                Costs.Remove(selectedCost);
                Item.Products.Remove(selectedCost);
            }
            else
            {
                MessageBox.Show("This Cost is already in use", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public static class ItemDepartmentExtensions
    {
        public static IQueryable<string> GetDepartments(this IQueryable<Item> items)
            => items.Where(i => !string.IsNullOrEmpty(i.Department))
                    .GroupBy(s => s.Department)
                    .Select(s => s.Key.ToString());
    }
}
