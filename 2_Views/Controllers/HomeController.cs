using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_Views.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Products()
        {           
            return View();
        }

        public ActionResult Services()
        {         
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

       
    }
}