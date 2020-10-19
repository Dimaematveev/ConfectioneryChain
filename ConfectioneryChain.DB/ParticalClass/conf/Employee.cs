using ConfectioneryChain.DB.Inheritance;

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
            var general = new Employee
            {
                IDEmployee = -1,

                PassportSeria = null,
                PassportNumber = 0,

                Family = null,
                Name = null,
                PatronymicName = null
            };

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
