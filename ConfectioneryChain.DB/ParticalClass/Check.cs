namespace ConfectioneryChain.DB
{
    public partial class Check
    {
        public override string ToString()
        {
            return $"[{ConfectioneryID}-{OrderID}-{CashierID}]";
        }
    }
}
