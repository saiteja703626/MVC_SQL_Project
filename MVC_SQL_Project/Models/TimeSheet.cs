using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_SQL_Project.Models
{
    public class TimeSheet
    {
        public int Id { get; set; }

        [Required]
        public string Story { get; set; }

        [Required]
        public string IT { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [Required]
        public DateTime CompletedDate { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Description { get; set; }
    }
}