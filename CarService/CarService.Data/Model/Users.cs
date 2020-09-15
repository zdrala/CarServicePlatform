using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.Data.Model
{
    public class Users
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }


        public int CityID { get; set; }

        public int? CarModelID { get; set; }

        public int? CarBrandID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Username { get; set; }


        public DateTime DateCreated { get; set; }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

    }
}
