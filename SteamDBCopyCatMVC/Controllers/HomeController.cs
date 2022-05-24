using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SteamDBCopyCatMVC.EDMX;
using SteamDBCopyCatMVC.Models;
using SteamDBCopyCatMVC.Repository;

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

        public ActionResult ListAllItem()
        {
            return View();
        }
        public ActionResult ListAllItem2(string option, string search, int? pageNumber, string sort)
        {
        https://www.c-sharpcorner.com/UploadFile/219d4d/implement-search-paging-and-sort-in-mvc-5/
            var records = barangDB.Students.AsQueryable();
            if (option == "Subjects")
            {
                records = records.Where(x = > x.Subjects == search || search == null);
            }
            else if (option == "Gender")
            {
                records = records.Where(x = > x.Gender == search || search == null);
            }
            else
            {
                records = records.Where(x = > x.Name.StartsWith(search) || search == null);
            }


            return View(from Nama_Barang in dBCopyCatEntities.TabelBarangs.Take(5) select Nama_Barang);
        }

        public ActionResult PartialViewDetailItem(int ID)
        {
            BarangDB barangDBs = new BarangDB();
            return View(_unitOfWork.GetRepositoryInstance<TabelBarang>().GetFirstorDefault(ID));
        }

        public ActionResult ListView()
        {
            return View();
        }
        public ActionResult DetailViewItem(int ID)
        {
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
            return View(_unitOfWork.GetRepositoryInstance<TabelBarang>().GetFirstorDefault(ID));
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        // https://canvasjs.com/asp-net-mvc-charts/area-chart/
    }
}