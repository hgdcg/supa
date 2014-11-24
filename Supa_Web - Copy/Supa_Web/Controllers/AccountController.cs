using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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
            return View();
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
                    if (query.Count()==1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return View();
                }
            }
        }
    }
}