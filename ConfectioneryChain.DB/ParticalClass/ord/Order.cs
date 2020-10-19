using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Order : General
    {
        public override string ToString()
        {
            return $"[{IDOrder}]";
        }
        public override General CreateNew()
        {
            var general = new Order
            {
                IDOrder = -1,
                ConfectioneryID = -1,
                CustomerPhone = -1,
                OrderIssueOptionChar = null,
                DateTime = System.DateTime.Now
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Order general)
            {
                ConfectioneryID = general.ConfectioneryID;
                CustomerPhone = general.CustomerPhone;
                OrderIssueOptionChar = general.OrderIssueOptionChar;
                DateTime = general.DateTime;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Order general)
            {
                Fill(general);
                IDOrder = general.IDOrder;
            }


        }
    }
}
