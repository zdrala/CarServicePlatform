using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [ForeignKey("ScheduleID")]
        public int ScheduleID { get; set; }

        public Schedule Schedule { get; set; }


        public double totalPrice { get; set; }

        public DateTime IssueDate { get; set; }

        public bool isProccessed { get; set; }//placen tiket (on line racun)


    }
}
