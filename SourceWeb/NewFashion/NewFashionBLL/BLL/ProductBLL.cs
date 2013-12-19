using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ProductBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<product> getList()
        {
            return db.products.ToList();
        }

        //get List
        public List<product> getList(int index, int n)
        {
            List<product> list = db.products.ToList();
            //list.OrderByDescending();
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

        //get List by idCategory
        public List<product> getListByIdCategory(int idCategory)
        {
            List<product> list = db.products.Where(p => p.procatid == idCategory).ToList();
           
            return list;
        }

        //get List by idCategory
        public List<product> getListByIdCategory(int index, int n, int idCategory)
        {
            CategoryBLL categoryBLL = new CategoryBLL();
            List<int> listIdCategory = categoryBLL.getIdCategoryChild(idCategory);
            List<product> list = new List<product>();
            foreach(int i in listIdCategory)
            {
                List<product> listTemp = db.products.Where(p => p.procatid == i).ToList();
                if(listTemp != null)
                {
                    foreach (product p in listTemp)
                    {
                        list.Add(p);
                    }
                }
            }
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

        //get List Top n Bestsellers
        public List<product> getListBestSellers(int n)
        {
            List<product> list = db.products.ToList();
            OrderDetailBLL orderDetailBLL = new OrderDetailBLL();
            foreach (product p in list)
            {
                int quantity = orderDetailBLL.getCountOrderByIdProduct(p.proid);
                p.proquantityorder = quantity;
            }
            list.OrderByDescending(p => p.proquantityorder);
            if (list != null)
            {
                if (list[0].proquantityorder == 0)
                {
                    return null;
                }
                if (list.Count <= n)
                {
                    return list;
                }
                else
                {
                    list = list.GetRange(0, n);
                    return list;
                }
            }
            return null;
        }

        //get List Top n NewArrival
        public List<product> getListNewArrival(int n)
        {
            List<product> list = db.products.OrderByDescending(p => p.datearrival).ToList();
            if (list != null)
            {
                if (list.Count <= n)
                {
                    return list;
                }
                else
                {
                    list = list.GetRange(0, n);
                    return list;
                }
            }
            return null;
        }

        //get Count List by idCategory
        public int getCountByIdCategory(int idCategory)
        {
            CategoryBLL categoryBLL = new CategoryBLL();
            List<int> listIdCategory = categoryBLL.getIdCategoryChild(idCategory);
            List<product> list = new List<product>();
            foreach (int i in listIdCategory)
            {
                List<product> listTemp = db.products.Where(p => p.procatid == i).ToList();
                if (listTemp != null)
                {
                    foreach (product p in listTemp)
                    {
                        list.Add(p);
                    }
                }
            }
            return list.Count;
        }

        //get By id
        public product getProductById(int id)
        {
            return db.products.Where(sp => sp.proid == id).FirstOrDefault();
        }

        //create 
        public void create(product _product)
        {
            db.products.Add(_product);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.products.Any(p => p.proid == id));
        }

        //edit
        public void edit(product _product)
        {
            db.Entry(_product).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            product _product = db.products.Find(id);
            db.products.Remove(_product);
            db.SaveChanges();
        }

        public int getCountProduct()
        {
            return db.products.Count();
        }
    }
}
