using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Ratings
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public int CarServiceID { get; set; }
        public bool isLiked { get; set; }
        public bool isDisliked { get; set; }
    }
}
