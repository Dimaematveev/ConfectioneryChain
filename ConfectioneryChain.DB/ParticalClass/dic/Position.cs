using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class Position : General
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
        public override General CreateNew()
        {
            var general = new Position
            {
                IDPosition = -1,
                Name = null,
                MinimumHours = -1,
                WorkHourRate = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Position general)
            {
                Name = general.Name;
                MinimumHours = general.MinimumHours;
                WorkHourRate = general.WorkHourRate;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is Position general)
            {
                Fill(general);
                IDPosition = general.IDPosition;
            }


        }
    }
}
