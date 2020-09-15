using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class RequestUpsert
    {
        public int RequestID { get; set; }

        public DateTime DateOfRequest { get; set; }
        public int UserID { get; set; }


        public int CarServiceID { get; set; }


        public int RequestStatusID { get; set; }

        public List<Data.Model.Services> _selectedServicesList { get; set; } = new List<Data.Model.Services>();
    }
}
