namespace POS
{
    public class NewCartDetails
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public decimal GrandTotal => Quantity * (Price - Discount);
    }
}
