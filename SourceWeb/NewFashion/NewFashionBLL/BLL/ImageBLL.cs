using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ImageBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<imagetb> getList()
        {
            return db.imagetbs.ToList();
        }

        //get By id
        public imagetb getImageById(int id)
        {
            return db.imagetbs.Where(i => i.imgid == id).FirstOrDefault();
        }
        //create 
        public int create(imagetb _image)
        {
            imagetb image = db.imagetbs.Add(_image);
            db.SaveChanges();

            return image.imgid;
        }

        //Exist
        public bool exist(int id)
        {
            return (db.imagetbs.Any(i => i.imgid == id));
        }

        //edit
        public void edit(imagetb _image)
        {
            db.Entry(_image).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            imagetb _image = db.imagetbs.Find(id);
            db.imagetbs.Remove(_image);
            db.SaveChanges();
        }
    }
}
