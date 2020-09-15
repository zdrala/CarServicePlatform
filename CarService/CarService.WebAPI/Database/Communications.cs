using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Communications
    {
        [Key]
        public int CommunicationID { get; set; }

        public DateTime DateOfMessage { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public Users User { get; set; }

        [ForeignKey("CarServiceID")]
        public int CarServiceID { get; set; }

        public CarService CarService { get; set; }

        public string Content { get; set; }

        public string AnswerContent { get; set; }

        public bool isAnswered { get; set; }
    }
}
