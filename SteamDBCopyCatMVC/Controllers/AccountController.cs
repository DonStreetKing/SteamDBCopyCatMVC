using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SteamDBCopyCatMVC.EDMX;
using SteamDBCopyCatMVC.Models;
using System.Web.Security;
using System.Net;
using System.Net.Mail;

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
        public ActionResult SaveRegisterDetail(SignUpModell signUp)
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

                //Validating the user, whether the user is valid or not.
                var isValidUser = IsValidUser(model);

                //If user is valid & present in database, we are redirecting it to Welcome page.
                if (isValidUser != null)
                    return View("Welcome", isValidUser);
                else
                {
                    //If the username and password combination is not present in DB then error message is shown.
                    ModelState.AddModelError("Failure", "Wrong Username and password combination !");
                    return View();
                }
            }
            else
            {
                //If model state is not valid, the model with error message is returned to the View.
                return View(model);
            }
        }
        public ActionResult Welcome()
        {
            return View();
        }

        //function to check if User is valid or not
        public Akun IsValidUser(LoginViewModel model)
        {
            using (var dataContext = new SteamDBCopyCatEntities())
            {
                //Retireving the user details from DB based on username and password enetered by user.
                Akun user = dataContext.Akuns.Where(query => query.Email.Equals(model.Email) && query.Password.Equals(model.Password)).SingleOrDefault();
                //If user is present, then true is returned.
                if (user == null)
                    return null;
                //If user is not present false is returned.
                else
                    return user;
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("youremail@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("youremail@gmail.com", "YourPassword");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }
    }
}