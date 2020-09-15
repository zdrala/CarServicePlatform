using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarBrands
    {
        [Key]
        public int CarBrandID { get; set; }

        public string BrandName { get; set; }
    }
}
