namespace CampBooking.Domain.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for checking the availability of a camping location.
/// </summary>
/// <param name="CampId">The unique identifier of the camping location to check for availability.</param>
/// <param name="CheckIn">The proposed check-in date as a string, representing the start of the potential booking.</param>
/// <param name="CheckOut">The proposed check-out date as a string, representing the end of the potential booking.</param>
public record CheckForFreeDTO(
    Guid CampId,
    string CheckIn,
    string CheckOut);
