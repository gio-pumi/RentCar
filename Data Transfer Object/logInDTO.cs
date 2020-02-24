using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class logInDTO
    {
       [Required(ErrorMessage = "Missing Password")]
        public string password { get; set; }

       [Required(ErrorMessage = "Missing User Name")]
        public string userName { get; set; }
    }
}
