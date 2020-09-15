using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class CarPartCategory
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
