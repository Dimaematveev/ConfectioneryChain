namespace ConfectioneryChain.DB
{
    public partial class Good
    {
        public override string ToString()
        {
            return $"[{TypeOfGood.ToString()}-{Name}-{Unit.ToString()}]";
        }
    }
}
