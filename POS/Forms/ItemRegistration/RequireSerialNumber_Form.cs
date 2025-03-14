using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{
    public partial class RequireSerialNumber_Form : Form
    {
        private readonly Item item;

        public RequireSerialNumber_Form(Item item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            item.IsSerialRequired = true;
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.IsSerialRequired = false;
            DialogResult = DialogResult.OK;
        }
    }
}
