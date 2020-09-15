using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
   public class CommunicationsSearchRequest
    {
        public int carServiceID { get; set; }
        public bool AdminSearch { get; set; } = false;

        public bool ClientSearch { get; set; } = false;
        public int UserID { get; set; }
    }
}
