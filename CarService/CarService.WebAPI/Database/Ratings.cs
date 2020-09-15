using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Ratings
    {
        [Key]
        public int RatingID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public Users User { get; set; }

        [ForeignKey("ScheduleID")]
        public int ScheduleID { get; set; }

        public Schedule Schedule { get; set; }

        [ForeignKey("CarServiceID")]
        public int CarServiceID { get; set; }

        public CarService CarService { get; set; }

        public bool isLiked { get; set; }

        public bool isDisliked { get; set; }
    }
}
