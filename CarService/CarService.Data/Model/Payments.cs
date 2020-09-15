using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Payments
    {
        public int PaymentID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public int ScheduleID { get; set; }

    }
}
