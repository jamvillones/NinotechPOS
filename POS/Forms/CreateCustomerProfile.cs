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
    public partial class CreateCustomerProfile : Form
    {
        public event EventHandler OnSave;
        public CreateCustomerProfile()
        {
            InitializeComponent();
        }
        bool canSave()
        {
            if (string.IsNullOrEmpty(name.Text) || string.IsNullOrEmpty(address.Text) || string.IsNullOrEmpty(contact.Text))
            {
                MessageBox.Show("Fields cannot be empty.");
                return false;
            }
            using (var p = new POSEntities())
            {
                var c = p.Customers.FirstOrDefault(x => x.Name == name.Text);
                if (c != null)
                {
                    MessageBox.Show("Name already taken.");
                    return false;
                }
            }
            return true;
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!canSave())
                return;
            using (var p = new POSEntities())
            {
                Customer c = new Customer();
                //c.Id = Id.Text;
                c.Name = name.Text;
                c.Address = address.Text;
                c.ContactDetails = contact.Text;
                p.Customers.Add(c);
                p.SaveChanges();
                MessageBox.Show("Customer Saved.");
                OnSave?.Invoke(this, null);
            }
            this.Close();

        }

        private void CreateCustomerProfile_Load(object sender, EventArgs e)
        {
            customerTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                foreach (var i in p.Customers)
                    customerTable.Rows.Add(i.Name, i.Address, i.ContactDetails);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
