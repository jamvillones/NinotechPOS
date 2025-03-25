using POS.Misc;
using System;
using System.Linq;

namespace POS
{
    partial class Item
    {
        public int QuantityInInventory => this.Products
            .Select(a => a.InventoryItems
                .Select(b => b.Quantity)
                .DefaultIfEmpty(0)
                .Sum())
            .Sum();

        public bool InCriticalQuantity
        {
            get
            {
                if (!IsEnumerable || this.CriticalQuantity == null) return false;

                var totalQty = this.QuantityInInventory;

                if (totalQty == 0)
                    return false;

                return (totalQty <= this.CriticalQuantity);
            }
        }

        public bool IsEnumerable => /*Type.Equals(ItemType.Quantifiable.ToString(), StringComparison.OrdinalIgnoreCase);*/
            this.Type == ItemType.Quantifiable.ToString();
    }

    partial class Product
    {
        public override string ToString() => $"{Item.Name} - {Supplier.Name}";
    }

    partial class Sale
    {
        /// <summary>
        /// grand total of the sale
        /// </summary>
        public decimal AmountDue => Total - Discount;
        public decimal Total => SoldItems.Sum(x => x.Quantity * (x.ItemPrice - x.Discount));

        /// <summary>
        /// used as the actual gained money
        /// </summary>
        public decimal TotalGained => AmountRecieved > AmountDue ? AmountDue : AmountRecieved;
        /// <summary>
        /// remaining to be paid
        /// </summary>
        public decimal Remaining => (AmountDue - AmountRecieved) < 0 ? 0 : AmountDue - AmountRecieved;
        /// <summary>
        /// is it fully paid?
        /// </summary>
        public bool FullyPaid => Remaining == 0;
    }

    partial class Supplier
    {
        public override string ToString() => Name + (string.IsNullOrWhiteSpace(ContactDetails) ? "" : " - " + ContactDetails);
    }

    partial class Customer
    {
        public override string ToString() => Name +
            (string.IsNullOrWhiteSpace(ContactDetails) ? "" : " - " + ContactDetails) +
            (string.IsNullOrWhiteSpace(Address) ? "" : " - " + Address);
    }

    partial class Login
    {
        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? Username : Name;
    }

    public static class ContextManipulationMethods
    {

        /// <summary>
        /// run this to set the isSerialRequired Property based on stockin entries with serial
        /// </summary>
        public static void SetIsSerialRequired()
        {
            using (var context = new POSEntities())
            {
                var items = context.Items.AsQueryable().Where(i => i.Products.Any(p => p.StockinHistories.Any(st => st.SerialNumber != null))).ToList();

                foreach (var i in items)
                    i.IsSerialRequired = true;

                context.SaveChanges();
            }
        }
    }
}
