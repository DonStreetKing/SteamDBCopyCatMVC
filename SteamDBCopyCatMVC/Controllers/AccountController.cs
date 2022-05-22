using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;
using SteamDBCopyCatMVC.Models;
using System.Web.Security;

namespace SteamDBCopyCatMVC.Controllers
{
    public class AccountController : Controller
    {
        SteamDBCopyCatEntities dBCopyCatEntities = new SteamDBCopyCatEntities();

        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRegisterDetail(SignUp signUp)
        {
            if (ModelState.IsValid)
            {
                using (var db = new SteamDBCopyCatEntities())
                {
                    Akun akun = new Akun();

                    akun.Nama = signUp.Nama;
                    akun.Email = signUp.Email;
                    akun.Password = signUp.Password;

                    db.Akuns.Add(akun);
                    db.SaveChanges();
                }
                ViewBag.Message = "User Details Saved";
                return View("SignUp");
            }
            else
            {
                return View("SignUp", signUp);
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = isValidUser(model);
                if (isValidUser) !=null) {
                    FormAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}