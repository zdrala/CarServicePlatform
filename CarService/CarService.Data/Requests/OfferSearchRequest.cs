using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class OfferSearchRequest
    {
        public bool AdminSearch { get; set; }
        public int CarServiceID { get; set; }


        public int ScheduleID { get; set; } = 0;
    }
}
