using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class RatingInsertRequest
    {

        public int UserID { get; set; }
        public int ScheduleID { get; set; }
        public int CarServiceID { get; set; }
        public bool isLiked { get; set; }
        public bool isDisliked { get; set; }
    }
}
