using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SteamDBCopyCatMVC.Models
{
    public class Barang
    {
        public int ID { get; set; }
        public string Images { get; set; }
        public string Nama_Barang { get; set; }
        public string Tipe_Barang { get; set; }
        public string Ukuran { get; set; }
        public int Harga { get; set; }
        public string Tanggal_Muncul { get; set; }
    }
    public class ProductDetailAccess
    {
        public static List<Barang> GetAllProduct(int ID)
        {
            List<Barang> ProductList = new List<Barang>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from TabelBarang where ID = @ID", con);
                SqlParameter param = new SqlParameter("@ID", ID);
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Barang ProductDetail = new Barang();
                    ProductDetail.ID = Convert.ToInt32(rdr["ID"]);
                    ProductDetail.Nama_Barang = rdr["Nama_Barang"].ToString();
                    ProductDetail.Tipe_Barang = rdr["Tipe_Barang"].ToString();
                    ProductDetail.Ukuran = rdr["Ukuran"].ToString();
                    ProductDetail.Harga = Convert.ToInt32(rdr["Harga"]);

                    ProductList.Add(ProductDetail);
                }
            }
            return ProductList;
        }
    }
}