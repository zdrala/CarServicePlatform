using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.ViewModel
{
    public class OfferItemsVM
    {



        public string Date { get; set; }

        public string Status { get; set; }


        public string User { get; set; }
        public string UserCar { get; set; }
        public int OfferID { get; set; }

        public List<Parts> listOfParts { get; set; }

        public class Parts { 
        public int ItemID { get; set; }
        public int CarPartID { get; set; }
         public byte[] Photo { get; set; }
         public string CarPartName { get; set; }
        public double CarPartPrice { get; set; }
         public string Quality { get; set; }
         public string SubCategoryName { get; set; }
        public int QuantityNeeded { get; set; }
        public bool IsSelected { get; set; }
        };


    }
}
