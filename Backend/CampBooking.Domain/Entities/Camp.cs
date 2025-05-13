namespace CampBooking.Domain.Entities;

public sealed class Camp
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Capacity { get; set; }
    public double Rating { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
