using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SteamDBCopyCatMVC.EDMX;
using SteamDBCopyCatMVC.Models;
using SteamDBCopyCatMVC.Repository;
using PagedList;
using System.Dynamic;

namespace SteamDBCopyCatMVC.Controllers
{
    public class HomeController : Controller
    {
        public SomeRep _unitOfWork = new SomeRep();
        SteamDBCopyCatEntities dBCopyCatEntities = new SteamDBCopyCatEntities();
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        BarangDB barangDB = new BarangDB();
        Model4Chart model4Charts = new Model4Chart();

        public ActionResult HomeScreen()
        {
            return View(from Nama_Barang in dBCopyCatEntities.TabelBarangs.Take(5) select Nama_Barang);
        }
        public JsonResult List()
        {
            return Json(barangDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ListAllItem_OLD()
        {
            return View();
        }
        public ActionResult ListAllItem(string option, string search, int? pageNumber, string sort)
        {
            //if the sort parameter is null or empty then we are initializing the value as descending name  
            ViewBag.SortByName = string.IsNullOrEmpty(sort) ? "descending Nama_Barang" : "";
            //if the sort value is gender then we are initializing the value as descending gender  
            ViewBag.SortByGender = sort == "Tipe_Barang" ? "descending tipe_barang" : "Tipe_Barang";

            //here we are converting the db.Students to AsQueryable so that we can invoke all the extension methods on variable records.  
            var records = dBCopyCatEntities.TabelBarangs.AsQueryable();

            if (option == "Ukuran")
            {
                records = records.Where(x => x.Ukuran == search || search == null);
            }
            else if (option == "Tipe_Barang")
            {
                records = records.Where(x => x.Tipe_Barang == search || search == null);
            }
            else
            {
                records = records.Where(x => x.Nama_Barang.StartsWith(search) || search == null);
            }

            switch (sort)
            {

                case "descending name":
                    records = records.OrderByDescending(x => x.Nama_Barang);
                    break;

                case "descending gender":
                    records = records.OrderByDescending(x => x.Tipe_Barang);
                    break;

                case "Gender":
                    records = records.OrderBy(x => x.Tipe_Barang);
                    break;

                default:
                    records = records.OrderBy(x => x.Nama_Barang);
                    break;

            }
            return View(records.ToPagedList(pageNumber ?? 1, 3));
        }

        public ActionResult PartialViewDetailItem(int ID_Barang)
        {
            BarangDB barangDBs = new BarangDB();
            return View(_unitOfWork.GetRepositoryInstance<TabelBarang>().GetFirstorDefault(ID_Barang));
        }

        public ActionResult ListView()
        {
            return View();
        }
        public ActionResult DetailViewItem(int ID_Barang)
        {
            /*MultiModel model = new MultiModel();*/
            

            try
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(dBCopyCatEntities.TabelBarangs.ToList(), _jsonSetting);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
            return View(_unitOfWork.GetRepositoryInstance<TabelDaftarBarang>().GetFirstorDefault(ID_Barang));

           

        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        // https://canvasjs.com/asp-net-mvc-charts/area-chart/

        public ActionResult TesterViewer()
        {
            dynamic model = new ExpandoObject();
            model.TabelDaftarBarang = GetTabelDaftarBarang();
            model.TabelHarga = GetTabelHarga();
            return View(model);
        }
        private static List<TabelHarga> GetTabelHarga()
        {
            List<TabelHarga> tabelHargas = new List<TabelHarga>();
            string query = "Select * From TabelHarga";
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tabelHargas.Add(new TabelHarga
                            {
                                ID_Toko = Convert.ToInt32(sdr["ID_Toko"]),
                                ID_NamaBarang = Convert.ToInt32(sdr["ID_NamaBarang"]),
                                Harga = Convert.ToInt32(sdr["Harga"])
                            });
                        }
                        con.Close();
                        return tabelHargas;
                    }
                }
            }
        }
        private static List<TabelDaftarBarang> GetTabelDaftarBarang()
        {
            List<TabelDaftarBarang> tabelDaftarBarangs = new List<TabelDaftarBarang>();
            string query = "Select * From TabelDaftarBarang";
            string constr = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tabelDaftarBarangs.Add(new TabelDaftarBarang
                            {
                                ID_Barang = Convert.ToInt32(sdr["ID_Barang"]),
                                Nama_Barang = sdr["Nama_Barang"].ToString(),
                                Tipe_Barang = sdr["Tipe_Barang"].ToString()
                            });
                        }
                        con.Close();
                        return tabelDaftarBarangs;
                    }
                }
            }
        }
    }
}