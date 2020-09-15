using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarParts
    {
        [Key]
        public int CarPartID { get; set; }

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public double Price { get; set; }

        public string Quality { get; set; }
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public CarPartCategory Category { get; set; }

        [ForeignKey("SubCategoryID")]
        public int SubCategoryID { get; set; }
        public CarPartSubCategory SubCategory { get; set; }

        [ForeignKey("CarServiceID")]
        public int CarServiceID { get; set; }
        public CarService CarService { get; set; }
    }
}
