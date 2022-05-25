using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.Models;
using SteamDBCopyCatMVC.EDMX;

namespace SteamDBCopyCatMVC.Controllers
{
    public class TambahKeWishlistController : Controller
    {
        DataTable dt;
/*        ModelUntukWishlistKeknya modelUntukWishlistKeknya = new ModelUntukWishlistKeknya();
*/        // GET: TambahKeWishlist
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(TabelBarang TB)
        {
            if (Session["cart"] == null)
            {
                List<TabelBarang> li = new List<TabelBarang>();

                li.Add(TB);
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;


            }
            else
            {
                List<TabelBarang> li = (List<TabelBarang>)Session["cart"];
                li.Add(TB);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("HomeScreen", "Home");
        }
        public ActionResult WishList()
        {
            return View((List<TabelBarang>)Session["cart"]);
        }
        public ActionResult Remove(TabelBarang TB)
        {
            List<TabelBarang> li = (List<TabelBarang>)Session["cart"];
            li.RemoveAll(x => x.ID == TB.ID);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}