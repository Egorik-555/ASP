using _5_Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5_Helpers.Controllers
{
    public class HomeController : Controller
    {
        List<Product> list;

        public HomeController()
        {
            list = new List<Product>
            {
                new Product{Id = 1, Name = "iPhone", Price = 300},
                new Product{Id = 2, Name = "iPad", Price = 500},
                new Product{Id = 3, Name = "Mac", Price = 1000},
            };
        }

        // GET: Index
        public ActionResult Index()
        {
            var product = new Product { Name = "new new", Price = 100 };

            return View(product);
        }

    }
}