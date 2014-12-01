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
        // Here we define allGoods as String because Boolean can never be null
        public ActionResult GoodsList(String allGoods, string type3)
        {
            GoodsListModel model = new GoodsListModel();
            if (allGoods != null)
            {
                // Here means we clicked "All Goods"
                if (allGoods == "True")
                    TempData["GoodType"] = null;
                //Here means we clicked a specific type
                else
                    TempData["GoodType"] = type3;
            }
            // We came here by paging
            else
            {
                if (TempData["GoodPage"] != null)
                    model.CurrentPage = (int)TempData["GoodPage"];
                if (TempData["GoodType"] != null)
                    type3 = (String)TempData["GoodType"];
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

                if (type3 == null)
                {
                    var query = from goods in db.Goods
                                orderby goods.GoodID
                                select goods;
                    model.PageNumber = (int)Math.Ceiling((double)query.Count() / (double)model.PageLength);
                    if (model.PageNumber == 0)
                        model.PageNumber = 1;
                    var result = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                    model.Good.Clear();
                    foreach (Good goods in result)
                    {
                        model.Good.Add(goods);
                        foreach (Inventory inventory in goods.Inventories)
                        {
                            model.Prices.Add((double)inventory.Price);
                        }
                    }
                }
                else
                {
                    var query = from goods in db.Goods
                                where goods.Class3 == type3
                                orderby goods.GoodID
                                select goods;
                    model.PageNumber = (int)Math.Ceiling((double)query.Count() / (double)model.PageLength);
                    var result = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                    model.Good.Clear();
                    foreach (Good good in result)
                    {
                        model.Good.Add(good);
                        foreach (Inventory inventory in good.Inventories)
                        {
                            model.Prices.Add((double)inventory.Price);
                        }
                    }
                }

                if (model.PageNumber < model.CurrentPage)
                {
                    model.CurrentPage = 1;
                }
            }

            TempData["GoodPage"] = model.CurrentPage;
            TempData["GoodPageNumber"] = model.PageNumber;
            TempData["GoodType"] = type3;
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