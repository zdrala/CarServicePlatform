using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class OfferItemsInsertRequest
    {


        public int OfferID { get; set; }

        public int subCategoryID { get; set; }

        public int CarPartID { get; set; }

        public int QuantityNeeded { get; set; }
        public bool isSelected { get; set; }
    }
}
