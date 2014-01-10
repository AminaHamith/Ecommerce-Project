using NewFashionBLL;
using NewFashionBLL.BLL;
using NewFashionWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;

namespace NewFashionWebsite.Controllers
{
    public class HomeController : Controller
    {
        ProductBLL productBLL = new ProductBLL();
        ImageBLL imageBLL = new ImageBLL();
        ImageSlideBLL imageSlideBLL = new ImageSlideBLL();
        CategoryBLL categoryBLL = new CategoryBLL();

        public class ShoppingCartAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                // Don't bother running this for child action or ajax requests
                if (!filterContext.IsChildAction && !filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
                {
                    
                }
                ProductBLL productBLL = new ProductBLL();
                CustomerBLL customerBLL = new CustomerBLL();
                ShoppingCartBLL shoppingCartBLL = new ShoppingCartBLL();

                //int price = productBLL.getProductById(idProduct).prostockprice;
                if (filterContext.RequestContext.HttpContext.Request.IsAuthenticated == true)
                {
                    ShoppingCartModel model = null;
                    MembershipUser user = Membership.GetUser(filterContext.HttpContext.User.Identity.Name);
                    customer cus = customerBLL.getById((Guid)user.ProviderUserKey);
                    int count = shoppingCartBLL.GetCount(cus.cusid);
                    int total = shoppingCartBLL.GetTotal(cus.cusid);
                    string result = (count).ToString() + " " + (total).ToString();
                    model = new ShoppingCartModel
                    {
                        listCart = shoppingCartBLL.GetCartItems(cus.cusid),
                        total = shoppingCartBLL.GetTotal(cus.cusid),
                    };
                    filterContext.Controller.ViewBag.SHOPPING_CART = model;
                }
                //List<shopping_cart> listCart = 
                //filterContext.Controller.ViewBag.CART = 
            }
        }
        //
        // GET: /Home/
         
        public ActionResult Index()
        {
            var listImageSlides = imageSlideBLL.getList();
            var listProductBestsellers = productBLL.getListBestSellers(6);
            var listProductNewArrival = productBLL.getListNewArrival(6);
            @ViewBag.LIST_IMAGE_SLIDES = listImageSlides;
            @ViewBag.LIST_BEST_SELLERS = listProductBestsellers;
            @ViewBag.LIST_NEW_ARRIVAL = listProductNewArrival;
            return View();
        }

        //
        // GET: /Home/About
         
        public ActionResult About()
        {
            return View();
        }

        //
        // POST: /Home/About

        [HttpPost]
        public ActionResult About(FormCollection collection)
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
        // GET: /Home/Contact
         
        public ActionResult Contact()
        {
            return View();
        }

        //
        // POST: /Home/Contact

        [HttpPost]
        public ActionResult Contact(FormCollection collection)
        {
            try
            {
                //throw new Exception();
                foreach (string _formData in collection)
                {
                    ViewData[_formData] = collection[_formData];
                }

                string message = "Họ tên: " + ViewData["name"].ToString() + "<br />"
                    + "Email: " + ViewData["email"].ToString() + "<br />"
                    + "Nội dung: " + ViewData["message"].ToString();

                bool send = AccountController.SendMail("[Khách hàng liên hệ] " + ViewData["email"].ToString(), message, "gaulucky92@gmail.com", true, false);

                if (send)
                {
                    return View("SendMessageSuccess");
                }
                return View("SendMessageFailure");
            }
            catch (Exception)
            {
                return View("SendMessageFailure");
            }
        }

        //
        // GET: /Home/ProductDetail
         
        public ActionResult ProductDetail(int idProduct)
        {
            product pro = productBLL.getProductById(idProduct);
            return View(pro);
        }

        //
        // POST: /Home/ProductDetail

        [HttpPost]
        public ActionResult ProductDetail(FormCollection collection)
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
        // GET: /Home/Search

        public ActionResult Search()
        {
            return View();
        }

        //
        // POST: /Home/Search

        [HttpPost]
        public ActionResult Search(FormCollection collection)
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
        // GET: /Home/ShoppingCart
         
        public ActionResult ShoppingCart()
        {
            CustomerBLL customerBLL = new CustomerBLL();
            ShoppingCartBLL shoppingCartBLL = new ShoppingCartBLL();
            List<shopping_cart> listCart = null;

            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            listCart = cartModel.GetCartItems();

            return View(listCart);
        }

        //
        // POST: /Home/ShoppingCart

        [HttpPost]
        public ActionResult ShoppingCart(FormCollection collection)
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
        // GET: /Home/Checkout
         
        public ActionResult Checkout()
        {
            return View();
        }

        //
        // POST: /Home/Checkout

        [HttpPost]
        public ActionResult Checkout(FormCollection collection)
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
        // GET: /Home/ProductList
         
        public ActionResult ProductList(int idCategory, int? page)
        {
            page = page ?? 1;
            int soLuongTrenTrang = 10;
            var tongSoLuong = productBLL.getCountByIdCategory(idCategory);
            int index = ((int)page - 1)* 10;
            var listProduct = productBLL.getListByIdCategory(index, soLuongTrenTrang, idCategory);

            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }
            @ViewBag.ID_CATEGORY = idCategory;
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            @ViewBag.CATEGORY_NAME = categoryBLL.getFullNameCategory(idCategory);
            return View(listProduct);
        }

        //
        // POST: /Home/ProductList

        [HttpPost]
        public ActionResult getProductList(int idCategory,int page)
        {
            int soLuongTrenTrang = 10;
            var tongSoLuong = productBLL.getCountByIdCategory(idCategory);
            int index = (page - 1) * 10;
            List<product> listProduct = productBLL.getListByIdCategory(index, soLuongTrenTrang, idCategory);

            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }
            @ViewBag.ID_CATEGORY = idCategory;
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            @ViewBag.CATEGORY_NAME = categoryBLL.getFullNameCategory(idCategory);
            return PartialView("PartialProductList", listProduct);
        }

        //
        // GET: /Home/PurchaseHistory
         
        public ActionResult PurchaseHistory()
        {
            return View();
        }

        //
        // POST: /Home/PurchaseHistory

        [HttpPost]
        public ActionResult PurchaseHistory(FormCollection collection)
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
        // GET: /Home/Brands
         
        public ActionResult Brands()
        {
            return View();
        }

        //
        // POST: /Home/Brands

        [HttpPost]
        public ActionResult Brands(FormCollection collection)
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
        // GET: /Home/Compare
         
        public ActionResult Compare()
        {
            return View();
        }

        //
        // POST: /Home/Compare

        [HttpPost]
        public ActionResult Compare(FormCollection collection)
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
        // GET: /Home/Wishlist
         
        public ActionResult Wishlist()
        {
            return View();
        }

        //
        // POST: /Home/Wishlist

        [HttpPost]
        public ActionResult Wishlist(FormCollection collection)
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

    }
}
