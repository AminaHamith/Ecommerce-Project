using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Tên Đăng Nhập")]
        [StringLength(30, ErrorMessage = "{0} dài từ {2} đến {1} kí tự", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [StringLength(30, ErrorMessage = "{0} dài từ {2} đến {1} kí tự", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} dài tối đa {1} kí tự")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "{0} không đúng đinh dạng")]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Xác nhận Email")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [StringLength(50, ErrorMessage = "{0} dài tối đa {1} kí tự")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "{0} không đúng đinh dạng")]
        [System.Web.Mvc.Compare("Email", ErrorMessage = "Email không trùng khớp")]
        public string ConfirmEmail { get; set; }
    }
}