//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMD.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductModel
    {
        public int ProductModelID { get; set; }
        public int ProductId { get; set; }
        public string ModelName { get; set; }
        public string ModelDescription { get; set; }

        public virtual Product Product { get; set; }
        
        public virtual ICollection<ProductTechSpec> ProductTechSpecs { get; set; }
        
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
