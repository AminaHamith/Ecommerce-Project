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
    
    public partial class advertisement
    {
        public int id { get; set; }
        public string advdescription { get; set; }
        public Nullable<int> imgid { get; set; }
        public string advname { get; set; }
    
        public virtual imagetb imagetb { get; set; }
    }
}