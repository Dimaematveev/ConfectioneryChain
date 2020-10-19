using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ToppingInRecipe : General
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Good.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new ToppingInRecipe();
            general.RecipeID = -1;
            general.GoodsID = -1;
            general.PercentageOfInfluenceOnTaste = -1;
            general.Count = -1;
            general.MaxCount = -1;
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
