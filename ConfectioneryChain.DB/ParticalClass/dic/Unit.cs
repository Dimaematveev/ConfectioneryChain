﻿using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Unit : General
    {
        public override string ToString()
        {
            return $"[{Name}({MultipleValue})]";
        }
        public override General CreateNew()
        {
            var general = new Unit
            {
                IDUnits = -1,
                MultipleValue = -1,
                Name = null
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Unit general)
            {
                MultipleValue = general.MultipleValue;
                Name = general.Name;
            }
        }

        public override void AllFill(General copy)
        {
            if (copy is Unit general)
            {
                Fill(general);
                IDUnits = general.IDUnits;
            }


        }
    }
}
