using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarModels
    {
        [Key]
        public int CarModelID { get; set; }

        public string CarModelName { get; set; }

        [ForeignKey("CarBrandID")]
        public int CarBrandID { get; set; }
        public CarBrands CarBrand { get; set; }
    }
}
