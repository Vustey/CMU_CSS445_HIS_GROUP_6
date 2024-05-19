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


        // Alert
        public ActionResult Alert()
        {
            return View();
        }


        // Overview 
        public ActionResult TotalEarning()
        {
            return View();
        }
        public ActionResult VacationDays()
        {
            return View();
        }
        public ActionResult AverageBenefit()
        {
            return View();
        }
    }
}