using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcAgenda
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
    name: "ControllerPageRoute",
    url: "{controller}/Page{page}",
    defaults: new { controller = "{controller}", action = "Index" },
    constraints: new { page = @"\d+" },
    namespaces: new[] { "MvcAgenda.Controllers" }
);
            //this route could be replace by the previous one with a default page = 1
            routes.MapRoute(
                name: "ControllerUserRoute",
                url: "{controller}/User{user_id}",
                defaults: new { controller = "{controller}", action = "Index", page = 1 },
                constraints: new { user_id = @"\d+" },
                namespaces: new[] { "MvcAgenda.Controllers" }
                );


            routes.MapRoute(
                name: "EventCreate",
                url: "Events/Create/{strStartTime}",
                defaults: new { controller = "Events", action = "Create", strStartTime = UrlParameter.Optional },
                namespaces: new[] { "MvcAgenda.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MvcAgenda.Controllers" }
            );

            //anything coming after id will be assigned to catchall separated by slash, we have to process it.
            routes.MapRoute(
    name: "DefaultWithCatchAll",
    url: "{controller}/{action}/{id}/{*catchall}",
    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    namespaces: new[] { "MvcAgenda.Controllers" }
);
        }
    }
}