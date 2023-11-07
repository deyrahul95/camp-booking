using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampBooking.Domain.DTOs
{
    public class AddCampDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
