using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Good : General
    {
        public override string ToString()
        {
            return $"[{TypeOfGood}-{Name}-{Unit}]";
        }
        public override General CreateNew()
        {
            var general = new Good
            {
                IDGoods = -1,
                TypesOfGoodsChar = null,
                UnitsID = -1,
                Name = null,
                Calories = null
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Good general)
            {
                TypesOfGoodsChar = general.TypesOfGoodsChar;
                UnitsID = general.UnitsID;
                Name = general.Name;
                Calories = general.Calories;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Good general)
            {
                Fill(general);
                IDGoods = general.IDGoods;
            }


        }
    }
}
