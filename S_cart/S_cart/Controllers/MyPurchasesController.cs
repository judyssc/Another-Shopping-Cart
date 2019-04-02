using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_cart.Controllers
{
    public class MyPurchasesController : Controller
    {
        // GET: MyPurchases
        public ActionResult MyPurchases()
        {
            
            return View();
        }

        public ActionResult ManageActivation()
        {
            // Code for manage activation codes method
            return View();
        }
    }
}