using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class ScheduleSecondUpdateRequest
    {
        public bool updateTotalPrice { get; set; } = false;
        public bool updateIsPaid { get; set; } = false;

        public double TotalPrice { get; set; }
    }
}
