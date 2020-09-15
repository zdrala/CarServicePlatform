using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class PaymentInsertRequest
    {
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int PaymentTypeID { get; set; }
        public int ScheduleID { get; set; }
    }
}
