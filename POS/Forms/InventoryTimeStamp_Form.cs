using POS.Misc;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms {
    public partial class InventoryTimeStamp_Form : Form {
        public InventoryTimeStamp_Form() {
            InitializeComponent();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) {
            if (sender is RadioButton rb && rb.Checked) {
                if (rb == radioButton1)
                    inventorySnapshot_Items1.BringToFront();
                else if (rb == radioButton2)
                    inventorySnapshot_Graph1.BringToFront();
            }
        }

        private async void InventoryTimeStamp_Form_Load(object sender, EventArgs e) {

            await Task.WhenAll(inventorySnapshot_Items1.Initialize_Async(), inventorySnapshot_Graph1.Initialize_Async());
        }

        private void InventoryTimeStamp_Form_FormClosing(object sender, FormClosingEventArgs e) {
            inventorySnapshot_Graph1.TryCancel();
            inventorySnapshot_Items1.TryCancel();
        }
    }
}
