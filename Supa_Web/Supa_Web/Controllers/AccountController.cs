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
                        User user = query.ElementAt<User>(0);
                        IndexModel indexModel = new IndexModel();
                        indexModel.LogInState = true;
                        indexModel.User = user;
                        TempData["IndexModel"] = indexModel;
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Cart()
        {
            CartModel model = new CartModel();
            if (TempData["LogInModel"] != null)
            {
                model = (CartModel)TempData["LogInModel"];
            }

            using (var db = new Entities())
            {
                var query = from order in db.Orders
                            where order.User.UserId == model.User.UserId
                            select order;
                model.PageNumber = (int)(query.Count() / model.PageLength + 1);
                query = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                model.Orders.Clear();
                foreach (Order order in query)
                {
                    model.Orders.Add(order);
                }
            }

            return View(model);
        }
    }
}