using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarService.Data.Requests
{
    public class CarServiceUpsertRequest
    {

        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string CarServiceName { get; set; }

        [Required]
     
        public int CityID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false)]
       
        public string PhoneNumber { get; set; }

        public byte[] Photo { get; set; }

       public int UserID { get; set; }
        public string Owner { get; set; }

        public bool isLiked { get; set; } = false;
        public bool isDisliked { get; set; } = false;
    }
}
