using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class PriceList : General
    {
        public override string ToString()
        {
            return $"[{IDPriceList}]";
        }
        public override General CreateNew()
        {
            var general = new PriceList
            {
                IDPriceList = -1,
                DateTimeBegin = DateTime.Now.AddDays(1).Date,
                DateTimeEnd = DateTime.Now.AddDays(2).Date,
                IsWorks = false,
                ConfectioneryID = -1
            };

            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is PriceList general)
            {
                DateTimeBegin = general.DateTimeBegin;
                DateTimeEnd = general.DateTimeEnd;
                IsWorks = general.IsWorks;
                ConfectioneryID = general.ConfectioneryID;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is PriceList general)
            {
                Fill(general);
                IDPriceList = general.IDPriceList;
            }


        }
    }
}
