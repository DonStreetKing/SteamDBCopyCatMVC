/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SteamDBCopyCatMVC.Models
{
    public class ModelUntukWishlistKeknya
    {
        public static SqlConnection connect()
        {
            string connection = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
            else
            {
                con.Open();
            }
            return con;
        }

        public bool DMLOpperation(string query)
        {
            cmd = new SqlCommand(query, ModelUntukWishlistKeknya.connect());
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelactAll(string query)
        {
            da = new SqlDataAdapter(query, ModelUntukWishlistKeknya.connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}*/