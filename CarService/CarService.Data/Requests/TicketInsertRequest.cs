using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
   public class TicketInsertRequest
    {
        public int ScheduleID { get; set; }
        public double totalPrice { get; set; }
        public DateTime IssueDate { get; set; }
        public bool isProccessed { get; set; }
    }
}
