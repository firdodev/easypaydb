using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using EasyPayDatabase.Controllers;
using EasyPayDatabase.Models;

namespace EasyPayDatabase.Controllers
{
    public class HomeController : Controller
    {
        LoginTable db;
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<Adress> addresses = new List<Adress>();

        public HomeController()
        {
            con.ConnectionString = EasyPayDatabase.Properties.Resources.ConnectionString;
        }


        // GET: Home
        public ActionResult Index()
        {
            FetchData();
            return View(addresses);
        }

        private void FetchData()
        {
            if(addresses.Count > 0)
            {
                addresses.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [UserId] ,[Emer] ,[Mbiemer] ,[Mosha] ,[Depoziton] FROM[LoginDatabase].[dbo].[Admin]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    addresses.Add(new Adress()
                    {
                        UserId = dr["UserId"].ToString()
                        ,
                        Emer = dr["Emer"].ToString()
                        ,
                        Mbiemer = dr["Mbiemer"].ToString()
                        ,
                        Mosha = dr["Mosha"].ToString()
                        ,
                        Depoziton = dr["Depoziton"].ToString()

                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}