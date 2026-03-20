namespace CampBooking.Domain.Ratings.DTOs;

public class AddRatingDTO
{
    public Guid CampId { get; set; }
    public string ReferenceNumber { get; set; }
    public string CellPhone { get; set; }
    public int Star { get; set; }
    public string Comment { get; set; }
}
