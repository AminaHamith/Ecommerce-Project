using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFashionWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RevenueMgmtController : Controller
    {
        //
        // GET: /RevenueMgmt/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /RevenueMgmt/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /RevenueMgmt/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RevenueMgmt/Create

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
        // GET: /RevenueMgmt/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /RevenueMgmt/Edit/5

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
        // GET: /RevenueMgmt/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /RevenueMgmt/Delete/5

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
