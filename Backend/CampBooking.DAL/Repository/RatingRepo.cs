using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.Repository;

/// <summary>
/// Repository class for managing ratings in the CampDB context.
/// Implements the IRatingRepo interface.
/// </summary>
/// <param name="context">The CampDBContext instance used for database operations.</param>
public class RatingRepo(CampDBContext context) : IRatingRepo
{
    /// <summary>
    /// Retrieves all ratings from the repository.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of ratings.</returns>
    public async Task<IList<Rating>> GetAllRatings()
    {
        return await context.Ratings.ToListAsync();
    }

    /// <summary>
    /// Retrieves a specific rating by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the rating.</param>
    /// <returns>A task that represents the asynchronous operation, containing the requested rating.</returns>
    public async Task<Rating> GetRating(Guid Id)
    {
        return await context.Ratings.FindAsync(Id);
    }

    /// <summary>
    /// Adds a new rating to the repository.
    /// </summary>
    /// <param name="rating">The rating to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the unique identifier of the added rating.</returns>
    public async Task<Guid> AddRating(Rating rating)
    {
        var newRating = new Rating()
        {
            Id = rating.Id,
            CampId = rating.CampId,
            ReferenceNumber = rating.ReferenceNumber,
            CellPhone = rating.CellPhone,
            Star = rating.Star,
            Comment = rating.Comment
        };

        await context.Ratings.AddAsync(newRating);
        return newRating.Id;
    }

    /// <summary>
    /// Updates an existing rating in the repository.
    /// </summary>
    /// <param name="Id">The unique identifier of the rating to be updated.</param>
    /// <param name="rating">The updated rating information.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated rating.</returns>
    public async Task<Rating> UpdateRating(Guid Id, Rating rating)
    {
        var existingRating = await GetRating(Id);

        if (existingRating == null)
        {
            return null;
        }

        existingRating.Star = existingRating.Star;
        existingRating.Comment = existingRating.Comment;
        return existingRating;
    }
}
