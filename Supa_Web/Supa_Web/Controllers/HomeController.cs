using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Supa_Web.Models;

namespace Supa_Web.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            IndexModel model = new IndexModel();
            if (TempData["IndexModel"] != null)
            {
                model = (IndexModel)TempData["IndexModel"];
            }
            if (Session["LogInState"] == null)
            {
                Session["LogInState"] = false;
            }

            using (var db = new Entities())
            {
                var query1 = from types1 in db.Types1
                             select types1;
                foreach (Types1 types1 in query1)
                {
                    model.Types1.Add(types1);
                }

                var query2 = from types2 in db.Types2
                             select types2;
                foreach (Types2 types2 in query2)
                {
                    model.Types2.Add(types2);
                }

                var query3 = from types3 in db.Types3
                             select types3;
                foreach (Types3 types3 in query3)
                {
                    model.Types3.Add(types3);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GoodsList()
        {
            GoodsListModel model = new GoodsListModel();
            if (TempData["GoodsListModel"] != null)
            {
                model = (GoodsListModel)TempData["GoodsListModel"];
            }
            if (TempData["GoodPage"] != null)
            {
                model.CurrentPage = (int)TempData["GoodPage"];
            }

            using (var db = new Entities())
            {
                var query1 = from types1 in db.Types1
                             select types1;
                foreach (Types1 types1 in query1)
                {
                    model.Types1.Add(types1);
                }

                var query2 = from types2 in db.Types2
                             select types2;
                foreach (Types2 types2 in query2)
                {
                    model.Types2.Add(types2);
                }

                var query3 = from types3 in db.Types3
                             select types3;
                foreach (Types3 types3 in query3)
                {
                    model.Types3.Add(types3);
                }

                var query = from goods in db.Goods
                            orderby goods.GoodID
                            select goods;
                model.PageNumber = (int)Math.Ceiling((double)(query.Count() / model.PageLength));
                var result = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                model.Good.Clear();
                foreach (Good goods in result)
                {
                    model.Good.Add(goods);
                }
            }
            TempData["GoodPage"] = model.CurrentPage;
            TempData["GoodPageNumber"] = model.PageNumber;
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult GoodFirstPage()
        {
            TempData["GoodPage"] = 1;
            return RedirectToAction("GoodsList", "Home");
        }
        [AllowAnonymous]
        public ActionResult GoodNextPage()
        {
            TempData["GoodPage"] = (int)TempData["GoodPage"] + 1;
            return RedirectToAction("GoodsList", "Home");
        }
        [AllowAnonymous]
        public ActionResult GoodPreviousPage()
        {
            TempData["GoodPage"] = (int)TempData["GoodPage"] - 1;
            return RedirectToAction("GoodsList", "Home");
        }
        [AllowAnonymous]
        public ActionResult GoodLastPage()
        {
            TempData["GoodPage"] = TempData["GoodPageNumber"];
            return RedirectToAction("GoodsList", "Home");
        }
    }
}