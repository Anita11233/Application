using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ReportingErrorApp.Models;

namespace ReportingErrorApp.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult AddOrEdit(int id =0)
        {
            Registration regModel = new Registration();
            
            return View(regModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Registration registration) {

            using (DbModel dbModel = new DbModel()) {

                    dbModel.Registrations.Add(registration);
                    dbModel.SaveChanges();
        
            }

            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("AddOrEdit", new Registration());
        }

 
    }
}