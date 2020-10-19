using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class TypeOfGood : General
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
        public override General CreateNew()
        {
            var general = new TypeOfGood();
            general.CharTypesOfGoods = null;
            general.Name = null;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is TypeOfGood general)
            {
                Name = general.Name;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is TypeOfGood general)
            {
                Fill(general);
                CharTypesOfGoods = general.CharTypesOfGoods;
            }


        }
    }
}
