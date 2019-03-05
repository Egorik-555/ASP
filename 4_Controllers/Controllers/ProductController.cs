﻿using _4_Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_Controllers.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("Result", new Result { ControllerName = "Product", ActionName = "Index"});
        }

        public ActionResult List()
        {
            return View("Result", new Result { ControllerName = "Product", ActionName = "List" });
        }
    }
}