using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class PaymentMethodBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        public List<payment_method> getList()
        {
            return db.payment_method.ToList();
        }
    }
}
