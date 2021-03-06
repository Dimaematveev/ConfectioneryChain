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
    
    public partial class ToppingInRecipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ToppingInRecipe()
        {
            this.ToppingInOrders = new HashSet<ToppingInOrder>();
        }
    
        public int RecipeID { get; set; }
        public int GoodsID { get; set; }
        public decimal PercentageOfInfluenceOnTaste { get; set; }
        public decimal Count { get; set; }
        public int MaxCount { get; set; }
    
        public virtual Good Good { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToppingInOrder> ToppingInOrders { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
