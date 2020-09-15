using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class RequestServices
    {
        [Key]
        public int RequestServiceID {get;set;}

        [ForeignKey("RequestID")]
        public int RequestID { get; set; }

        public Request Request { get; set; }

        [ForeignKey("ServiceID")]
        public int ServiceID { get; set; }
        public Services Service { get; set; }
    }
}
