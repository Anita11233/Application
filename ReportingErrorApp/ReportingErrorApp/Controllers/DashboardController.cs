using ReportingErrorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ReportingErrorApp.Controllers
{

    public class DashboardController : Controller
    {


        [HttpGet]
        public ActionResult Watch (int id = 0)
        {
            SqlConnection connection = new SqlConnection(ReportingErrorApp.Properties.Resources.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Dashboard", connection);

            List<Dashboard> dash_List = new List<Dashboard>();

            connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                dash_List.Add(new Dashboard
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    ClientName =Convert.ToString(dr["ClientName"]),
                    Contract =Convert.ToString(dr["Contract"]),
                    Description = Convert.ToString(dr["Description"])
                }) ;
            
            }


            connection.Close();
            
            
            
            return PartialView(dash_List);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Watch(Dashboard dashboardModel)
        {

                return View(dashboardModel);
        
        }


        [HttpGet]
        public ActionResult AddTask(int id = 0)
        {
            Dashboard dashboardModel = new Dashboard();

            return View(dashboardModel);
        }

        [HttpPost]
        public ActionResult AddTask(Dashboard dashboardModel)
        {
            using (DbModel dbModel = new DbModel())
            {
                dbModel.Dashboards.Add(dashboardModel);
                ViewBag.SuccessMessage = "Task is succesifully Added";
                dbModel.SaveChanges();
                ModelState.Clear();
            }
                return View(dashboardModel);
        }


        [HttpGet]
        public ActionResult Info(Dashboard dashboardModel, int Id)
        {

            List<Dashboard> Info_List = new List<Dashboard>();


            SqlConnection connection = new SqlConnection(ReportingErrorApp.Properties.Resources.ConnectionString);

         
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Dashboard WHERE Id ='" + Convert.ToString(Id)+ "'", connection);

           

            connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Info_List.Add(new Dashboard
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    ClientName = Convert.ToString(dr["ClientName"]),
                    Priority = Convert.ToString(dr["Priority"]),
                    RequestType = Convert.ToString(dr["RequestType"]),
                    Description = Convert.ToString(dr["Description"]),
                    Contract = Convert.ToString(dr["Contract"]),
                    Phone = Convert.ToString(dr["Phone"]),
                    AssignUser = Convert.ToString(dr["AssignUser"])
                });

            }


            connection.Close();



            return PartialView(Info_List);
        }


        public IEnumerable<Dashboard> GetDatabaseList()
        {
            using (DbModel dbModel = new DbModel())
            {
                return dbModel.Dashboards.ToList();
            }


        }

        /*public Dashboard_ID Get(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return dbModel.Dashboards.FirstOrDefault(e => e.Id == id);
            }

        } */

 


    }
}