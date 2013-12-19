using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ImageSlideBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<image_slide> getList()
        {
            return db.image_slide.ToList();
        }

        //get By id
        public image_slide getImageById(int id)
        {
            return db.image_slide.Where(i => i.id == id).FirstOrDefault();
        }
        //create 
        public void create(image_slide _image)
        {
            db.image_slide.Add(_image);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.image_slide.Any(i => i.id == id));
        }

        //edit
        public void edit(image_slide _image)
        {
            db.Entry(_image).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            image_slide _image = db.image_slide.Find(id);
            db.image_slide.Remove(_image);
            db.SaveChanges();
        }
    }
}
