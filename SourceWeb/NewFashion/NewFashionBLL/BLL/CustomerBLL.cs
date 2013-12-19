using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class CustomerBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<customer> getList()
        {
            return db.customers.ToList();
        }

        //get List
        public List<customer> getList(int index, int n)
        {
            List<customer> list = db.customers.ToList();
            list.OrderByDescending(c => c.aspnet_Users.UserName);
            if (list != null)
            {
                if (list.Count <= n)
                {
                    return list;
                }
                else
                {
                    if (list.Count - (index + n) >= 0)//Trường hợp trong list từ vị trí index có đủ n phần tử tiếp theo
                        list = list.GetRange(index, n);
                    else
                    {
                        list = list.GetRange(index, list.Count - index);
                    }
                    return list;
                }
            }
            return null;
        }

        public customer getByUserName(String username)
        {
            return db.customers.Where(c => c.aspnet_Users.UserName == username).FirstOrDefault();
        }

        public customer getById(System.Guid id)
        {
            return db.customers.Where(m => m.cusid == id).FirstOrDefault();
        }

        public int getCountCustomer()
        {
            return db.customers.Count();
        }
        //create 
        public void create(customer cus)
        {
            db.customers.Add(cus);
            db.SaveChanges();
        }

        //Exist
        public bool exist(System.Guid id)
        {
            return (db.customers.Any(c => c.cusid == id));
        }

        //edit
        public void edit(customer _customer)
        {
            db.Entry(_customer).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(System.Guid id)
        {
            customer _customer = db.customers.Find(id);
            db.customers.Remove(_customer);
            db.SaveChanges();
        }


    }
}
