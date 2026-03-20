namespace CampBooking.Domain.Ratings.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for searching ratings of a specific camping location.
/// </summary>
/// <param name="CampId">The unique identifier of the camping location.</param>
/// <param name="ReferenceNumber">The reference number associated with the booking.</param>
/// <param name="CellPhone">The contact phone number linked to the rating.</param>
public record SearchRatingDTO(Guid CampId, string ReferenceNumber, string CellPhone);
