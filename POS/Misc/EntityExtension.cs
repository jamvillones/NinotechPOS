using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Misc
{
    static class EntityExtension
    {
        public static decimal GetSaleTotalPrice(this Sale sale)
        {
            decimal total = 0;
            using (var p = new POSEntities())
            {
                total = p.Sales.FirstOrDefault(x => x.Id == sale.Id).SoldItems.Sum(y => y.Quantity * (y.ItemPrice - y.Discount ?? 0));
            }
            return total;

        }
    }
}
