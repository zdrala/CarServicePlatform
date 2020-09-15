using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }

        [ForeignKey("CarServiceID")]
        public int CarServiceID { get; set; }
        public string ServiceName { get; set; }

        public double ServicePrice { get; set; }

        public string Description { get; set; }

        public string ServiceTime { get; set; }

        public CarService CarService { get; set; }
    }
}
