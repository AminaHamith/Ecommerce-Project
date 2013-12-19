using NewFashionBLL;
using NewFashionBLL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class ProductModel
    {
        public product product { get; set; }

        [Required(ErrorMessage = "Chưa chọn {0}")]
        [Display(Name = "Hình đại diện")]
        public HttpPostedFileBase anhDaiDien { get; set; }
        public List<HttpPostedFileBase> anhGioiThieu { get; set; }

        public int luuAnhDaiDien()
        {
            int id;
            string path = ImageModel.renameUploadFile(anhDaiDien, 200, 200);
            imagetb image = new imagetb();

            image.url = path;
            ImageBLL imageBLL = new ImageBLL();
            id = imageBLL.create(image);
            return id;
        }
        /*
        public CHI_TIET_HINH_ANH_GIOI_THIEU_TUYEN[] luuAnhGioiThieu()
        {
            List<CHI_TIET_HINH_ANH_GIOI_THIEU_TUYEN> chiTiets = new List<CHI_TIET_HINH_ANH_GIOI_THIEU_TUYEN>();

            for (int i = 0; i < anhGioiThieu.Count; i++)
            {
                CHI_TIET_HINH_ANH_GIOI_THIEU_TUYEN chiTiet = new CHI_TIET_HINH_ANH_GIOI_THIEU_TUYEN();
                string path = ImageModel.renameUploadFile(anhGioiThieu[i], 500, 334);

                HINH_ANH hinhAnh = new HINH_ANH();
                int j = i + 1;
                hinhAnh.CHU_THICH = "Ảnh giới thiệu " + TuyenDuLich.TEN_TUYEN + " " + j;
                hinhAnh.DUONG_DAN = path;

                HinhAnhBLL hinhAnhBLL = new HinhAnhBLL();
                int idHinhAnh = hinhAnhBLL.create(hinhAnh);

                chiTiet.ID_HINH_ANH = idHinhAnh;

                chiTiets.Add(chiTiet);
            }

            return chiTiets.ToArray();
        }*/
    }
}