using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    public class SearchCarDTO
    {
        public string manufacturer { get; set; }
       
        public string model { get; set; }

        public string transmission { get; set; }

        public DateTime productionYear { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string textToSearch { get; set; }

    }
}
