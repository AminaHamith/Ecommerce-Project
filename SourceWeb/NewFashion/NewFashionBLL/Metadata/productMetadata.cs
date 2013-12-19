using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL
{
    [MetadataType(typeof(productMetadata))]
    public partial class product { }

    public class productMetadata
    {
        [Display(Name="ID Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int proid { get; set; }

        [Display(Name = "Tên Sản Phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public string proname { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int procatid { get; set; }

        [Display(Name = "Thông tin")]
        public string prointro { get; set; }

        [Display(Name = "Bài viết")]
        public string proarticle { get; set; }

        [Display(Name = "Số lượng")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Vui lòng nhập số")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int proquantity { get; set; }

        [Display(Name = "Giá gốc")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Vui lòng nhập số")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public int prostockprice { get; set; }

        [Display(Name = "ID Chất liệu")]
        public Nullable<int> materialid { get; set; }

        [Display(Name = "ID Khuyến mãi")]
        public Nullable<int> discountid { get; set; }

        [Display(Name = "ID Nhà sản xuất")]
        public Nullable<int> brandid { get; set; }

        [Display(Name = "ID Màu sắc")]
        public Nullable<int> colorid { get; set; }

        [Display(Name = "ID Kích cỡ")]
        public Nullable<int> sizeid { get; set; }

        [Display(Name = "Ngày nhập hàng")]
        [Required(ErrorMessage = "Vui lòng nhập {0}")]
        public System.DateTime datearrival { get; set; }
    }
}
