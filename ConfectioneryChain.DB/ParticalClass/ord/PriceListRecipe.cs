using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class PriceListRecipe : General
    {
        public override string ToString()
        {
            return $"[{PriceList.ToString()}-{Recipe.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new PriceListRecipe();
            general.PriceListID = -1;
            general.RecipeID = -1;
            general.TimeForPreparing = new TimeSpan(0,15,0);
            general.Price = -1;
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
