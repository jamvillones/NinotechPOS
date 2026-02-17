using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class PreInventoryExtractionForm : Form
    {
        public PreInventoryExtractionForm()
        {
            InitializeComponent();
        }

        private async void PreInventoryExtractionForm_Load(object sender, EventArgs e)
        {

            await LoadDepartmentAsync();
            comboBox1.SelectedIndex = 0;
        }

        async Task LoadDepartmentAsync()
        {
            comboBox1.Items.AddRange(Departments_Store.Departments.ToArray());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var properties = typeof(ExcelData).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(x => x.Name).ToList();

            if (!checkBox2.Checked)
                properties.Remove(nameof(ExcelData.Price));

            if (!checkBox4.Checked)
                properties.Remove(nameof(ExcelData.Notes));

            var department = comboBox1.SelectedIndex == 0 ? string.Empty : comboBox1.Text;


            await ContextManipulationMethods.ExtractInventory(department, checkBox1.Checked, checkBox3.Checked, properties.ToArray());
        }
    }
}
