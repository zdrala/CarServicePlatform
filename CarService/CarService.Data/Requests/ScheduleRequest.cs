using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class ScheduleRequest
    {
        public int ScheduleStatusID { get; set; }

        public int CarServiceID { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }

        public bool AdminSearch { get; set; }
    }
}
