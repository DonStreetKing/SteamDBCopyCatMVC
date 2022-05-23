using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;
using SteamDBCopyCatMVC.Models;

namespace SteamDBCopyCatMVC.Controllers
{
    public class AccountController : Controller
    {
        SteamDBCopyCatEntities dBCopyCatEntities = new SteamDBCopyCatEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginMang(AkunModels model)
        {
            var s = dBCopyCatEntities.GetLoginInfo(model.Email, model.Password);
            var item = s.FirstOrDefault();
            if (item == "Success")
            {
                return RedirectToAction("HomeScreen", "Home");
            }
            else if (item == "User Does No Exist")
            {
                ViewBag.NotValidUser = item;
            }
            else
            {
                ViewBag.Failedcount = item;
            }
            return View("LoginMang");
        }
        public ActionResult RegisterAkun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRegisterDetails(AkunModels registerAkun)
        {
            //We check if the model state is valid or not. We have used DataAnnotation attributes.
            //If any form value fails the DataAnnotation validation the model state becomes invalid.
            if (ModelState.IsValid)
            {
                //create database context using Entity framework 
                using (var databaseContext = new SteamDBCopyCatEntities())
                {
                    //If the model state is valid i.e. the form values passed the validation then we are storing the User's details in DB.
                    Akun reglog = new Akun();

                    //Save all details in RegitserUser object

                    reglog.Nama = registerAkun.Nama;
                    reglog.Email = registerAkun.Email;
                    reglog.Password = registerAkun.Password;


                    //Calling the SaveDetails method which saves the details.
                    databaseContext.Akuns.Add(reglog);
                    databaseContext.SaveChanges();
                }

                ViewBag.Message = "User Details Saved";
                return View("RegisterAkun");
            }
            else
            {

                //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
                return View("RegisterAkun", registerAkun);
            }
        }
    }
}