using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SteamDBCopyCatMVC.Models
{
    public class BarangDB
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public List<Barang> ListAll()
        {
            List<Barang> barang = new List<Barang>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ShowListBarang", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    barang.Add(new Barang
                    {
                        ID = Convert.ToInt32(rdr["ID"]),
                        Nama_Barang = rdr["Nama_Barang"].ToString(),
                        Tipe_Barang = rdr["Tipe_Barang"].ToString(),
                        Ukuran = rdr["Ukuran"].ToString(),
                        Harga = Convert.ToInt32(rdr["Harga"]),
                        Images = rdr["Images"].ToString(),
                        Tanggal_Muncul = rdr["Tanggal_Muncul"].ToString(),
                    });
                }
                return barang;
            }
        }
    }
}