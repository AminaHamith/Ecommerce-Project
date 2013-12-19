using NewFashionBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class ShoppingCartModel
    {
        public List<shopping_cart> listCart{get; set;}

        [DisplayName("Tổng số tiền")]
        public int subTotal { get; set; }

        [DisplayName("Tổng số tiền")]
        public int total{get; set;}

        [DisplayName("VAT")]
        public int vat { get; set; }
    }
}