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
        public int ID_Barang { get; set; }
        public string Images { get; set; }
        public string Nama_Barang { get; set; }
        public string Tipe_Barang { get; set; }
        public string Ukuran { get; set; }
        public int Harga { get; set; }
        public string Tanggal_Muncul { get; set; }
        public int Stok_Barang { get; set; }
    }
    public class ProductDetailAccess
    {
        public static List<Barang> GetAllProduct(int ID_Barang)
        {
            List<Barang> ProductList = new List<Barang>();

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from TabelBarang where ID_Barang = @ID_Barang", con);
                SqlParameter param = new SqlParameter("@ID_Barang", ID_Barang);
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Barang ProductDetail = new Barang();
                    ProductDetail.ID_Barang = Convert.ToInt32(rdr["ID_Barang"]);
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