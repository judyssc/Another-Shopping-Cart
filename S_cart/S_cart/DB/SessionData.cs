﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace S_cart.DB
{
    // Handle all queries pertaining to Session
    
public class SessionData : Data
    {
        static string session_id;
        public static bool IsActiveSessionId(string sessionId)
        {
            
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) FROM user_info
                    WHERE session_Id = '" + sessionId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = (int)cmd.ExecuteScalar();
                return (count == 1);
            }
        }

        public static string CreateSession(int userId)
        {
            
            string sessionId = Guid.NewGuid().ToString();

            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"UPDATE user_info SET session_id = '" + sessionId + "'" +
                        " WHERE user_id =" + userId;
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }

            return sessionId;
        }

        public static void RemoveSession(string sessionId)
        {
            
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();
                string sql = @"UPDATE user_info SET session_id = NULL 
                    WHERE session_id = '" + sessionId + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static string getSessionId()
        {
            return session_id;
        }
    }
}