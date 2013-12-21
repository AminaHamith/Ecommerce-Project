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
    [Authorize(Roles = "Admin")]
    public class CustomerMgmtController : Controller
    {
        private CustomerBLL customerBLL = new CustomerBLL();
        //
        // GET: /CustomerMgmt/

        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            int soLuongTrenTrang = 10;
            var tongSoLuong = customerBLL.getCountCustomer();

            int index = ((int)page - 1) * 10;
            List<customer> list = customerBLL.getList(index, soLuongTrenTrang);
            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            return View(list);
        }


        //
        // Post: /CustomerMgmt/
        [HttpPost]
        public ActionResult Index(int page)
        {
            int soLuongTrenTrang = 10;
            var tongSoLuong = customerBLL.getCountCustomer();

            int index = ((int)page - 1) * 10;
            List<customer> list = customerBLL.getList(index, soLuongTrenTrang);
            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            return View("PartialCustomerList", list);
        }
        //
        // GET: /CustomerMgmt/Details/5

        public ActionResult Details(System.Guid id)
        {
            customer cus = customerBLL.getById(id);

            /*ViewData["id"] = cus.cusid;
            ViewData["name"] = cus.cusfirstname + " " + cus.cuslastname;
            ViewData["gender"] = cus.customer_information.gender == "M" ? "Nam" : "Nữ";
            ViewData["birthday"] = cus.customer_information.birthday.Value.ToString("dd/MM/yyyy");
            ViewData["address1"] = cus.customer_information.address1;
            ViewData["address2"] = cus.customer_information.address2;
            ViewData["city"] = cus.customer_information.city;
            ViewData["country"] = cus.customer_information.country;
            ViewData["postcode"] = cus.customer_information.post_code;
            ViewData["tel1"] = cus.customer_information.phonenumber1;
            ViewData["tel2"] = cus.customer_information.phonenumber2;*/
            
            return View(cus);
        }

        //
        // GET: /CustomerMgmt/Create

        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Nam", Value = "0" });
            items.Add(new SelectListItem { Text = "Nữ", Value = "1" });
            items.Add(new SelectListItem { Text = "Khác", Value = "2" });

            ViewBag.GENDER = items;

            RegisterModel model = new RegisterModel();
            return View(model);
        }

        //
        // POST: /CustomerMgmt/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (Membership.GetUser(model.accountModel.Username) != null)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại, vui lòng nhập tên đăng nhập khác.");
                }
                else
                {
                    try
                    {
                        MembershipUser user = Membership.CreateUser(model.accountModel.Username, model.accountModel.Password, model.accountModel.Email);
                        Roles.AddUserToRole(model.accountModel.Username, "Customer");
                        customer cus = new customer();
                        cus = model.customerModel;
                        cus.cusid = (Guid)user.ProviderUserKey;

                        CustomerBLL customerBLL = new CustomerBLL();
                        customerBLL.create(cus);

                        //FormsAuthentication.SetAuthCookie(model.accountModel.Username, true);
                        return RedirectToAction("CreateCustomerSuccess");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", "Có lỗi trong quá trình tạo.");
                    }
                }
            }
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Nam", Value = "0" });
            items.Add(new SelectListItem { Text = "Nữ", Value = "1" });
            items.Add(new SelectListItem { Text = "Khác", Value = "2" });

            ViewBag.GENDER = items;
            return View(model);
        }

        //
        // GET: /CustomerMgmt/Edit/5

        public ActionResult Edit(System.Guid id)
        {
            return View();
        }

        //
        // POST: /CustomerMgmt/Edit/5

        [HttpPost]
        public ActionResult Edit(System.Guid id, FormCollection collection)
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
        // GET: /CustomerMgmt/Delete/5

        public ActionResult Delete(System.Guid id)
        {
            return View();
        }

        //
        // POST: /CustomerMgmt/Delete/5

        [HttpPost]
        public ActionResult Delete(int page, System.Guid idCustomer)
        {
            customer cus = customerBLL.getById(idCustomer);

            
            if (Roles.IsUserInRole(cus.aspnet_Users.UserName, "Admin"))
            {
                Roles.RemoveUserFromRole(cus.aspnet_Users.UserName, "Admin");
            }
            if (Roles.IsUserInRole(cus.aspnet_Users.UserName, "Customer"))
            {
                Roles.RemoveUserFromRole(cus.aspnet_Users.UserName, "Customer");
            }
            customerBLL.delete(idCustomer);
            Membership.DeleteUser(cus.aspnet_Users.UserName);
            
            int soLuongTrenTrang = 10;
            var tongSoLuong = customerBLL.getCountCustomer();
            
            int index = (page - 1) * 10;
            List<customer> list = customerBLL.getList(index, soLuongTrenTrang);
            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            return View("PartialCustomerList", list);
        }

        public ActionResult CreateCustomerSuccess()
        {
            return View();
        }
    }
}
