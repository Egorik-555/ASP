using _2_1_Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2_1_Views.Controllers
{
    public class ProductController : Controller
    {
        List<Product> listProducts;

        public ProductController()
        {
            listProducts = new List<Product>();
           
            for(int i = 1; i <= 10; i++)
            {
                listProducts.Add(new Product
                {
                    Id = i.ToString(),
                    Name = "item" + i.ToString(),
                    Price = 10 * i,
                    CreateDate = new DateTime(2018, 1, i)
                });
            }
        }


        public ActionResult StringProduct()
        {
            return View();
        }

        public ActionResult TableProduct()
        { 
            return View();
        }

        public ActionResult GetString()
        {
            return PartialView(listProducts);
        }
    }
}