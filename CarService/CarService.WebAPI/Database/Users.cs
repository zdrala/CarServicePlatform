using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        
        [ForeignKey("CityID")]
        public int CityID { get; set; }
        public Cities City { get; set; }
        [ForeignKey("CarModelID")]
        public int? CarModelID { get; set; }
        public CarModels CarModel { get; set; }

        [ForeignKey("CarBrandID")]
        public int? CarBrandID { get; set; }
        public CarBrands CarBrand { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("RoleID")]
        public int RoleID { get; set; }

        public Roles Role { get; set; }


    }
}
