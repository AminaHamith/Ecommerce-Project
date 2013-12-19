using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace NewFashionWebsite.Models
{
    public class ImageModel
    {
        public static readonly string ItemUploadFolderPath = "~/Images/products/";

        public static string renameUploadFile(HttpPostedFileBase file, int width, int height, Int32 counter = 0)
        {
            var fileName = Path.GetFileName(file.FileName);

            string append = "item_";
            string finalFileName = append + ((counter).ToString()) + "_" + +width + "x" + height + "_" + fileName;
            if (System.IO.File.Exists
        (HttpContext.Current.Request.MapPath(ItemUploadFolderPath + finalFileName)))
            {
                //file exists 
                return renameUploadFile(file, width, height, ++counter);
            }
            //file doesn't exist, upload item but validate first
            return uploadFile(file, finalFileName, width, height);
        }

        private static string uploadFile(HttpPostedFileBase file, string fileName, int width, int height)
        {
            var path =
          Path.Combine(HttpContext.Current.Request.MapPath(ItemUploadFolderPath), fileName);

            try
            {
                file.SaveAs(path);

                Image imgOriginal = Image.FromFile(path);

                Image imgActual = ScaleBySize(imgOriginal, width, height);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                return ItemUploadFolderPath + fileName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Image ScaleBySize(Image imgPhoto, int width, int height)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = height;
            float destWidth = width;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }
    }
}