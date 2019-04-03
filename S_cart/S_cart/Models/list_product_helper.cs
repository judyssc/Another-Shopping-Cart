using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using S_cart.Models;
using System.Diagnostics;

namespace S_cart.Models
{
    public class list_product_helper
    {
        public List<product> list_products()
        {
            List<product> L1 = new List<product>();

            using (SqlConnection conn = new SqlConnection("Server=DESKTOP-BINNY;" + "Database=ca_SHOPPING;" + "Integrated Security=true"))
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
        }
}