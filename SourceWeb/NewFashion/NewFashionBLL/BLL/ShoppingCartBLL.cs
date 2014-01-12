using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFashionBLL.BLL
{
    public class ShoppingCartBLL
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();

        //get list cart of customer
        public List<shopping_cart> GetCartItems(System.Guid idCustomer)
        {
            return db.shopping_cart.Include("product").Where(s => s.cusid == idCustomer).ToList();
        }

        //get cart by id
        public shopping_cart getCartById(int idCart)
        {
            return db.shopping_cart.Where(c => c.id == idCart).FirstOrDefault();
        }

        //get cart by idProduct and idCustomer
        public shopping_cart getCartById(int idProduct, System.Guid idCustomer)
        {
            return db.shopping_cart.Where(c => c.proid == idProduct).Where(c => c.cusid == idCustomer).FirstOrDefault();
        }

        //add product to cart
        public void AddToCart(shopping_cart cart)
        {
            db.shopping_cart.Add(cart);
            db.SaveChanges();
        }
        //add product to cart
        public void AddToCart(int idProduct,System.Guid idCustomer,int quantity)
        {
            shopping_cart cartItem = getCartById(idProduct, idCustomer);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new shopping_cart
                {
                    proid = idProduct,
                    count =  quantity,
                    cusid = idCustomer,
                    create_date = DateTime.Now
                };

                db.shopping_cart.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.count += quantity;
                db.Entry(cartItem).State = EntityState.Modified;
            }

            // Save changes
            db.SaveChanges();
        }

        public void UpdateCart(shopping_cart cart)
        {
            db.Entry(cart).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void RemoveFromCart(int idCart)
        {
            // Get the cart
            shopping_cart cartItem = getCartById(idCart);


            if (cartItem != null)
            {
                db.shopping_cart.Remove(cartItem);
                // Save changes
                db.SaveChanges();
            }
        }
        public void RemoveFromCart(shopping_cart cart)
        {
                db.shopping_cart.Remove(cart);
                // Save changes
                db.SaveChanges();
        }
        public shopping_cart GetCartByIdProduct(int idProduct,System.Guid CustomerId)
        {
            return db.shopping_cart.Where(c => c.proid == idProduct).Where(c => c.cusid == CustomerId).FirstOrDefault();
        }
        public void EmptyCart(System.Guid idCustomer)
        {
            List<shopping_cart> cartItems = db.shopping_cart.Where(cart => cart.cusid == idCustomer).ToList();

            foreach (var cartItem in cartItems)
            {
                db.shopping_cart.Remove(cartItem);
            }

            // Save changes
            db.SaveChanges();
        }

        

        public int GetCount(System.Guid idCustomer)
        {
            List<shopping_cart> list = db.shopping_cart.Where(s => s.cusid == idCustomer).ToList();
            if (list.Count <= 0)
            {
                return 0;
            }
            else
            {
                int? total = (from cartItems in db.shopping_cart
                              where cartItems.cusid == idCustomer
                              select cartItems.count).Sum();
                return total ?? 0;
            }
        }

        public int GetTotal(System.Guid idCustomer)
        {
            List<shopping_cart> list = db.shopping_cart.Where(s => s.cusid == idCustomer).ToList();
            if (list.Count <= 0)
            {
                return 0;
            }
            else
            {
                int? total = (from cartItems in db.shopping_cart
                              where cartItems.cusid == idCustomer
                              select cartItems.count * cartItems.product.prostockprice).Sum();
                return total ?? 0;
            }
        }

        public void MigrateCart(System.Guid curCusId, System.Guid newCusId)
        {
            var shoppingCart = db.shopping_cart.Where(c => c.cusid == curCusId);

            foreach (shopping_cart item in shoppingCart)
            {
                item.cusid = newCusId;
                db.Entry(item).State = System.Data.EntityState.Modified;
            }
            db.SaveChanges();
        }
    }
}
