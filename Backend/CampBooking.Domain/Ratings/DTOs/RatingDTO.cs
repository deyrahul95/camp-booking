namespace CampBooking.Domain.Ratings.DTOs;

public class RatingDTO
{
    public Guid Id { get; set; }
    public Guid CampId { get; set; }
    public string ReferenceNumber { get; set; }
    public string CellPhone { get; set; }
    public double Star { get; set; }
    public string Comment { get; set; }
}
