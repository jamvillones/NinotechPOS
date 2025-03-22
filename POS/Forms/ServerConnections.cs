using Connections;
using Newtonsoft.Json;
using POS.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class ServerConnections : Form
    {
        public ServerConnections()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionConfiguration_Source.Save();
            DialogResult = DialogResult.OK;
        }

        private void ServerConnections_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = ConnectionConfiguration_Source.Configurations;
            comboBox1.SelectedItem = ConnectionConfiguration_Source.CurrentConfiguration;

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TryCancel();
            button5.Text = "Test";
            ConnectionConfiguration_Source.CurrentConfiguration = comboBox1.SelectedItem as ConnectionConfigurationProfile;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var add_EditConfig = new Add_Edit_ConnectionConfig())
            {
                if (add_EditConfig.ShowDialog() == DialogResult.OK)
                {
                    var newConfig = add_EditConfig.Tag as ConnectionConfigurationProfile;
                    ConnectionConfiguration_Source.Configurations.Add(newConfig);
                    comboBox1.SelectedItem = newConfig;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var config = ConnectionConfiguration_Source.CurrentConfiguration;
            if (config.Id == 0)
            {
                return;
            }

            using (var add_EditConfig = new Add_Edit_ConnectionConfig(config))
            {
                if (add_EditConfig.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var config = ConnectionConfiguration_Source.CurrentConfiguration;
            if (config.Id == 0)
                return;

            ConnectionConfiguration_Source.Configurations.Remove(config);
        }

        CancellationTokenSource cancelSource = new CancellationTokenSource();

        private async void button5_Click(object sender, EventArgs e)
        {

            var button = sender as Button;
            button.Text = "Connecting...";
            cancelSource = new CancellationTokenSource();

            await Task.Run(() =>
            {
                try
                {
                    using (var context = new POSEntities())
                    {
                        var currentConfig = ConnectionConfiguration_Source.CurrentConfiguration;
                        context.TestConnection(currentConfig);
                        bool databaseFound = context.Database.Exists();

                        cancelSource.Token.ThrowIfCancellationRequested();

                        if (databaseFound)
                            MessageBox.Show("Connection established.", currentConfig.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                            MessageBox.Show("Connection failed!", currentConfig.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cancelSource.Dispose();
                }
            });

            button.Text = "Test";
        }

        void TryCancel()
        {
            try
            {
                cancelSource?.Cancel();
            }
            catch
            {

            }
        }

        private void ServerConnections_FormClosing(object sender, FormClosingEventArgs e)
        {
            TryCancel();
        }
    }


    public static class ConnectionConfiguration_Source
    {
        static Settings settings = null;

        static bool isInitialized = false;

        public static void Initialize()
        {
            if (!isInitialized)
            {
                settings = Properties.Settings.Default;
                Configurations.Add(new ConnectionConfigurationProfile()
                {
                    Id = 0,
                    Name = "Local Connection",
                    DataSource = System.Environment.MachineName
                });

                var configs = JsonConvert.DeserializeObject<ConnectionConfigurationProfile[]>(settings.Configs);

                if (configs != null)
                    foreach (var config in configs)
                        Configurations.Add(config);

                isInitialized = true;
            }

            int id = settings.ConfigIndex;
            CurrentConfiguration = Configurations.First(x => x.Id == id);
        }

        public static ConnectionConfigurationProfile CurrentConfiguration { get; set; } = null;

        public static void Save()
        {
            var newConfig = JsonConvert.SerializeObject(Configurations.Skip(1).ToArray());
            settings.Configs = newConfig;
            settings.ConfigIndex = CurrentConfiguration.Id;
            settings.Save();
        }

        public static BindingList<ConnectionConfigurationProfile> Configurations { get; private set; } = new BindingList<ConnectionConfigurationProfile>();
    }

    public class ConnectionConfigurationProfile
    {
        public override string ToString() => string.IsNullOrEmpty(Name) ? "Configuration: " + Id : "[" + Name + "] " + DataSource;
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataSource { get; set; }
        public string Port { get; set; } = null;
        public string Username { get; set; }
        public string Password { get; set; }

        public string Connection => Port is null ? DataSource + "\\SQLEXPRESS" : DataSource + "," + Port;
    }
}
