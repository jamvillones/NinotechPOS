using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS.Forms
{
    public partial class PurchasedItem_Chart : Form
    {
        public PurchasedItem_Chart(params DataPoint[] points)
        {
            InitializeComponent();
            this.points = points;
        }



        async Task LoadDataAsync()
        {
            try
            {
                cancelSource = new CancellationTokenSource();

                await LoadGraphDetails(cancelSource.Token);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loading Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                cancelSource.Dispose();
                cancelSource = null;
            }
        }

        CancellationTokenSource cancelSource = new CancellationTokenSource();
        private readonly DataPoint[] points;

        private async Task LoadGraphDetails(CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                foreach (var point in points)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return;

                    chart1.InvokeIfRequired(() => chart1.Series[0].Points.Add(point));
                }
            });
        }

        private void PurchasedItem_Chart_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                cancelSource?.Cancel();
            }
            catch
            {

            }
        }

        private async void PurchasedItem_Chart_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
