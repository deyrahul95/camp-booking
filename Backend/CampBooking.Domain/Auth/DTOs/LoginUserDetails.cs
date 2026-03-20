namespace CampBooking.Domain.Auth.DTOs;

public record LoginUserDetails(string Name, string Email, bool IsAdmin);
