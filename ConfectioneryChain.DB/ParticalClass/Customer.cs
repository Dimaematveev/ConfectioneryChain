using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Customer : General
    {
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
            var general= new Customer();
            general.Phone = -1;
            general.Family = null;
            general.Name = null;
            general.PatronymicName = null;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Customer general)
            {
                Family = general.Family;
                Name = general.Name;
                PatronymicName = general.PatronymicName;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Customer general)
            {
                Fill(general);
                Phone = general.Phone;
            }


        }
    }
}
