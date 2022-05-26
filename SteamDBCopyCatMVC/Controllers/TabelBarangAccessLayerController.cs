using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;

namespace SteamDBCopyCatMVC.Controllers
{
    public class TabelBarangAccessLayerController : Controller
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection("cs");
        public string AddEmployeeRecord(TabelBarang employeeEntities)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Employee_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nama_Barang", employeeEntities.Nama_Barang);
                cmd.Parameters.AddWithValue("@Tipe_Barang", employeeEntities.Tipe_Barang);
                cmd.Parameters.AddWithValue("@Ukuran", employeeEntities.Ukuran);
                cmd.Parameters.AddWithValue("@Harga", employeeEntities.Harga);
                cmd.Parameters.AddWithValue("@Halal", employeeEntities.Halal);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

        // GET: TabelBarangAccessLayer
        public ActionResult Index()
        {
            return View();
        }
    }
}