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
    
    public partial class PriceList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceList()
        {
            this.PriceListRecipes = new HashSet<PriceListRecipe>();
        }
    
        public int IDPriceList { get; set; }
        public System.DateTime DateTimeBegin { get; set; }
        public System.DateTime DateTimeEnd { get; set; }
        public bool IsWorks { get; set; }
        public int ConfectioneryID { get; set; }
    
        public virtual Confectionery Confectionery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PriceListRecipe> PriceListRecipes { get; set; }

        public override string ToString()
        {
            return $"[{IDPriceList}]";
        }
    }
}
