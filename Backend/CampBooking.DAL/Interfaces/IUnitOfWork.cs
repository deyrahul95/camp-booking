namespace CampBooking.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICampRepository CampRepository { get; }
        IUserRepository UserRepository { get; }
        IBookingDetailsRepo BookingDetailsRepository { get; }
        IRatingRepo RatingRepository { get; }
        Task<bool> SaveAsync();
    }
}
