using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DashboardPremium.Models;
using System.Data;
using System.Data.SqlClient;


namespace DashboardPremium.Controllers
{
    public class View: ConnectDB.ConnectSqlServer
    {
        private readonly ConnectDB.ConnectSqlServer _connectSqlServer; // Assuming ConnectSqlServer instance injected

        public View(ConnectDB.ConnectSqlServer connectSqlServer)
        {
            _connectSqlServer = connectSqlServer;
        }

        public IActionResult Index()
        {
            List<benefitPlans> data; // Or any suitable data structure

            try
            {
                string query = "SELECT * FROM BENEFIT_PLANS"; // Replace with your actual query
                data = GetDataListFromQuery(query); // Call your data retrieval method
            }
            catch (Exception ex)
            {
                // Handle errors gracefully (e.g., log, display error message)
                Console.WriteLine("Error retrieving data: " + ex.Message);
                data = new List<benefitPlans>(); // Empty list to avoid null reference errors
            }

            return View(data);
        }

        private List<benefitPlans> GetDataListFromQuery(string query)
        {
            throw new NotImplementedException();
        }


        private List<benefitPlans> GetDataListFromQuery(string query)
    {
        List<benefitPlans> data = new List<benefitPlans>();

        if (!_connectSqlServer.OpenConnection())
        {
            return data; // Handle connection opening failures
        }

        try
        {
            using (SqlCommand cmd = new SqlCommand(query, _connectSqlServer.Connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        benefitPlans model = new benefitPlans();
                        model.BENEFIT_PLANS_ID = reader.GetInt32(0); // Assuming Id is the first column (adjust indices)
                        model.PLAN_NAME = reader.GetString(1); // Assuming Name is the second column
                        // Assign values to other properties based on column indices
                        model.DEDUCTABLE = reader.GetInt32(2); 
                        model.PERCENTAGE_COPAY = reader.GetInt32(3); 
                        data.Add(model);

                    }
                }
            }
        }
        catch (SqlException ex)
        {
            // Handle data retrieval errors (e.g., log, throw exception)
            Console.WriteLine("Error retrieving data: " + ex.Message);
        }
        finally
        {
            _connectSqlServer.CloseConnection();
        }

        return data;
    }
    }

    public interface IActionResult
    {
    }
}