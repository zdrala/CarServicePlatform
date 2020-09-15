using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [ForeignKey("RequestID")]
        public int RequestID { get; set; }

        public Request Request { get; set; }

        public DateTime DateofSchedule { get; set; }

        [ForeignKey("ScheduleStatusID")]
        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse

        public ScheduleStatus ScheduleStatus { get; set; }
        public bool isPaid { get; set; } 

        public double totalPrice { get; set; }

    }
}
