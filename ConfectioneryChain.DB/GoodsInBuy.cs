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
    
    public partial class GoodsInBuy
    {
        public int IDGoodsInBuy { get; set; }
        public int BuyGoodsID { get; set; }
        public int ShopID { get; set; }
        public int GoodsID { get; set; }
        public int ConfectioneryID { get; set; }
        public decimal Count { get; set; }
    
        public virtual FilingTheWarehouseShop FilingTheWarehouseShop { get; set; }
    }
}
