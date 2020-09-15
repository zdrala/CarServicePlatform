using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("RoleID")]
        public int RoleID { get; set; }

        public Roles Role { get; set; }
    }
}
