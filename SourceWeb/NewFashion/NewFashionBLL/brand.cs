//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewFashionBLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class brand
    {
        public brand()
        {
            this.products = new HashSet<product>();
        }
    
        public int brandid { get; set; }
        public string urlimage { get; set; }
        public string brandname { get; set; }
    
        public virtual ICollection<product> products { get; set; }
    }
}
