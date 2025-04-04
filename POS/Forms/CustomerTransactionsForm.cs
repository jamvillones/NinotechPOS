﻿using System;
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
    public partial class CustomerTransactionsForm : Form
    {
        public CustomerTransactionsForm()
        {
            InitializeComponent();
        }
        public bool SetId(int id)
        {
            using (var p = POSEntities.Create())
            {
                //customerNameTxt.Text = p.Customers.FirstOrDefault(x => x.Id == id)?.Name;

                this.Text = this.Text + " - " + p.Customers.FirstOrDefault(c => c.Id == id)?.Name ?? "Walk-in";
                var tr = p.Sales.Where(x => x.CustomerId == id);
                if (tr.Count() == 0)
                {
                    return false;
                }

                transactionsTable.Rows.Clear();
                foreach (var i in tr.OrderByDescending(x => x.Date))
                {
                    transactionsTable.Rows.Add(i.Id,
                                                i.Date,
                                                i.SoldItems.Sum(x => (x.ItemPrice - x.Discount) * x.Quantity),
                                                i.SaleType);
                }

            }
            return true;
        }

        private void transactionsTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (var saledetails = new SaleDetails((int)(transactionsTable.Rows[e.RowIndex].Cells[0].Value)))
            {
                //saledetails.SetId();
                saledetails.ShowDialog();
            }
        }

        private void CustomerTransactionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
