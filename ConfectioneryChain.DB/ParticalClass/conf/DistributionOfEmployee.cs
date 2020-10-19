using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class DistributionOfEmployee : General
    {
        public override string ToString()
        {
            return $"[{Confectionery.ToString()}-{Employee.ToString()}-{Position.ToString()}]";
        }
        public override General CreateNew()
        {
            var general= new DistributionOfEmployee();
            general.ConfectioneryID = -1;
            general.EmployeeID = -1;
            general.PositionID = -1;
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
