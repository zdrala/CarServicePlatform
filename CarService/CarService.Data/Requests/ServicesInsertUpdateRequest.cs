using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarService.Data.Requests
{
    public class ServicesInsertUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(5)]
        public string ServiceName { get; set; }
        [Required]
        
        public double ServicePrice { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ServiceTime { get; set; }

        public int CarServiceID { get; set; }
    }
}
