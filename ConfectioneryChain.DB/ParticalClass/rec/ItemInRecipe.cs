using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ItemInRecipe : General
    {
        public override string ToString()
        {
            return $"[{HierararchyInRecipe}-{ItemInRecipeID}-{Good}]";
        }
        public override General CreateNew()
        {
            var general = new ItemInRecipe
            {
                IDItemInRecipe = -1,
                ItemInRecipeID = -1,
                RecipeID = -1,
                Hierarchy = -1,
                GoodsID = null,
                Count = -1,
                PercentageOfInfluenceOnTaste = 0
            };
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
