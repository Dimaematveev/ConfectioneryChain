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
            {
                CharOrderIssueOption = null;
                Name = null;
            }
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is OrderIssueOption general)
            {
                Name = general.Name;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is OrderIssueOption general)
            {
                Fill(general);
                CharOrderIssueOption = general.CharOrderIssueOption;
            }


        }
    }
}
