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
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            con = new SqlConnection(constr);
        }
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
        public List<Barang> ShowDetailItems()
        {
            connection();
            List<Barang> barangDBs = new List<Barang>();
            SqlCommand com = new SqlCommand("ShowListBarang", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                barangDBs.Add(

                new Barang
                {

                    ID = Convert.ToInt32(dr["ID"]),
                    Nama_Barang = Convert.ToString(dr["Nama_Barang"]),
                    Tipe_Barang = Convert.ToString(dr["Tipe_Barang"]),
                    Ukuran = Convert.ToString(dr["Ukuran"]),
                    Harga = Convert.ToInt32(dr["Harga"]),
                    Images = Convert.ToString(dr["Images"]),
                    Tanggal_Muncul = Convert.ToString(dr["Tanggal_Muncul"]),

                }
                );
            }
            return barangDBs;
        }
    }
}