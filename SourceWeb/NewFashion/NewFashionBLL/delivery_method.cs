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
    
    public partial class delivery_method
    {
        public delivery_method()
        {
            this.product_order = new HashSet<product_order>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string deliveryintro { get; set; }
    
        public virtual ICollection<product_order> product_order { get; set; }
    }
}
