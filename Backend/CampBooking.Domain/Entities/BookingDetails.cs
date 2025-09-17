namespace CampBooking.Domain.Entities;

public sealed class BookingDetails
{
    public Guid Id { get; set; }
    public Guid CampId { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Persons { get; set; }
    public int Nights { get; set; }
    public string CheckIn { get; set; } = string.Empty;
    public string CheckOut { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string CellPhone { get; set; } = string.Empty;
}
