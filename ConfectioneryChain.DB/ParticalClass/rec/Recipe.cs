using ConfectioneryChain.DB.Inheritance;
using System;

namespace ConfectioneryChain.DB
{
    public partial class Recipe : General
    {
        public override string ToString()
        {
            return $"[{Name}-{Employee.ToString()}]";
        }
        public override General CreateNew()
        {
            var general = new Recipe();
            general.IDRecipe = -1;
            general.DateCreate = DateTime.Now;
            general.MarkIsWork = false;
            general.ChefID = -1;
            general.Name = null;
            general.Description = null;
            return general;
        }

        public override void Fill(General copy)
        {
            if (copy is Recipe general)
            {
                DateCreate = general.DateCreate;
                MarkIsWork = general.MarkIsWork;
                ChefID = general.ChefID;
                Name = general.Name;
                Description = general.Description;

            }



        }

        public override void AllFill(General copy)
        {
            if (copy is Recipe general)
            {
                Fill(general);
                IDRecipe = general.IDRecipe;

            }


        }
    }
}
