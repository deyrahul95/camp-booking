using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampBooking.Domain.DTOs
{
    public class AddRatingDTO
    {
        public Guid CampId { get; set; }
        public string ReferenceNumber { get; set; }
        public string CellPhone { get; set; }
        public int Star { get; set; }
        public string Comment { get; set; }
    }
}
