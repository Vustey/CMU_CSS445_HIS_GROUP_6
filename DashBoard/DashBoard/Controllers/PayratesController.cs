using Microsoft.AspNetCore.Mvc;
using DashBoard.Data;
using DashBoard.Models;


namespace DashBoard.Controllers
{
    public class PayratesController : Controller
    {
        private readonly MySqlDbContext _mySql;
        private readonly SqlServerDbContext _mySqlServer;

        //public  PayratesController(MySqlDbContext mySql,SqlServerDbContext sqlServer)
        //{
        //    _mySql = mySql;
        //    _mySqlServer = sqlServer;
        //}
        public PayratesController(MySqlDbContext mySql)
        {
            _mySql = mySql;
        }
        public IActionResult Index()
        {
            //var query = from emp in _mySql.Employees 
            //            join bn in _mySqlServer.BenefitPlans 
            IEnumerable<PayRate> objPayratesList = _mySql.PayRates.ToList();
            return View(objPayratesList);

        }
    }
}
