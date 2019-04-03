using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using S_cart.Models;
using S_cart.DB;
using System.Diagnostics;
using System.Web.Configuration;

namespace S_cart.DB
{
    //Handle all queries relating to user
    public class UserData : Data
    {
        public static User GetUserByUsername(string username)
        {
            User user = new User();
            //string connectionString = "Server=DESKTOP-BINNY;" + "Database=ca_SHOPPING;" + "Integrated Security=true";
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT user_id, username, password,firstname,lastname,session_id from user_info
                    WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User();
                    user.Id = (int)reader["user_id"];
                    user.Username = (string)reader["username"];
                    user.Password = (string)reader["password"];
                    user.FirstName = (string)reader["firstname"];
                    user.LastName = (string)reader["lastname"];
                    //user.SessionId = (string)reader["session_id"];

                }
            }
            return user;   //pass to calling function (Login controller)
        }
    }
}