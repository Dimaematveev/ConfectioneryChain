using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class PriceListRecipe : General
    {
        public override string ToString()
        {
            return $"[{PriceList}-{Recipe}]";
        }
        public override General CreateNew()
        {
            var general = new PriceListRecipe
            {
                PriceListID = -1,
                RecipeID = -1,
                TimeForPreparing = new TimeSpan(0, 15, 0),
                Price = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is PriceListRecipe general)
            {
                PriceListID = general.PriceListID;
                RecipeID = general.RecipeID;
                TimeForPreparing = general.TimeForPreparing;
                Price = general.Price;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is PriceListRecipe general)
            {
                Fill(general);

            }


        }
    }
}
