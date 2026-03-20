namespace CampBooking.Domain.Ratings.DTOs;

/// Represents a data transfer object (DTO) for retrieving rating information for a camping location.
/// </summary>
/// <param name="Id">The unique identifier of the rating entry.</param>
/// <param name="CampId">The unique identifier of the camping location being rated.</param>
/// <param name="ReferenceNumber">A unique reference number associated with the original booking.</param>
/// <param name="CellPhone">The contact phone number of the person who submitted the rating.</param>
/// <param name="Star">The rating score, typically on a scale of 1-5, represented as a double for precise ratings.</param>
/// <param name="Comment">Additional textual feedback or review about the camping experience.</param>
public record RatingDTO(
    Guid Id,
    Guid CampId,
    string ReferenceNumber,
    string CellPhone,
    double Star,
    string Comment);
