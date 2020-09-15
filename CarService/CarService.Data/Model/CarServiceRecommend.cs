using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class CarServiceRecommend
    {
        public int CarServiceID { get; set; }
        public string CarServiceName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CityID { get; set; }

        public string Street { get; set; }

        public string PhoneNumber { get; set; }

        public string Owner { get; set; }

        public byte[] Photo { get; set; }
        public int NumberOfLikes { get; set; }

        public int NumberOfDislikes { get; set; }
        public int UserID { get; set; }

        public float PositiveDifferent { get; set; }
    }
}
