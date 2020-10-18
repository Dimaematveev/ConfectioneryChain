namespace ConfectioneryChain.DB
{
    public partial class Employee
    {
        public override string ToString()
        {
            return $"[{Family} {Name} {PatronymicName}]";
        }
    }
}
