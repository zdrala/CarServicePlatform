using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarPartSubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        public string SubCategoryName { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public CarPartCategory Category { get; set; }

    }
}
