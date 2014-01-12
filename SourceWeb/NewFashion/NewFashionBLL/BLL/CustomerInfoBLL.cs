using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class CustomerInfoBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<customer_information> getList()
        {
            return db.customer_information.ToList();
        }

        //get By id
        public customer_information getCustomerInfoById(int id)
        {
            return db.customer_information.Where(c => c.id == id).FirstOrDefault();
        }

        

        //get By code
        /*public size getSizeByCode(string code)
        {
            return db.sizes.Where(c => c.sizecode == code).FirstOrDefault();
        }*/

        //create 
        public int create(customer_information cusInfo)
        {
            db.customer_information.Add(cusInfo);
            db.SaveChanges();
            return cusInfo.id;
        }

        //Exist
        public bool exist(int id)
        {
            return (db.customer_information.Any(c => c.id == id));
        }

        //edit
        public void edit(customer_information cusInfo)
        {
            db.Entry(cusInfo).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            customer_information cusInfo = db.customer_information.Find(id);
            db.customer_information.Remove(cusInfo);
            db.SaveChanges();
        }
    }
}
