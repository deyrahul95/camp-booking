using CampBooking.Domain.Ratings.DTOs;
using CampBooking.Domain.Ratings.Entity;

namespace CampBooking.Shared.Mappers;

/// <summary>
/// Represents rating mapper extensions
/// </summary>
public static class RatingMapper
{
    /// <summary>
    /// Mapped rating entity to rating dto object
    /// </summary>
    /// <param name="rating">The rating entity</param>
    /// <returns>Return rating dto object</returns>
    public static RatingDTO ToDto(this Rating rating) => new(
        Id: rating.Id,
        CampId: rating.CampId,
        ReferenceNumber: rating.ReferenceNumber,
        CellPhone: rating.CellPhone,
        Star: rating.Star,
        Comment: rating.Comment);

    /// <summary>
    /// Mapped rating dto to rating entity
    /// </summary>
    /// <param name="rating">Rating dto object</param>
    /// <returns>Returns rating entity</returns>
    public static Rating ToEntity(this RatingDTO rating) => new()
    {
        Id = rating.Id,
        CampId = rating.CampId,
        CellPhone = rating.CellPhone,
        Comment = rating.CellPhone,
        ReferenceNumber = rating.ReferenceNumber,
        Star = (int)rating.Star
    };

    /// <summary>
    /// Mapped add rating dto to rating entity
    /// </summary>
    /// <param name="ratingDTO">Add rating dto object</param>
    /// <returns>Returns rating entity</returns>
    public static Rating ToEntity(this AddRatingDTO ratingDTO) => new()
    {
        Id = Guid.NewGuid(),
        CampId = ratingDTO.CampId,
        CellPhone = ratingDTO.CellPhone,
        Comment = ratingDTO.CellPhone,
        ReferenceNumber = ratingDTO.ReferenceNumber,
        Star = ratingDTO.Star
    };
}
