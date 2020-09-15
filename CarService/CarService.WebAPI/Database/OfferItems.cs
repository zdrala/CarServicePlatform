using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class OfferItems
    {
        [Key]
        public int itemID { get; set; }

        [ForeignKey("OfferID")]
        public int OfferID { get; set; }
        public Offers Offer { get; set; }
        
        [ForeignKey("subCategoryID")]
        public int subCategoryID { get; set; }

        public CarPartSubCategory CarPartSubCategory { get; set; }

        [ForeignKey("CarPartID")]
        public int CarPartID { get; set; }
        public CarParts CarPart { get; set; }

        public int QuantityNeeded { get; set; }
        public bool isSelected { get; set; }
    }
}
