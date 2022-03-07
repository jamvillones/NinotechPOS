using Connections;
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

namespace POS
{
    public partial class ConnectionConfigurations : Form
    {
        public ConnectionConfigurations()
        {
            InitializeComponent();
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();

        string dataSource { get => textBox1.Text.Trim(); set => textBox1.Text = value; }
        string portName { get => textBox2.Text.Trim(); set => textBox2.Text = value; }
        string id { get => textBox3.Text.Trim(); set => textBox3.Text = value; }
        string password { get => textBox4.Text.Trim(); set => textBox4.Text = value; }

        private async void button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                using (var context = new POSEntities())
                {
                    try
                    {
                        context.ChangeDatabase(dataSource, portName, id, password);
                        label1.InvokeIfRequired(() => label1.Text = "processing...");
                        bool cond = context.Database.Exists();

                        tokenSource.Token.ThrowIfCancellationRequested();

                        if (cond)
                        {
                            MessageBox.Show("Connection established.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Connection failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        label1.InvokeIfRequired(() => label1.Text = string.Empty);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("loading cancelled. " + ex.Message);
                    }
                }
            });
        }

        private void ConnectionConfigurations_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource?.Cancel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveSettings();
            DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// save the values to settings
        /// </summary>
        private void saveSettings()
        {
            var settings = Properties.Settings.Default;

            settings.DataSource = dataSource;
            settings.PortName = portName;
            settings.UserId = id;
            settings.Password = password;
            settings.Save();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = !(string.IsNullOrWhiteSpace(dataSource) || 
                                string.IsNullOrWhiteSpace(portName) || 
                                string.IsNullOrWhiteSpace(id) || 
                                string.IsNullOrWhiteSpace(password));
        }

        private void ConnectionConfigurations_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;

            dataSource = settings.DataSource;
            portName = settings.PortName;
            id = settings.UserId;
            password = settings.Password;
        }
    }
}
