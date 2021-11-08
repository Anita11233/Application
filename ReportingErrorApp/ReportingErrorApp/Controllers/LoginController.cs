using ReportingErrorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportingErrorApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            Login LoginModel = new Login();

            return View(LoginModel);
        }

        // Post: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login LoginModel)
        {
            Boolean ErrorValues = false; 

            using (DbModel dbModel = new DbModel()) { 
             
                if(!dbModel.Registrations.Any(x=> x.UserName == LoginModel.UserName))
                {
                    ErrorValues = true;
                }

                if (!dbModel.Registrations.Any(x => x.Password == LoginModel.Password))
                {
                    ErrorValues = true;
                }

                if(!dbModel.Registrations.Any(x => x.ConfirmPassword == LoginModel.ConfirmPassword))
                {
                    ErrorValues = true;
                }


                if (!ErrorValues.Equals(false))
                {
                    
                    ViewBag.UnsuccessMessage = "Login is invalid";
                    return RedirectToAction("Login", new Login());
                }
                else
                {
                    Session["UserSession"] = LoginModel.UserName.ToString();
                    return RedirectToAction("Watch", "Dashboard");
                }

                //return View("Login", LoginModel);
                return View();
            }

           
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("", "Home");

        }


    }
}