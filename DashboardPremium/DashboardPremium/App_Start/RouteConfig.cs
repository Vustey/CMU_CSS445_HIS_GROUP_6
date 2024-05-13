using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

// Dự án bắt đầu ở đây

namespace DashboardPremium
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Mặt định dự án sẽ là ở đây
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                // ở đây sẽ gọi đến controller là Home và hành động sẽ là HomePageView| Mỗi controller thường sẽ trả về 1 view
                defaults: new { controller = "Home", action = "HomePageView", id = UrlParameter.Optional }
                // Sau dòng này sẽ chạy đến HomeController trong Controller
            );
        }
    }
}
