using CampBooking.DAL.DB;
using CampBooking.DAL.Interfaces;

namespace CampBooking.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CampDBContext _context;

        public UnitOfWork(CampDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public ICampRepository CampRepository => new CampRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        public IBookingDetailsRepo BookingDetailsRepository => new BookingDetailsRepo(_context);

        public IRatingRepo RatingRepository => new RatingRepo(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
