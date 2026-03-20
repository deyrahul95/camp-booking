using CampBooking.DAL.Interfaces;
using CampBooking.Domain.Ratings.DTOs;
using CampBooking.Domain.Ratings.Entity;
using CampBooking.Service.Interfaces;
using CampBooking.Shared.Mappers;

namespace CampBooking.Service.Services;

/// <summary>
/// Service class for managing rating operations.
/// Implements the IRatingService interface.
/// </summary>
/// <param name="uow">The unit of work instance used for database operations.</param>
public class RatingService(IUnitOfWork uow) : IRatingService
{
    /// <summary>
    /// Retrieves the rating for a specific camp by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing the rating as an integer.</returns>
    public async Task<int> GetRating(Guid campId)
    {
        var list = await uow.RatingRepository.GetAllRatings();
        int count = 0;
        double rating = 0;

        foreach (var item in list)
        {
            if (item.CampId == campId)
            {
                if (item.Star > 0)
                {
                    rating += item.Star;
                    count++;
                }
            }
        }

        if (count == 0)
        {
            return 0;
        }

        return (int)Math.Round(rating / count);
    }

    /// <summary>
    /// Searches for a rating based on the provided search criteria.
    /// </summary>
    /// <param name="data">The search criteria for finding ratings.</param>
    /// <returns>A task that represents the asynchronous operation, containing the found rating details DTO.</returns>
    public async Task<RatingDTO?> SearchRating(SearchRatingDTO data)
    {
        var ratings = await uow.RatingRepository.GetAllRatings();

        foreach (var rating in ratings)
        {
            if (rating.CampId == data.CampId
                && rating.CellPhone == data.CellPhone
                && rating.ReferenceNumber == data.ReferenceNumber)
            {
                return rating.ToDto();
            }
        }

        return null;
    }

    /// <summary>
    /// Adds a new rating.
    /// </summary>
    /// <param name="rating">The rating information to be added.</param>
    /// <returns>A task that represents the asynchronous operation, containing the added rating details DTO.</returns>
    public async Task<AddRatingDTO?> AddNewRating(AddRatingDTO rating)
    {
        var newRating = rating.ToEntity();

        try
        {
            Guid id = await uow.RatingRepository.AddRating(newRating);
            var camp = await uow.CampRepository.ViewDetails(rating.CampId);

            if (camp is null)
            {
                return null;
            }

            camp.Rating = await GetRating(camp.Id);
            bool res = await uow.SaveAsync();

            if (id != Guid.Empty && res)
            {
                return rating;
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Updates an existing rating by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the rating to be updated.</param>
    /// <param name="rating">The updated rating information.</param>
    /// <returns>A task that represents the asynchronous operation, containing the updated rating details DTO.</returns>
    public async Task<RatingDTO?> UpdateRating(Guid id, RatingDTO rating)
    {
        var mapped = rating.ToEntity();

        try
        {
            var existingRating = await uow.RatingRepository.UpdateRating(id, mapped);
            var camp = await uow.CampRepository.ViewDetails(rating.CampId);

            if (camp is null)
            {
                return null;
            }

            camp.Rating = await GetRating(camp.Id);
            bool res = await uow.SaveAsync();

            if (res && existingRating != null)
            {
                return existingRating.ToDto();
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Retrieves comments associated with a specific camp by its unique identifier.
    /// </summary>
    /// <param name="campId">The unique identifier of the camp.</param>
    /// <returns>A task that represents the asynchronous operation, containing a list of comments.</returns>
    public async Task<IList<string>> GetComments(Guid campId)
    {
        var list = await uow.RatingRepository.GetAllRatings();
        var comments = new List<string>();

        foreach (var item in list)
        {
            if (item.CampId == campId)
            {
                comments.Add(item.Comment);
            }
        }

        return comments;
    }
}