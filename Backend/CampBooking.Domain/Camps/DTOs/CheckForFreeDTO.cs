namespace CampBooking.Domain.Camps.DTOs;

public record CheckForFreeDTO(Guid CampId, string CheckIn, string CheckOut);
