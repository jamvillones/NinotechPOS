namespace POS.Forms.ItemRegistration
{
    public class Cost_ViewModel
    {
        public Cost_ViewModel()
        {

        }

        public Cost_ViewModel(Product p)
        {
            Id = p.Id;
            Supplier = p.Supplier;
            Cost = p.Cost;
        }

        public int Id { get; set; } = 0;
        public Supplier Supplier { get; set; }
        public decimal Cost { get; set; } = 0;

        public Product ToProduct => new Product() { Id = Id, SupplierId = Supplier?.Id, Cost = Cost };
    }
}
