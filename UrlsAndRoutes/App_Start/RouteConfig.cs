﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");    

           

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {action = "Index", controller = "Home", id = UrlParameter.Optional}                   
            );

            routes.MapRoute(
               name: "AdminDo",
               url: "AdminDo/{action}",
               defaults: new { controller = "Admin" }
           );
        }
    }
}
