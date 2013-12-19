using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class OrderDetailBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<order_detail> getList()
        {
            return db.order_detail.ToList();
        }
        
        //get List
        public List<order_detail> getListByIdProduct(int idProduct)
        {
            return db.order_detail.Where(o => o.proid == idProduct).ToList();
        }

        //get count order By idProduct
        public int getCountOrderByIdProduct(int idProduct)
        {
            return db.order_detail.Where(o => o.proid == idProduct).Count(); ;
        }

        //get By id
        public order_detail getOrderDetailById(int id)
        {
            return db.order_detail.Where(o => o.id == id).FirstOrDefault();
        }
        
        //create 
        public void create(order_detail _order_detail)
        {
            db.order_detail.Add(_order_detail);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.order_detail.Any(o => o.id == id));
        }

        //edit
        public void edit(order_detail _order_detail)
        {
            db.Entry(_order_detail).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            order_detail _order_detail = db.order_detail.Find(id);
            db.order_detail.Remove(_order_detail);
            db.SaveChanges();
        }
    }
}
