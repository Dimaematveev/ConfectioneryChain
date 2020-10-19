using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Shop : General
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
        public override General CreateNew()
        {
            var general = new Shop
            {
                IDShop = -1,
                Name = null,
                Address = null
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Shop general)
            {
                Name = general.Name;
                Address = general.Address;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Shop general)
            {
                Fill(general);
                IDShop = general.IDShop;
            }


        }
    }
}
