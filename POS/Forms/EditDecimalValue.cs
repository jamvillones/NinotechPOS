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
    public partial class EditDecimalValue : Form
    {
        public EditDecimalValue(decimal initialValue, decimal maxValue = 999999999, bool isIntOnly = false)
        {
            InitializeComponent();
            numericUpDown1.Value = initialValue;
            numericUpDown1.Maximum = maxValue;
            if (isIntOnly)
            {
                numericUpDown1.DecimalPlaces = 0; numericUpDown1.Minimum = 1;
            }
        }

        //public bool IsIntOnly { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to proceed with this new value?",
                "",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel) return;

            this.Tag = numericUpDown1.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
