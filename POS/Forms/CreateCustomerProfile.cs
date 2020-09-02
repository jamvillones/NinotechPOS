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
                    customerTable.Rows.Add(i.Id, i.Name, i.Address, i.ContactDetails, "Delete");
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

        private void searchControl_OnSearch(object sender, Misc.SearchEventArgs e)
        {

            using (var p = new POSEntities())
            {
                var s = p.Customers.Where(x => x.Name.Contains(e.Text));
                if (s.Count() != 0)
                {

                    e.SearchFound = true;
                    customerTable.Rows.Clear();
                    foreach (var i in s)
                    {
                        customerTable.Rows.Add(i.Id, i.Name, i.Address, i.ContactDetails, "Delete");
                    }
                }

            }
        }

        private void searchControl_OnTextEmpty(object sender, EventArgs e)
        {

            using (var p = new POSEntities())
            {
                customerTable.Rows.Clear();
                foreach (var i in p.Customers)
                {
                    customerTable.Rows.Add(i.Id, i.Name, i.Address, i.ContactDetails, "Delete");
                }
            }
        }

        private void customerTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 4)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var table = sender as DataGridView;
            var id = (int)(table.Rows[e.RowIndex].Cells[0].Value);
            using (var p = new POSEntities())
            {
                var c = p.Customers.FirstOrDefault(x => x.Id == id);
                if (c != null)
                    p.Customers.Remove(c);
                p.SaveChanges();
            }
            table.Rows.RemoveAt(e.RowIndex);
            MessageBox.Show("Customer deleted.");
        }

        int targetCustomerId = 0;
        private void customerTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var table = sender as DataGridView;
            targetCustomerId = (int)(table.Rows[e.RowIndex].Cells[0].Value);
        }

        private void customerTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var table = sender as DataGridView;
            var value = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            using (var p = new POSEntities())
            {
                var target = p.Customers.FirstOrDefault(x => x.Id == targetCustomerId);
                switch (e.ColumnIndex)
                {
                    case 1:
                        target.Name = value;
                        break;
                    case 2:
                        target.Address = value;
                        break;
                    case 3:
                        target.ContactDetails = value;
                        break;
                    default:
                        break;
                }
                p.SaveChanges();
            }
        }
    }

}
