using NewFashionBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace NewFashionWebsite.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
        }
    }

    public class RegisterModel
    {
        public AccountModel accountModel {get; set;}
        public customer customerModel {get; set;}

        [MustBeTrue(ErrorMessage = "Bạn phải đồng ý các điều khoản.")]
        [DisplayName("Tôi đã đọc và đồng ý các điều khoản")]
        public bool isAcceptsTerms { get; set; }

        public bool isADMIN { get; set; }

        public bool isCUSTOMER { get; set; }
    }
}