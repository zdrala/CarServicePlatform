using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        public int RequestID { get; set; }

        public DateTime DateofSchedule { get; set; }

        public string Date { get; set; }
        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse

        public string Status { get; set; }

        public bool isPaid { get; set; }

        public double totalPrice { get; set; }

        public string User { get; set; }

        public string CarServiceName { get; set; }
    }
}
