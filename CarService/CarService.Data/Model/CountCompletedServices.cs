using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class CountCompletedServices
    {
        public List<Service> servicesList { get; set; }
    public class Service
        {
            public int serviceID { get; set; }
            public string ServiceName { get; set; }
            public int Count { get; set; }
        };
    }
}
