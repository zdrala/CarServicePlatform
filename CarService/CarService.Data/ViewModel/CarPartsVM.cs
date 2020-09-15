using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.ViewModel
{
    public class CarPartsVM
    {
        public int CarPartID { get; set; }
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        public double Price { get; set; }

        public string Quality { get; set; }

        public string CategoryName { get; set; }
        public string SubCategoryName{ get; set; }
        public int CategoryID { get; set; }

        public int SubCategoryID { get; set; }
    }
}
