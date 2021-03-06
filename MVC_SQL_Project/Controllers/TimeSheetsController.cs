﻿using MVC_SQL_Project.Models;
using MVC_SQL_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MVC_SQL_Project.Controllers
{
    public class TimeSheetsController : Controller
    {

        private ApplicationDbContext dbContext = null;

        public TimeSheetsController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if(dbContext!=null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: TimeSheets
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Details(int? id)
        {
            var viewModel = new TimeSheetViewModel
            {
                TimeSheet = new TimeSheet(),
                Status = GetStatus()
            };
            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult Details(TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new TimeSheetViewModel
                {
                    TimeSheet = new TimeSheet(),
                    Status = GetStatus()
                };
                return View("Details", ViewModel);
            }
            dbContext.timeSheets.Add(timeSheet);
            dbContext.SaveChanges();
            return RedirectToAction("GridView", "TimeSheets");
        }
        [NonAction]
        public List<TimeSheet> GetTimeSheet()
        {
            return dbContext.timeSheets.ToList();
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetStatus()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="Select Status"},
                new SelectListItem{Text="Completed",Value="Completed"},
                new SelectListItem{Text="NotCompleted",Value="NotCompleted"}
            };
        }

        public ActionResult Grid()
        {
            List<TimeSheet> timesheet = GetTimeSheet();
            return View(timesheet);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginInfo loginInfo)
        {
                string maincon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(maincon);
                string sqlquery = "select * from LoginInfo where UserName=@UserName and Password=@Password";
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            //sqlcom.Parameters.AddWithValue("@UserName", loginInfo.UserName);
            SqlParameter usernameparam = sqlcom.Parameters.AddWithValue("@UserName",loginInfo.UserName);
            if (loginInfo.UserName == null)
            {
                usernameparam.Value = DBNull.Value;
            }

            SqlParameter passwordparam = sqlcom.Parameters.AddWithValue("@Password", loginInfo.Password);
            if (loginInfo.Password == null)
            {
                passwordparam.Value = DBNull.Value;
            }

            //sqlcom.Parameters.AddWithValue("@Password", loginInfo.Password);
            SqlDataReader sdr = sqlcom.ExecuteReader();
            if (sdr.Read())
            { 
                return RedirectToAction("Details");
            }
            else
            {
                RedirectToAction("Error");
            }
            sqlcon.Close();
            return View();
        }

  
        public ActionResult GridView()
        {
            var timesheet = (from Time in dbContext.timeSheets select Time).ToList();

            return View(timesheet);
        }

       


    }
}