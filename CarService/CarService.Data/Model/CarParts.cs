using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class CarParts
    {
        public int CarPartID { get; set; }

        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public double Price { get; set; }

        public string Quality { get; set; }

        public int CategoryID { get; set; }

        public int SubCategoryID { get; set; }

        public int CarServiceID { get; set; }
    }
}
