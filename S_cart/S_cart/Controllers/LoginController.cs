using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using S_cart.Models;
using S_cart.DB;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace S_cart.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login(string Username, string Password)
        {
            //Check if username is null
            if (Username == null)
                return View();

            //Successful login by user
            //Call database (UserData.cs)
            User user = UserData.GetUserByUsername(Username);
            // User not found in database so is null
            if (user == null)
            {
                return View();
            }
            if (user.Password != Password)
                return View();  //Login screen(Index)

            //Start new session
            string sessionId = SessionData.CreateSession(user.Id);
            return RedirectToAction("Search", "Gallery", new { sessionId });
        }

        [HttpPost]     
        public JsonResult IsChecked(string Username)
        {
            if (Regex.IsMatch(Username.ToString(), "^[a-zA-Z0-9]+$"))
                return Json(true);
            return Json(false);
        }
    }
}