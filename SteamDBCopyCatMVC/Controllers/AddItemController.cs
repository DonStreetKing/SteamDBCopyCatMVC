using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;

namespace SteamDBCopyCatMVC.Controllers
{
    public class AddItemController : Controller
    {
        // GET: AddItem
        public ActionResult Index()
        {
            return View();
        }
    }
}