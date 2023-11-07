using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampBooking.DAL.DbModel
{
    public class BookingDetails
    {
        public Guid Id { get; set; }
        public Guid CampId { get; set; }
        public string ReferenceNumber { get; set; }
        public int Price { get; set; }
        public int Persons { get; set; }
        public int Nights { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string CellPhone { get; set; }
    }
}
