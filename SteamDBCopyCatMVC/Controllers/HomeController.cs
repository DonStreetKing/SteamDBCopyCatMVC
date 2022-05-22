using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult PartialViewDetailItem(int ID)
        {
            BarangDB barangDBs = new BarangDB();
            return View(_unitOfWork.GetRepositoryInstance<TabelBarang>().GetFirstorDefault(ID));
        }

        public ActionResult ListView()
        {
            return View();
        }
    }
}