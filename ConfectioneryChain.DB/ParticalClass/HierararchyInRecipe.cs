namespace ConfectioneryChain.DB
{
    public partial class HierararchyInRecipe
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Hierarchy.ToString()}]";
        }
    }
}
