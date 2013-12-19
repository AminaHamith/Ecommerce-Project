using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class DeliveryMethodBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        public List<delivery_method> getList()
        {
            return db.delivery_method.ToList();
        }
    }
}
