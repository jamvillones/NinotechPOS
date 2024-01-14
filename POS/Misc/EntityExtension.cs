using POS.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    partial class Item
    {
        public int QuantityInInventory => this.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();
        public bool InCriticalQuantity
        {
            get
            {
                if (this.Type != ItemType.Quantifiable.ToString() || this.CriticalQuantity == null) return false;

                var q = this.QuantityInInventory;

                if (q == 0)
                    return false;

                return (q <= this.CriticalQuantity);
            }
        }
    }

    partial class Sale
    {
        /// <summary>
        /// grand total of the sale
        /// </summary>
        public decimal Total => SoldItems.Sum(x => x.Quantity * (x.ItemPrice - x.Discount));

        /// <summary>
        /// used as the actual gained money
        /// </summary>
        public decimal TotalGained => AmountRecieved > Total ? Total : AmountRecieved;
        /// <summary>
        /// remaining to be paid
        /// </summary>
        public decimal Remaining => (Total - AmountRecieved) < 0 ? 0 : Total - AmountRecieved;
        /// <summary>
        /// is it fully paid?
        /// </summary>
        public bool FullyPaid => Remaining == 0;
    }

    partial class Supplier
    {
        public override string ToString() => Name;
    }
}
