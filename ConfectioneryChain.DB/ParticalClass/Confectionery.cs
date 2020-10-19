using ConfectioneryChain.DB.Inheritance;
using System;
using System.Configuration;

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
            var general= new Confectionery();
            general.IDConfectionery = -1;
            general.Name = null;
            general.Address = null;
            general.RentPricel = 0;
            general.BeginWork = new TimeSpan(7,0,0);
            general.EndWork = new TimeSpan(23,0,0);
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
