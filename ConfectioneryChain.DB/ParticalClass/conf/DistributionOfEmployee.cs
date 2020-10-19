using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class DistributionOfEmployee : General
    {
        public override string ToString()
        {
            return $"[{Confectionery}-{Employee}-{Position}]";
        }
        public override General CreateNew()
        {
            var general = new DistributionOfEmployee
            {
                ConfectioneryID = -1,
                EmployeeID = -1,
                PositionID = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is DistributionOfEmployee general)
            {
                ConfectioneryID = general.ConfectioneryID;
                EmployeeID = general.EmployeeID;
                PositionID = general.PositionID;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is DistributionOfEmployee general)
            {
                Fill(general);
            }


        }
    }
}
