namespace ConfectioneryChain.DB
{
    public partial class ItemInRecipe
    {
        public override string ToString()
        {
            return $"[{HierararchyInRecipe.ToString()}-{ItemInRecipeID}-{Good.ToString()}]";
        }
    }
}
