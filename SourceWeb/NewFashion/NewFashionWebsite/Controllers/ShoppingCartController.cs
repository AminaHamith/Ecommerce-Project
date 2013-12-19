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
            return View();
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
        [HttpPost]
        public ActionResult AddToCart(int idProduct, int quantity)
        {
            ProductBLL productBLL = new ProductBLL();
            CustomerBLL customerBLL = new CustomerBLL();
            ShoppingCartBLL shoppingCartBLL = new ShoppingCartBLL();
            ShoppingCartModel model = null;

            if (Request.IsAuthenticated == true)
            {
                MembershipUser user = Membership.GetUser(User.Identity.Name);
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                shoppingCartBLL.AddToCart(idProduct, cus.cusid,quantity);

                int price = productBLL.getProductById(idProduct).prostockprice;
                int count = shoppingCartBLL.GetCount(cus.cusid);
                int total = shoppingCartBLL.GetTotal(cus.cusid);
                string result = (count).ToString() + " " + (total).ToString();
                model = new ShoppingCartModel
                {
                    listCart = shoppingCartBLL.GetCartItems(cus.cusid),
                    total = shoppingCartBLL.GetTotal(cus.cusid),
                };
                ViewBag.SHOPPING_CART = model;
            }
            else
            {
            }
            return PartialView("PartialShoppingCart");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int idCart)
        {
            CustomerBLL customerBLL = new CustomerBLL();
            ShoppingCartBLL shoppingCartBLL = new ShoppingCartBLL();

            shoppingCartBLL.RemoveFromCart(idCart);
            List<shopping_cart> listCart = null;
            if (Request.IsAuthenticated == true)
            {
                MembershipUser user = Membership.GetUser(User.Identity.Name);
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                listCart = shoppingCartBLL.GetCartItems(cus.cusid);
            }
            return PartialView("PartialCartList",listCart);
        }
    }
}
