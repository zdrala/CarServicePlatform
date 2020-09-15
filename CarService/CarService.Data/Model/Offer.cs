using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Offer
    {
        public int OfferID { get; set; }

        public int ScheduleID { get; set; }

        public bool isLocked { get; set; }

        public bool partsSelected { get; set; }//from user
    }
}
