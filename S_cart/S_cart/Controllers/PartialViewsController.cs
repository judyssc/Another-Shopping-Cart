using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_cart.Models;

namespace S_cart.Controllers
{
    public class PartialViewsController : Controller
    {
        // GET: PartialViews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViews(string page)
        {
            //initializing a User object and setting values - to be used in layout page
            User user = new User();
            user.Id = 1;
            user.FirstName = "first name"; //need to call method from UserData
            user.LastName = "last name";
            user.Username = "username";
            user.Password = "password";
            user.SessionId = "123";
            ViewData["user"] = user;

            //using ViewData, pass the object with parameter to view
            
            ViewData["type"] = page; 
            return View();
        }
    }
}