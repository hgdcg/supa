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
    
    public partial class Types2
    {
        public Types2()
        {
            this.Types3 = new HashSet<Types3>();
        }
    
        public string Class2 { get; set; }
        public string Class1 { get; set; }
    
        public virtual Types1 Types1 { get; set; }
        public virtual ICollection<Types3> Types3 { get; set; }
    }
}
