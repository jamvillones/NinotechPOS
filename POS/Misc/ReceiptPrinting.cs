using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace POS.Misc
{
    public static class ReceiptPrinting
    {

        public static void FormatReciept(this PrintPageEventArgs e, PrintAction printAction, ReceiptDetails details)
        {
            var settings = Properties.Settings.Default;

            using (Graphics graphics = e.Graphics)
            using (Pen bluePen = new Pen(Brushes.Black) { Width = 0.5f, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
            using (Font font = new Font("MS Gothic", 8, FontStyle.Regular))
            using (Font titleFont = new Font("MS Gothic", 8, FontStyle.Bold))
            using (StringFormat centerAlignment = new StringFormat() { Alignment = StringAlignment.Center })
            using (StringFormat leftFormat = new StringFormat() { Alignment = StringAlignment.Near })
            using (StringFormat farAlignment = new StringFormat() { Alignment = StringAlignment.Far })
            {
                RectangleF printableArea = e.PageSettings.PrintableArea;

                if (printAction == PrintAction.PrintToPreview)
                    graphics.TranslateTransform(printableArea.X, printableArea.Y);

                int availableWidth = (int)Math.Floor(printableArea.Width);
                int availableHeight = (int)Math.Floor(printableArea.Height);

                var area = new Rectangle(0, 0, availableWidth - 1, availableHeight - 1);

                string Header = settings.HeaderText;
                var headerSize = e.Graphics.MeasureString(Header, titleFont, area.Width);
                var headerRect = new Rectangle(0, 0, area.Width, (int)Math.Floor(headerSize.Height));

                if (Header != string.Empty)
                    e.Graphics.DrawString(Header, titleFont, Brushes.Black, headerRect, centerAlignment);

                string titleString = settings.DetailsText;

                var titleSize = e.Graphics.MeasureString(titleString, titleFont, e.PageBounds.Width);
                var titelRect = new Rectangle(0, headerRect.Bottom, area.Width, (int)titleSize.Height);

                e.Graphics.DrawString(titleString, titleFont, Brushes.Black, titelRect, centerAlignment);

                string first = "Control Number:\n" +
                               "Customer Name:\n" +
                               "Transact By:\n" +
                               "Date/Time:";

                var firstSize = e.Graphics.MeasureString(first, font, e.PageBounds.Width);
                var firstRect = new Rectangle(0, titelRect.Bottom + 10, (int)firstSize.Width + 1, (int)firstSize.Height);

                e.Graphics.DrawString(first, font, Brushes.Black, firstRect, leftFormat);

                string second = details.ControlNumber + "\n" +
                                details.CustomerName + "\n" +
                                details.TransactBy + "\n" +
                                DateTime.Now.ToString("MMMM d, yyyy hh:mm tt");

                var secondSize = e.Graphics.MeasureString(second, titleFont, e.PageBounds.Width);
                var secondRect = new Rectangle(firstRect.Right + 10, firstRect.Top, (int)secondSize.Width + 1, (int)firstSize.Height);

                e.Graphics.DrawString(second, titleFont, Brushes.Black, secondRect, leftFormat);

                var contentsRect = new Rectangle();


                var colSize = graphics.MeasureString("Item Name / Serial", font);

                var colRect = new Rectangle(0,
                                            secondRect.Bottom + 10,
                                            area.Width,
                                            (int)Math.Ceiling(colSize.Height));

                //graphics.DrawRectangle(bluePen, colRect);
                graphics.DrawLine(bluePen, new Point(0, colRect.Top), new Point(area.Width, colRect.Top));
                graphics.DrawString("Item Name: / Serial", font, Brushes.Black, colRect);

                colRect.Y = colRect.Bottom;

                colRect.Width = area.Width / 4;
                //graphics.DrawRectangle(bluePen, colRect);
                graphics.DrawString("Qty:", font, Brushes.Black, colRect);

                colRect.X = area.Width / 4;
                //graphics.DrawRectangle(bluePen, colRect);
                graphics.DrawString("Price:", font, Brushes.Black, colRect, farAlignment);

                colRect.X = (area.Width / 4) * 2;
                //graphics.DrawRectangle(bluePen, colRect);
                graphics.DrawString("Discount:", font, Brushes.Black, colRect, farAlignment);

                colRect.X = (area.Width / 4) * 3;
                colRect.Width = area.Width - colRect.X;

                //graphics.DrawRectangle(bluePen, colRect);
                graphics.DrawString("Total:", font, Brushes.Black, colRect, farAlignment);
                graphics.DrawLine(bluePen, new Point(0, colRect.Bottom), new Point(area.Width, colRect.Bottom));


                int currentY = colRect.Bottom + 2;
                foreach (var i in details.Items)
                {
                    var size = graphics.MeasureString(i.Name + (i.Serial != null ? "\nSN: " + i.Serial : ""), titleFont, area.Width);

                    contentsRect.X = area.Left;
                    contentsRect.Y = currentY;
                    contentsRect.Width = area.Width;
                    contentsRect.Height = (int)size.Height;

                    //graphics.DrawRectangle(bluePen, contentsRect);
                    graphics.DrawString(i.Name + (i.Serial != null ? "\nSN: " + i.Serial : ""), titleFont, Brushes.Black, contentsRect);

                    currentY += (int)size.Height + 2;

                    var length = i.BiggestLength(graphics, area.Width / 4, titleFont);
                    contentsRect.X = 0;
                    contentsRect.Y = currentY;
                    contentsRect.Width = area.Width / 4;
                    contentsRect.Height = length;

                    //graphics.DrawRectangle(bluePen, contentsRect);
                    graphics.DrawString(i.Quantity.ToString() + "x", font, Brushes.Black, contentsRect, centerAlignment);

                    contentsRect.X = area.Width / 4;

                    //graphics.DrawRectangle(bluePen, contentsRect);
                    graphics.DrawString(i.Price.ToMoneyFormat(), font, Brushes.Black, contentsRect, farAlignment);

                    contentsRect.X = (area.Width / 4) * 2;

                    //graphics.DrawRectangle(bluePen, contentsRect);
                    graphics.DrawString("-" + i.Discount.ToMoneyFormat(), font, Brushes.Black, contentsRect, farAlignment);

                    contentsRect.X = (area.Width / 4) * 3;
                    contentsRect.Width = area.Width - contentsRect.X;

                    //Console.WriteLine(contentsRect.X + " , " + contentsRect.Width);

                    //graphics.DrawRectangle(bluePen, contentsRect);
                    graphics.DrawString(i.Total.ToMoneyFormat(), font, Brushes.Black, contentsRect, farAlignment);

                    currentY += length + 2;
                }
                graphics.DrawLine(bluePen, new Point(0, contentsRect.Bottom), new Point(area.Width, contentsRect.Bottom));

                string b2 = details.GrandTotal.ToMoneyFormat() + "\n" +
                            details.Tendered.ToMoneyFormat() + "\n" +
                            details.Change.ToMoneyFormat();

                var b2Size = graphics.MeasureString(b2, titleFont, area.Width, farAlignment);
                var b2Rect = new Rectangle(area.Width - (int)Math.Floor(b2Size.Width),
                                           contentsRect.Bottom + 10,
                                           (int)Math.Ceiling(b2Size.Width),
                                           (int)b2Size.Height + 1);

                graphics.DrawString(b2, titleFont, Brushes.Black, b2Rect, farAlignment);

                string b1 = "Grand Total: \n" +
                           "Tendered: \n" +
                           "Change: ";

                var summarySize = graphics.MeasureString(b1, font, area.Width);
                var summaryRect = new Rectangle(b2Rect.Left - (int)summarySize.Width - 10, contentsRect.Bottom + 10, (int)summarySize.Width + 1, (int)summarySize.Height);
                graphics.DrawString(b1, font, Brushes.Black, summaryRect, farAlignment);

                string disclaimer = "*THIS IS AN INTERNAL ORDER FORM ONLY.\nPLEASE ASK FOR SALES INVOICE FROM CASHIER.";
                var discSize = graphics.MeasureString(disclaimer, font, area.Width);
                var discRect = new Rectangle(0, summaryRect.Bottom + 10, area.Width, (int)Math.Floor(discSize.Height));
                graphics.DrawString(disclaimer, font, Brushes.Black, discRect, centerAlignment);

                //DrawRectangles(graphics, bluePen, firstRect, secondRect, b2Rect, summaryRect);       
            }
        }

        static void DrawRectangles(Graphics g, Pen p, params Rectangle[] rects)
        {
            foreach (var i in rects)
                g.DrawRectangle(p, i);
        }
    }

    public class ReceiptDetails
    {
        public string CustomerName { get; set; }
        public string ControlNumber { get; set; }
        public string TransactBy { get; set; }

        public class ItemDetails
        {
            public string Name { get; set; }
            public string Serial { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Discount { get; set; }
            public decimal Total => Quantity * (Price - Discount);

            public int BiggestLength(Graphics g, int width, Font f)
            {
                return Helper.LongestWord(g, f, width, Quantity.ToString() + "x", Price.ToMoneyFormat(), Discount.ToMoneyFormat(), Total.ToMoneyFormat());
            }
        }

        public List<ItemDetails> Items { get; } = new List<ItemDetails>();

        public decimal Tendered { get; set; }
        public decimal GrandTotal => Items.Sum(x => x.Total);
        public decimal Change => Tendered - GrandTotal;

        public void Additem(string name, string serial, int quantity, decimal price, decimal discount)
        {
            var i = new ItemDetails()
            {
                Name = name,
                Serial = serial,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };
            Items.Add(i);
        }

    }

}
