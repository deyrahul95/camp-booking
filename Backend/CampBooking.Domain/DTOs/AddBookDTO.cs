namespace CampBooking.Domain.DTOs
{
    public class AddBookDTO
    {
        public Guid CampId { get; set; }
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
