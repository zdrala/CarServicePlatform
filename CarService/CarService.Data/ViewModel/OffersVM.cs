using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.ViewModel
{
    public class OffersVM
    {
        public int ScheduleID { get; set; }

        public int RequestID { get; set; }

        public DateTime DateofSchedule { get; set; }

        public string Date { get; set; }
        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse

        public string Status { get; set; }

        public bool isPaid { get; set; }

        public double totalPrice { get; set; }

        public string User { get; set; }
        public string UserCar { get; set; }
        public int OfferID { get; set; }

        public bool isLocked { get; set; }

        public bool partsSelected { get; set; }//from user
    }
}
