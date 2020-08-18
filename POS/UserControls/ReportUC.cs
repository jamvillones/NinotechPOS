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

    public partial class ReportUC : UserControl, ITab
    {
        SaleType saleType = SaleType.Regular;
        Button defButton = new Button();
        int[] ids;

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
            defButton.Click += DefButton_Click;
            month.Items.Clear();
            for (int i = 0; i < (int)Months.Count; i++)
            {
                month.Items.Add(((Months)i).ToString());
                month.AutoCompleteCustomSource.Add(((Months)i).ToString());
            }

            month.Text = DateTime.Today.ToString("MMMM");
            day.Value = DateTime.Today.Day;
            year.Value = DateTime.Today.Year;
            day.Maximum = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

            setRegularTableByDate();

            tabControl1.Selected += TabControl1_Selected;

        }

        private void DefButton_Click(object sender, EventArgs e)
        {
            searchBtn.PerformClick();
            chargedSearchBtn.PerformClick();
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
                setRegularTableByDate();

            else if (e.TabPageIndex == 1)
                setCharegedTable();
        }


        private void saleTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var table = (DataGridView)sender;
            int index = table.CurrentCell.RowIndex;

            using (var saleDetails = new SaleDetails())
            {
                saleDetails.SetId(ids[index]);
                saleDetails.OnSave += (a, b) => { setCharegedTable(); };
                saleDetails.ShowDialog();
            }
        }

        private void month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (month.Items.Count == 0 || year.Value < 1)
                return;

            day.Maximum = DateTime.DaysInMonth((int)year.Value, month.SelectedIndex + 1);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            setRegularTableByDate();
        }

        void setRegularTableByDate()
        {
            string type = SaleType.Regular.ToString();
            saleTable.Rows.Clear();

            IQueryable<Sale> filteredSales;
            using (var p = new POSEntities())
            {
                filteredSales = p.Sales.Where(x => x.Date.Value.Year == (int)year.Value && x.SaleType == SaleType.Regular.ToString());

                if (!string.IsNullOrEmpty(month.Text))
                    filteredSales = filteredSales.Where(x => x.Date.Value.Month == month.SelectedIndex + 1);

                if (!string.IsNullOrEmpty(day.Text))
                    filteredSales = filteredSales.Where(x => x.Date.Value.Day == (int)day.Value);

                totalSale.Text = string.Format("₱ {0:n}", filteredSales.Sum(x => x.TotalPrice));

                ids = filteredSales.Select(x => x.Id).ToArray();

                foreach (var x in filteredSales)
                    saleTable.Rows.Add(x.Date.Value.ToString("MMMM dd, yyyy hh:mm: tt"), x.Login?.Username, x.Customer.Name, string.Format("₱ {0:n}", x.TotalPrice));
            }
        }

        void setCharegedTable()
        {
            chargedTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                var sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString()).OrderBy(x => x.Date);
                ids = sales.Select(x => x.Id).ToArray();
                foreach (var x in sales)
                    chargedTable.Rows.Add(x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"), x.Login?.Username, x.Customer.Name, string.Format("₱ {0:n}", x.TotalPrice), string.Format("₱ {0:n}", x.AmountRecieved), x.AmountRecieved < x.TotalPrice ? false : true);
            }
        }

        private void month_TextChanged(object sender, EventArgs e)
        {
            day.Enabled = month.Text == string.Empty ? false : true;
            if (month.Text == string.Empty)
                day.Text = string.Empty;
        }

        void searchChargeByName()
        {
            //for(int i =0;i< chargedTable.RowCount; i++)
            //{
            //    //// need to lower the case because string.contains is case sensitive :(
            //    string name = chargedTable.Rows[i].Cells[2].Value.ToString().ToLower();
            //    if (name.Contains(chargedSaleSearch.Text.ToLower()))
            //    {
            //        chargedTable.Rows[i].Selected = true;
            //        chargedTable.FirstDisplayedScrollingRowIndex = i;
            //        break;
            //    }
            //}       
            chargedTable.Rows.Clear();
            using (var p = new POSEntities())
            {
                var sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString() && x.Customer.Name.Contains(chargedSaleSearch.Text)).OrderBy(x => x.Date);
                ids = sales.Select(x => x.Id).ToArray();
                foreach (var x in sales)
                    chargedTable.Rows.Add(x.Date.Value.ToString("MMMM dd, yyyy hh:mm tt"), x.Login?.Username, x.Customer.Name, string.Format("₱ {0:n}", x.TotalPrice), string.Format("₱ {0:n}", x.AmountRecieved), x.AmountRecieved < x.TotalPrice ? false : true);
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
            Console.WriteLine("Refreshed: " + this.Name);
            if (saleType == SaleType.Regular)
                setRegularTableByDate();
            else
                setCharegedTable();
        }

        private void regularSalesTab_Click(object sender, EventArgs e)
        {
            saleType = SaleType.Regular;
        }

        private void chargedPage_Click(object sender, EventArgs e)
        {
            saleType = SaleType.Charged;
        }
    }
}
