using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class HierararchyInRecipe : General
    {
        public override string ToString()
        {
            return $"[{Recipe}-{Hierarchy}]";
        }
        public override General CreateNew()
        {
            var general = new HierararchyInRecipe
            {
                RecipeID = -1,
                Hierarchy = -1,
                PercentageOfInfluenceOnTaste = -1
            };
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is HierararchyInRecipe general)
            {
                RecipeID = general.RecipeID;
                Hierarchy = general.Hierarchy;
                PercentageOfInfluenceOnTaste = general.PercentageOfInfluenceOnTaste;
            }


        }

        public override void AllFill(General copy)
        {
            if (copy is HierararchyInRecipe general)
            {
                Fill(general);

            }


        }
    }
}
