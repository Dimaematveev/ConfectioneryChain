namespace ConfectioneryChain.DB
{
    public partial class PriceListRecipe
    {
        public override string ToString()
        {
            return $"[{PriceList.ToString()}-{Recipe.ToString()}]";
        }
    }
}
