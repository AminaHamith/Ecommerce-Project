using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFashionWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderMgmtController : Controller
    {
        //
        // GET: /OrderMgmt/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /OrderMgmt/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OrderMgmt/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderMgmt/Create

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
        // GET: /OrderMgmt/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OrderMgmt/Edit/5

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
        // GET: /OrderMgmt/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrderMgmt/Delete/5

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
    }
}
