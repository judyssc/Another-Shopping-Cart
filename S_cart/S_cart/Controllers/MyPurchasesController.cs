using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using S_cart.Models;
using S_cart.DB;


namespace S_cart.Controllers
{
    public class MyPurchasesController : Controller
    {
        // GET: MyPurchases
        public ActionResult MyPurchases()
        {
            // Find session id here
            //Storing query result in purchase1
            List<Purchase> purchase1 = PurchaseData.purchasesdb();
            //Storing key-value pair with key as "list", value as purchase1
            //This is to use inside MyPurchases.cshtml 
            ViewData["list"] = purchase1;

            return View();
        }

        public ActionResult ManageActivation()
        {
            // Code for manage activation codes method
            return View();
        }
    }
}   
   