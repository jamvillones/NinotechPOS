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
        StringFormat farFormat = new StringFormat() { Alignment = StringAlignment.Far };
        StringFormat centerFormat = new StringFormat() { Alignment = StringAlignment.Center };
        Font contentFont = new Font("Times New Roman", 10, FontStyle.Regular);
        Font columnFont = new Font("Times New Roman", 10, FontStyle.Bold);
        int index = 0;
        int pageCount = 1;

        void PrintLayout(PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle pageNumberRect = new Rectangle(0, 0, area.Width, 20);
            farFormat.Alignment = StringAlignment.Far;
            e.Graphics.DrawString("Page: " + pageCount, contentFont, Brushes.Black, pageNumberRect, farFormat);
            int colHeight = (int)g.MeasureString("Item Name", contentFont).Height;

            Rectangle colRect = new Rectangle(area.Left, pageNumberRect.Bottom, area.Width * 3 / 9, colHeight);
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Item Name", columnFont, Brushes.Black, colRect,centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 2 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Serial Number", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Quantity", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Price", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Discount", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Total", columnFont, Brushes.Black, colRect, centerFormat);

            int yStart = colRect.Bottom;
            Rectangle stringHolderRect = new Rectangle();

            while (index < datas.Count)
            {
                var i = datas[index];

                decimal total = (int)i[2] * ((decimal)i[3] - (decimal)i[4]);

                var max = i.Items.Select(x => (int)g.MeasureString(x?.ToString() ?? string.Empty, contentFont, area.Width * 3 / 9).Height).Max();

                if (yStart + max > area.Height)
                {
                    e.HasMorePages = true;
                    pageCount++;
                    return;
                }
                else
                    e.HasMorePages = false;

                stringHolderRect.X = area.Left;
                stringHolderRect.Width = area.Width * 3 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[0].ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 2 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[1]?.ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;
                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[2].ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(string.Format("₱ {0:n}", (decimal)i[3]), contentFont, Brushes.Black, stringHolderRect, farFormat);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(string.Format("₱ {0:n}", (decimal)i[4]), contentFont, Brushes.Black, stringHolderRect, farFormat);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(string.Format("₱ {0:n}", total), contentFont, Brushes.Black, stringHolderRect, farFormat);

                yStart = stringHolderRect.Bottom;
                index++;
            }

            numericUpDown1.Maximum = pageCount;
            label1.Text = "Page: " + (int)numericUpDown1.Value + " of " + ((int)numericUpDown1.Maximum).ToString();
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
                datas = s.SoldItems.OrderBy(x => x.Product.Item.Name).Select(y => new DataListHolder(y.Product.Item.Name, y.SerialNumber, y.Quantity, y.ItemPrice, y.Discount ?? 0)).ToList();
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
