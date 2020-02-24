using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class carDTO
    {
        [Required(ErrorMessage = "Missing Brand")]
        public int typeId { get; set; }

        [Required(ErrorMessage = "Missing Mileage")]
        public int mileage { get; set; }

        [Required(ErrorMessage = "Missing Image")]
        public string image { get; set; }

        [Required(ErrorMessage = "Missing Proper For Rent")]
        public bool properForRent { get; set; }

        [Required(ErrorMessage = "Missing Avilable")]
        public bool avilable { get; set; }

        [Required(ErrorMessage = "Missing Vehicle Identification Number (VIN)")]
        public int number { get; set; }

        [Required(ErrorMessage = "Missing Branch Place")]
        public string branchPlace { get; set; }
    }
}
