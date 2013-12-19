using NewFashionBLL;
using NewFashionBLL.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFashionWebsite.Models
{
    public partial class ShoppingCartModel1
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        ShoppingCartBLL shoppingCartBLL;
        public const string CartSessionCustomerKey = "CART_CUSTOMER_ID";
        System.Guid CustomerId { get; set; }

        public static ShoppingCartModel1 GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCartModel1();
            cart.CustomerId = System.Guid.Parse(cart.GetCartIdCustomer(context));
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static ShoppingCartModel1 GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public String GetCartIdCustomer(HttpContextBase context)
        {
            if (context.Session[CartSessionCustomerKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    CustomerBLL customerBLL = new CustomerBLL();
                    System.Guid idCustomer = customerBLL.getByUserName(context.User.Identity.Name).cusid;
                    context.Session[CartSessionCustomerKey] = idCustomer.ToString();
                }
                /*else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionCustomerKey] = tempCartId.ToString();
                }*/
            }
            return context.Session[CartSessionCustomerKey].ToString();
        }

        //get list cart of customer
        public List<shopping_cart> GetCartItems()
        {
            return db.shopping_cart.Where(cart => cart.cusid == this.CustomerId).ToList();
        }

        /*
        //get cart by id
        public shopping_cart getCartById(int idCart)
        {
            return db.shopping_cart.Where(c => c.id == this.shoppingCart.id).FirstOrDefault();
        }*/

        //get cart by idProduct and idCustomer
        public shopping_cart GetCartByIdProduct(int idProduct)
        {
            return db.shopping_cart.Where(c => c.proid == idProduct).Where(c => c.cusid == CustomerId).FirstOrDefault();
        }

        //add product to cart
        public void AddToCart(product product)
        {
            //Lấy 1 dòng trong cart của customer mua sản phẩm
            shopping_cart cartItem = GetCartByIdProduct(product.proid);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new shopping_cart
                {
                    proid = product.proid,
                    count = 1,
                    cusid = CustomerId,
                    create_date = DateTime.Now
                };

                db.shopping_cart.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.count++;
                db.Entry(cartItem).State = EntityState.Modified;
            }

            // Save changes
            db.SaveChanges();
        }

        public int RemoveFromCart(int idCart)
        {
            // Get the cart
            shopping_cart cartItem = db.shopping_cart.Where(c => c.id == idCart).FirstOrDefault();

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.count > 1)
                {
                    cartItem.count--;
                    itemCount = cartItem.count;
                }
                else
                {
                    db.shopping_cart.Remove(cartItem);
                }

                // Save changes
                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            List<shopping_cart> cartItems = db.shopping_cart.Where(cart => cart.cusid == CustomerId).ToList();

            foreach (var cartItem in cartItems)
            {
                db.shopping_cart.Remove(cartItem);
            }

            // Save changes
            db.SaveChanges();
        }



        public int GetCount()
        {
            return 0;
        }

        public int GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            int? total = (from cartItems in db.shopping_cart
                          where cartItems.cusid == CustomerId
                          select cartItems.count * cartItems.product.prostockprice).Sum();
            return total ?? 0;
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        // Sau khi khách hàng đăng nhập cập nhật lại cusid của các dòng trong shopping_cart
        public void MigrateCart(System.Guid idCus)
        {
            var shoppingCart = db.shopping_cart.Where(c => c.cusid == CustomerId);

            foreach (shopping_cart item in shoppingCart)
            {
                item.cusid = idCus;
            }
            db.SaveChanges();
        }
    }
}