using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class PrintInventory : Form
    {
        public PrintInventory()
        {
            InitializeComponent();
        }

        private void PrintInventory_Load(object sender, EventArgs e)
        {
            // flowLayoutPanel1.Enabled = false;
            worker.RunWorkerAsync();

            using (var p = new POSEntities())
            {
                //var s = p.InventoryItems.ToArray();
                datas = p.InventoryItems.ToArray().OrderBy(x => x.Product.Item.Barcode).Select(y => new DataListHolder(y.Product.Item.Barcode, y.SerialNumber, y.Product.Item.Name, y.Quantity)).ToList();
            }
        }

        Rectangle area;
        PrintAction printAction;
        Pen areaPen = new Pen(Brushes.Red);
        Pen gridPen = new Pen(Brushes.Gray);
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            RectangleF marginBounds = e.MarginBounds;
            RectangleF printableArea = e.PageSettings.PrintableArea;

            if (printAction == PrintAction.PrintToPreview)
                graphics.TranslateTransform(printableArea.X, printableArea.Y);

            int availableWidth = (int)Math.Floor(printDocument.OriginAtMargins
                ? marginBounds.Width
                : (e.PageSettings.Landscape
                    ? printableArea.Height
                    : printableArea.Width));
            int availableHeight = (int)Math.Floor(printDocument.OriginAtMargins
                ? marginBounds.Height
                : (e.PageSettings.Landscape
                    ? printableArea.Width
                    : printableArea.Height));

            area = new Rectangle(1, 1, availableWidth - 1, availableHeight - 1);
            if (printAction == PrintAction.PrintToPreview)
            {
                //e.Graphics.DrawRectangle(areaPen, area);
                //drawLines(area, e.Graphics, 9);
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

            Rectangle colRect = new Rectangle(area.Left, pageNumberRect.Bottom, area.Width * 1 / 9, colHeight);
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Barcode", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 2 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Serial Number", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 4 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Name", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("Quantity", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("On Hand", columnFont, Brushes.Black, colRect, centerFormat);

            int yStart = colRect.Bottom;
            Rectangle stringHolderRect = new Rectangle();

            while (index < datas.Count)
            {
                var i = datas[index];

                //decimal total = (int)i[2] * ((decimal)i[3] - (decimal)i[4]);

                var max = i.Items.Select(x => (int)g.MeasureString(x?.ToString() ?? string.Empty, contentFont, area.Width * 4 / 9).Height).Max();

                if (yStart + max > area.Height)
                {
                    e.HasMorePages = true;
                    pageCount++;
                    return;
                }
                else
                    e.HasMorePages = false;

                stringHolderRect.X = area.Left;
                stringHolderRect.Width = area.Width * 1 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[0].ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 2 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[1]?.ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 4 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;
                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[2].ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[3].ToString(), contentFont, Brushes.Black, stringHolderRect, farFormat);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString("", contentFont, Brushes.Black, stringHolderRect, farFormat);

                yStart = stringHolderRect.Bottom;
                index++;
            }

            numericUpDown1.Maximum = pageCount;
            //label1.Text = "Page: " + (int)numericUpDown1.Value + " of " + ((int)numericUpDown1.Maximum).ToString();
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

        private void PrintInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                button2.PerformClick();
            }
            if (e.Alt)
            {
                if (e.KeyCode == Keys.Left)
                    if (printPreviewControl1.StartPage > 0)
                        printPreviewControl1.StartPage--;
                if (e.KeyCode == Keys.Right)
                    printPreviewControl1.StartPage++;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //foreach (var i in PrinterSettings.InstalledPrinters)
            //{
            //    comboBox1.Invoke((MethodInvoker)delegate { comboBox1.Items.Add(i); });
            //}
            var printers = PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
            comboBox1.Invoke((MethodInvoker)delegate { comboBox1.Items.AddRange(printers); });

            comboBox1.Invoke((MethodInvoker)delegate { comboBox1.Text = printDocument.PrinterSettings.PrinterName; });




        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //flowLayoutPanel1.Enabled = true;
        }

        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            printAction = e.PrintAction;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.PrinterSettings.Copies = (short)numericUpDown1.Value;

            printDocument.Print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            printDocument.PrinterSettings.PrinterName = comboBox1.Text;


            printPreviewControl1.StartPage = 0;
            pageCount = 1;

            printPreviewControl1.Document = printDocument;
        }
    }
}
