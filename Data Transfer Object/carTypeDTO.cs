using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class carTypeDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Missing Manufacturer")]
        [MinLength(2, ErrorMessage = "Manufacturer must be minimum 2 chars")]
        [MaxLength(20, ErrorMessage = "Manufacturer must be maximum 20 chars")]
        public string manufacturer { get; set; }

        [Required(ErrorMessage = "Missing Model")]
        [MinLength(2, ErrorMessage = "Model must be minimum 2 chars")]
        [MaxLength(15, ErrorMessage = "Model must be maximum 15 chars")]
        public string model { get; set; }

        [Required(ErrorMessage = "Missing Transmission")]
        [MinLength(2, ErrorMessage = "Transmission must be minimum 2 chars")]
        [MaxLength(15, ErrorMessage = "Transmission must be maximum 15 chars")]
        public string transmission { get; set; }

        public DateTime productionYear { get; set; }

        [Required(ErrorMessage = "Missing Price Per Day")]
        public int pricePerDay { get; set; }

        [Required(ErrorMessage = "Missing Price Per Day If Dalay")]
        public int pricePerDayIfDalay { get; set; }
    }
}
