using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DashboardPremium.ConnectDB
{
    public class ConnectSqlServer
    {
        string sql = @"Data Source=MSI;Initial Catalog=item;Integrated Security=True";
        SqlConnection conn;

        public SqlConnection Connection { get; internal set; }

        private void knoi()
        {
            sql = @"Data Source=MSI;Initial Catalog=HRM;Integrated Security=True";
            conn = new SqlConnection(sql);
        }

        private void dongknoi()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public DataTable getdata(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                knoi();
                SqlDataAdapter adap = new SqlDataAdapter(sql, conn);
                adap.Fill(dt);
            }
            catch
            {
                dt = null;
            }
            finally
            {
                dongknoi();
            }
            return dt;
        }
        }
    }