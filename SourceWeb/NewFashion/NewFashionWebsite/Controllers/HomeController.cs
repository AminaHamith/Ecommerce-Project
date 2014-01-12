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

            ShoppingCartModel model = new ShoppingCartModel();
            model.listCart = listCart;
            model.total = cartModel.GetTotal();
            return View(model);
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
            CheckoutModel model = new CheckoutModel();
            CartModel cartModel = CartModel.GetCart(this.HttpContext);
            if (!string.IsNullOrWhiteSpace(User.Identity.Name))
            {
                MembershipUser user = Membership.GetUser(User.Identity.Name);
                CustomerBLL customerBLL = new CustomerBLL();
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                model.cart = new ShoppingCartModel();
                model.cart.listCart = cartModel.GetCartItems();
                model.cart.total = cartModel.GetTotal();
                model.customer = cus;
                if (cus.customer_information != null)
                {
                    model.arrival_information = cus.customer_information;
                }
                else
                {
                    model.arrival_information = new customer_information();
                }
                model.arrival_information.firstname = cus.cusfirstname;
                model.arrival_information.lastname = cus.cuslastname ;
                model.arrival_information.email = cus.aspnet_Users.aspnet_Membership.Email;
            }
            else
            {

            }
            List<SelectListItem> items1 = new List<SelectListItem>();
            items1.Add(new SelectListItem { Text = "Chọn phương thức", Value = "0" });
            items1.Add(new SelectListItem { Text = "Trong vòng 1 tuần", Value = "1" });
            items1.Add(new SelectListItem { Text = "Trong vòng 5 ngày", Value = "2" });
            items1.Add(new SelectListItem { Text = "Trong vòng 2 ngày", Value = "3" });
            items1.Add(new SelectListItem { Text = "Trong vòng 1 ngày", Value = "4" });
            ViewBag.SHIPPING_METHOD = items1;

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "Chọn phương thức", Value = "0" });
            items2.Add(new SelectListItem { Text = "Tại cửa hàng", Value = "1" });
            items2.Add(new SelectListItem { Text = "Tại nhà", Value = "2" });

            ViewBag.DELIVERY_METHOD = items2;
            return View(model);
        }

        //
        // POST: /Home/Checkout

        [HttpPost]
        public ActionResult Checkout(CheckoutModel model)
        {
            if(ModelState.IsValid)
            {
                customer_information cusInfo = new customer_information();
                cusInfo.address1 = model.address1;
                cusInfo.address2 = model.address2;
                cusInfo.city = model.city;
                cusInfo.country = model.country;
                cusInfo.email = model.Email;
                cusInfo.firstname = model.firstname;
                cusInfo.lastname = model.lastname;
                cusInfo.phonenumber1 = model.phonenumber1;
                cusInfo.phonenumber2 = model.phonenumber2;
                cusInfo.region_state = model.region_state;

                CustomerInfoBLL cusInfoBLL = new CustomerInfoBLL();
                int idCusInfo = cusInfoBLL.create(cusInfo);
                product_order order = new product_order();
                order.idarrival_information = idCusInfo;
                order.ordstatus = 0;
                order.ordcreate_date = DateTime.Now;
                order.idbuyer_information = idCusInfo;
                order.idpayment_method = 1;
                order.idshipping_method = model.shipping.id;
                order.iddelivery_method = model.delivery.id;

                MembershipUser user = Membership.GetUser(User.Identity.Name);
                CustomerBLL customerBLL = new CustomerBLL();
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                order.cusid = cus.cusid;
                OrderBLL orderBLL = new OrderBLL();
                int idOrder = orderBLL.create(order);

                OrderDetailBLL orderDetailBLL = new OrderDetailBLL();

                CartModel cartModel = CartModel.GetCart(this.HttpContext);
                List<shopping_cart> listCart = cartModel.GetCartItems();

                foreach (shopping_cart item in listCart)
                {
                    order_detail orderDetail = new order_detail();
                    orderDetail.ordid = idOrder;
                    orderDetail.ordquantity = item.count;
                    orderDetail.ordtotalprice = item.count * item.product.prostockprice;
                    orderDetail.proid = item.proid;
                    orderDetail.ordsaleprice = 0;
                    orderDetail.currency_code = "VND";

                    orderDetailBLL.create(orderDetail);
                }
            }

            return View("CheckoutSuccess");
            
        }

        public ActionResult CheckoutSuccess()
        {
            return View();
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
