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
    
    public partial class payment_method
    {
        public payment_method()
        {
            this.product_order = new HashSet<product_order>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string paymentintro { get; set; }
        public Nullable<int> image { get; set; }
    
        public virtual imagetb imagetb { get; set; }
        public virtual ICollection<product_order> product_order { get; set; }
    }
}
