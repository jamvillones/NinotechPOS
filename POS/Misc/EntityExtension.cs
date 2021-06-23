using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    //static class EntityExtension
    //{
    //    public static decimal GetSaleTotalPrice(this Sale sale)
    //    {
    //        decimal total = 0;
    //        using (var p = new POSEntities())
    //        {
    //            total = p.Sales.FirstOrDefault(x => x.Id == sale.Id).SoldItems.Sum(y => y.Quantity * (y.ItemPrice - y.Discount ?? 0));
    //        }
    //        return total;

    //    }

    //}
    partial class Item
    {
        public int QuantityInInventory => this.Products.Select(a => a.InventoryItems.Select(b => b.Quantity).DefaultIfEmpty(0).Sum()).Sum();
    }

    partial class Sale
    {
        public decimal Total => this.SoldItems.Select(x => x.Quantity * (x.ItemPrice - x.Discount ?? 0)).DefaultIfEmpty(0).Sum();
        public decimal Remaining
        {
            get
            {
                decimal r = Total - AmountRecieved ?? 0;
                return r < 0 ? 0 : r;
            }
        }
        public bool FullyPaid => Remaining == 0;
    }
}
