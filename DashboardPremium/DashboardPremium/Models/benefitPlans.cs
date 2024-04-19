using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DashboardPremium.Models
{
    public class benefitPlans
    { 
            public int BENEFIT_PLANS_ID { get; set; }
            public string PLAN_NAME { get; set; }     
            public int DEDUCTABLE { get; set; }
            public int PERCENTAGE_COPAY { get; set; }
        // Add other properties as needed
    }
}