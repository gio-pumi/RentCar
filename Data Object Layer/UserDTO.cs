using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar
{
    public class UserDTO
    {
            public int id { get; set; }

            [Required(ErrorMessage = "Missing First Name")]
            // [StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be 2 to 30 chars")]
            [MinLength(2, ErrorMessage = "First Name must be minimum 2 chars")]
            [MaxLength(30, ErrorMessage = "First Name must be maximum 30 chars")]
            public string firstName { get; set; }

            [Required(ErrorMessage = "Missing Last Name")]
            [Range(0, 1000, ErrorMessage = "Last Name  must be 0 to 1000")]
            public string lastName { get; set; }

            [Required(ErrorMessage = "Missing userID")]
            [Range(0, 1000, ErrorMessage = "User id must be 0 to 1000")]
            public string ID { get; set; }

            [Required(ErrorMessage = "Missing userName")]
            [Range(0, 1000, ErrorMessage = "userName must be 0 to 1000")]
            public string userName { get; set; }

            [Range(0, 1000, ErrorMessage = "Stock must be 0 to 1000")]
            public DateTime dateOfBirth { get; set; }

            [Required(ErrorMessage = "Missing email")]
            [Range(0, 1000, ErrorMessage = "Stock must be 0 to 1000")]
            public string email{ get; set; }

            [Required(ErrorMessage = "Missing gender")]
            [Range(0, 1000, ErrorMessage = "gender must be 0 to 1000")]
            public string gender { get; set; }

            [Required(ErrorMessage = "Missing stock")]
            [Range(0, 1000, ErrorMessage = "Stock must be 0 to 1000")]
            public string password { get; set; }

            [Required(ErrorMessage = "Missing stock")]
            [Range(0, 1000, ErrorMessage = "Stock must be 0 to 1000")]
            public string image { get; set; }
    }
}