using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class ToppingInOrder : General
    {
        public override string ToString()
        {
            return $"[{ToppingInRecipe.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new ToppingInOrder();
            general.RecipesInOrdersID = -1;
            general.RecipeID = -1;
            general.GoodsID = -1;
            general.Count = -1;
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
