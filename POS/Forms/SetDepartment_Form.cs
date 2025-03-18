using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class SetDepartment_Form : Form
    {
        public SetDepartment_Form()
        {
            InitializeComponent();
        }

        private void SetDepartment_Form_Load(object sender, EventArgs e)
        {
            departmentOption.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            departmentOption.AutoCompleteSource = AutoCompleteSource.ListItems;
            departmentOption.DataSource = Departments_Store.Departments;
            departmentOption.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Tag = departmentOption.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
