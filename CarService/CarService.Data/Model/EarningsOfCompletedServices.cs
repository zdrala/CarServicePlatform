using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class EarningsOfCompletedServices
    {
        public List<Service> servicesList { get; set; }
        public class Service
        {
            public int serviceID { get; set; }
            public string ServiceName { get; set; }
            public double Earnings { get; set; }
        };
    }
}
