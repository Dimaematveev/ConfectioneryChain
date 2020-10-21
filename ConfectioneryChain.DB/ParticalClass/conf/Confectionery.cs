using ConfectioneryChain.DB.Inheritance;
using System;
using System.ComponentModel;

namespace ConfectioneryChain.DB
{
    public partial class Confectionery : General
    {

        public override string ToString()
        {
            return $"[{Name}]";
        }
        public override General CreateNew()
        {
            var general = new Confectionery
            {
                IDConfectionery = -1,
                Name = null,
                Address = null,
                RentPricel = 0,
                BeginWork = new TimeSpan(7, 0, 0),
                EndWork = new TimeSpan(23, 0, 0),
                Money = 500000,
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Confectionery general)
            {
                Name = general.Name;
                Address = general.Address;
                RentPricel = general.RentPricel;
                BeginWork = general.BeginWork;
                EndWork = general.EndWork;
                Money = general.Money;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Confectionery general)
            {
                Fill(general);
                IDConfectionery = general.IDConfectionery;
            }


        }
    }
}
