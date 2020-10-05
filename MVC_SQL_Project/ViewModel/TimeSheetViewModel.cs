using MVC_SQL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SQL_Project.ViewModel
{
    public class TimeSheetViewModel
    {
        public TimeSheet TimeSheet { get; set; }

        public IEnumerable<SelectListItem> Status { get; set; }
    }
}