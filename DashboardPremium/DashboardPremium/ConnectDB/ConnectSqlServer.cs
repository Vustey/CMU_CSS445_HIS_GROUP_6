using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace DashboardPremium.ConnectDB
{
    public class ConnectSqlServer
    {
        string sql = @"Data Source=MSI;Initial Catalog=item;Integrated Security=True";
        SqlConnection conn;
        public ConnectSqlServer()
        {
            sql = @"Data Source=MSI;Initial Catalog=HRM;Integrated Security=True";
            conn = new SqlConnection(sql);
        }
    }
}