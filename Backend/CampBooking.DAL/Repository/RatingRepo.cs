using CampBooking.DAL.DB;
using CampBooking.DAL.DbModel;
using CampBooking.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CampBooking.DAL.Repository
{
    public class RatingRepo : IRatingRepo
    {
        private readonly CampDBContext _context;

        public RatingRepo(CampDBContext context)
        {
            _context = context;
        }
        public async Task<IList<Rating>> GetAllRatings()
        {
            return await _context.Ratings.ToListAsync();
        }
        public async Task<Rating> GetRating(Guid Id)
        {
            return await _context.Ratings.FindAsync(Id);
        }
        public async Task<Guid> AddRating(Rating _rating)
        {
            var newRating = new Rating()
            {
                Id = _rating.Id,
                CampId = _rating.CampId,
                ReferenceNumber = _rating.ReferenceNumber,
                CellPhone = _rating.CellPhone,
                Star = _rating.Star,
                Comment = _rating.Comment
            };
            await _context.Ratings.AddAsync(newRating);
            return newRating.Id;
        }

        public async Task<Rating> UpdateRating(Guid Id, Rating _rating)
        {
            var rating = await GetRating(Id);
            if (rating == null) return null;
            rating.Star = _rating.Star;
            rating.Comment = _rating.Comment;
            return rating;
        }
    }
}
