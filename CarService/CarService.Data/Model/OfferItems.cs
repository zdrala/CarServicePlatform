using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class OfferItems
    {
        public int itemID { get; set; }

        public int OfferID { get; set; }

        public int subCategoryID { get; set; }

        public int CarPartID { get; set; }

        public int QuantityNeeded { get; set; }
        public bool isSelected { get; set; }
    }
}
