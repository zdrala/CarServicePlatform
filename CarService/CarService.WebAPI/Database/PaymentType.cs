using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }
       public string PaymentName { get; set; }
    }
}
