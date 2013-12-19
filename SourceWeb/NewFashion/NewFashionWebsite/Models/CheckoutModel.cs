using NewFashionBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NewFashionWebsite.Models
{
    public class CheckoutModel
    {
        public customer customer { get; set; }
        public MembershipUser user { get; set; }
        public customer_information arrival_information { get; set; }
        public delivery_method delivery { get; set; }
        public shipping_method shipping { get; set; }
        public payment_method payment { get; set; }
        public List<shopping_cart> listCart { get; set; }
    }
}