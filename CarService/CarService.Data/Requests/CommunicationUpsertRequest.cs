using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Requests
{
    public class CommunicationUpsertRequest
    {
        public DateTime DateOfMessage { get; set; }

  
        public int UserID { get; set; }


        public int CarServiceID { get; set; }


        public string Content { get; set; }

        public string AnswerContent { get; set; }

        public bool isAnswered { get; set; }
    }
}
