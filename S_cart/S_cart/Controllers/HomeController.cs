using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_cart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ListProducts()
        {
            // Code for list products method
            return View();
        }

        public ActionResult ViewPurchase()
        {
            // Code for view purchase history
            return View();
        }

        public ActionResult Logout()
        {
            // Code for logout
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}