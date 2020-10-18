namespace ConfectioneryChain.DB
{
    public partial class DistributionOfEmployee
    {
        public override string ToString()
        {
            return $"[{Confectionery.ToString()}-{Employee.ToString()}-{Position.ToString()}]";
        }
    }
}
