namespace CampBooking.Domain.Camps.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for searching available camping locations within a specific date range.
/// </summary>
/// <param name="CheckIn">The proposed check-in date as a string, representing the start of the desired booking period.</param>
/// <param name="CheckOut">The proposed check-out date as a string, representing the end of the desired booking period.</param>
public record SearchFreeCampsDTO(string CheckIn, string CheckOut);
