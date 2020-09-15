using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Communication
    {
        public int CommunicationID { get; set; }

        public DateTime DateOfMessage { get; set; }


        public int UserID { get; set; }

        public string UserNameLastName { get; set; }

        public int CarServiceID { get; set; }


        public string Content { get; set; }

        public string AnswerContent { get; set; }

        public bool isAnswered { get; set; }
    }
}
