using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class EditCostForm : Form {
        public EditCostForm(decimal oldCost) {
            InitializeComponent();
            Cost = oldCost;
            numericUpDown1.Value = Cost;
        }

        public decimal Cost { get; private set; }

        private void button1_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to change the cost?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DialogResult = DialogResult.OK;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {

            Cost = numericUpDown1.Value;
        }
    }
}
