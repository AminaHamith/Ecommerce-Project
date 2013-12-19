using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ShippingMethodBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        public List<shipping_method> getList()
        {
            return db.shipping_method.ToList();
        }
    }
}
