

using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class BuyGood : General
    {
        public override string ToString()
        {
            return $"[{IDBuyGoods}]";
        }
        public override General CreateNew()
        {
            var general = new BuyGood
            {
                IDBuyGoods = -1,
                ConfectioneryID = -1,
                EmployeeID = -1,
                DateTime = new DateTime()
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is BuyGood general)
            {
                ConfectioneryID = general.ConfectioneryID;
                EmployeeID = general.EmployeeID;
                DateTime = general.DateTime;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is BuyGood general)
            {
                Fill(general);
                IDBuyGoods = general.IDBuyGoods;
            }


        }
    }
}
