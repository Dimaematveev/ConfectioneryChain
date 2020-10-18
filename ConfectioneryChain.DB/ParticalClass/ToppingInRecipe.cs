namespace ConfectioneryChain.DB
{
    public partial class ToppingInRecipe
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Good.ToString()}]";
        }
    }
}
