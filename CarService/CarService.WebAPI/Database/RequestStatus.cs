using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class RequestStatus
    {
        [Key]
        public int StatusID { get; set; }

        public string statusName { get; set; }
    }
}
