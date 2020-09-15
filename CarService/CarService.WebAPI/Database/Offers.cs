using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Offers
    {
        [Key]
        public int OfferID { get; set; }

        [ForeignKey("ScheduleID")]
        public int ScheduleID { get; set; }

        public Schedule Schedule { get; set; }

        public bool isLocked { get; set; }

        public bool partsSelected { get; set; }//from user
    }
}
