using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class RecipesInOrder : General
    {
        public override string ToString()
        {
            return $"[{PriceListRecipe.ToString()}-{HierararchyInRecipe.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new RecipesInOrder();
            general.IDRecipesInOrders = -1;
            general.PriceListID = -1;
            general.RecipeID = -1;
            general.Hierarchy = -1;
            general.OrderID = -1;
            general.MarkCancel = null;
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
