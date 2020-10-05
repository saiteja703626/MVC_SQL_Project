using MVC_SQL_Project.Models;
using MVC_SQL_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            return View();
        }

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
            return RedirectToAction("Grid", "TimeSheets");
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
    }
}