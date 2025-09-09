//using VS2017POS.EntitiyFolder;
namespace POS.Forms
{
    public struct ItemInfoHolder
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string Supplier { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        private int q;
        public int Quantity
        {
            get
            {
                return Serial == null ? q : 1;
            }
            set { q = value; }
        }
        public decimal TotalPrice { get { return (Quantity * (SellingPrice - Discount)); } }

        public string Reason { get; set; }
    }
}
