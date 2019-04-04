using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_cart.Models;
using System.Data.SqlClient;
using System.Diagnostics;
using S_cart.DB;

namespace S_cart.Controllers
{
    public class ViewCartController : Controller
    {
        // GET: ViewCart
        public ActionResult ViewCart(int u_id, string user_name)
        {
            list_cart_helper new_1 = new list_cart_helper();
            List<Cart> L1 = new_1.list_cart(u_id);
            ViewData["list"] = L1;
            ViewData["uid"] = u_id;
            ViewData["user"]= user_name;

            int cart_count = new_1.cart_count(u_id);
            ViewData["count"] = cart_count;

            return View();
        }

        public ActionResult rfc(int u_id, int p_id)
        {
            removefromcart(u_id, p_id);

            return RedirectToAction("ViewCart", new { u_id = u_id });
        }


        public static void removefromcart(int user_id, int p_id)
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string cmdtext = @"delete from cart_info where product_id="+p_id+" and user_id="+user_id;
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                cmd.ExecuteNonQuery();
            }
        }
    }

    internal class list_cart_helper
    {
        public List<Cart> list_cart(int u_id)
        {
            List<Cart> L1 = new List<Cart>();

            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string cmdtext = @"select p.product_id, count(p.product_id) as count,  p.product_name,p.image_url,p.unit_price from cart_info c join product_info p on c.product_id = p.product_id where c.user_id = "+u_id+" and c.status_code = 0 group by p.product_id,p.product_name,p.image_url,p.unit_price";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Cart c = new Cart();
                    c.product_name = (string)sdr["product_name"];
                    c.product_id = (int)sdr["product_id"];
                    c.image_url = (string)sdr["image_url"];
                    c.unit_price = (int)sdr["unit_price"];
                    c.quantity = (int)sdr["count"];

                    L1.Add(c);

                    Debug.WriteLine(sdr["product_id"]);
                    Debug.WriteLine(sdr["product_name"]);
                    Debug.WriteLine(sdr["image_url"]);
                    Debug.WriteLine(sdr["unit_price"]);
                    Debug.WriteLine(sdr["count"]);
                }
            }
            return L1;
        }
        public int cart_count(int user_id)
        {
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string cmdtext = @"select count(*) as count from cart_info where user_id =" + user_id + "and status_code=0";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                int count = (int)cmd.ExecuteScalar();
                return count;
            }
        }
    }
}