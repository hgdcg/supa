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
            using (var db = new Entities())
            {
                var query = from user in db.Users
                            where user.Password == model.Password
                            && user.UserName == model.UserName
                            select user;
                if (query.Count() > 0)
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session["User"] = null;
            Session["LogInState"] = false;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            if (TempData["RegisterModel"] != null)
            {
                model = (RegisterModel)TempData["RegisterModel"];
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new Entities())
            {
                User newUser = new User();
                newUser.UserName = model.UserName;
                newUser.Password = model.Password;
                db.Users.Add(newUser);
                db.SaveChanges();

                // Now fetch this new user from DB
                var query = from user in db.Users
                            where user.UserName == model.UserName
                            orderby -user.UserId
                            select user;
                foreach (var user in query)
                {
                    newUser = (User)user;
                    break;
                }
                Session["User"] = newUser;
                Session["LogInState"] = true;
            }
            return RedirectToAction("Index", "Home");
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
            if (TempData["CartPage"] != null)
            {
                model.CurrentPage = (int)TempData["CartPage"];
            }

            User user = (User)Session["User"];

            using (var db = new Entities())
            {
                var query = from order in db.Orders
                            where order.User.UserId == user.UserId
                            orderby order.GoodID
                            select order;

                // Calculate total amount of money
                foreach (Order order in query)
                {
                    model.TotalAmount += (double)order.Inventory.Price * (double)order.Amount;
                }

                model.PageNumber = (int)Math.Ceiling((double)(query.Count() / model.PageLength));
                var result = query.Skip(model.PageLength * (model.CurrentPage - 1)).Take(model.PageLength);
                model.Orders.Clear();
                foreach (Order order in result)
                {
                    model.Orders.Add(order);
                }
            }

            TempData["CartPage"] = model.CurrentPage;
            TempData["CartPageNumber"] = model.PageNumber;
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult CartFirstPage()
        {
            TempData["CartPage"] = 1;
            return RedirectToAction("Cart", "Account");
        }
        [AllowAnonymous]
        public ActionResult CartNextPage()
        {
            TempData["CartPage"] = (int)TempData["CartPage"] + 1;
            return RedirectToAction("Cart", "Account");
        }
        [AllowAnonymous]
        public ActionResult CartPreviousPage()
        {
            TempData["CartPage"] = (int)TempData["CartPage"] - 1;
            return RedirectToAction("Cart", "Account");
        }
        [AllowAnonymous]
        public ActionResult CartLastPage()
        {
            TempData["CartPage"] = TempData["CartPageNumber"];
            return RedirectToAction("Cart", "Account");
        }
        [AllowAnonymous]
        public ActionResult CartDelete(String GoodName)
        {
            User user = (User)Session["User"];

            using (var db = new Entities())
            {
                var query = from order in db.Orders
                            where order.UserId == user.UserId
                            where order.GoodID == GoodName
                            select order;
                foreach (var order in query)
                {
                    db.Orders.Remove(order);
                }
                db.SaveChanges();
            }
            TempData["CartPage"] = 1;
            return RedirectToAction("Cart", "Account");
        }
        [AllowAnonymous]
        public ActionResult ChangeOrderNumber(Boolean Plus, String GoodName)
        {
            User user = (User)Session["User"];

            using (var db = new Entities())
            {
                var query = from order in db.Orders
                            where order.UserId == user.UserId
                            where order.GoodID == GoodName
                            select order;
                foreach (var order in query)
                {
                    if (Plus)
                        order.Amount += 1;
                    else order.Amount -= 1;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Cart", "Account");
        }
    }
}