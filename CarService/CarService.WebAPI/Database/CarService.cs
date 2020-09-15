using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarService
    {
        [Key]
        public int CarServiceID { get; set; }
        public string CarServiceName { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey("CityID")]
        public int CityID { get; set; }
        public Cities City { get; set; }
        public string Street { get; set; }

        public string PhoneNumber { get; set; }
    
        public string Owner { get; set; }

        public byte[] Photo { get; set; }
        public int NumberOfLikes { get; set; }

        public int NumberOfDislikes { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public Users User { get; set; }
    }
}
