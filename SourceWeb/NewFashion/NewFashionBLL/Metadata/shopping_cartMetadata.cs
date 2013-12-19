using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.Metadata
{
    [MetadataType(typeof(shopping_cartMetadata))]
    public partial class shopping_cart
    {

    }

    public class shopping_cartMetadata
    {
        [Display(Name = "ID Giỏ hàng")]
        public int id { get; set; }

        [Display(Name = "ID Khách hàng")]
        public System.Guid cusid { get; set; }

        [Display(Name = "ID Sản phẩm")]
        public int proid { get; set; }

        [Range(1, 100, ErrorMessage = "Số lượng phải lớn hơn 0")]
        [Display(Name = "Số lượng")]
        public int count { get; set; }

        [Display(Name = "Ngày tạo")]
        public Nullable<System.DateTime> create_date { get; set; }

        [Display(Name = "Tình trạng")]
        public Nullable<int> cartstatus { get; set; }
    }
}
