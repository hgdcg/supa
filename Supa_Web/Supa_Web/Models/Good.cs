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
    
    public partial class Good
    {
        public Good()
        {
            this.Inventories = new HashSet<Inventory>();
        }
    
        public string GoodID { get; set; }
        public string Class3 { get; set; }
    
        public virtual Types3 Types3 { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
