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

using System.Text;
using System.Security.Cryptography;

namespace S_cart.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login(string Username, string Password)
        {
            //Check if username is null
            if (Username == null)
                return View();

            string hashpwd = MD5Hash(Password);
            Debug.WriteLine(hashpwd);

            //Successful login by user
            //Call database (UserData.cs)
            User user = UserData.GetUserByUsername(Username);
            // User not found in database so is null
            if (user == null)
            {
                return View();
            }
            if (user.Password != hashpwd)
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

        public static string MD5Hash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}