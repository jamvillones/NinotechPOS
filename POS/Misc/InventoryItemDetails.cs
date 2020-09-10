using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InventoryItemDetailArgs : EventArgs
{
    public InventoryItemDetailArgs(int id, int quantity, decimal price, decimal discount)
    {
        Id = id;
        Quantity = quantity;
        Price = price;
        Discount = discount;
    }

    public int Id { get; private set; }
    public decimal Price { get; private set; }
    public decimal Discount { get; private set; }
    public int Quantity { get; private set; }
}

