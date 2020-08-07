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
    public partial class TransactionHistoryForm : Form
    {
        Sale currentSale;
        public void SetId(int id)
        {
            using(var p = new POSEntities())
            {
                currentSale = p.Sales.FirstOrDefault(x => x.Id == id);
                custName.Text = currentSale.Customer.Name;
                total.Text = string.Format("₱ {0:n}", currentSale.TotalPrice);

                table.Rows.Clear();
                var ts = p.ChargedPayRecords.Where(x => x.SaleId == currentSale.Id);
                foreach(var i in ts)
                {
                    table.Rows.Add(i.Username,i.AmountPayed,i.TransactionTime.Value.ToString("MMMM dd, yyyy hh:mm tt"));
                }
            }
        }
        public TransactionHistoryForm()
        {
            InitializeComponent();
        }
    }
}
