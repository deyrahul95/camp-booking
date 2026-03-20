namespace CampBooking.Domain.Camps.Entity;

public sealed class Camp
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Capacity { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
