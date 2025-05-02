using POS.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Forms
{
    public partial class PrintInventory : Form
    {
        public PrintInventory()
        {
            InitializeComponent();

            pagesOption.SelectedIndex = 0;
            pagesOption.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            printPreview.MouseWheel += PrintInventory_MouseWheel;

            SetupAvailablePrinters();

            paperOptions.DisplayMember = nameof(PaperSize.PaperName);
            paperOptions.DataSource = Papers;
        }

        private void PrintInventory_MouseWheel(object sender, MouseEventArgs e)
        {
            PreviewZoom(e.Delta);
        }


        const double ZoomStep = 0.03; // adjust zoom increment
        void PreviewZoom(int delta)
        {
            if (delta > 0)
            {
                printPreview.Zoom += ZoomStep;
            }
            else if (delta < 0)
            {
                double newZoom = printPreview.Zoom;
                newZoom -= ZoomStep;
                newZoom = Math.Max(0.1, Math.Min(3, newZoom));
                printPreview.Zoom = newZoom;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = textBox2.Visible = pagesOption.SelectedIndex == 3;
        }

        private async void PrintInventory_Load(object sender, EventArgs e)
        {
            using (var context = POSEntities.Create())
            {
                var entries = await context.InventoryItems
                    .AsNoTracking()
                    .AsQueryable()
                    .Where(inv => inv.Product.Item.Type == ItemType.Quantifiable.ToString())
                    .OrderBy(x => x.Product.Item.Name)
                    .ToListAsync();

                Data = ProcessData(entries);
            }

            printerOption.SelectedItem = AvailablePrinters.FirstOrDefault(p => p.Equals(printDocument.PrinterSettings.PrinterName));
        }

        List<DataListHolder> ProcessData(List<InventoryItem> inventoryItems)
        {
            var groupedByName = inventoryItems.GroupBy(i => i.Product.Item.Name);
            var list = new List<DataListHolder>();

            foreach (var name in groupedByName)
            {
                var groupedItems = inventoryItems.Where(i => i.Product.Item.Name == name.Key);
                var inventoryItem = inventoryItems.First(inv => inv.Product.Item.Name == name.Key);
                int qty = groupedItems.Sum(i => i.Quantity);

                bool isFirstEntry = true;
                foreach (var item in groupedItems)
                {
                    list.Add(new DataListHolder(
                        isFirstEntry ? inventoryItem.Product.Item.Barcode : "",
                        item.SerialNumber,
                        isFirstEntry ? inventoryItem.Product.Item.Name : "",
                        isFirstEntry ? qty.ToString() : "",
                        isFirstEntry ? inventoryItem.Product.Cost.ToString() : "",
                        isFirstEntry ? (qty * inventoryItem.Product.Cost).ToString() : ""
                        ));

                    isFirstEntry = false;
                }
            }
            return list;
        }

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

            //if (printAction == PrintAction.PrintToPreview)
            //{
            //    e.Graphics.DrawRectangle(areaPen, area);
            //    drawLines(area, e.Graphics, 9);
            //}

            PrintLayout(e);
        }

        Rectangle area;
        PrintAction printAction;
        Pen areaPen = new Pen(Brushes.Red);
        Pen gridPen = new Pen(Brushes.Gray);
        StringFormat farFormat = new StringFormat() { Alignment = StringAlignment.Far };
        StringFormat centerFormat = new StringFormat() { Alignment = StringAlignment.Center };
        Font contentFont = new Font("Consolas", 9, FontStyle.Regular);
        Font columnFont = new Font("Consolas", 10, FontStyle.Bold);
        int index = 0;
        int pageIndex { get; set; } = 1;

        void PrintLayout(PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle pageNumberRect = new Rectangle(0, 0, area.Width, 40);
            farFormat.Alignment = StringAlignment.Far;
            g.DrawString("Date Printed: " + DateTime.Now.ToString("MMM-d-yyyy hh:mm tt").ToUpper() + "\nUser: " + UserManager.instance.CurrentLogin.ToString(), contentFont, Brushes.Black, pageNumberRect);
            g.DrawString("Page: " + pageIndex, contentFont, Brushes.Black, pageNumberRect, farFormat);

            int colHeight = (int)g.MeasureString("Test for column height", columnFont).Height;

            Rectangle colRect = new Rectangle(area.Left, pageNumberRect.Bottom, area.Width * 2 / 9, colHeight);
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("BARCODE", columnFont, Brushes.Black, colRect, centerFormat);


            colRect.X = colRect.Right;
            colRect.Width = area.Width * 3 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("NAME", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 2 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("SERIAL #", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("QTY", columnFont, Brushes.Black, colRect, centerFormat);

            colRect.X = colRect.Right;
            colRect.Width = area.Width * 1 / 9;
            g.DrawRectangle(gridPen, colRect);
            g.DrawString("ON HAND", columnFont, Brushes.Black, colRect, centerFormat);

            int yStart = colRect.Bottom;
            Rectangle stringHolderRect = new Rectangle();

            while (index < Data.Count)
            {
                var i = Data[index];

                List<int> heights = new List<int>
                {
                    (int)g.MeasureString(i.Items[0]?.ToString() ?? string.Empty, contentFont, area.Width * 2 / 9).Height,
                    (int)g.MeasureString(i.Items[1]?.ToString() ?? string.Empty, contentFont, area.Width * 2 / 9).Height,
                    (int)g.MeasureString(i.Items[2]?.ToString() ?? string.Empty, contentFont, area.Width * 3 / 9).Height
                };

                var max = heights.Max();

                if (yStart + max > area.Height)
                {
                    e.HasMorePages = true;
                    pageIndex++;
                    return;
                }
                else
                    e.HasMorePages = false;

                stringHolderRect.X = area.Left;
                stringHolderRect.Width = area.Width * 2 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[0]?.ToString() ?? "", contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 3 / 9;
                stringHolderRect.Y = yStart;
                stringHolderRect.Height = max;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[2].ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 2 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[1]?.ToString(), contentFont, Brushes.Black, stringHolderRect);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString(i[3].ToString(), contentFont, Brushes.Black, stringHolderRect, farFormat);

                //stringHolderRect.X = stringHolderRect.Right;
                //stringHolderRect.Width = area.Width * 1 / 9;

                //g.DrawRectangle(gridPen, stringHolderRect);
                //g.DrawString(i[4].ToString(), contentFont, Brushes.Black, stringHolderRect, farFormat);

                //stringHolderRect.X = stringHolderRect.Right;
                //stringHolderRect.Width = area.Width * 1 / 9;

                //g.DrawRectangle(gridPen, stringHolderRect);
                //g.DrawString(i[5].ToString(), contentFont, Brushes.Black, stringHolderRect, farFormat);

                stringHolderRect.X = stringHolderRect.Right;
                stringHolderRect.Width = area.Width * 1 / 9;

                g.DrawRectangle(gridPen, stringHolderRect);
                g.DrawString("", contentFont, Brushes.Black, stringHolderRect, farFormat);

                yStart = stringHolderRect.Bottom;
                index++;
            }

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
            printDocument.PrinterSettings.PrinterName = printerOption.Text;
        }

        List<DataListHolder> Data = new List<DataListHolder>();
        private void PrintInventory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                button2.PerformClick();
            }
        }

        private BindingList<string> AvailablePrinters { get; } = new BindingList<string>();
        private void SetupAvailablePrinters()
        {
            var printers = PrinterSettings.InstalledPrinters.Cast<string>().ToArray();

            foreach (var printer in printers)
                AvailablePrinters.Add(printer);

            printerOption.DataSource = AvailablePrinters;

            printerOption.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void printDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            printAction = e.PrintAction;
            pageIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument.DefaultPageSettings.PrinterSettings.Copies = (short)numericUpDown1.Value;
            printDocument.Print();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isPaperSizesResetting = true;

            Papers.Clear();

            foreach (PaperSize paperSize in printDocument.PrinterSettings.PaperSizes)
                Papers.Add(paperSize);

            isPaperSizesResetting = false;

            printDocument.PrinterSettings.PrinterName = printerOption.Text;
            printPreview.Document = printDocument;
        }

        private void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            textBox2.Text = $"{1} - {pageIndex}";
            printPreview.Rows = pageIndex;
        }

        BindingList<PaperSize> Papers { get; } = new BindingList<PaperSize>();

        bool isPaperSizesResetting = false;
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (isPaperSizesResetting)
                return;

            printDocument.DefaultPageSettings.PaperSize = (PaperSize)paperOptions.SelectedItem;
            printPreview.Document = printDocument;
        }
    }
}
