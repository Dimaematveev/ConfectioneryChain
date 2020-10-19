using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ToppingInRecipe : General
    {
        public override string ToString()
        {
            return $"[{Recipe}-{Good}]";
        }
        public override General CreateNew()
        {
            var general = new ToppingInRecipe
            {
                RecipeID = -1,
                GoodsID = -1,
                PercentageOfInfluenceOnTaste = -1,
                Count = -1,
                MaxCount = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is ToppingInRecipe general)
            {
                RecipeID = general.RecipeID;
                GoodsID = general.GoodsID;
                PercentageOfInfluenceOnTaste = general.PercentageOfInfluenceOnTaste;
                Count = general.Count;
                MaxCount = general.MaxCount;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is ToppingInRecipe general)
            {
                Fill(general);

            }


        }
    }
}
