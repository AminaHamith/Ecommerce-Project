using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ColorBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<color> getList()
        {
            return db.colors.ToList();
        }

        //get By id
        public color getColorById(int id)
        {
            return db.colors.Where(c => c.colorid == id).FirstOrDefault();
        }

        //get By name
        public color getColorByName(string name)
        {
            return db.colors.Where(c => c.colorname == name).FirstOrDefault();
        }

        //get By code
        public color getColorByCode(string code)
        {
            return db.colors.Where(c => c.colorcode == code).FirstOrDefault();
        }

        //create 
        public void create(color _color)
        {
            db.colors.Add(_color);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.colors.Any(c => c.colorid == id));
        }

        //edit
        public void edit(color _color)
        {
            db.Entry(_color).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            color _color = db.colors.Find(id);
            db.colors.Remove(_color);
            db.SaveChanges();
        }
    }
}
