using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class AccountBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        public List<aspnet_Users> getAll()
        {
            var users = db.aspnet_Users;
            return users.ToList();
        }

        public int getCountOfUsers()
        {
            return db.aspnet_Users.Count();
        }

        public aspnet_Users getDetails(Guid id)
        {
            aspnet_Users user = db.aspnet_Users.Find(id);
            return user;
        }

        //khong ho tro membership nho them o ngoai
        public void create(aspnet_Users user)
        {
            //db.aspnet_Users.Add(user);
            //db.SaveChanges();
        }

        public bool exists(Guid id)
        {
            return db.aspnet_Users.Any(t => t.UserId == id);
        }

        public void edit(aspnet_Users user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        //khong ho tro membership nho xoa o ngoai
        public void delete(Guid id)
        {
            aspnet_Users user = getDetails(id);
            //CommentBLL commentBLL = new CommentBLL();
            //KHACH_HANG khachHang = db.KHACH_HANG.Find(id);
            //commentBLL.deleteUserComments(id);
            //db.KHACH_HANG.Remove(khachHang);

            db.SaveChanges();
        }
    }
}
