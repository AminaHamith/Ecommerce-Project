using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class CategoryBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get List
        public List<category> getList()
        {
            return db.categories.ToList();
        }

        //get List By id parent 
        public category getByIDParent(int idParent)
        {
            return db.categories.Where(c => c.catparent == idParent).ToList().FirstOrDefault();
        }

        //get By id
        public category getCategoryById(int id)
        {
            return db.categories.Where(c => c.catid == id).FirstOrDefault();
        }

        //get By name
        public category getCategoryByName(string name)
        {
            return db.categories.Where(c => c.catname == name).FirstOrDefault();
        }
        //lấy tất cả id category con
        public List<int> getIdCategoryChild(int idCategory)
        {
            List<int> listIdCategory = new List<int>();
            listIdCategory.Add(idCategory);
            
            List<category> list = getList();
            foreach(category category in list)
            {
                if (category.catparent == idCategory)
                {
                    List<int> listId = getIdCategoryChild(category.catid);
                    foreach(int i in listId)
                    {
                        listIdCategory.Add(i);
                    }
                }
            }
            return listIdCategory;
        }

        //get full name category
        public string getFullNameCategory(int idCategory)
        {
            string name = "";
            List<int> list = getListIdCategoryParent(idCategory);
            foreach(int i in list)
            {
                category cat = getCategoryById(i);
                if(list.Last() == i)
                    name = name + cat.catname;
                else
                    name = name + cat.catname + " - ";
            }
            return name.ToUpper();
        }

        public List<int> getListIdCategoryParent(int idCategory)
        {
            List<int> listId = new List<int>();
            List<category> list = getList();
           
            listId.Add(idCategory);
            category category = getCategoryById(listId.Last());
            while (category.catparent != 0)
            {
                foreach (category cat in list)
                {
                    if (category.catparent == cat.catid)
                    {
                        listId.Add(cat.catid);
                        category = cat;
                    }
                }
            }
            
            return listId;
        }

        public List<category> getListCategoryLeaf()
        {
            List<category> listLeaf = new List<category>();
            List<category> listAll = db.categories.ToList();

            foreach (category cat1 in listAll)
            {
                category cat = cat1;
                bool flag = true;
                foreach (category cat2 in listAll)
                {
                    if (cat2.catparent == cat.catid)//cat1 là cha
                    {
                        flag = false;
                        break;
                    }
                    
                }
                if (flag == true)//nếu ko thấy ai có cha là cat1
                {
                    listLeaf.Add(cat1);
                }
            }
            return listLeaf;
        }
        //create 
        public void create(category _category)
        {
            db.categories.Add(_category);
            db.SaveChanges();
        }

        //Exist
        public bool exist(int id)
        {
            return (db.categories.Any(c => c.catid == id));
        }

        //edit
        public void edit(category _category)
        {
            db.Entry(_category).State = EntityState.Modified;
            db.SaveChanges();
        }

        //delete
        public void delete(int id)
        {
            category _category = db.categories.Find(id);
            db.categories.Remove(_category);
            db.SaveChanges();
        }
    }
}
