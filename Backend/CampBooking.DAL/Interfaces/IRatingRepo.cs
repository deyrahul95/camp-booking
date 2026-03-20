using CampBooking.Domain.Ratings.Entity;

namespace CampBooking.DAL.Interfaces;

/// <summary>
/// Interface for managing ratings in a repository.
/// </summary>
public interface IRatingRepo
{
    /// <summary>
    /// Retrieves all ratings from the repository.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of ratings.</returns>
    Task<IList<Rating>> GetAllRatings();

    /// <summary>
    /// Retrieves a specific rating by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the rating.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested rating.</returns>
    Task<Rating?> GetRating(Guid Id);

    /// <summary>
    /// Adds a new rating to the repository.
    /// </summary>
    /// <param name="rating">The rating to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the unique identifier of the added rating.</returns>
    Task<Guid> AddRating(Rating rating);

    /// <summary>
    /// Updates an existing rating in the repository.
    /// </summary>
    /// <param name="Id">The unique identifier of the rating to be updated.</param>
    /// <param name="rating">The updated rating information.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated rating.</returns>
    Task<Rating?> UpdateRating(Guid Id, Rating rating);
}
