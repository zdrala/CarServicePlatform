using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class ScheduleUpsertRequest
    {

        public int RequestID { get; set; }


        public DateTime DateofSchedule { get; set; }

        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse


        public bool isPaid { get; set; }

        public double totalPrice { get; set; }
    }
}
