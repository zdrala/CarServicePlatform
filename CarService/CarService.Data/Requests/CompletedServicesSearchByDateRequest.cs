using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class CompletedServicesSearchByDateRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int carServiceID { get; set; }
    }
}
