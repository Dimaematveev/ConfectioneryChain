using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Check : General
    {
        public override string ToString()
        {
            return $"[{ConfectioneryID}-{OrderID}-{CashierID}]";
        }
        public override General CreateNew()
        {
            var general = new Check
            {
                OrderID = -1,
                ConfectioneryID = -1,
                CashierID = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Check general)
            {
                ConfectioneryID = general.ConfectioneryID;
                CashierID = general.CashierID;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Check general)
            {
                Fill(general);
                OrderID = general.OrderID;
            }


        }
    }
}
