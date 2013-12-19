using NewFashionBLL;
using NewFashionBLL.BLL;
using NewFashionWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewFashionWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductMgmtController : Controller
    {
        private ProductBLL productBLL = new ProductBLL();
        private CategoryBLL categoryBLL = new CategoryBLL();
        //
        // GET: /ProductMgmt/

        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            int soLuongTrenTrang = 10;
            var tongSoLuong = productBLL.getCountProduct();

            int index = ((int)page - 1) * 10;
            List<product> list = productBLL.getList(index, soLuongTrenTrang);
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

        [HttpPost]
        public ActionResult Index(int page)
        {
            int soLuongTrenTrang = 10;
            var tongSoLuong = productBLL.getCountProduct();

            int index = ((int)page - 1) * 10;
            List<product> list = productBLL.getList(index, soLuongTrenTrang);
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
            return View("PartialProductListMgmt", list);
        }
        //
        // GET: /ProductMgmt/Details/5

        public ActionResult Details(int id)
        {
            product pro = productBLL.getProductById(id);
            return View(pro);
        }

        //
        // GET: /ProductMgmt/Create

        public ActionResult Create()
        {

            List<category> listLeaf = categoryBLL.getListCategoryLeaf();


            List<SelectListItem> itemsCategory = new List<SelectListItem>();
            foreach (category cat in listLeaf)
            {
                itemsCategory.Add(new SelectListItem { Text = categoryBLL.getFullNameCategory(cat.catid), Value = cat.catid.ToString() });
            }
            ViewBag.CATEGORIES = itemsCategory;
            return View();
        }

        //
        // POST: /ProductMgmt/Create

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int idHinhDaiDien = model.luuAnhDaiDien();

                    model.product.imgthumbid = idHinhDaiDien;
                    model.product.datearrival = DateTime.Now;
                    productBLL.create(model.product);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                }
            }
            List<category> listLeaf = categoryBLL.getListCategoryLeaf();
            List<SelectListItem> itemsCategory = new List<SelectListItem>();
            foreach (category cat in listLeaf)
            {
                itemsCategory.Add(new SelectListItem { Text = categoryBLL.getFullNameCategory(cat.catid), Value = cat.catid.ToString() });
            }

            ViewBag.TEMP = model.product.procatid.ToString();
            ViewBag.CATEGORIES = itemsCategory;
            return View(model);
        }

        //
        // GET: /ProductMgmt/Edit/5

        public ActionResult Edit(int id)
        {
            product pro = productBLL.getProductById(id);
            return View(pro);
        }

        //
        // POST: /ProductMgmt/Edit/5

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
        // GET: /ProductMgmt/Delete/5

        public ActionResult Delete(int id)
        {
            product pro = productBLL.getProductById(id);
            return View(pro);
        }

        //
        // POST: /ProductMgmt/Delete/5

        [HttpPost]
        public ActionResult Delete(int page, int idProduct)
        {
            productBLL.delete(idProduct);

            int soLuongTrenTrang = 10;
            var tongSoLuong = productBLL.getCountProduct();

            int index = (page - 1) * 10;
            List<product> list = productBLL.getList(index, soLuongTrenTrang);
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
            return View("PartialProductListMgmt", list);
        }
    }
}
