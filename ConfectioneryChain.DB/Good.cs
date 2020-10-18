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
    
    public partial class Good
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Good()
        {
            this.ItemInRecipes = new HashSet<ItemInRecipe>();
            this.ToppingInRecipes = new HashSet<ToppingInRecipe>();
        }
    
        public int IDGoods { get; set; }
        public string TypesOfGoodsChar { get; set; }
        public int UnitsID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Calories { get; set; }
    
        public virtual TypeOfGood TypeOfGood { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemInRecipe> ItemInRecipes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToppingInRecipe> ToppingInRecipes { get; set; }

        public override string ToString()
        {
            return $"[{TypeOfGood.ToString()}-{Name}-{Unit.ToString()}]";
        }
    }
}
