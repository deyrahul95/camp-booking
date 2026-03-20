namespace CampBooking.Domain.Ratings.Entity;

public sealed class Rating
{
    public Guid Id { get; set; }
    public Guid CampId { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;
    public int Star { get; set; }
    public string Comment { get; set; } = string.Empty;
}
