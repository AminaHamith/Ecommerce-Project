using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class ChangePasswordModel
    {

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} dài từ {2} đến {1} kí tự", MinimumLength = 6)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "{0} dài từ {2} đến {1} kí tự", MinimumLength = 6)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [StringLength(30, ErrorMessage = "{0} dài từ {2} đến {1} kí tự", MinimumLength = 6)]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string ConfirmNewPassword { get; set; }
    }
}