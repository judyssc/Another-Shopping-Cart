using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_cart.Models;

namespace S_cart.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        
        public ActionResult Search()
        {
            list_product_helper new_1 = new list_product_helper();
            List<product> L1 = new_1.list_products();
            ViewData["list"] = L1;
                    
            // Code for search method (if needed)
            return View();
        }

        public ActionResult AddtoCart()
        {
            // Code for add to cart method 
            return View();
        }

        public ActionResult ViewCart()
        {
            // Code for view cart method 
            return View();
        }
    }
}