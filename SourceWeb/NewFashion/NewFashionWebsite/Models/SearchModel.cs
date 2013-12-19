using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class SearchModel
    {
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        [Display(Name = "Từ khóa")]
        public string keyWord { get; set; }

    }
}