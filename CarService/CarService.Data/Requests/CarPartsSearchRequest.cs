using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class CarPartsSearchRequest
    {
        public int? categoryID { get; set; }
        public int? subCategoryID { get; set; }
    public int CarServiceID { get; set; }
    }
}
