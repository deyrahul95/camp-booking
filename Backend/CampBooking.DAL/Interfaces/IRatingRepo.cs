using CampBooking.DAL.DbModel;

namespace CampBooking.DAL.Interfaces
{
    public interface IRatingRepo
    {
        Task<IList<Rating>> GetAllRatings();
        Task<Rating> GetRating(Guid Id);
        Task<Guid> AddRating(Rating _rating);
        Task<Rating> UpdateRating(Guid Id, Rating _rating);
    }
}
