using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewFashionBLL;
using NewFashionWebsite.Models;

namespace NewFashionWebsite.Controllers
{
    public class SearchController : Controller
    {
        private NewFashionDBEntities db = new NewFashionDBEntities();
        //
        // GET: /Search/

        public ActionResult Index()
        {
            
            return View("AdvancedSearch");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Result(SearchModel model, int? page)
        {
            List<product> lstResult = db.products.Where(p => p.proname.Contains(model.keyWord)).ToList();

            page = page ?? 1;
            int soLuongTrenTrang = 10;
            var tongSoLuong = lstResult.Count;
            int index = ((int)page - 1) * 10;
            //var listProduct = productBLL.getListByIdCategory(index, soLuongTrenTrang, idCategory);
            if (lstResult.Count > soLuongTrenTrang)
            {
                if (lstResult.Count - (index + soLuongTrenTrang) >= 0)//Trường hợp trong list từ vị trí index có đủ n phần tử tiếp theo
                    lstResult = lstResult.GetRange(index, soLuongTrenTrang);
                else
                {
                    lstResult = lstResult.GetRange(index, lstResult.Count - index);
                }
            }

            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }

            @ViewBag.KEY_WORD = model.keyWord;
            @ViewBag.SEARCH_RESULT = lstResult;
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            return View("SearchResult", lstResult);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ajaxResult(SearchModel model, int? page)
        {
            List<product> lstResult = db.products.Where(p => p.proname.Contains(model.keyWord)).ToList();

            page = page ?? 1;
            int soLuongTrenTrang = 10;
            var tongSoLuong = lstResult.Count;
            int index = ((int)page - 1) * 10;
            //var listProduct = productBLL.getListByIdCategory(index, soLuongTrenTrang, idCategory);
            if (lstResult.Count > soLuongTrenTrang)
            {
                if (lstResult.Count - (index + soLuongTrenTrang) >= 0)//Trường hợp trong list từ vị trí index có đủ n phần tử tiếp theo
                    lstResult = lstResult.GetRange(index, soLuongTrenTrang);
                else
                {
                    lstResult = lstResult.GetRange(index, lstResult.Count - index);
                }
            }

            int soLuongTrang = tongSoLuong / soLuongTrenTrang;
            if (tongSoLuong % soLuongTrenTrang == 0)
            {
            }
            else
            {
                soLuongTrang += 1;
            }

            @ViewBag.KEY_WORD = model.keyWord;
            @ViewBag.SEARCH_RESULT = lstResult;
            @ViewBag.COUNT = soLuongTrang;
            @ViewBag.CURRENT_PAGE = page;
            return View("ajaxSearchResult", lstResult);
        }

    }
}
