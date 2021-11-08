using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingErrorApp.Models;

namespace ReportingErrorApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {

            using (DbModel dbModel = new DbModel())
            {

                if (dbModel.Users.Any(x => x.Username == userModel.Username))
                {
                    ViewBag.DuplicateMessage = "User alreday exist.";
                    return RedirectToAction("Watch", "Dashboard");
                }
                else
                {
                    dbModel.Users.Add(userModel);
                    dbModel.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "User is succesifully Registred";
                    return View("AddOrEdit", userModel);
                }

            }

        }
    }
}