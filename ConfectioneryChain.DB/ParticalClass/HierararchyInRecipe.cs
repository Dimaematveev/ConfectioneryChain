using ConfectioneryChain.DB.Inheritance;

namespace ConfectioneryChain.DB
{
    public partial class HierararchyInRecipe : General
    {
        public override string ToString()
        {
            return $"[{Recipe.ToString()}-{Hierarchy.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new HierararchyInRecipe();
            general.RecipeID = -1;
            general.Hierarchy = -1;
            general.PercentageOfInfluenceOnTaste = -1;
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
