using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AGAD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "AdminLogin",
                "admin",
                new { controller = "ADMIN", action = "Index" }
                );

            routes.MapRoute(
                "AdminList",
                "admin/{pagination}",
                new { controller = "ADMIN", action = "getList", pagination = "^[0-9]+$" }
                );
            routes.MapRoute(
                "AdminDetail",
                "admin/detay/{detailPage}",
                new { controller = "ADMIN", action = "getDetailAGAD", detailPage = 0 }
                );

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "AGAD", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
