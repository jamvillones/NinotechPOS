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
        public ReportUC()
        {
            InitializeComponent();
        }

        private void ReportUC_Load(object sender, EventArgs e)
        {
            saleStatus.SelectedIndex = 0;
            comboFilterType.SelectedIndex = 0;

            saleStatus.SelectedIndexChanged += saleStatus_SelectedIndexChanged;
            comboFilterType.SelectedIndexChanged += comboFilterType_SelectedIndexChanged;
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
            return null;
        }

        public async Task InitializeAsync()
        {
            var regT = Task.Run(() => { setRegularTableByDate(); });
            var chargedT = Task.Run(() => { setCharegedTable(); });

            await Task.WhenAll(regT, chargedT);
        }

        private void DefButton_Click(object sender, EventArgs e)
        {

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

        DataGridViewRow createRegularRow(Sale sale)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(saleTable);
            row.Cells[0].Value = sale.Id;
            row.Cells[1].Value = sale.Date.Value.ToString("MMM dd, yyyy hh:mm: tt");
            row.Cells[2].Value = sale.Login?.Username;
            row.Cells[3].Value = sale.Customer.Name;
            row.Cells[4].Value = string.Format("₱ {0:n}", sale.GetSaleTotalPrice());

            return row;
        }
        POSEntities posEnt => new POSEntities();
        void setRegularTableByDate()
        {
            Console.WriteLine("started: Regular");
            using (var p = posEnt)
            {
                string type = SaleType.Regular.ToString();

                saleTable.InvokeIfRequired(() => { saleTable.Rows.Clear(); });

                IQueryable<Sale> filteredSales = p.Sales.Where(x => x.SaleType == type);

                int index = 0;

                comboFilterType.InvokeIfRequired(() => { index = comboFilterType.SelectedIndex; });

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

                saleTable.InvokeIfRequired(() =>
                {
                    var rows = filteredSales.Select(createRegularRow).ToArray();
                    saleTable.Rows.AddRange(rows);
                });

                totalSale.InvokeIfRequired(() => { totalSale.Text = string.Format("₱ {0:n}", filteredSales.ToArray().Sum(x => x.GetSaleTotalPrice())); });
            }
            Console.WriteLine("finished: Regular");
        }

        DataGridViewRow createChargedRow(Sale sale)
        {
            var row = new DataGridViewRow();
            row.CreateCells(chargedTable);
            row.Cells[0].Value = sale.Id;
            row.Cells[1].Value = sale.Date.Value.ToString("MMMM dd, yyyy hh:mm tt");
            row.Cells[2].Value = sale.Login?.Username;
            row.Cells[3].Value = sale.Customer.Name;
            row.Cells[4].Value = string.Format("₱ {0:n}", sale.GetSaleTotalPrice());
            row.Cells[5].Value = string.Format("₱ {0:n}", sale.AmountRecieved);
            row.Cells[6].Value = string.Format("₱ {0:n}", remaining(sale.AmountRecieved ?? 0, sale.GetSaleTotalPrice()));
            row.Cells[7].Value = sale.AmountRecieved < sale.GetSaleTotalPrice() ? false : true;
            return row;
        }
        void setCharegedTable()
        {
            Console.WriteLine("started: Charged");
            using (var p = posEnt)
            {
                chargedTable.InvokeIfRequired(() => { chargedTable.Rows.Clear(); });

                var sales = p.Sales.Where(x => x.SaleType == SaleType.Charged.ToString()).Take(100).OrderByDescending(x => x.Date);
                decimal total = p.Sales.ToArray().Sum(x => remaining(x.AmountRecieved ?? 0, x.GetSaleTotalPrice()));

                toBeSettledTxt.InvokeIfRequired(() => { toBeSettledTxt.Text = string.Format("P {0:n}", total); });

                var rows = sales.Select(createChargedRow).ToArray();
                chargedTable.InvokeIfRequired(() => { chargedTable.Rows.AddRange(rows); });
            }
            Console.WriteLine("finished: Charged");
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
        bool searchMade { get; set; } = false;
        private void chargedSearchBtn_Click(object sender, EventArgs e)
        {
            //var button = sender as Button;
            if (chargedSaleSearch.Text == string.Empty || string.IsNullOrWhiteSpace(chargedSaleSearch.Text))
                return;

            searchMade = true;
            searchChargeByName();
        }
        private void chargedSaleSearch_TextChanged(object sender, EventArgs e)
        {
            if (chargedSaleSearch.Text == string.Empty && searchMade)
            {
                //using (var p = new POSEntities())
                setCharegedTable();
                searchMade = false;
            }
        }
        private void chargedSaleSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                chargedSearchBtn.PerformClick();
        }
        private void month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //using (var p = new POSEntities())
                setRegularTableByDate();
            }
        }
        public void Refresh_Callback(object sender, EventArgs e)
        {

            setRegularTableByDate();
            setCharegedTable();

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
                    sales = sales.ToArray().Where(x => x.GetSaleTotalPrice() > x.AmountRecieved);
                }
                else if (saleStatus.Text == "Paid")
                {
                    sales = sales.ToArray().Where(x => x.GetSaleTotalPrice() <= x.AmountRecieved);
                }

                foreach (var x in sales.OrderByDescending(y => y.Id))
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
            //using (var p = new POSEntities())
            setRegularTableByDate();
        }
    }
}
