using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace POS.Forms
{
    public interface ICreatingForm
    {
        void Reset();
        event EventHandler<object> OnSuccessfulCreation;
    }
    public partial class Create_Customer_Form : Form, ICreatingForm
    {
        public Create_Customer_Form()
        {
            InitializeComponent();
        }

        public Create_Customer_Form(string name)
        {
            InitializeComponent();
            CustomerName = name;
        }

        //public List<Customer> Result { get; } = new List<Customer>();

        public string CustomerName
        {
            get => string.IsNullOrWhiteSpace(customerName.Text) ? null : customerName.Text.Trim();
            set => customerName.Text = value.Trim();
        }

        public string ContactDetails
        {
            get => string.IsNullOrWhiteSpace(contactDetails.Text) ? null : contactDetails.Text.Trim();
            set => contactDetails.Text = value.Trim();
        }

        public string Address
        {
            get => string.IsNullOrWhiteSpace(address.Text) ? null : address.Text.Trim();
            set => address.Text = value.Trim();
        }

        public event EventHandler<object> OnSuccessfulCreation;

        public void Reset()
        {
            CustomerName = Address = ContactDetails = string.Empty;
        }

        private async void addSuppBtn_Click(object sender, EventArgs e)
        {
            if (CustomerName is null)
            {
                MessageBox.Show("Name cannot be empty!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var context = new POSEntities())
                {
                    var found = await context.Customers.AnyAsync(c => c.Name == CustomerName);

                    if (found)
                    {
                        if (MessageBox.Show(
                            "This new customer might already be registered. Are you sure you want to continue?",
                            "",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                    else if (MessageBox.Show(
                            "Are you sure you want to add this new customer?",
                            "",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }

                    var customer = new Customer()
                    {
                        Name = CustomerName,
                        Address = Address,
                        ContactDetails = ContactDetails,
                    };

                    var result = context.Customers.Add(customer);
                    await context.SaveChangesAsync();

                    MessageBox.Show("Save successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    OnSuccessfulCreation.Invoke(this, result);
                }
            }
            catch (Exception) { }

            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Customer_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CustomerName != null && MessageBox.Show("Are you sure you want to exit?", "Changes Not Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel;
        }
    }
}
