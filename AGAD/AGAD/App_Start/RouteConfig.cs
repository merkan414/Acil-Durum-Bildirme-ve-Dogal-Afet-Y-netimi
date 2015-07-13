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
                "AdminChangeState",
                "changeState",
                new { controller = "ADMIN", action = "changeState" }
                );

            routes.MapRoute(
                "AdminLogin",
                "admin",
                new { controller = "ADMIN", action = "Index" }
                );

            routes.MapRoute(
                "AdminLogout",
                "logout",
                new { controller = "ADMIN", action = "logOut" }
                );

            routes.MapRoute(
                "AdminList",
                "admin/{pagination}",
                new { controller = "ADMIN", action = "getList", pagination = "^[0-9]+$" }
                );
            routes.MapRoute(
                "AdminDetail",
                "admin/detay/{detailPage}",
                new { controller = "ADMIN", action = "getDetailAGAD", detailPage = "^[0-9]+$" }
                );

            routes.MapRoute(
                "getList",
                "getList",
                new { controller = "AGAD", action = "getList" }
                );
            routes.MapRoute(
                "saveImage",
                "saveImage",
                new { controller = "AGAD", action = "saveImage" }
                );
            routes.MapRoute(
                "save",
                "save",
                new { controller = "AGAD", action = "saveAgad" }
                );
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "AGAD", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
