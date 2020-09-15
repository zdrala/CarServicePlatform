using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.ViewModel
{
    public class RequestVM
    {
        public int RequestID { get; set; }

        public DateTime DateOfRequest { get; set; }

        public string Date { get; set; }
        public int UserID { get; set; }
        public string UserNameLastName { get; set; }

        public string UserCar { get; set; }
        public int CarServiceID { get; set; }

        public int StatusID { get; set; }

        public List<Service> ListOfRequestedServices { get; set; }

        public class Service
        {
            public int serviceID { get; set; }
            public double ServicePrice { get; set; }
            
            public string ServiceName { get; set; }
        }
    }
}
