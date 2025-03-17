using POS.Misc;
using System;
using System.Linq;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{
    public partial class ConfirmNewItemDetails : Form
    {
        private readonly Item item;

        public ConfirmNewItemDetails(Item item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void ConfirmNewItemDetails_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = item.SampleImage?.ToImage();

            dataGridView1.Rows.Add("Barcode", item.Barcode);
            dataGridView1.Rows.Add("Name", item.Name);
            dataGridView1.Rows.Add("Require Serial Number", item.IsSerialRequired ? "Yes" : "No");
            dataGridView1.Rows.Add("Item Type", item.Type.ToString());
            dataGridView1.Rows.Add("Department", item.Department.NullIfEmpty());
            dataGridView1.Rows.Add("Selling Price", item.SellingPrice.ToString("C2"));

            if (item.IsFinite)
            {
                dataGridView1.Rows.Add("Number of Cost", item.Products.Count);
                dataGridView1.Rows.Add("Average Cost", item.Products.Count == 0 ? "--" : item.Products.Average(p => p.Cost).ToString("C2"));
                dataGridView1.Rows.Add("Critical Quantity", item.CriticalQuantity);
            }

            dataGridView1.Rows.Add("Tags", item.Tags);
            dataGridView1.Rows.Add("Details", item.Details);
        }
        bool exitPermitted = false;
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kindly Check The Details Of The Item.",
                "Create Item?",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel) return;
            DialogResult = DialogResult.OK;
            exitPermitted = true;
        }

        private void ConfirmNewItemDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exitPermitted)
                return;

            if (MessageBox.Show("Changes not yet saved.", "Closing Item Registration", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                e.Cancel = true;
        }
    }
}
