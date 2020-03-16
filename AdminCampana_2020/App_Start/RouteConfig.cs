﻿using System.Web.Mvc;
using System.Web.Routing;

namespace AdminCampana_2020
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Persona", action = "Registro", id = UrlParameter.Optional }
            );
        }
    }
}
