using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class GoodsInBuy : General
    {
        public override string ToString()
        {
            return $"[{IDGoodsInBuy}]";
        }
        public override General CreateNew()
        {
            var general = new GoodsInBuy
            {
                IDGoodsInBuy = -1,
                BuyGoodsID = -1,
                ShopID = -1,
                GoodsID = -1,
                ConfectioneryID = -1,
                Count = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is GoodsInBuy general)
            {
                BuyGoodsID = general.BuyGoodsID;
                ShopID = general.ShopID;
                GoodsID = general.GoodsID;
                ConfectioneryID = general.ConfectioneryID;
                Count = general.Count;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is GoodsInBuy general)
            {
                Fill(general);
                IDGoodsInBuy = general.IDGoodsInBuy;
            }


        }
    }
}
