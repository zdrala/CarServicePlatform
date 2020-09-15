using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarService.Data.Requests
{
    public class CarPartsUpsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        [Range(1,double.MaxValue)]
        public double Price { get; set; }

        [Required]
        public string Quality { get; set; }
        
        public int CategoryID { get; set; }
       
        public int SubCategoryID { get; set; }

        public int CarServiceID { get; set; }
    }
}
