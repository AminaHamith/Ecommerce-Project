using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL
{
    [MetadataType(typeof(customerMetaData))]
    public partial class customer { }

    public class customerMetaData
    {
        [Display(Name = "ID Khách hàng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public System.Guid cusid { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string cusfirstname { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string cuslastname { get; set; }

        public int idcustomer_information { get; set; }
    }
}
