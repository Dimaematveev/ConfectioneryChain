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
    
    public partial class HierararchyInRecipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HierararchyInRecipe()
        {
            this.RecipesInOrders = new HashSet<RecipesInOrder>();
            this.ItemInRecipes = new HashSet<ItemInRecipe>();
        }
    
        public int RecipeID { get; set; }
        public int Hierarchy { get; set; }
        public decimal PercentageOfInfluenceOnTaste { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecipesInOrder> RecipesInOrders { get; set; }
        public virtual Recipe Recipe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemInRecipe> ItemInRecipes { get; set; }
    }
}
