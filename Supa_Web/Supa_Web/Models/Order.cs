//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supa_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int GoodID { get; set; }
        public int MarketID { get; set; }
        public int UserId { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<bool> IsPayed { get; set; }
    
        public virtual Inventory Inventory { get; set; }
        public virtual User User { get; set; }
    }
}
