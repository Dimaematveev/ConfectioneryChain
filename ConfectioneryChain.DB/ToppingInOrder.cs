//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConfectioneryChain.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToppingInOrder
    {
        public int RecipesInOrdersID { get; set; }
        public int RecipeID { get; set; }
        public int GoodsID { get; set; }
        public int Count { get; set; }
    
        public virtual ToppingInRecipe ToppingInRecipe { get; set; }
    }
}
