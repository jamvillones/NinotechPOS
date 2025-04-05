using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class Show_Image : Form
    {
        readonly Image image;

        public Show_Image(Image image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void Show_Image_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }
    }
}
