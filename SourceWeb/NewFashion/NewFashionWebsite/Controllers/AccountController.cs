using NewFashionBLL;
using NewFashionBLL.BLL;
using NewFashionWebsite.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Recaptcha;
using System.IO;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;

namespace NewFashionWebsite.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
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
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(AccountModel model)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.Username, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Username, true);
                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");

            return View(model);
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginInLayout()
        {
            NameValueCollection nvc = Request.Form;
            String username = nvc["username"];
            String password = nvc["password"];
            if (Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
            AccountModel model = new AccountModel();
            model.Username = username;
            
            return View("Login",model);
        }

        //
        // POST: /Account/Logout

        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
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
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [RecaptchaControlMvc.CaptchaValidator]
        public ActionResult Register(RegisterModel model, bool captchaValid, string captchaErrorMessage)
        {
            if (!captchaValid)
                ModelState.AddModelError("captcha", captchaErrorMessage);
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

                        FormsAuthentication.SetAuthCookie(model.accountModel.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", "Có lỗi trong quá trình đăng ký.");
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
        // GET: /Account/ChangeInformation
        [ShoppingCartAttribute]
        public ActionResult ChangeInformation()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            RegisterModel model = new RegisterModel();
            if (user != null)
            {
                model.accountModel = new AccountModel();
                model.accountModel.Username = user.UserName;
                model.accountModel.Email = user.Email;

                //model.customerModel = new customer();
                CustomerBLL customerBLL = new CustomerBLL();
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                model.customerModel = cus;
            }
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Nam", Value = "0" });
            items.Add(new SelectListItem { Text = "Nữ", Value = "1" });
            items.Add(new SelectListItem { Text = "Khác", Value = "2" });

            ViewBag.GENDER = items;
            return View(model);
        }

        //
        // POST: /Account/ChangeInformation

        [HttpPost]
        public ActionResult ChangeInformation(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                CustomerBLL customerBLL = new CustomerBLL();

                customerBLL.edit(model.customerModel);
                return RedirectToAction("ChangeInformationSuccess");
            }
            return View();
        }

        //
        // GET: /Account/ChangePassword
        [ShoppingCartAttribute]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePasswordAjax(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name);
                    changePasswordSucceeded = currentUser.ChangePassword(model.CurrentPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return Json(new { url = Url.Action("ChangePasswordSuccess") });
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu hiện tại không chính xác");
                }
            }
            return PartialView("PartialValidationSummary");
            //return View(model);
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [ShoppingCartAttribute]
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            ResetPasswordModel model = new ResetPasswordModel();
            return View(model);
        }

        //
        // POST: /Account/ResetPassword

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            StreamReader sr = new StreamReader(HttpContext.Server.MapPath("/Content/template_email/ResetPassword.html"));
            sr = System.IO.File.OpenText(HttpContext.Server.MapPath("/Content/template_email/ResetPassword.html"));
            if (ModelState.IsValid)
            {
                MembershipUser user = Membership.GetUser(model.Username);
                if (user != null)
                {
                    if (user.Email.Equals(model.Email))
                    {
                        string pass = user.ResetPassword();
                        string content = sr.ReadToEnd();
                        content = content.Replace("[Username]", model.Username);
                        content = content.Replace("[Password]", pass);
                        bool send = AccountController.SendMail("Khôi phục mật khẩu", content, model.Email, true, false);
                        if (send)
                        {
                            return RedirectToAction("ResetPasswordSuccess");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Gửi email thất bại. Vui lòng kiểm tra lại kết nối mạng.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email không đúng như đăng ký.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản nhập không đúng.");
                }
            }
            return View(model);
        }

        //
        // GET: /Account/Information
        [ShoppingCartAttribute]
        public ActionResult Information()
        {
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            RegisterModel model = new RegisterModel();
            if (user != null)
            {
                model.accountModel = new AccountModel();
                model.accountModel.Username = user.UserName;
                model.accountModel.Email = user.Email;

                //model.customerModel = new customer();
                CustomerBLL customerBLL = new CustomerBLL();
                customer cus = customerBLL.getById((Guid)user.ProviderUserKey);

                model.customerModel = cus;
            }
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Nam", Value = "0" });
            items.Add(new SelectListItem { Text = "Nữ", Value = "1" });
            items.Add(new SelectListItem { Text = "Khác", Value = "2" });

            ViewBag.GENDER = items;
            return View(model);
        }
        [ShoppingCartAttribute]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        [ShoppingCartAttribute]
        [AllowAnonymous]
        public ActionResult ResetPasswordSuccess()
        {
            return View();
        }
        [ShoppingCartAttribute]
        public ActionResult ChangeInformationSuccess()
        {
            return View();
        }
        public static String FromAddress
        {
            get
            {
                SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection
                    ("system.net/mailSettings/smtp");
                return cfg.Network.UserName;
            }
        }
        public static bool SendMail(string subject, string body, string to, bool isHtml, bool isSSL)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(FromAddress, "NEWFASHION");
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = isHtml;
                    SmtpClient client = new SmtpClient();
                    client.EnableSsl = true;
                    client.Send(mail);
                }
            }
            catch (SmtpException ex)
            {
                return false;
            }
            return true;
        }
    }

}
