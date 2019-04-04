using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using S_cart.Models;
using System.Web.Configuration;
using System.Diagnostics;
using S_cart.DB;

namespace S_cart.DB
{
    public class PurchaseData : Data
    {
        //Handle all queries relating to purchase
        public static List<Purchase> purchasesdb()
        {
            string current_session_id = SessionData.getSessionId();
            List<Purchase> purchase1 = new List<Purchase>();

            //Instantiate the connection
            SqlConnection conn = new SqlConnection(Data.connectionString);
            
                conn.Open();

            string userid_query = "select user_id from user_info where session_id = '" + current_session_id + "'";

            //Instantiate a new command with a query and connection
            string cmdtext = @"select c.user_id, p.product_id, count(p.product_id) as Quantity, p.product_name,p.image_url, p.product_description, c.date_time, c.activation_code" +
                                            " from cart_info c join product_info p on c.product_id = p.product_id" +
                                            " where c.user_id = (" + userid_query + ") and c.status_code = 1" +
                                            " group by c.user_id, p.product_id, p.product_name, p.image_url, p.product_description, c.date_time, c.activation_code" +
                                            " order by c.user_id, p.product_id, p.product_name, p.image_url, p.product_description, c.date_time, c.activation_code";
            SqlCommand cmd = new SqlCommand(cmdtext, conn);

            //Call Execute reader to get query results
            SqlDataReader sdr = cmd.ExecuteReader();

            //Print out each record
            while (sdr.Read())
            {
                Purchase purc = new Purchase();
                {
                    purc.productid = (int)sdr["product_id"];
                    purc.quantity = (int)sdr["Quantity"];
                    purc.product_name = (string)sdr["product_name"];
                    purc.image = (string)sdr["image_url"];
                    purc.productdesc = (string)sdr["product_description"];
                    purc.purchasedate = (string)sdr["date_time"];
                    purc.activationcode = (string)sdr["activation_code"];
                }
                purchase1.Add(purc);
                Debug.WriteLine(sdr["product_id"]);
            }

            return purchase1;
        }
    }
}