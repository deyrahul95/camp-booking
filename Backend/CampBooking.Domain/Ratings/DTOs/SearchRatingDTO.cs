namespace CampBooking.Domain.Ratings.DTOs;

public record SearchRatingDTO(Guid CampId, string ReferenceNumber, string CellPhone);
