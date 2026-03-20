namespace CampBooking.Domain.Ratings.DTOs;

/// <summary>
/// Represents a data transfer object (DTO) for adding a new rating to a camping location.
/// </summary>
/// <param name="CampId">The unique identifier of the camping location being rated.</param>
/// <param name="ReferenceNumber">A unique reference number associated with the booking or rating.</param>
/// <param name="CellPhone">The contact phone number of the person submitting the rating.</param>
/// <param name="Star">The rating score, typically on a scale (e.g., 1-5 stars).</param>
/// <param name="Comment">Additional textual feedback or review about the camping experience.</param>
public record AddRatingDTO(
    Guid CampId,
    string ReferenceNumber,
    string CellPhone,
    int Star,
    string Comment);
