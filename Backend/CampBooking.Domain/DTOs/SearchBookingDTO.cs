using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampBooking.Domain.DTOs
{
    public class SearchBookingDTO
    {
        public string RefNum { get; set; }
        public string Phone { get; set; }
        public string Zipcode { get; set; }
    }
}
