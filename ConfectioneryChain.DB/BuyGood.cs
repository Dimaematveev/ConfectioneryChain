//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfectioneryChain.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuyGood
    {
        public int IDBuyGoods { get; set; }
        public int ConfectioneryID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual DistributionOfEmployee DistributionOfEmployee { get; set; }
    }
}
