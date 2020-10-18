namespace ConfectioneryChain.DB
{
    public partial class RecipesInOrder
    {
        public override string ToString()
        {
            return $"[{PriceListRecipe.ToString()}-{HierararchyInRecipe.ToString()}]";
        }
    }
}
