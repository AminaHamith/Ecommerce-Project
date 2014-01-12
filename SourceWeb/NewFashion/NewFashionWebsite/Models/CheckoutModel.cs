using NewFashionBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ShoppingCartModel cart { get; set; }

       

        [Display(Name = "Địa chỉ thứ nhất")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string address1 { get; set; }

        [Display(Name = "Địa chỉ thứ hai")]
        public string address2 { get; set; }

        [Display(Name = "Số điện thoại thứ nhất")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string phonenumber1 { get; set; }

        [Display(Name = "Số điện thoại thứ hai")]
        public string phonenumber2 { get; set; }

        [Display(Name = "Quốc gia")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string country { get; set; }

        [Display(Name = "Quận / huyện")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string region_state { get; set; }

        [Display(Name = "Tỉnh / Thành phố")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string city { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string firstname { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string lastname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} dài tối đa {1} kí tự")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "{0} không đúng đinh dạng")]
        public string Email { get; set; }
    }
}