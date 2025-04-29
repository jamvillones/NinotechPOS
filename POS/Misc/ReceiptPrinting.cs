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
        static int currentPage = 1;
        static int currentIndex = 0;
        public static void FormatReceipt(this PrintPageEventArgs e, PrintAction printAction, ReceiptDetails details)
        {
            //var settings = Properties.Settings.Default;
            var settings = ReceiptPrintingConfigurations.ReceiptPrintingConfig;

            using (Graphics graphics = e.Graphics)
            using (Pen bluePen = new Pen(Brushes.Black) { Width = 0.5f, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
            using (Font font = new Font("MS Gothic", 8, FontStyle.Regular))
            using (Font titleFont = new Font("MS Gothic", 8, FontStyle.Bold))
            using (Font serialFont = new Font("MS Gothic", 8, FontStyle.Bold))
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
                int currentY = area.Top;

                if (currentPage == 1)
                {
                    string Header = settings.Header;
                    var headerSize = e.Graphics.MeasureString(Header, titleFont, area.Width);
                    var headerRect = new Rectangle(0, 0, area.Width, (int)Math.Floor(headerSize.Height));

                    if (Header != string.Empty)
                        e.Graphics.DrawString(Header, titleFont, Brushes.Black, headerRect, centerAlignment);

                    string titleString = settings.Details;

                    var titleSize = e.Graphics.MeasureString(titleString, titleFont, e.PageBounds.Width);
                    var titleRect = new Rectangle(0, headerRect.Bottom, area.Width, (int)titleSize.Height);

                    e.Graphics.DrawString(titleString, titleFont, Brushes.Black, titleRect, centerAlignment);

                    string first = "Control Number:\n" +
                                   "Customer Name:\n" +
                                   "Transact By:\n" +
                                   "Issued On:";

                    var firstSize = e.Graphics.MeasureString(first, font, e.PageBounds.Width);
                    var firstRect = new Rectangle(0, titleRect.Bottom + 10, (int)firstSize.Width + 1, (int)firstSize.Height);

                    e.Graphics.DrawString(first, font, Brushes.Black, firstRect, leftFormat);

                    string second = details.ControlNumber + "\n" +
                                    details.CustomerName + "\n" +
                                    details.TransactBy + "\n" +
                                    details.IssuedOn.ToString("MMMM d, yyyy hh:mm tt");

                    var secondSize = e.Graphics.MeasureString(second, titleFont, e.PageBounds.Width);
                    var secondRect = new Rectangle(firstRect.Right + 10, firstRect.Top, (int)secondSize.Width + 1, (int)firstSize.Height);

                    e.Graphics.DrawString(second, titleFont, Brushes.Black, secondRect, leftFormat);



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


                    currentY = colRect.Bottom + 2;
                }

                var contentsRect = new Rectangle();

                for (int ii = currentIndex; ii < details.Items.Count; ii++)
                {
                    var i = details.Items[ii];

                    var nameSize = graphics.MeasureString(i.Name, titleFont, area.Width);
                    var serialSize = i.Serial is null ? SizeF.Empty : graphics.MeasureString("► " + i.Serial, serialFont, area.Width);

                    var length = i.BiggestLength(graphics, area.Width / 4, titleFont);

                    if (currentY + nameSize.Height + serialSize.Height + length + 2 > area.Height)
                    {
                        currentPage++;
                        e.HasMorePages = true;
                        return;
                    }
                    else
                        e.HasMorePages = false;


                    contentsRect.X = area.Left;
                    contentsRect.Y = currentY;
                    contentsRect.Width = area.Width;
                    contentsRect.Height = (int)nameSize.Height;
                    graphics.DrawString(i.Name, titleFont, Brushes.Black, contentsRect);
                    currentY += contentsRect.Height;

                    if (i.Serial != null)
                    {
                        contentsRect.X = area.Left;
                        contentsRect.Y = currentY;
                        contentsRect.Width = area.Width;
                        contentsRect.Height = (int)serialSize.Height;
                        graphics.DrawString("► " + i.Serial, serialFont, Brushes.Black, contentsRect);
                        currentY += contentsRect.Height;
                    }

                    contentsRect.X = area.Left;
                    contentsRect.Y = currentY;
                    contentsRect.Width = area.Width / 4;
                    contentsRect.Height = length;


                    graphics.DrawString(i.Quantity.ToString() + "x", font, Brushes.Black, contentsRect, centerAlignment);

                    contentsRect.X = area.Width / 4;
                    graphics.DrawString(i.Price.ToCurrency(), font, Brushes.Black, contentsRect, farAlignment);

                    contentsRect.X = (area.Width / 4) * 2;
                    graphics.DrawString("-" + i.Discount.ToCurrency(), font, Brushes.Black, contentsRect, farAlignment);

                    contentsRect.X = (area.Width / 4) * 3;
                    contentsRect.Width = area.Width - contentsRect.X;

                    graphics.DrawString(i.Total.ToCurrency(), font, Brushes.Black, contentsRect, farAlignment);

                    currentY += contentsRect.Height + 5;
                    currentIndex++;
                }

                graphics.DrawLine(bluePen, new Point(0, contentsRect.Bottom), new Point(area.Width, contentsRect.Bottom));

                string b2 = details.Discount.ToCurrency() + "\n" +
                            details.GrandTotal.ToCurrency() + "\n" +
                            details.Tendered.ToCurrency() + "\n" +
                            details.Change.ToCurrency();

                string b1 = "Discount: \n" +
                         "Grand Total: \n" +
                            "Tendered: \n" +
                              "Change: ";

                currentY += 10;
                var b2Size = graphics.MeasureString(b2, titleFont, area.Width, farAlignment);
                var b2Rect = new Rectangle(area.Width - (int)Math.Floor(b2Size.Width),
                                           contentsRect.Bottom + 10,
                                           (int)Math.Ceiling(b2Size.Width),
                                           (int)b2Size.Height + 1);

                var summarySize = graphics.MeasureString(b1, font, area.Width);
                var summaryRect = new Rectangle(b2Rect.Left - (int)summarySize.Width - 10, currentY, (int)summarySize.Width + 1, (int)summarySize.Height);

                currentY += summaryRect.Height + 10;

                string disclaimer = settings.Footer;
                var discSize = disclaimer is null ? SizeF.Empty : graphics.MeasureString(disclaimer, font, area.Width);
                var discRect = new Rectangle(0, currentY, area.Width, (int)Math.Floor(discSize.Height));

                currentY += discRect.Height;

                if (currentY > area.Height)
                {
                    currentPage++;
                    e.HasMorePages = true;
                    return;
                }
                else
                    e.HasMorePages = false;

                graphics.DrawString(b2, titleFont, Brushes.Black, b2Rect, farAlignment);
                graphics.DrawString(b1, font, Brushes.Black, summaryRect, farAlignment);

                if (disclaimer != null)
                    graphics.DrawString(disclaimer, font, Brushes.Black, discRect, centerAlignment);

                //currentY += b2Rect.Height;

                currentIndex = 0;
                currentPage = 1;
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
        public DateTime IssuedOn { get; set; }

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
                return Helper.LongestWord(g, f, width, Quantity.ToString() + "x", Price.ToCurrency(), Discount.ToCurrency(), Total.ToCurrency());
            }
        }

        public List<ItemDetails> Items { get; } = new List<ItemDetails>();

        public decimal Tendered { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal GrandTotal => Items.Sum(x => x.Total) - Discount;
        public decimal Change => Tendered - GrandTotal;

        public void AddItem(string name, string serial, int quantity, decimal price, decimal discount)
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
