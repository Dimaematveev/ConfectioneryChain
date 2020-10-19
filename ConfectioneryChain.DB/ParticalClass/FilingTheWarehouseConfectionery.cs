using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class FilingTheWarehouseConfectionery : General
    {
        public override string ToString()
        {
            return $"[{ConfectioneryID}-{GoodsID}]";
        }
        public override General CreateNew()
        {
            var general= new FilingTheWarehouseConfectionery();
            general.ConfectioneryID = -1;
            general.GoodsID = -1;
            general.Count = -1;
            general.Price = -1;
            general.ShelfLife = new DateTime();
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is FilingTheWarehouseConfectionery general)
            {
                ConfectioneryID = general.ConfectioneryID;
                GoodsID = general.GoodsID;
                Count = general.Count;
                Price = general.Price;
                ShelfLife = general.ShelfLife;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is FilingTheWarehouseConfectionery general)
            {
                Fill(general);

            }


        }
    }
}
