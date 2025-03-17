using POS.Misc;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POS.Forms.ItemRegistration
{
    public partial class Item_Image_From : Form
    {
        private readonly Item item;

        public Item_Image_From(Item item)
        {
            InitializeComponent();
            this.item = item;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            item.SampleImage = pictureBox.Image.ToByteArray();
            this.DialogResult = DialogResult.OK;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg;*.png)|*.jpg; *.jpeg; *.png";
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    pictureBox.Image = new Bitmap(openFileDialog.FileName);
                }
                catch (IOException)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this image?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            
            if (pictureBox.Image != null)
                pictureBox.Image = null;

        }

        private void Item_Image_From_Load(object sender, EventArgs e)
        {

        }
    }
}
