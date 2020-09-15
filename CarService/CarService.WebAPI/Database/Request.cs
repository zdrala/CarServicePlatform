using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Request
    {
        [Key]
        public int RequestID { get; set; }

        public DateTime DateOfRequest { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public Users User { get; set; }

        [ForeignKey("CarServiceID")]
        public int CarServiceID { get; set; }

        public CarService CarService { get; set; }

        [ForeignKey("RequestStatusID")]
        public int RequestStatusID { get; set; } //napraviti referentnu za statuse

        public RequestStatus RequestStatus { get; set; }
        //public List<string> ListOfRequestedServices { get; set; }
    }

}
