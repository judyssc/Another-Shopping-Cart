using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_cart.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        
        public ActionResult Search()
        {
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