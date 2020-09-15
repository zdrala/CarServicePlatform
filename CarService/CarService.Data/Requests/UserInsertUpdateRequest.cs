using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarService.Data.Requests
{
    public class UserInsertUpdateRequest
    {

        [Required(AllowEmptyStrings =false)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int CityID { get; set; }

        public int? CarModelID { get; set; }

        public int? CarBrandID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
   
        public string PhoneNumber { get; set; }
        [Required]
        public string Username { get; set; }

    
       public string Password { get; set; }

        
   
       public string PasswordConfirmation { get; set; }

        public int RoleID { get; set; }
    }
}
