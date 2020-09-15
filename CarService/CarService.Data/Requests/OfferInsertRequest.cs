using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class OfferInsertRequest
    {
        public int ScheduleID { get; set; }

        public bool isLocked { get; set; }

        public bool partsSelected { get; set; }
    }
}
