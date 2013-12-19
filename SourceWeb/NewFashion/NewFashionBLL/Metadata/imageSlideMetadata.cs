using NewFashionBLL.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL
{
    [MetadataType(typeof(image_slideMetadata))]
    public partial class image_slide
    {
        ImageBLL imageBLL = new ImageBLL();
        public string getUrlImage
        {
            get
            {
                return imageBLL.getImageById(1).url;
            }
        }
    }

    public class image_slideMetadata
    {
        public int id { get; set; }
        public int imgthumbid { get; set; }
        public int imgid { get; set; }
        public int proid { get; set; }
        public string imgdescription { get; set; }

        public bool imagetb { get; set; }
        public bool imagetb1 { get; set; }
        public bool product { get; set; }
    }
}
