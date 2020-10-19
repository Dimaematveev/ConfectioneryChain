using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ItemInRecipe : General
    {
        public override string ToString()
        {
            return $"[{HierararchyInRecipe.ToString()}-{ItemInRecipeID}-{Good.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new ItemInRecipe();
            general.IDItemInRecipe = -1;
            general.ItemInRecipeID = -1;
            general.RecipeID = -1;
            general.Hierarchy = -1;
            general.GoodsID = null;
            general.Count = -1;
            general.PercentageOfInfluenceOnTaste = 0;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is ItemInRecipe general)
            {
                ItemInRecipeID = general.ItemInRecipeID;
                RecipeID = general.RecipeID;
                Hierarchy = general.Hierarchy;
                GoodsID = general.GoodsID;
                Count = general.Count;
                PercentageOfInfluenceOnTaste = general.PercentageOfInfluenceOnTaste;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is ItemInRecipe general)
            {
                Fill(general);
                IDItemInRecipe = general.IDItemInRecipe;
            }


        }
    }
}
