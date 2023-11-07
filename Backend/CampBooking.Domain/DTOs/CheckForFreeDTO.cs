using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampBooking.Domain.DTOs
{
    public class CheckForFreeDTO
    {
        public Guid CampId { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
    }
}
