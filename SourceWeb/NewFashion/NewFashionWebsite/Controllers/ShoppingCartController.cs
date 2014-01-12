using NewFashionBLL;
using NewFashionBLL.BLL;
using NewFashionWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NewFashionWebsite.Controllers
{
    public class ShoppingCartController : Controller
    {
        public const string CartSession = "CART";
        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            CustomerBLL customerBLL = new CustomerBLL();
            
            List<shopping_cart> listCart = null;

            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            listCart = cartModel.GetCartItems();

            return View(listCart);
        }

        //
        // GET: /ShoppingCart/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ShoppingCart/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ShoppingCart/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ShoppingCart/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ShoppingCart/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ShoppingCart/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ShoppingCart/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        

        public ActionResult AddToCart(int idProduct, int quantity)
        {
            ProductBLL productBLL = new ProductBLL();
            
            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            product pro = productBLL.getProductById(idProduct);
            
            cartModel.AddToCart(pro,quantity);

            cartModel.UpdateCartSumary(this.HttpContext);
            return RedirectToAction("ShoppingCart","Home");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int idCart)
        {
            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            cartModel.RemoveFromCart(idCart);

            List<shopping_cart> listCart = null;
            listCart = cartModel.GetCartItems();

            ShoppingCartModel model = new ShoppingCartModel();
            model.listCart = listCart;
            model.total = cartModel.GetTotal();

            cartModel.UpdateCartSumary(this.HttpContext);
            return PartialView("PartialCartList", model);
        }

        [HttpPost]
        public ActionResult UpdateFromCart(int idCart,int quantity)
        {
            ProductBLL productBLL = new ProductBLL();
            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            shopping_cart cart = cartModel.getCartById(idCart);
            
            product pro = productBLL.getProductById(cart.proid);
            if (pro.proquantity >= quantity)
            {
                cart.count = quantity;
                cartModel.UpdateFromCart(cart);
                cartModel.UpdateCartSumary(this.HttpContext);
                return Json(new
                {
                    Message = "Cập nhật " + cart.product.proname + " số lượng " + quantity + " thành công",
                    Total = cartModel.GetTotal(),
                    TotalItem = pro.prostockprice*quantity,
                    Status = "Success"
                });
            }
            else
            {
                return Json(new
                {
                    Message = "Cập nhật " + cart.product.proname + " số lượng " + quantity + 
                    " thất bại, số lượng sản phẩm chỉ còn " + pro.proquantity + " cái",
                    Count = cart.count,
                    Status = "Error"
                });
            }
        }

        
    }
}
