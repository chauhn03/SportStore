﻿using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Product", action = "List", category = (string)null}
                );

            routes.MapRoute(
                name: null,
                url: "{category}",
                defaults: new { controller = "Product", action = "List", page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new { controller = "Product", action = "List", page = 1}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}