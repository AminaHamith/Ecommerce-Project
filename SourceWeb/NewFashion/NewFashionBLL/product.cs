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
    
    public partial class product
    {
        public product()
        {
            this.comments = new HashSet<comment>();
            this.image_product = new HashSet<image_product>();
            this.image_slide = new HashSet<image_slide>();
            this.order_detail = new HashSet<order_detail>();
            this.shopping_cart = new HashSet<shopping_cart>();
            this.wish_list = new HashSet<wish_list>();
        }
    
        public int proid { get; set; }
        public string proname { get; set; }
        public int procatid { get; set; }
        public string prointro { get; set; }
        public string proarticle { get; set; }
        public int proquantity { get; set; }
        public int prostockprice { get; set; }
        public Nullable<int> materialid { get; set; }
        public Nullable<int> discountid { get; set; }
        public Nullable<int> brandid { get; set; }
        public Nullable<int> colorid { get; set; }
        public Nullable<int> sizeid { get; set; }
        public System.DateTime datearrival { get; set; }
        public int imgthumbid { get; set; }
        public Nullable<int> proquantityorder { get; set; }
    
        public virtual brand brand { get; set; }
        public virtual category category { get; set; }
        public virtual color color { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual discount discount { get; set; }
        public virtual ICollection<image_product> image_product { get; set; }
        public virtual ICollection<image_slide> image_slide { get; set; }
        public virtual imagetb imagetb { get; set; }
        public virtual material material { get; set; }
        public virtual ICollection<order_detail> order_detail { get; set; }
        public virtual size size { get; set; }
        public virtual ICollection<shopping_cart> shopping_cart { get; set; }
        public virtual ICollection<wish_list> wish_list { get; set; }
    }
}
