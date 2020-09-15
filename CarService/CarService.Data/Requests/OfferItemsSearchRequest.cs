using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class OfferItemsSearchRequest
    {
        public bool AdminSearch { get; set; }
        public int OfferID { get; set; }
    }

}
