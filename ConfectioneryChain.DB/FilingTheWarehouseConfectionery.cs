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
    
    public partial class FilingTheWarehouseConfectionery
    {
        public int ConfectioneryID { get; set; }
        public int GoodsID { get; set; }
        public decimal Count { get; set; }
        public decimal Price { get; set; }
        public System.DateTime ShelfLife { get; set; }
    
        public virtual Confectionery Confectionery { get; set; }

        public override string ToString()
        {
            return $"[{ConfectioneryID}-{GoodsID}]";
        }
    }
}
