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
    
    public partial class wish_list
    {
        public int id { get; set; }
        public System.Guid cusid { get; set; }
        public int proid { get; set; }
        public int count { get; set; }
        public Nullable<int> status_wish_list { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
    
        public virtual customer customer { get; set; }
        public virtual product product { get; set; }
    }
}