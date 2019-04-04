using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using S_cart.Models;
using System.Diagnostics;
using S_cart.DB;


namespace S_cart.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        
        public ActionResult Search(string fname,string lname, string sess_id , int uid)
        {
            list_product_helper new_1 = new list_product_helper();
            List<product> L1 = new_1.list_products();
            ViewData["list"] = L1;
            ViewData["user"] = fname + " " + lname;
            ViewData["uid"] = uid;

            int cart_count = new_1.cart_count(uid);
            ViewData["count"] = cart_count;
            
            return View();

        }

        [HttpPost]
        public ActionResult Search(int count, int uid , string search)
        {
            search = Request.Form["searchqueery"];
            List<product> search1 = list_product_helper.Searchd(search);
            ViewData["list"] = search1;
            ViewData["uid"] = uid;
            ViewData["count"] = count;
            return View();
        }


        [HttpPost]
        public JsonResult AddtoCart(string id)
        {
            Debug.WriteLine(id);
            // Code for add to cart method 
            return Json("ok",JsonRequestBehavior.AllowGet);
        }

        public ActionResult rtc (int u_id, int p_id)
        {
            addtocart(u_id,p_id);

            return RedirectToAction("Search",new { uid = u_id });
        }

        public ActionResult rtc_remove(int u_id, int p_id)
        {
            removefromcart(u_id, p_id);

            return RedirectToAction("Search", new { uid = u_id });
        }

        public static void addtocart(int user_id, int p_id)
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string cmdtext = @"insert into cart_info (user_id,product_id,status_code) values ("+ user_id + ","+ p_id + ",0)";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();
            }
        }
        public static void removefromcart(int user_id, int p_id)
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string cmdtext = @"delete from  cart_info where cart_id in (select TOP 1 cart_id from cart_info where user_id ="+user_id+" and product_id="+p_id+"  order by cart_id desc )";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}