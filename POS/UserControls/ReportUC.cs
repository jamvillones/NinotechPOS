using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.Interfaces;
using POS.Forms;
using POS.Misc;



namespace POS.UserControls
{
    public enum SaleStatusFilter { All, Pending, Paid, Count }
    public partial class ReportUC : UserControl, ITab
    {
        Button defButton = new Button();
        //int[] ids;

        public ReportUC()
        {
            InitializeComponent();
        }

        public void RefreshData()
        {

        }

        public Control FirstControl()
        {
            return null;
        }

        public Button EnterButton()
        {
            return defButton;
        }

        public void Initialize()
        {
            comboFilterType.SelectedIndex = 0;

            for (int i = 0; i < (int)SaleStatusFilter.Count; i++)
                saleStatus.Items.Add(((SaleStatusFilter)i).ToString());

            saleStatus.SelectedIndex = 0;

            defButton.Click += DefButton_Click;

            setRegularTableByDate();
            setCharegedTable();

           /// tabControl1.Selected += TabControl1_Selected;

        }

        private void DefButton_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //if (e.TabPageIndex == 0)
            //    setRegularTableByDate();

            //else if (e.TabPageIndex == 1)
            //    setCharegedTable();
        }


        private void saleTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var table = (DataGridView)sender;
            int index = (int)(table.SelectedCells[0].Value);

            using (var saleDetails = new SaleDetails())
            {
                saleDetails.SetId(index);
                saleDetails.OnSave += (a, b) => { setCharegedTable(); };
                saleDetails.ShowDialog();
            }
        }

        void setRegularTableByDate()
        {
            string type = SaleType.Regular.ToString();
            saleTable.Rows.Clear();

            using (var p = new POSEntities())
            {
                IQueryable<Sale> filteredSales = p.Sales.Where(x=>x.SaleType == type);

                int index = comboFilterType.SelectedIndex;

                switch (index)
                {
                    case 0:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year && x.Date.Value.Month == dtFilter.Value.Month && x.Date.Value.Day == dtFilter.Value.Day);
                        break;
                    case 1:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year && x.Date.Value.Month == dtFilter.Value.Month);
                        break;
                    case 2:
                        filteredSales = filteredSales.Where(x => x.Date.Value.Year == dtFilter.Value.Year);
                        break;
                }

                foreach (var x in filteredSales)
                    saleTable.Rows.Add(x.Id, x.Date.Value.ToString("MMMM dd, yyyy hh:mm: tt"), x.Login?.Username, x.Customer.Name, string.Format("₱ {0:n}", x.GetSaleTotalPrice()));

                totalSale.Text = string.Format("₱ {0:n}", filteredSales.ToArray().Sum(x => x.GetSaleTotalPrice()));
            }
        }

        void setCharegedTable()
        {
            chargedTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                var sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString()).OrderByDescending(x => x.Date);
                decimal total = p.Sales.ToArray().Sum(x => remaining(x.AmountRecieved ?? 0, x.GetSaleTotalPrice()));

                toBeSettledTxt.Text = string.Format("P {0:n}", total);
                //ids = sales.Select(x => x.Id).ToArray();
                foreach (var x in sales)
                    chargedTable.Rows.Add(x.Id,
                                          x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                          x.Login?.Username,
                                          x.Customer.Name,
                                          string.Format("₱ {0:n}", x.GetSaleTotalPrice()),
                                          string.Format("₱ {0:n}", x.AmountRecieved),
                                          string.Format("₱ {0:n}", remaining(x.AmountRecieved ?? 0, x.GetSaleTotalPrice())),
                                          x.AmountRecieved < x.GetSaleTotalPrice() ? false : true);
            }
        }
        decimal remaining(decimal recieved, decimal totalPrice)
        {
            if (recieved > totalPrice)
                return 0;
            return totalPrice - recieved;
        }

        void searchChargeByName()
        {
            chargedTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                var sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString() && x.Customer.Name.Contains(chargedSaleSearch.Text)).OrderBy(x => x.Date);
                //ids = sales.Select(x => x.Id).ToArray();
                foreach (var x in sales)
                    chargedTable.Rows.Add(x.Id,
                                          x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                          x.Login?.Username,
                                          x.Customer.Name,
                                          string.Format("₱ {0:n}", x.GetSaleTotalPrice()),
                                          string.Format("₱ {0:n}", x.AmountRecieved),
                                          string.Format("₱ {0:n}", remaining(x.AmountRecieved ?? 0, x.GetSaleTotalPrice())),
                                          x.AmountRecieved < x.GetSaleTotalPrice() ? false : true);
            }

        }

        private void chargedSearchBtn_Click(object sender, EventArgs e)
        {
            searchChargeByName();
        }

        private void chargedSaleSearch_TextChanged(object sender, EventArgs e)
        {
            if (chargedSaleSearch.Text == string.Empty)
                setCharegedTable();
        }

        private void chargedSaleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchChargeByName();
        }

        private void month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                setRegularTableByDate();
        }

        public void Refresh_Callback(object sender, EventArgs e)
        {
            setRegularTableByDate();
            setCharegedTable();
        }

        private void regularSalesTab_Click(object sender, EventArgs e)
        {

        }

        private void chargedPage_Click(object sender, EventArgs e)
        {

        }

        private void saleStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargedTable.Rows.Clear();

            using (var p = new POSEntities())
            {
                var sales = p.Sales.ToArray().Where(x => x.SaleType == SaleType.Charged.ToString());

                if (chargedSaleSearch.Text != string.Empty)
                {
                    sales = sales.Where(x => x.Customer.Name.Contains(chargedSaleSearch.Text));
                }

                if (saleStatus.Text == "Pending")
                {
                    Console.WriteLine("hey");
                    sales = sales.ToArray().Where(x => x.GetSaleTotalPrice() > x.AmountRecieved);
                }
                else if (saleStatus.Text == "Paid")
                {
                    sales = sales.ToArray().Where(x => x.GetSaleTotalPrice() <= x.AmountRecieved);
                }

                foreach (var x in sales)
                    chargedTable.Rows.Add(x.Id,
                                          x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"),
                                          x.Login?.Username,
                                          x.Customer.Name,
                                          string.Format("₱ {0:n}", x.GetSaleTotalPrice()),
                                          string.Format("₱ {0:n}", x.AmountRecieved),
                                          string.Format("₱ {0:n}", remaining(x.AmountRecieved ?? 0, x.GetSaleTotalPrice())),
                                          x.AmountRecieved < x.GetSaleTotalPrice() ? false : true);
            }
        }

        private void comboFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = ((ComboBox)sender).SelectedIndex;
            switch (index)
            {
                case 0:
                    dtFilter.CustomFormat = "MMMM d, yyyy";
                    break;
                case 1:
                    dtFilter.CustomFormat = "MMMM yyyy";
                    break;
                case 2:
                    dtFilter.CustomFormat = "yyyy";
                    break;
            }
            setRegularTableByDate();
        }

        private void dtFilter_ValueChanged(object sender, EventArgs e)
        {
            setRegularTableByDate();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
