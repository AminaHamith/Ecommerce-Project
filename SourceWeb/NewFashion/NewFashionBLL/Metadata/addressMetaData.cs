using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL
{
    [MetadataType(typeof(addressMetaData))]
    public partial class address { }

    public class addressMetaData
    {
        [Display(Name = "ID Address")]
        public int id { get; set; }

        [Display(Name = "Địa chỉ thứ nhất")]
        public string address1 { get; set; }

        [Display(Name = "Địa chỉ thứ hai")]
        public string address2 { get; set; }

        [Display(Name = "Số điện thoại thứ nhất")]
        public string phonenumber1 { get; set; }

        [Display(Name = "Số điện thoại thứ hai")]
        public string phonenumber2 { get; set; }

        [Display(Name = "Ngày tháng năm sinh")]
        public Nullable<System.DateTime> birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string gender { get; set; }

        [Display(Name = "Quốc gia")]
        public string country { get; set; }

        [Display(Name = "Quận / huyện")]
        public string region_state { get; set; }

        [Display(Name = "Tỉnh / Thành phố")]
        public string city { get; set; }

        [Display(Name = "Mã vùng")]
        public string post_code { get; set; }
    }
}
