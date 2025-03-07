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
            var button = sender as Button;
            button.Text = "Connecting...";
            await Task.Run(() =>
            {
                try
                {
                    using (var context = new POSEntities())
                    {
                        context.ChangeDatabase(dataSource, portName, id, password, checkBox1.Checked);

                        bool databaseFound = context.Database.Exists();

                        tokenSource.Token.ThrowIfCancellationRequested();

                        if (databaseFound)
                            MessageBox.Show("Connection established.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                            MessageBox.Show("Connection failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            button.Text = "Test Connection";
        }

        private void ConnectionConfigurations_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource?.Cancel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveSettings();
            DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// save the values to settings
        /// </summary>
        private void saveSettings()
        {
            var settings = Properties.Settings.Default;

            settings.IsLocalConnection = checkBox1.Checked;
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
            checkBox1.Checked = settings.IsLocalConnection;

            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = !checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = !checkBox1.Checked;
        }
    }
}
