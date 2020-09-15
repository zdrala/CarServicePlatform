using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int ScheduleID { get; set; }
        public double totalPrice { get; set; }
        public DateTime IssueDate { get; set; }
        public bool isProccessed { get; set; }//placen tiket (on line racun)
    }
}
