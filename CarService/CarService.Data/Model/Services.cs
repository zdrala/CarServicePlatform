using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Services
    {
        public int ServiceID { get; set; }
        public int CarServiceID { get; set; }
        public string ServiceName { get; set; }

        public double ServicePrice { get; set; }

        public string Description { get; set; }

        public string ServiceTime { get; set; }
    }
}
