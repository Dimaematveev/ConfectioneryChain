namespace ConfectioneryChain.DB
{
    public partial class Customer
    {
        public override string ToString()
        {
            return $"[{Family} {Name} {PatronymicName}]";
        }
    }
}
