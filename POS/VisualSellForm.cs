using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class VisualSellForm : Form
    {
        public VisualSellForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("tabtip.exe");
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == MouseButtons.Left)
                System.Diagnostics.Process.Start("tabtip.exe");
        }

        private void VisualSellForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                this.ActiveControl = searchTxt;
        }
    }
}
