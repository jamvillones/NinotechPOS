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

            if (p.Supplier != null)
                Supplier = new Supplier() { Id = p.Supplier.Id, Name = p.Supplier.Name, ContactDetails = p.Supplier.ContactDetails };

            Cost = p.Cost;
        }

        public int Id { get; set; } = 0;
        public Supplier Supplier { get; set; }
        public decimal Cost { get; set; } = 0;

        public Product ToProduct => new Product() { Id = Id, SupplierId = Supplier?.Id, Cost = Cost };
    }
}
