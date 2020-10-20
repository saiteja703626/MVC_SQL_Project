using MVC_SQL_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SQL_Project.ViewModel
{
    public class LoginViewModel
    {
        public TimeSheet TimeSheet { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}