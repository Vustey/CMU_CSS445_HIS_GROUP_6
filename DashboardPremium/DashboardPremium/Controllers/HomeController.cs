using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DashboardPremium.Controllers
{
    public class HomeController : Controller
    {
        // Đầu tiên Route sẽ gọi đến hành động HomePageView
        public ActionResult HomePageView()
        {
            // Trả về trang có tên là HomePageView.cshtml
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}