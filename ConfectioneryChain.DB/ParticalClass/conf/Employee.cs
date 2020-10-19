using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class Employee : General
    {
        //Полное имя
        public string FullName 
        {
            get 
            {
                return $"{Family} {Name} {PatronymicName}";
            }
        }
        public override string ToString()
        {
            return $"[{Family} {Name} {PatronymicName}]";
        }

        public override General CreateNew()
        {
            var general= new Employee();
            general.IDEmployee = -1;

            general.PassportSeria = null; 
            general.PassportNumber = 0;

            general.Family = null;
            general.Name = null;
            general.PatronymicName = null;

            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Employee general)
            {
                PassportSeria = general.PassportSeria;
                PassportNumber = general.PassportNumber;

                Family = general.Family;
                Name = general.Name;
                PatronymicName = general.PatronymicName;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Employee general)
            {
                Fill(general);
                IDEmployee = general.IDEmployee;
            }


        }

    }
}
