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
    
    public partial class category
    {
        public category()
        {
            this.products = new HashSet<product>();
        }
    
        public int catid { get; set; }
        public string catname { get; set; }
        public int catparent { get; set; }
        public string catintro { get; set; }
    
        public virtual ICollection<product> products { get; set; }
    }
}
