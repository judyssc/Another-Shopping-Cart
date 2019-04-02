using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using S_cart.Models;
using System.Diagnostics;
using System.Web.Configuration;

namespace S_cart.DB
{
    //Handle all queries relating to user
    public class UserData : Data
    {
        public static User GetUserByUsername(string username)
        {
            User user = null;

            //Able to use connection string freely as UserData is inherited
            //from Data parent class
            //using (SqlConnection conn = new SqlConnection(Data.connectionString))
            //{
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                conn.Open();

                string sql = @"SELECT user_id, username, password from user_info
                    WHERE firstname = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User()
                    {
                        Id = (int)reader["user_id"],
                        Password = (string)reader["password"]
                    };
                }
            //}
            return user;    //pass to calling function (Login controller)
        }
    }
}