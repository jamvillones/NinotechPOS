using AForge.Video.DirectShow;
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
    public partial class CaptureImage : Form
    {
        public CaptureImage()
        {
            InitializeComponent();
        }

        FilterInfoCollection infoCollection;
        VideoCaptureDevice captureDevice;

        private BindingList<FilterInfo> Devices { get; set; } = new BindingList<FilterInfo>();

        private void CaptureImage_Load(object sender, EventArgs e)
        {
            infoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo info in infoCollection)
            {
                Devices.Add(info);
            }

            comboBox1.DataSource =
                Devices;

        }
    }
}
