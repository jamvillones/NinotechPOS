using Connections;
using POS.Misc;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace POS.Forms
{
    public partial class Add_Edit_ConnectionConfig : Form
    {
        private readonly ConnectionConfigurationProfile config;

        public Add_Edit_ConnectionConfig()
        {
            InitializeComponent();
        }

        public Add_Edit_ConnectionConfig(ConnectionConfigurationProfile config)
        {
            InitializeComponent();
            this.config = config;
        }

        private void Add_Edit_ConnectionConfig_Load(object sender, EventArgs e)
        {
            if (config is null)
                return;

            textBox1.Text = config.DataSource;
            textBox2.Text = config.Port;
            textBox3.Text = config.Username;
            textBox4.Text = config.Password;
            textBox5.Text = config.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (config is null)
            {
                Tag = new ConnectionConfigurationProfile()
                {
                    Id = ConnectionConfiguration_Source.Configurations.Select(i => i.Id).Max() + 1,
                    Name = textBox5.Text.NullIfEmpty(),
                    DataSource = textBox1.Text.Trim(),
                    Port = textBox2.Text.Trim().NullIfEmpty(),
                    Username = textBox3.Text.Trim().NullIfEmpty(),
                    Password = textBox4.Text.Trim().NullIfEmpty(),
                };

                DialogResult = DialogResult.OK;
            }
            else
            {
                config.Name = textBox5.Text.NullIfEmpty();
                config.DataSource = textBox1.Text.Trim();
                config.Port = textBox2.Text.Trim().NullIfEmpty();
                config.Username = textBox3.Text.Trim().NullIfEmpty();
                config.Password = textBox4.Text.Trim().NullIfEmpty();

                DialogResult = DialogResult.OK;

            }
        }

        private void Add_Edit_ConnectionConfig_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
