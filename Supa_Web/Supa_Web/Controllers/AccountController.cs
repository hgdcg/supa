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
                        IndexModel indexModel = new IndexModel();
                        indexModel.LogInState = true;
                        indexModel.UserName = model.UserName;
                        TempData["IndexModel"] = indexModel;
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }
            }
        }
    }
}