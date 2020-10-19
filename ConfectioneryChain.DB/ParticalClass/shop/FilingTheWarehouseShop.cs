using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class FilingTheWarehouseShop : General
    {
        public override string ToString()
        {
            return $"[{Shop}-{GoodsID}]";
        }
        public override General CreateNew()
        {
            var general = new FilingTheWarehouseShop
            {
                ShopID = -1,
                GoodsID = -1,
                Count = -1,
                PriceBuy = null,
                PriceSell = null
            };
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
