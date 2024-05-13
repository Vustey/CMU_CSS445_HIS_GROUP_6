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

        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult OverView()
        {
            return View();
        }
    }
}