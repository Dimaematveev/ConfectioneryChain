namespace ConfectioneryChain.DB
{
    public partial class Recipe
    {
        public override string ToString()
        {
            return $"[{Name}-{Employee.ToString()}]";
        }
    }
}
