using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar
{
    public class userDTO
    {

            [Required(ErrorMessage = "Missing First Name")]
            [MinLength(2, ErrorMessage = "First Name must be minimum 2 chars")]
            [MaxLength(30, ErrorMessage = "First Name must be maximum 30 chars")]
            public string firstName { get; set; }

            [Required(ErrorMessage = "Missing Last Name")]
            [MinLength(2, ErrorMessage = "First Name must be minimum 2 chars")]
            [MaxLength(30, ErrorMessage = "First Name must be maximum 30 chars")]
            public string lastName { get; set; }

            [Required(ErrorMessage = "Missing User ID")]
            public int IdOfUser { get; set; }

            [Required(ErrorMessage = "Missing User Name")]
            public string nameOfUser { get; set; }
            
            public string dateOfBirth { get; set; }

            [Required(ErrorMessage = "Missing email")]
            public string email{ get; set; }

            [Required(ErrorMessage = "Missing Gender")]
            public string gender { get; set; }

            [Required(ErrorMessage = "Missing Password")]
            public string password { get; set; }

            public string image { get; set; }

            public string role { get; set; }
    }
}