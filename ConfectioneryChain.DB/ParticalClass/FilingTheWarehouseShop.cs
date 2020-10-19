using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class FilingTheWarehouseShop : General
    {
        public override string ToString()
        {
            return $"[{Shop.ToString()}-{GoodsID}]";
        }
        public override General CreateNew()
        {
            var general = new FilingTheWarehouseShop();
            general.ShopID = -1;
            general.GoodsID = -1;
            general.Count = -1;
            general.PriceBuy = null;
            general.PriceSell = null;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is FilingTheWarehouseShop general)
            {
                ShopID = general.ShopID;
                GoodsID = general.GoodsID;
                Count = general.Count;
                PriceBuy = general.PriceBuy;
                PriceSell = general.PriceSell;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is FilingTheWarehouseShop general)
            {
                Fill(general);

            }


        }
    }
}
