using CampBooking.Domain.DTOs;

namespace CampBooking.Service.Interfaces
{
    public interface IRatingService
    {
        Task<int> GetRating(Guid _campId);
        Task<RatingDTO> SearchRating(SearchRatingDTO _data);
        Task<AddRatingDTO> AddNewRating(AddRatingDTO _rating);
        Task<RatingDTO> UpdateRating(Guid id, RatingDTO _rating);
        Task<IList<string>> GetComments(Guid _campId);
    }
}
