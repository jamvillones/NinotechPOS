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

        public CreateCustomerProfile(string Name)
        {
            InitializeComponent();

            name.Text = Name.Trim();
        }

        bool canSave()
        {
            if (string.IsNullOrEmpty(name.Text.Trim()))
            {
                MessageBox.Show("Name cannot be empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            using (var p = new POSEntities())
            {
                var c = p.Customers.FirstOrDefault(x => x.Name == name.Text);
                if (c != null)
                {
                    MessageBox.Show("Name already taken.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                var add = address.Text.Trim();
                var cont = contact.Text.Trim();

                Customer c = new Customer();

                c.Name = name.Text.Trim();

                c.Address = add == string.Empty ? null : add;
                c.ContactDetails = cont == string.Empty ? null : cont;

                p.Customers.Add(c);
                p.SaveChanges();

                OnSave?.Invoke(this, null);
            }

            this.Tag = name.Text.Trim();
            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void CreateCustomerProfile_Load(object sender, EventArgs e)
        {
            customerTable.Rows.Clear();

            using (var p = new POSEntities())
            {
                IEnumerable<Customer> customers = p.Customers;
                var rows = customers.Select(x => customerTable.createRow(x.Id, x.Name, x.Address, x.ContactDetails, "Delete", "Transactions")).ToArray();
                customerTable.Rows.AddRange(rows);
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
                        customerTable.Rows.Add(i.Id, i.Name, i.Address, i.ContactDetails, "Delete", "Transactions");
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
                    customerTable.Rows.Add(i.Id, i.Name, i.Address, i.ContactDetails, "Delete", "Transactions");
                }
            }
        }
        void DeleteCustomer(int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            var table = customerTable;
            var id = (int)(table.Rows[rowIndex].Cells[0].Value);
            using (var p = new POSEntities())
            {
                var c = p.Customers.FirstOrDefault(x => x.Id == id);
                if (c != null)
                    p.Customers.Remove(c);
                p.SaveChanges();
            }
            table.Rows.RemoveAt(rowIndex);
            MessageBox.Show("Customer deleted.");
        }

        private void customerTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DeleteCustomer(e.RowIndex);
            }
            if (e.ColumnIndex == 5)
            {
                using (var ct = new CustomerTransactionsForm())
                {
                    if (ct.SetId((int)(customerTable.Rows[e.RowIndex].Cells[0].Value)))
                        ct.ShowDialog();
                }
            }


        }

        int targetCustomerId = 0;
        string lastValue = "";
        private void customerTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var table = sender as DataGridView;
            targetCustomerId = (int)(table.Rows[e.RowIndex].Cells[0].Value);
            lastValue = table[e.ColumnIndex, e.RowIndex].Value?.ToString();
        }

        private void customerTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var table = sender as DataGridView;

            if (table[e.ColumnIndex, e.RowIndex].Value?.ToString() == lastValue)
                return;

            if (MessageBox.Show("Are you sure you want to edit this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                table[e.ColumnIndex, e.RowIndex].Value = lastValue;
                lastValue = "";
                return;
            }

            var value = table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

            using (var p = new POSEntities())
            {
                var target = p.Customers.FirstOrDefault(x => x.Id == targetCustomerId);
                switch (e.ColumnIndex)
                {
                    case 1:
                        if (value == null)
                        {
                            MessageBox.Show("Name cannot be null", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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
