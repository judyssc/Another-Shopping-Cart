using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_cart.Models;

namespace S_cart.Controllers
{
    public class PartialViewController : Controller
    {
        // GET: PartialView,
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViews(string title)
        {
            User user = new User();
            user.FirstName = "firstname";
            user.LastName = "lastname";
            ViewData["user"] = user;

            return View(); 
        }
    }
}