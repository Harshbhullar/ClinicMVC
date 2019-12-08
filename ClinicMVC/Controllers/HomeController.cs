using ClinicMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class HomeController : Controller
    {

        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqldr;


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Service()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        [HttpPost]
        public ActionResult Enquiry(Service instance)
        {
            sqlcon.ConnectionString = "Data Source=LAPTOP-OIRKFLCJ\\SQLEXPRESS06;Initial Catalog=DBClinic;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "insert into tbAppointment(Name,Service,Gender,Phone,Email,AppDate) values('" + instance.txtName + "','" + instance.txtService + "','" + instance.txtGender + "','" + instance.txtContact + "','"+instance.txtEmail+"','"+instance.txtDate+"')";
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            return View("Confirmation");


        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult sendMsg(ContactUs instance)
        {
            sqlcon.ConnectionString = "Data Source=LAPTOP-OIRKFLCJ\\SQLEXPRESS06;Initial Catalog=DBClinic;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;

            sqlcmd.CommandText = "insert into tbContact(Name,Email,Mssg) values('" + instance.txtName + "','" + instance.txtEmail + "','" + instance.txtMsg + "')";
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            return View("FeedBack");


        }




    }
}