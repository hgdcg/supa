using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Supa_Web.Models;

namespace Supa_Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogIn()
        {
            LogInModel model = new LogInModel();
            if (TempData["LogInModel"] != null)
            {
                model = (LogInModel)TempData["LogInModel"];
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                using (var db = new Entities())
                {
                    var query = from user in db.Users
                                where user.Password == model.Password
                                && user.UserName == model.UserName
                                select user;
                    if (query.Count() == 1)
                    {
                        // In fact there is only one user here.
                        foreach (User user in query)
                        {
                            Session["User"] = user;
                            Session["LogInState"] = true;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    return View();
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Cart()
        {

            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            CartModel model = new CartModel();
            if (TempData["CartModel"] != null)
            {
                model = (CartModel)TempData["CartModel"];
            }

            User user = (User)Session["User"];

            using (var db = new Entities())
            {
                var query = from order in db.Orders
                            where order.User.UserId == user.UserId
                            orderby order.GoodID
                            select order;
                model.PageNumber = (int)(query.Count() / model.PageLength + 1);
                var result = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                model.Orders.Clear();
                foreach (Order order in result)
                {
                    model.Orders.Add(order);
                }
            }

            return View(model);
        }
    }
}