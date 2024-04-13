using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace DashboardPremium.ConnectDB
{
    public class ConnectMySql
    {

        string strconn = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=040220;";
        MySqlConnection connection;
        public MySqlConnection Connectsql()
        {
            strconn = "Server=127.0.0.1;Port=3306;Database=mydb;Uid=root;Pwd=Vu21012003@;";
            connection = new MySqlConnection(strconn);
            try
            {
                connection.Open();
                return connection;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}