using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ToppingInOrder : General
    {
        public override string ToString()
        {
            return $"[{ToppingInRecipe}]";
        }
        public override General CreateNew()
        {
            var general = new ToppingInOrder
            {
                RecipesInOrdersID = -1,
                RecipeID = -1,
                GoodsID = -1,
                Count = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is ToppingInOrder general)
            {
                RecipesInOrdersID = general.RecipesInOrdersID;
                RecipeID = general.RecipeID;
                GoodsID = general.GoodsID;
                Count = general.Count;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is ToppingInOrder general)
            {
                Fill(general);

            }


        }
    }
}
