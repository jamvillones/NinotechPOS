using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class ShiftSummaryForm : Form
    {
        public ShiftSummaryForm()
        {
            InitializeComponent();
        }

        private decimal resultAmount => totalCash - ((totalSales + totalInvoice) - totalExpenses);

        private Color resultsColor
        {
            get
            {
                if (resultAmount == 0)
                    return Color.DarkGreen;

                if (resultAmount > 0)
                    return Color.DarkBlue;

                return Color.Maroon;
            }
        }

        void updateResult()
        {
            resultTxt.InvokeIfRequired(() =>
            {
                resultTxt.Text = string.Format("₱ {0:n}", resultAmount);
                resultTxt.ForeColor = resultsColor;
            });
        }
        /// <summary>
        /// used to synchronize the result generation
        /// </summary>
        /// <param name="l"></param>
        /// <param name="value"></param>
        private void SetValues(Label l, decimal value)
        {
            l.InvokeIfRequired(() => l.Text = string.Format("₱ {0:n}", value));
            updateResult();
        }

        private async void ShiftSummaryForm_Load(object sender, EventArgs e)
        {
            await loadDataAsync();
        }

        private async void datePicker_ValueChanged(object sender, EventArgs e)
        {
            await loadSalesAsync();
        }

        private async void usersOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadSalesAsync();
        }

        private async Task loadDataAsync()
        {
            ///load the users first
            await Task.Run(() =>
            {
                using (var pos = new POSEntities())
                {
                    ///get the users data
                    var users = pos.Logins.Select(x => x.Username).ToArray();

                    usersOption.InvokeIfRequired(() =>
                    {
                        ///then put it in combobox
                        usersOption.Items.AddRange(users);
                        ///make sure that all users is selected
                        usersOption.SelectedIndex = 0;
                        usersOption.SelectedIndexChanged += usersOption_SelectedIndexChanged;
                    });
                }
            });
            ///load the sales associated with user
            await loadSalesAsync();
        }

        private async Task loadSalesAsync()
        {
            await Task.Run(() =>
            {
                using (var pos = new POSEntities())
                {
                    ///filter sales by date selected in datePicker
                    var sales = pos.Sales.Where(x => x.Date.Value.Day == datePicker.Value.Day &&
                                                     x.Date.Value.Month == datePicker.Value.Month &&
                                                     x.Date.Value.Year == datePicker.Value.Year &&
                                                     x.SaleType == "Regular");
                    ///if sales need to be filtered by user
                    bool is0Index = false;
                    usersOption.InvokeIfRequired(() => is0Index = usersOption.SelectedIndex == 0);

                    if (!is0Index)
                    {
                        string username = string.Empty;
                        usersOption.InvokeIfRequired(() => username = usersOption.Text);

                        sales = sales.Where(x => x.Login.Username == username);
                    }
                    ///clear the table first
                    salesTable.InvokeIfRequired(() => salesTable.Rows.Clear());

                    try
                    {
                        ///populate the table
                        foreach (var i in sales)
                        {
                            salesTable.InvokeIfRequired(() => salesTable.Rows.Add(i.Id,
                                                                                  i.Customer.Name,
                                                                                  i.Login.Username,
                                                                                  i.Total));
                        }
                    }
                    catch
                    {

                    }
                    ///set the label to grand total
                    label1.InvokeIfRequired(() => label1.Text = string.Format("Total: ₱ {0:n}", totalSales));
                    label9.InvokeIfRequired(() => label9.Text = string.Format("₱ {0:n}", totalSales));

                    updateResult();
                }
            });
        }

        private decimal totalSales
        {
            get { return salesTable.Rows.Cast<DataGridViewRow>().Select(x => (decimal)x.Cells[saleTotalCol.Index].Value).DefaultIfEmpty(0).Sum(); }
        }

        #region money
        private decimal total1000 => thousands.Value * 1000;
        private decimal total500 => fivehundreds.Value * 500;
        private decimal total200 => twohundreds.Value * 200;
        private decimal total100 => onehundreds.Value * 100;
        private decimal total50 => fifties.Value * 50;
        private decimal total20 => twenties.Value * 20;
        private decimal total10 => tens.Value * 10;
        private decimal total5 => fives.Value * 5;
        private decimal total1 => ones.Value * 1;
        private decimal total25cents => twentyfivecents.Value * 0.25M;
        private decimal total10cents => tencents.Value * 0.1M;
        private decimal total5cents => fivecents.Value * 0.05M;

        private decimal totalCash => total1000 +
                                     total500 +
                                     total200 +
                                     total100 +
                                     total50 +
                                     total20 +
                                     total10 +
                                     total5 +
                                     total1 +
                                     total25cents +
                                     total10cents +
                                     total5cents;
        #endregion

        #region cash numeric valuechanged
        void calculateTotalCash()
        {
            totalCashTxt.Text = string.Format("₱ {0:n}", totalCash);
            SetValues(label6, totalCash);
            //label6.Text = string.Format("₱ {0:n}", totalCash);
        }

        private void thousands_ValueChanged(object sender, EventArgs e)
        {
            label36.Text = string.Format("₱ {0:n}", total1000);
            calculateTotalCash();
        }

        private void fivehundreds_ValueChanged(object sender, EventArgs e)
        {
            label35.Text = string.Format("₱ {0:n}", total500);
            calculateTotalCash();
        }

        private void twohundreds_ValueChanged(object sender, EventArgs e)
        {
            label34.Text = string.Format("₱ {0:n}", total200);
            calculateTotalCash();
        }

        private void onehundreds_ValueChanged(object sender, EventArgs e)
        {
            label33.Text = string.Format("₱ {0:n}", total100);
            calculateTotalCash();
        }

        private void fifties_ValueChanged(object sender, EventArgs e)
        {
            label32.Text = string.Format("₱ {0:n}", total50);
            calculateTotalCash();
        }

        private void twenties_ValueChanged(object sender, EventArgs e)
        {
            label31.Text = string.Format("₱ {0:n}", total20);
            calculateTotalCash();
        }

        private void tens_ValueChanged(object sender, EventArgs e)
        {
            label30.Text = string.Format("₱ {0:n}", total10);
            calculateTotalCash();
        }

        private void fives_ValueChanged(object sender, EventArgs e)
        {
            label29.Text = string.Format("₱ {0:n}", total5);
            calculateTotalCash();
        }

        private void ones_ValueChanged(object sender, EventArgs e)
        {
            label28.Text = string.Format("₱ {0:n}", total1);
            calculateTotalCash();
        }

        private void twentyfivecents_ValueChanged(object sender, EventArgs e)
        {
            label27.Text = string.Format("₱ {0:n}", total25cents);
            calculateTotalCash();
        }

        private void tencents_ValueChanged(object sender, EventArgs e)
        {
            label26.Text = string.Format("₱ {0:n}", total10cents);
            calculateTotalCash();
        }

        private void fivecents_ValueChanged(object sender, EventArgs e)
        {
            label25.Text = string.Format("₱ {0:n}", total5cents);
            calculateTotalCash();
        }
        #endregion

        #region invoice
        private decimal totalInvoice => invoiceTable.Rows.Cast<DataGridViewRow>().Select((x) =>
        {
            decimal temp;

            if (decimal.TryParse(x.Cells[invoiceTotalCol.Index].Value?.ToString(), out temp))
            {
                return temp;
            }
            return 0M;

        }).DefaultIfEmpty(0).Sum();

        private void invoiceTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == invoiceTotalCol.Index)
            {
                label12.Text = string.Format("Total: P {0:n}", totalInvoice);
                SetValues(label8, totalInvoice);
                // label8.Text = string.Format("₱ {0:n}", totalInvoice);
            }
        }
        private void invoiceTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label12.Text = string.Format("Total: ₱ 0:n", totalInvoice);
            SetValues(label8, totalInvoice);
        }
        #endregion

        #region expenses
        private decimal totalExpenses => expensesTable.Rows.Cast<DataGridViewRow>().Select((x) =>
        {
            decimal temp;

            if (decimal.TryParse(x.Cells[invoiceTotalCol.Index].Value?.ToString(), out temp))
            {
                return temp;
            }
            return 0M;

        }).DefaultIfEmpty(0).Sum();

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == expensesTotalCol.Index)
            {
                label10.Text = string.Format("Total: ₱ {0:n}", totalExpenses);
                SetValues(label7, totalExpenses);
                //label7.Text = string.Format("₱ {0:n}", totalExpenses);
            }
        }

        private void expensesTable_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            label10.Text = string.Format("Total: ₱ 0:n", totalExpenses);
            SetValues(label7, totalExpenses);
        }
        #endregion

        private async void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = sender as SaveFileDialog;
            var file = new FileInfo(dialog.FileName);
            using( var package = new ExcelPackage(file))
            {
                var ws = package.Workbook.Worksheets.Add("Sales");
                var sales = salesTable.Rows.Cast<DataGridViewRow>().Select(x => new SaleSummary.FilteredSaleModel() {
                    Customer = x.Cells[1].Value.ToString(),
                    By = x.Cells[2].Value.ToString(),
                    Total = x.Cells[3].Value.ToString()
                });
                ws.Cells["A1"].Value = "CASH COMPUTATION";
                ws.Cells["A1:C1"].Merge = true;

                ws.Cells["A2"].Value = "1000";
                ws.Cells["A3"].Value = "500";
                ws.Cells["A4"].Value = "200";
                ws.Cells["A5"].Value = "100";
                ws.Cells["A6"].Value = "50";
                ws.Cells["A7"].Value = "20";
                ws.Cells["A8"].Value = "10";
                ws.Cells["A9"].Value = "5";
                ws.Cells["A10"].Value = "1";
                ws.Cells["A11"].Value = "0.25";
                ws.Cells["A12"].Value = "0.10";
                ws.Cells["A13"].Value = "0.05";

                ws.Cells["B2"].Value = thousands.Value;
                ws.Cells["B3"].Value = fivehundreds.Value;
                ws.Cells["B4"].Value = twohundreds.Value;
                ws.Cells["B5"].Value = onehundreds.Value;
                ws.Cells["B6"].Value = fifties.Value;
                ws.Cells["B7"].Value = twenties.Value;
                ws.Cells["B8"].Value = tens.Value;
                ws.Cells["B9"].Value = fives.Value;
                ws.Cells["B10"].Value = ones.Value;
                ws.Cells["B11"].Value = twentyfivecents.Value;
                ws.Cells["B12"].Value = tencents.Value;
                ws.Cells["B13"].Value = fivecents.Value;

                ws.Cells["C2"].Value = total1000;
                ws.Cells["C3"].Value = total500;
                ws.Cells["C4"].Value = total200;
                ws.Cells["C5"].Value = total100;
                ws.Cells["C6"].Value = total50;
                ws.Cells["C7"].Value = total20;
                ws.Cells["C8"].Value = total10;
                ws.Cells["C9"].Value = total5;
                ws.Cells["C10"].Value = total1;
                ws.Cells["C11"].Value = total25cents;
                ws.Cells["C12"].Value = total10cents;
                ws.Cells["C13"].Value = total5cents;

                ws.Cells["A14"].Value = "TOTAL:";
                ws.Cells["B14"].Value = totalCash;
                ws.Cells["B14:C14"].Merge = true;

                ws.Cells["A16"].Value = "SALES";
                ws.Cells["A16"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["A16:C16"].Merge = true;
                ws.Cells["A17"].Value = "GRAND TOTAL:";
                ws.Cells["B17:C17"].Merge = true;
                ws.Cells["B17"].Value = totalSales;
               
                ws.Cells["A18"].LoadFromCollection( sales, true);


                var invoices = invoiceTable.Rows.Cast<DataGridViewRow>().Where(y=>y.Cells[0].Value != null).Select(x => new SaleSummary.InvoiceModel()
                {
                    Details = x.Cells[0].Value.ToString(),
                    Particular = x.Cells[1].Value?.ToString(),
                    Total = x.Cells[2].Value.ToString()
                });

                ws.Cells["E16"].Value = "INVOICES";
                ws.Cells["E16"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["E16:G16"].Merge = true;
                ws.Cells["E17"].Value = "GRAND TOTAL:";
                ws.Cells["F17"].Value = totalInvoice;
                ws.Cells["F17:G17"].Merge = true;
                ws.Cells["E18"].LoadFromCollection(invoices, true);


                var expenses =expensesTable.Rows.Cast<DataGridViewRow>().Where(y => y.Cells[0].Value != null).Select(x => new SaleSummary.InvoiceModel()
                {
                    Details = x.Cells[0].Value.ToString(),
                    Particular = x.Cells[1].Value?.ToString(),
                    Total = x.Cells[2].Value.ToString()
                });

                ws.Cells["I16"].Value = "EXPENSES";
                ws.Cells["I16"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells["I16:K16"].Merge = true;
                ws.Cells["I17"].Value = "GRAND TOTAL:";

                ws.Cells["J17"].Value = totalExpenses;
                ws.Cells["J17:K17"].Merge = true;

                ws.Cells["I18"].LoadFromCollection(expenses, true);


                ws.Cells["E1"].Value = "RESULT:";
                ws.Cells["F1"].Value = resultAmount;
                ws.Cells["F1:G1"].Merge = true;

                ws.Cells["E3"].Value = "LOGIN:";
                ws.Cells["F3"].Value = usersOption.Text;
                ws.Cells["E4"].Value = "DATE:";

                ws.Cells["F4"].Value = datePicker.Value.ToString("MMM/d/yyyy");


                await package.SaveAsync();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Shift Report " + datePicker.Value.ToString("MMM_d_yyyy_h_mm_tt");
            saveFileDialog.ShowDialog();
        }
    }
}
