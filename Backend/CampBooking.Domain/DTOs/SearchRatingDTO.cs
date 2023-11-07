namespace CampBooking.Domain.DTOs
{
    public class SearchRatingDTO
    {
        public Guid CampId { get; set; }
        public string ReferenceNumber { get; set; }
        public string CellPhone { get; set; }
    }
}
