using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
   public class displayCarDTO
    {
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string transmission { get; set; }
        public DateTime productionYear { get; set; }
        public decimal pricePerDay { get; set; }
        public decimal pricePerDayIfDalay { get; set; }
        public int typeId { get; set; }
        public string image { get; set; }
        public int mileage { get; set; }

        public bool properForRent { get; set; }
        public bool avilable { get; set; }
        public int number { get; set; }
        public string branchPlace { get; set; }
    }
}
