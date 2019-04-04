using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using S_cart.Models;
using System.Diagnostics;
using S_cart.DB;

namespace S_cart.Models
{
    public class list_product_helper
    {
        public List<product> list_products()
        {
            List<product> L1 = new List<product>();

            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string cmdtext = @"SELECT * FROM product_info";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    product p = new product();
                    p.name = (string)sdr["product_name"];
                    p.url = (string)sdr["image_url"];
                    p.price = (int)sdr["unit_price"];
                    p.product_id = (int)sdr["product_id"];
                    p.description = (string)sdr["product_description"];

                    L1.Add(p);
                    Debug.WriteLine(sdr["product_id"]);
                    Debug.WriteLine(sdr["product_name"]);
                }
                return L1;
            }

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
        public static List<product> Searchd(string search)
        {

            List<product> searchproduct = new List<product>();
            SqlConnection conn2 = new SqlConnection(Data.connectionString);
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand("select * from product_info where product_name LIKE '%" + search + "%'", conn2);
            SqlDataReader rdr2 = cmd2.ExecuteReader();

            while (rdr2.Read())
            {
                product prod2 = new product();
                {
                    prod2.product_id = (int)rdr2["product_id"];
                    prod2.name = (string)rdr2["product_name"];
                    prod2.price = (int)rdr2["unit_price"];
                    prod2.description = (string)rdr2["product_description"];
                    prod2.url = (string)rdr2["image_url"];
                }
                searchproduct.Add(prod2);
            }
            conn2.Close();
            return searchproduct;
        }
    }
}