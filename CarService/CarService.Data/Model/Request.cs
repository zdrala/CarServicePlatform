using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Request
    {
        public int RequestID { get; set; }

        public DateTime DateOfRequest { get; set; }

        public string Date { get; set; }
        public int UserID { get; set; }
        public string UserNameLastName { get; set; }

        public string UserCar { get; set; }
        public int CarServiceID { get; set; }

        public int StatusID { get; set; } 

        public List<string> ListOfRequestedServices { get; set; }

       
    }
}
