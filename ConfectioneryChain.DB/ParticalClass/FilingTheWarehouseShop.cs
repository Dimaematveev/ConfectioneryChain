namespace ConfectioneryChain.DB
{
    public partial class FilingTheWarehouseShop
    {
        public override string ToString()
        {
            return $"[{Shop.ToString()}-{GoodsID}]";
        }
    }
}
