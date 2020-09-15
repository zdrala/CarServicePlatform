using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        public DateTime PaymentDate { get; set; }

        public double Amount { get; set; }

        [ForeignKey("PaymentTypeID")]
        public int PaymentTypeID { get; set; }

       public PaymentType PaymentType { get; set; }

        [ForeignKey("ScheduleID")]
        public int ScheduleID { get; set; }
        public Schedule Schedule { get; set;}
    }
}
