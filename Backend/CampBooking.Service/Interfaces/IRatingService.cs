using CampBooking.Domain.Ratings.DTOs;

namespace CampBooking.Service.Interfaces;

/// <summary>
/// Interface for managing rating-related services.
/// </summary>
public interface IRatingService
{
    /// <summary>
    /// Retrieves the rating for a specific camp by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing the rating as an integer.</returns>
    Task<int> GetRating(Guid campId);

    /// <summary>
    /// Searches for a rating based on the provided search criteria.
    /// </summary>
    /// <param name="data">The search criteria for finding ratings.</param>
    /// <returns>A task that represents the asynchronous operation, containing the found rating details DTO.</returns>
    Task<RatingDTO> SearchRating(SearchRatingDTO data);

    /// <summary>
    /// Adds a new rating.
    /// </summary>
    /// <param name="rating">The rating information to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the added rating details DTO.</returns>
    Task<AddRatingDTO> AddNewRating(AddRatingDTO rating);

    /// <summary>
    /// Updates an existing rating by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the rating to be updated.</param>
    /// <param name="rating">The updated rating information.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated rating details DTO.</returns>
    Task<RatingDTO> UpdateRating(Guid id, RatingDTO rating);

    /// <summary>
    /// Retrieves comments associated with a specific camp by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of comments.</returns>
    Task<IList<string>> GetComments(Guid campId);
}