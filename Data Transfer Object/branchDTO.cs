using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar
{
    public class branchDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing Address")]
        [MinLength(2, ErrorMessage = "First Name must be minimum 2 chars")]
        [MaxLength(30, ErrorMessage = "First Name must be maximum 30 chars")]
        public string address { get; set; }

        [Required(ErrorMessage = "Missing Exact Location ")]
        [MinLength(2, ErrorMessage = "First Name must be minimum 2 chars")]
        [MaxLength(30, ErrorMessage = "First Name must be maximum 30 chars")]
        public string exactLocation { get; set; }

        [Required(ErrorMessage = "Missing  Name")]
        public string name { get; set; }
    }
}