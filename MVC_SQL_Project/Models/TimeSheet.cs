using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SQL_Project.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }

        public string Story { get; set; }

        public string IT { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }
    }
}