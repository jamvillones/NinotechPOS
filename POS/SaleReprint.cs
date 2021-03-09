using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class SaleReprint : Form
    {
        public SaleReprint()
        {
            InitializeComponent();
        }
        Sale sale = null;
        public bool SetId(int id)
        {
            using (var p = new POSEntities())
            {
                sale = p.Sales.FirstOrDefault(x => x.Id == id);
                if (sale != null)
                {
                    Initialize(sale);
                    return true;
                }
            }
            return false;
        }
        void Initialize(Sale s)
        {
            saleIdTxt.Text = s.Id.ToString();
            soldToTxt.Text = s.Customer.Name;

            printPreviewControl1.Document = document;
        }
        //Size hardMargins;
        Rectangle area;
        PrintAction printAction;
        Pen areaPen = new Pen(Brushes.Red);
        Pen gridPen = new Pen(Brushes.Gray);
        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;
            RectangleF marginBounds = e.MarginBounds;
            RectangleF printableArea = e.PageSettings.PrintableArea;

            if (printAction == PrintAction.PrintToPreview)
                graphics.TranslateTransform(printableArea.X, printableArea.Y);

            int availableWidth = (int)Math.Floor(document.OriginAtMargins
                ? marginBounds.Width
                : (e.PageSettings.Landscape
                    ? printableArea.Height
                    : printableArea.Width));
            int availableHeight = (int)Math.Floor(document.OriginAtMargins
                ? marginBounds.Height
                : (e.PageSettings.Landscape
                    ? printableArea.Width
                    : printableArea.Height));

            area = new Rectangle(1, 1, availableWidth - 1, availableHeight - 1);
            if (printAction == PrintAction.PrintToPreview)
            {
                //e.Graphics.DrawRectangle(areaPen, area);
                // drawLines(area, e.Graphics, 9);
            }

            PrintLayout(e);
        }
        Font contentFont = new Font("Times New Roman", 10, FontStyle.Regular);

        //int page = 1;
        SoldItem[] items;
        int index = 0;

        void PrintLayout(PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int yStart = area.Top;
            //using (var p = new POSEntities())
            //{
            //    if (items == null)
            //    {
            //        var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
            //        items = s.SoldItems.OrderBy(x => x.Product.Item.Name).ToArray();
            //    }

            Rectangle rName = new Rectangle();
            Rectangle rSerial = new Rectangle();
            Rectangle rQuantity = new Rectangle();
            Rectangle rPrice = new Rectangle();
            Rectangle rDiscount = new Rectangle();
            Rectangle rTotal = new Rectangle();

            //List<string> entries = new List<string>();
            while (index < datas.Count)
            {
                var i = datas[index];

                decimal total = (int)i[2] * ((decimal)i[3] - (decimal)i[4]);
                //entries.Add(i.Product.Item.Name);
                //entries.Add(i.SerialNumber);
                //entries.Add(i.Quantity.ToString());
                //entries.Add(i.ItemPrice.ToString());
                //entries.Add(i.Discount.ToString());
                //entries.Add(total.ToString());

                var max = i.Items.Select(x => (int)g.MeasureString(x?.ToString()??string.Empty, contentFont, area.Width * 3 / 9).Height).Max();

                if (yStart + max >= area.Height)
                {
                    e.HasMorePages = true;
                    numericUpDown1.Maximum = numericUpDown1.Value + 1;
                    return;
                }
                else
                    e.HasMorePages = false;

                rName.X = area.Left;
                rName.Width = area.Width * 3 / 9;
                rName.Y = yStart;
                rName.Height = max;

                rSerial.X = rName.Right;
                rSerial.Width = area.Width * 2 / 9;
                rSerial.Y = yStart;
                rSerial.Height = max;

                rQuantity.X = rSerial.Right;
                rQuantity.Width = area.Width * 1 / 9;
                rQuantity.Y = yStart;
                rQuantity.Height = max;

                rPrice.X = rQuantity.Right;
                rPrice.Width = area.Width * 1 / 9;
                rPrice.Y = yStart;
                rPrice.Height = max;

                rDiscount.X = rPrice.Right;
                rDiscount.Width = area.Width * 1 / 9;
                rDiscount.Y = yStart;
                rDiscount.Height = max;

                rTotal.X = rDiscount.Right;
                rTotal.Width = area.Width * 1 / 9;
                rTotal.Y = yStart;
                rTotal.Height = max;

                g.DrawRectangle(gridPen, rName);
                g.DrawRectangle(gridPen, rSerial);
                g.DrawRectangle(gridPen, rQuantity);
                g.DrawRectangle(gridPen, rPrice);
                g.DrawRectangle(gridPen, rDiscount);
                g.DrawRectangle(gridPen, rTotal);

                g.DrawString(i[0].ToString(), contentFont, Brushes.Black, rName);
                g.DrawString(i[1]?.ToString(), contentFont, Brushes.Black, rSerial);
                g.DrawString(i[2].ToString().ToString(), contentFont, Brushes.Black, rQuantity);
                g.DrawString(i[3].ToString(), contentFont, Brushes.Black, rPrice);
                g.DrawString(i[4].ToString(), contentFont, Brushes.Black, rDiscount);
                g.DrawString(total.ToString(), contentFont, Brushes.Black, rTotal);

                yStart = rName.Bottom;

                //entries.RemoveRange(0, entries.Count);
                index++;
            }
            //}

            label1.Text = "Page: " + (int)numericUpDown1.Value + " of " + ((int)numericUpDown1.Maximum).ToString();
            //items = null;
            index = 0;
        }

        void drawLines(RectangleF p, Graphics g, int xDivision)
        {
            Pen linePen = new Pen(Brushes.Blue);
            for (int i = 1; i < xDivision; i++)
            {
                int x = ((int)p.Width / xDivision) * i;
                Point start = new Point(x, 0);
                Point end = new Point(x, (int)p.Height);

                g.DrawLine(linePen, start, end);
            }
        }

        private void document_BeginPrint(object sender, PrintEventArgs e)
        {
            printAction = e.PrintAction;
        }

        List<DataListHolder> datas = new List<DataListHolder>();
        private void SaleReprint_Load(object sender, EventArgs e)
        {
            using (var p = new POSEntities())
            {
                var s = p.Sales.FirstOrDefault(x => x.Id == sale.Id);
                datas = s.SoldItems.OrderBy(x => x.Product.Item.Name).Select(y => new DataListHolder(y.Product.Item.Name, y.SerialNumber, y.Quantity, y.ItemPrice, y.Discount??0)).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            document.Print();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            printPreviewControl1.StartPage = (int)numericUpDown1.Value - 1;

            label1.Text = "Page: " + (int)numericUpDown1.Value + " of " + ((int)numericUpDown1.Maximum).ToString();
        }
    }
}
