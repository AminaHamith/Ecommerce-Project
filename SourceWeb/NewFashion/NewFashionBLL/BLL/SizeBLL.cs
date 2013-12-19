using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    class SizeBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<size> getList()
        {
            return db.sizes.ToList();
        }

        //get By id
        public size getSizeById(int id)
        {
            return db.sizes.Where(c => c.sizeid == id).FirstOrDefault();
        }

        //get By name
        public size getSizeByName(string name)
        {
            return db.sizes.Where(c => c.sizename == name).FirstOrDefault();
        }

        //get By code
        /*public size getSizeByCode(string code)
        {
            return db.sizes.Where(c => c.sizecode == code).FirstOrDefault();
        }*/

        //create 
        public void create(size _size)
        {
            db.sizes.Add(_size);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.sizes.Any(c => c.sizeid == id));
        }

        //edit
        public void edit(size _size)
        {
            db.Entry(_size).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            size _size = db.sizes.Find(id);
            db.sizes.Remove(_size);
            db.SaveChanges();
        }
    }
}
