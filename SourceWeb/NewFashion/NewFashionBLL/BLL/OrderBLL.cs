using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class OrderBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<product_order> getList()
        {
            return db.product_order.ToList();
        }

        //get List
        public List<product_order> getListByIdProductOrder(int id)
        {
            return db.product_order.Where(o => o.ordid == id).ToList();
        }

        //
        public int getCount(int id)
        {
            return db.product_order.Where(o => o.ordid == id).Count(); ;
        }


        //create 
        public int create(product_order order)
        {
            db.product_order.Add(order);
            db.SaveChanges();
            return order.ordid;
        }

        //Exist
        public bool exist(int id)
        {
            return (db.product_order.Any(o => o.ordid == id));
        }

        //edit
        public void edit(product_order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            product_order order = db.product_order.Find(id);
            db.product_order.Remove(order);
            db.SaveChanges();
        }
    }
}
