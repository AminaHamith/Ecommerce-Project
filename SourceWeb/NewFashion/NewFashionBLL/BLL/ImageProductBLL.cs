using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ImageProductBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<image_product> getList()
        {
            return db.image_product.ToList();
        }

        //get By id
        public image_product getimage_productById(int id)
        {
            return db.image_product.Where(c => c.id == id).FirstOrDefault();
        }
        
        //create 
        public void create(image_product _image_product)
        {
            db.image_product.Add(_image_product);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.image_product.Any(c => c.id == id));
        }

        //edit
        public void edit(image_product _image_product)
        {
            db.Entry(_image_product).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            image_product _image_product = db.image_product.Find(id);
            db.image_product.Remove(_image_product);
            db.SaveChanges();
        }
    }
}
