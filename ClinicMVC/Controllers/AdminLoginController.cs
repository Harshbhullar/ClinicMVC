using ClinicMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicMVC.Controllers
{
    public class AdminLoginController : Controller
    {

        SqlConnection sqlcon = new SqlConnection();
        SqlCommand sqlcmd = new SqlCommand();
        SqlDataReader sqldr;

        // GET: AdminLogin
        public ActionResult AdminLogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AdminLogin instance)
        {
            sqlcon.ConnectionString = "Data Source=LAPTOP-OIRKFLCJ\\SQLEXPRESS06;Initial Catalog=DBClinic;Integrated Security=True";




            sqlcon.Open();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = "select * from tbAdmin where Name='" + instance.Name + "' and Password='" + instance.Password + "'";

            sqldr = sqlcmd.ExecuteReader();

            if (sqldr.Read())
            {
                sqlcon.Close();
                return View("Panel");
            }
            else
            {
                sqlcon.Close();
                return View("Invalid");
            }


        }

    }
}