using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class RecipesInOrder : General
    {
        public override string ToString()
        {
            return $"[{PriceListRecipe}-{HierararchyInRecipe}]";
        }
        public override General CreateNew()
        {
            var general = new RecipesInOrder
            {
                IDRecipesInOrders = -1,
                PriceListID = -1,
                RecipeID = -1,
                Hierarchy = -1,
                OrderID = -1,
                MarkCancel = null
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is RecipesInOrder general)
            {
                PriceListID = general.PriceListID;
                RecipeID = general.RecipeID;
                Hierarchy = general.Hierarchy;
                OrderID = general.OrderID;
                MarkCancel = general.MarkCancel;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is RecipesInOrder general)
            {
                Fill(general);
                IDRecipesInOrders = general.IDRecipesInOrders;
            }


        }
    }
}
