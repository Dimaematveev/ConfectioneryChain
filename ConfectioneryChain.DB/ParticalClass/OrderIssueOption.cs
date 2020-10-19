using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class OrderIssueOption : General
    {
        public override string ToString()
        {
            return $"[{Name}]";
        }
        public override General CreateNew()
        {
            var general = new OrderIssueOption();

            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is OrderIssueOption general)
            {

            }


        }

        public override void AllFill(General copy)
        {
            if (copy is OrderIssueOption general)
            {
                Fill(general);

            }


        }
    }
}
