//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockinHistory
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Supplier { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string SerialNumber { get; set; }
        public string LoginUsername { get; set; }
        public Nullable<int> ProductId { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
