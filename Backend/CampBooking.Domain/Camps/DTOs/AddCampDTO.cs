namespace CampBooking.Domain.Camps.DTOs;

public record AddCampDTO(string Name,
    int Price,
    int Capacity,
    string Description,
    string ImageUrl);
