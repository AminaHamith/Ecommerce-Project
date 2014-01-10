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
    public partial class CartModel
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        ShoppingCartBLL shoppingCartBLL = new ShoppingCartBLL();
        public const string CartSessionKey = "CART_ID";
        System.Guid CustomerId { get; set; }

        public static CartModel GetCart(HttpContextBase context)
        {
            var cart = new CartModel();
            cart.CustomerId = System.Guid.Parse(cart.GetCartIdCustomer(context));
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static CartModel GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public String GetCartIdCustomer(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    CustomerBLL customerBLL = new CustomerBLL();
                    System.Guid idCustomer = customerBLL.getByUserName(context.User.Identity.Name).cusid;
                    context.Session[CartSessionKey] = idCustomer.ToString();
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        //get list cart of customer
        public List<shopping_cart> GetCartItems()
        {
            return shoppingCartBLL.GetCartItems(this.CustomerId);
        }

        
        //get cart by id
        public shopping_cart getCartById(int idCart)
        {
            return shoppingCartBLL.getCartById(idCart);
        }

        //get cart by idProduct and idCustomer
        public shopping_cart GetCartByIdProduct(int idProduct)
        {
            return shoppingCartBLL.GetCartByIdProduct(idProduct,CustomerId);
        }

        //add product to cart
        public void AddToCart(product product, int quantity)
        {
            //Lấy 1 dòng trong cart của customer mua sản phẩm
            shopping_cart cartItem = GetCartByIdProduct(product.proid);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new shopping_cart
                {
                    proid = product.proid,
                    count = quantity,
                    cusid = CustomerId,
                    create_date = DateTime.Now
                };

                shoppingCartBLL.AddToCart(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.count++;
                shoppingCartBLL.UpdateCart(cartItem);
            }

        }

        public void RemoveFromCart(int idCart)
        {
            // Get the cart
            shopping_cart cartItem = shoppingCartBLL.getCartById(idCart);
            shoppingCartBLL.RemoveFromCart(cartItem);
        }
        public int UpdateFromCart(int idCart)
        {
            // Get the cart
            shopping_cart cartItem = shoppingCartBLL.getCartById(idCart);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.count > 1)
                {
                    cartItem.count--;
                    shoppingCartBLL.UpdateCart(cartItem);
                    itemCount = cartItem.count;
                }
                else
                {
                    shoppingCartBLL.RemoveFromCart(cartItem);
                }

            }

            return itemCount;
        }
        public void EmptyCart()
        {
            shoppingCartBLL.EmptyCart(this.CustomerId);
        }



        public int GetCount()
        {
            return shoppingCartBLL.GetCount(this.CustomerId);
        }

        public int GetTotal()
        {
            return shoppingCartBLL.GetTotal(this.CustomerId);
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        // Sau khi khách hàng đăng nhập cập nhật lại cusid của các dòng trong shopping_cart
        public void MigrateCart(System.Guid newCusId)
        {
            shoppingCartBLL.MigrateCart(this.CustomerId,newCusId);
            this.CustomerId = newCusId;
        }
    }
}