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
            return View(model);
        }

    }
}